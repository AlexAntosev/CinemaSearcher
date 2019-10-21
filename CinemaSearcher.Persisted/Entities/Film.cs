using System;

namespace CinemaSearcher.Persisted.Entities
{
    public class Film : BaseEntity
    {
        public string Name { get; set; }

        public int DurationTime { get; set; }

        public string Filmmaker { get; set; }
    }
}
