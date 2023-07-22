using System.Text.Json;
using cesapp.Models;

namespace cesapp.Services
{
    public interface ISessionsHandler
    {
        public void setUserSession(string key, User user);
        public User getUserSession(string key);
        void clearSession();
    }
    public class SessionsHandler : ISessionsHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public SessionsHandler(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public void setUserSession(string key, User user)
        {
            var userSerialized = JsonSerializer.Serialize(user);
            if (getUserSession(key) == null)
            {
                _contextAccessor.HttpContext.Session.SetString(key, userSerialized);
            }
        }

        public User getUserSession(string key)
        {
            var userSerialized = _contextAccessor.HttpContext.Session.GetString(key);
            if(userSerialized == null)
            {
                return null;
            }
            User user = JsonSerializer.Deserialize<User>(userSerialized);
            return user;
        }

        public void clearSession()
        {
            _contextAccessor.HttpContext.Session.Clear();
        }
    }
}
