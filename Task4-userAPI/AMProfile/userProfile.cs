using AutoMapper;
using Task4_userAPI.DataTransferObject;
using Task4_userAPI.Models;

namespace Task4_userAPI.AMProfile
{
    public class userProfile : Profile
    {
        public userProfile()
        {
            CreateMap<user, UserVM>()
                .Include<user, UserVM>()
                .ForMember(
                dest=>dest.Id,
                opt=>opt.MapFrom(src=>src.Id)
                )
            .ForMember(
                dest => dest.fname,
                opt => opt.MapFrom(src => src.fname)
                )
            .ForMember(
                dest => dest.lname,
                opt => opt.MapFrom(src => src.lname)
                )
            .ForMember(
                dest => dest.postId,
                opt => opt.MapFrom(model => model.posts.ToList())
                )
            ;

        }
    }
}
