using CrudAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudAPI.Data.Map
{
    public class GameMap : IEntityTypeConfiguration<GamesModel>
    {
        public void Configure(EntityTypeBuilder<GamesModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Company).IsRequired().HasMaxLength(150);

        }
    }
}
