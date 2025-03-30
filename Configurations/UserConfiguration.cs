using kotkangrilli.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kotkangrilli.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
        public void Configure(EntityTypeBuilder<User> builder)
        {
                // Define table name
                builder.ToTable("users");
                
                // Define primary key
                builder.HasKey(u => u.Id);

                // Define columns
                builder.Property(u => u.Id).HasColumnName("id").IsRequired();
                builder.Property(u => u.Snowflake).HasColumnName("snowflake").IsRequired();
                builder.Property(u => u.Username).HasColumnName("username").IsRequired();
                builder.Property(u => u.Nickname).HasColumnName("nickname");
                builder.Property(u => u.Avatar).HasColumnName("avatar");
                builder.Property(u => u.Email).HasColumnName("email").IsRequired();
                builder.Property(u => u.Phone).HasColumnName("phone");
                builder.Property(u => u.Iban).HasColumnName("iban");
                builder.Property(u => u.Level).HasColumnName("user_level_id").IsRequired()
                        .HasConversion<int>();
                builder.Property(u => u.CreatedAt).HasColumnName("created_at");
                builder.Property(u => u.UpdatedAt).HasColumnName("updated_at");
                builder.Property(u => u.LastLogin).HasColumnName("last_login");
        }
}