using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AggApi.Data.Entities;
using AggApi.Data.Entities.Navigation;
using AggApi.Data.Entities.TypeTables;
using Microsoft.EntityFrameworkCore;

namespace AggApi.Data
{
	public class KyuContext : DbContext
	{
		public KyuContext(DbContextOptions<KyuContext> options) : base(options) { }

		public DbSet<Entry> Entries { get; set; }
		public DbSet<EntryType> EntryTypes { get; set; }
		public DbSet<EntryStatus> EntryStatuses { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<EntryTag> EntryTags { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Entry>(b =>
			{
				b.HasMany(e => e.EntryTags)
					.WithOne(et => et.Entry)
					.HasForeignKey(et => et.EntryId);
			});
		}
	}
}
