using AuthorBookWebAPI.DTOs;
using AuthorBookWebAPI.Models;
using AutoMapper;

namespace AuthorBookWebAPI.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.TotalBooks, val => val.MapFrom(src => src.Books.Count));
            CreateMap<AuthorDto, Author>();

            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();

            CreateMap<AuthorDetails, AuthorDetailsDto>();
            CreateMap<AuthorDetailsDto, AuthorDetails>();

        }
    }
}
