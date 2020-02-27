using System.Collections.Generic;
using KyuApi.Business.ViewModels.Abstract;
using KyuApi.Data.Entities;
using KyuApi.Data.Entities.TypeTables;

namespace KyuApi.Business.ViewModels
{
	public class EntryViewModel : GuidEntityViewModel<Entry>
	{
		public string Title { get; set; }
		public string Body { get; set; }
		public TypeTableViewModel<EntryStatus> Status { get; set; }
		public TypeTableViewModel<EntryType> Type { get; set; }
		public IEnumerable<TypeTableViewModel<Tag>> Tags { get; set; }
	}
}
