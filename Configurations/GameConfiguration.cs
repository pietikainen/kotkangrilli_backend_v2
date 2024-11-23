using kotkangrilli.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kotkangrilli.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        // Define table name
        builder.ToTable("games");
        
        // Define primary key
        builder.HasKey(g => g.Id);
        
        // Define columns
        builder.Property(g => g.Id).HasColumnName("id").IsRequired();
        builder.Property(g => g.ExternalId).HasColumnName("external_id").IsRequired();
        builder.Property(g => g.Title).HasColumnName("title").IsRequired();
        builder.Property(g => g.Image).HasColumnName("image");
        builder.Property(g => g.Price).HasColumnName("price");
        builder.Property(g => g.Link).HasColumnName("link");
        builder.Property(g => g.Store).HasColumnName("store"); 
        builder.Property(g => g.Players).HasColumnName("players");
        builder.Property(g => g.IsLan).HasColumnName("is_lan").IsRequired();
        builder.Property(g => g.Description).HasColumnName("description");
        builder.Property(g => g.CreatedAt).HasColumnName("created_at");
        builder.Property(g => g.UpdatedAt).HasColumnName("updated_at");
        
        // Define foreign key relationship
        builder.Property(g => g.SubmittedById).HasColumnName("submitted_by").IsRequired();
        builder.HasOne(g => g.SubmittedBy)
            .WithMany()
            .HasForeignKey(g => g.SubmittedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}