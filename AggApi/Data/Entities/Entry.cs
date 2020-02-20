using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AggApi.Data.Entities.Abstract;
using AggApi.Data.Entities.Navigation;
using AggApi.Data.Entities.TypeTables;

namespace AggApi.Data.Entities
{
	public class Entry : GuidEntity
	{
		public string Title { get; set; }
		public string Body { get; set; }

		public int EntryStatusId { get; set; }
		[ForeignKey("EntryStatusId")]
		public virtual EntryStatus EntryStatus { get; set; }

		public DateTime CreateDate { get; set; }

		public int EntryTypeId { get; set; }
		[ForeignKey("EntryTypeId")]
		public virtual EntryType EntryType { get; set; }

		public virtual ICollection<EntryTag> EntryTags { get; set; } = new List<EntryTag>();
	}
}
