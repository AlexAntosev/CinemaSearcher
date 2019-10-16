using AutoMapper;
using CinemaSearcher.Models;
using CinemaSearcher.Persisted.Entities;

namespace CinemaSearcher.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TicketModel, Ticket>();
        }
    }
}
