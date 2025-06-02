using AutoMapper;
using Core.Concretes.DTOs.Post;
using UI.Web.Models.Home;

namespace UI.Web.Models.Maps
{
    public class HomeViewModelProfile : Profile
    {
        public HomeViewModelProfile()
        {
            CreateMap<NewPostViewModel, CreatePostDto>();
        }
    }
}
