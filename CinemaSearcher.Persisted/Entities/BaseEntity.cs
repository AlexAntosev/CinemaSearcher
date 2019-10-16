using System;

namespace CinemaSearcher.Persisted.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
