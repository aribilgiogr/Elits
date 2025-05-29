using AutoMapper;
using Core.Concretes.Entities;
using UI.Web.Models.Account;

namespace UI.Web.Models.Maps
{
    public class AccountViewModelProfile:Profile
    {
        public AccountViewModelProfile()
        {
            CreateMap<RegisterViewModel, ApplicationUser>();
        }
    }
}
