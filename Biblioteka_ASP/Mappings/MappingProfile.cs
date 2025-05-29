using AutoMapper;
using Biblioteka_ASP.Models;
using Biblioteka_ASP.ViewModels;

namespace Biblioteka_ASP.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Klienci, KlienciViewModel>()
                .ForMember(dest =>
                dest.LiczbaWypozyczen, 
                opt =>
                opt.MapFrom(src => src.Wypozyczenia != null ? src.Wypozyczenia.Count : 0))
                .ReverseMap();
        }
    }
}
