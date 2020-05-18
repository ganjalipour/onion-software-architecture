using Consulting.Domains.Core.Entities;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore.ModelConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class ZoneConfiguration : BaseEntityTypeConfiguration<Zone>
    {
        public override void Configure(EntityTypeBuilder<Zone> builder)
        {
            builder.HasData(new Zone() { ID = 5, OSTAN = "00", OSTANCode = "38", OstanName = "مرکزی", SHAHRESTAN = "01", ShahrestName = "اراک", BAKHSH = "02", BakhshName = "مرکزی", Dehestan = "01", DehestanName = "امان آباد", Abadi = "00026", AbadiName = "امان آباد" });
            base.Configure(builder);
        }
    }
}
