using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AggApi.Data.Entities.Abstract;
using AggApi.Data.Entities.TypeTables;

namespace AggApi.Data.Entities.Navigation
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
