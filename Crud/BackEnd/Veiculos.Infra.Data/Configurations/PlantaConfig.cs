using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyHome.Infra.Data.Configurations
{
    public class PlantaConfig : IEntityTypeConfiguration<Planta>
    {
        public void Configure(EntityTypeBuilder<Planta> builder)
        {
            builder.ToTable("Plantas");
            builder.HasOne(x => x.Empreendimento).WithMany(e => e.Plantas).HasForeignKey(x => x.EmpreendimentoId);
        }
    }
}
