using AutoMapper;
using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Site.Library.Dto;
using SevenWinBackend.Common;

namespace SevenWinBackend.Site.Library.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeHelper.ToTimestamp(src.CreatedAt)))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeHelper.ToTimestamp(src.UpdatedAt)));
        }
    }
}
