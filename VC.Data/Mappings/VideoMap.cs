using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VC.Domain.Models;

namespace VC.Data.Mappings
{
    public class VideoMap : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(3000)");
            builder.Property(c => c.ThumbnailUrl)
                .HasColumnType("varchar(300)");
            builder.Property(c => c.ThumbnailmqUrl)
                .HasColumnType("varchar(300)");
            builder.Property(c => c.ThumbnailhqUrl)
                .HasColumnType("varchar(300)");
        }
    }
}