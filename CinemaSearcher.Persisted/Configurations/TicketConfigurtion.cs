using CinemaSearcher.Persisted.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaSearcher.Persisted.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.HasQueryFilter(_ => !_.IsDeleted);
        }
    }
}
