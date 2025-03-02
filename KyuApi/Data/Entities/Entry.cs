﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using KyuApi.Data.Entities.Abstract;
using KyuApi.Data.Entities.Navigation;
using KyuApi.Data.Entities.TypeTables;

namespace KyuApi.Data.Entities
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
