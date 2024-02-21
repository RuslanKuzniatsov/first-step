using Microsoft.AspNetCore.Http;
using System.Linq;
using web_first.EfStuff.DbModel;
using web_first.EfStuff.Repositores;

namespace web_first.Services
{
    public class UserService
    {
        private GalleryUserRepository _userRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public UserService(GalleryUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public GalleryUser GetCorrent()
        {
            var idsStr = _httpContextAccessor
                .HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type == "Id")
                ?.Value;
            if (idsStr == null)
            {
                return null;
            }
            var id = int.Parse(idsStr);

            var user = _userRepository.Get(id);


            return user;
        }
    }
}
