using System;
using System.Collections.Generic;
using KyuApi.Business.ViewModels;
using KyuApi.Business.ViewModels.Requests;

namespace KyuApi.Business.Services.Main
{
    public interface IKyuService
    {
        IEnumerable<EntryViewModel> GetEntries();
        EntryViewModel CreateEntry(EntryRequest req);
        EntryViewModel UpdateEntry(EntryRequest req);
        EntryViewModel UpdateStatus(Guid id, string direction);
        EntryViewModel Delete(Guid id);
    }
}