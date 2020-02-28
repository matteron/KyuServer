using KyuApi.Data.Entities;
using KyuApi.Data.Entities.Navigation;
using KyuApi.Data.Entities.TypeTables;
using Microsoft.EntityFrameworkCore;

namespace KyuApi.Data
{
	public class KyuContext : DbContext
	{
		public KyuContext(DbContextOptions<KyuContext> options) : base(options) { }

		public DbSet<Entry> Entries { get; set; }
		public DbSet<EntryType> EntryTypes { get; set; }
		public DbSet<EntryStatus> EntryStatuses { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<EntryTag> EntryTags { get; set; }
		public DbSet<HashHolder> HashHolders { get; set; }

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
