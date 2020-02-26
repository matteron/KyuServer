using System.Collections.Generic;
using KyuApi.Business.ViewModels.Abstract;
using KyuApi.Data.Entities;

namespace KyuApi.Business.ViewModels
{
	public class EntryViewModel : GuidEntityViewModel<Entry>
	{
		public string Title { get; set; }
		public string Body { get; set; }
		public EntryStatusViewModel Status { get; set; }
		public EntryTypeViewModel Type { get; set; }
		public IEnumerable<TagViewModel> Tags { get; set; }
	}
}
