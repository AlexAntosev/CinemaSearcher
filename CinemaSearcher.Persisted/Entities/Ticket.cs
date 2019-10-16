using System;

namespace CinemaSearcher.Persisted.Entities
{
    public class Ticket : BaseEntity
    {
        public int Number { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public Guid? FilmId { get; set; }
    }
}
