using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyHome.Infra.Data.Configurations
{
    public class EmpreendimentoConfig : IEntityTypeConfiguration<Empreendimento>
    {
        public void Configure(EntityTypeBuilder<Empreendimento> builder)
        {
            builder.ToTable("Empreendimentos");

            builder.Ignore(x => x.Lazeres);
        }
    }
}
