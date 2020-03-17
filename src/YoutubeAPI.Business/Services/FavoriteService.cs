using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using YoutubeAPI.Business.Interfaces;
using YoutubeAPI.Business.Models;


namespace YoutubeAPI.Business.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly IUserService userService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public FavoriteService( IFavoriteRepository favoriteRepository, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            this.favoriteRepository = favoriteRepository;
            this.userService = userService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task RemoveFavorite(string id)
        {
            await this.favoriteRepository.Remove(id);
        }

        public async Task SaveFavoriteAsync(Favorite favorite)
        {
            //to-do validate and error notify

            var user = httpContextAccessor.HttpContext.User.Identity.AuthenticationType;
            var entity = await this.userService.GetUserByEmail(user);
            favorite.User = entity;

            await this.favoriteRepository.Create(favorite);
        }
    }
}
