using AuthorBookWebAPI.DTOs;
using AuthorBookWebAPI.Models;
using AuthorBookWebAPI.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookWebAPI.Services
{
    public class AuthorDetailsService : IAuthorDetailsService
    {
        private readonly IGenericRepository<AuthorDetails> _authorDetailsRepository;
        private readonly IMapper _mapper;

        public AuthorDetailsService(IGenericRepository<AuthorDetails> authorDetailsRepository, IMapper mapper)
        {
            _authorDetailsRepository = authorDetailsRepository;
            _mapper = mapper;
        }

        public List<AuthorDetailsDto> GetAllAuthorDetails()
        {
            var authorDetailsList = _authorDetailsRepository.GetAll()
                                                            .AsNoTracking()  
                                                            .ToList();

            return _mapper.Map<List<AuthorDetailsDto>>(authorDetailsList);
        }

        public AuthorDetailsDto GetAuthorDetails(int id)
        {
            var authorDetails = _authorDetailsRepository.Get(id);
            if (authorDetails != null)
            {
                return _mapper.Map<AuthorDetailsDto>(authorDetails);
            }

            return null; 
        }

        public int AddAuthorDetails(AuthorDetailsDto authorDetailsDto)
        {
            var authorDetails = _mapper.Map<AuthorDetails>(authorDetailsDto);
            _authorDetailsRepository.Add(authorDetails);
            return authorDetails.AuthorDetailsId;


        }

        public bool UpdateAuthorDetails(AuthorDetailsDto authorDetailsDto)
        {
            var existingAuthorDetails = _authorDetailsRepository.Get(authorDetailsDto.AuthorDetailsId);

            if (existingAuthorDetails != null)
            {
                _mapper.Map(authorDetailsDto, existingAuthorDetails);
                _authorDetailsRepository.Update(existingAuthorDetails);
                return true;
            }

            return false;
        }

        public bool DeleteAuthorDetails(int id)
        {
            var authorDetails = _authorDetailsRepository.Get(id);

            if (authorDetails != null)
            {
                _authorDetailsRepository.Delete(authorDetails);
                return true;
            }

            return false;
        }

        public AuthorDetailsDto GetAuthorDetailsByAuthorId(int authorId)
        {
            var authorDetails = _authorDetailsRepository.GetAll()
                                                    .FirstOrDefault(ad => ad.AuthorId == authorId);

            if (authorDetails != null)
            {
                var authorDetailsDto = _mapper.Map<AuthorDetailsDto>(authorDetails);
                return authorDetailsDto;
                 
            }
            return null;

        }
    }


}
