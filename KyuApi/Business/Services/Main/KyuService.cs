using System;
using System.Collections.Generic;
using System.Linq;
using KyuApi.Business.Mappers;
using KyuApi.Business.Services.Abstract;
using KyuApi.Business.ViewModels;
using KyuApi.Business.ViewModels.Requests;
using KyuApi.Data.Constants;
using KyuApi.Data.Repositories.Interfaces;
using KyuApi.Extensions;
using KyuApi.Extensions.Filters;

namespace KyuApi.Business.Services.Main
{
    public class KyuService : ApiService, IKyuService
    {
        public KyuService(IRepositoryWrapper repo) : base(repo)
        {
        }

        public IEnumerable<EntryViewModel> GetEntries() 
        {
            return _repo.Entry.Query().ViewModelIncludes().OrderBy(e => e.CreateDate).MapEntries();
        }

        public EntryViewModel CreateEntry(EntryRequest req)
        {
            var entity = req.Map();
            _repo.Entry.Create(entity);
            var entryTags = req.Tags.CreateLinks(entity);
            if (entryTags.Any()) {
                _repo.EntryTag.CreateRange(entryTags);
            }
            _repo.Save();
            entity.EntryType = _repo.EntryType.Find(entity.EntryTypeId);
            entity.EntryStatus = _repo.EntryStatus.Find(entity.EntryStatusId);
            return entity.Map();
        }

        public EntryViewModel UpdateEntry(EntryRequest req)
        {
	        var entity = _repo.Entry.Query().ViewModelIncludes().FindById(req.Id);
	        if (entity == null)
	        {
		        return null;
	        }
	        var changes = req.Map();
	        entity.Title = changes.Title;
	        entity.Body = changes.Body;
	        entity.EntryTypeId = changes.EntryTypeId;

	        var tagIds = req.Tags;
	        var existingTags = entity.EntryTags.Select(et => et.TagId);
	        if (tagIds.Any() || existingTags.Any())
	        {
		        var toRemove = existingTags.Where(et => !tagIds.Contains(et)).CreateLinks(entity);
		        var toAdd = tagIds.Where(t => !existingTags.Contains(t)).CreateLinks(entity);
                _repo.EntryTag.DeleteRange(toRemove);
                _repo.EntryTag.CreateRange(toAdd);
            }

	        entity.EntryType = _repo.EntryType.Find(entity.EntryTypeId);
	        entity.EntryStatus = _repo.EntryStatus.Find(entity.EntryStatusId);
	        _repo.Entry.UpdateSave(entity);
	        return entity.Map();
        }

        public EntryViewModel UpdateStatus(Guid id, string direction)
        {
            var entity = _repo.Entry.Query().ViewModelIncludes().FindById(id);
            if (entity == null) {
                return null;
            }

            if (direction == StatusDirections.Elevate)
            {
	            if (entity.EntryStatusId == 3)
	            {
		            return null;
	            }

	            entity.EntryStatusId++;
            } else if (direction == StatusDirections.Demote)
            {
	            if (entity.EntryStatusId == 1)
	            {
		            return null;
	            }
	            entity.EntryStatusId--;
            }
            entity.EntryStatus = _repo.EntryStatus.Find(entity.EntryStatusId);

            _repo.Entry.UpdateSave(entity);
            return entity.Map();
        }

        public EntryViewModel Delete(Guid id)
        {
            var entity = _repo.Entry.Query().ViewModelIncludes().FindById(id);
            if (entity == null) {
                return null;
            }
            _repo.Entry.Delete(entity);
            return entity.Map();
        }
    }
}