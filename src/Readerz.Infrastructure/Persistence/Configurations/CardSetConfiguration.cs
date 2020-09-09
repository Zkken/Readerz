using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readerz.Domain.Entities;

namespace Readerz.Infrastructure.Persistence.Configurations
{
    public class CardSetConfiguration : IEntityTypeConfiguration<CardSet>
    {
        public void Configure(EntityTypeBuilder<CardSet> builder)
        {
            builder.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}