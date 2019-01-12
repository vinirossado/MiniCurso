using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyHome.Infra.Data.Configurations
{
    public class GaleriaConfig : IEntityTypeConfiguration<Galeria>
    {
        public void Configure(EntityTypeBuilder<Galeria> builder)
        {
            builder.ToTable("Galerias");
            builder.HasOne(x => x.Empreendimento).WithMany(e => e.Galerias).HasForeignKey(x => x.EmpreendimentoId);
        }
    }
}
