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
            return _repo.Entry.Query().ViewModelIncludes().MapEntries();
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
            return entity.Map();
        }

        public EntryViewModel UpdateStatus(Guid id, string direction)
        {
            var entity = _repo.Entry.Query().ViewModelIncludes().FindById(id);
            if (entity == null) {
                return null;
            }
            entity.EntryStatusId += (
                direction == StatusDirections.Elevate
                ? 1
                : direction == StatusDirections.Demote
                    ? -1
                    : 0);
            
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