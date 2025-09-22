using AutoMapper;
using PersonalLibraryAPI.Model;
using PersonalLibraryAPI.DTOs;

namespace PersonalLibraryAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTo>();
            CreateMap<BookCreateDTo, Book>();
            CreateMap<BookUpdateDT, Book>();
        }
    }
}