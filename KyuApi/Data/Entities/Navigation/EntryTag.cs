using System;
using System.ComponentModel.DataAnnotations.Schema;
using KyuApi.Data.Entities.Abstract;
using KyuApi.Data.Entities.TypeTables;

namespace KyuApi.Data.Entities.Navigation
{
	public class EntryTag : IntEntity
	{
		public Guid EntryId { get; set; }
		public int TagId { get; set; }

		[ForeignKey("EntryId")]
		public virtual Entry Entry { get; set; }
		[ForeignKey("TagId")]
		public virtual Tag Tag { get; set; }
	}
}
