
namespace Assignment4_Team2556_WebAPI.Models.Exceptions
{
    public class RefreshTokenBadRequest : Exception
    {
        public RefreshTokenBadRequest()
         : base("Invalid client request. The tokenDTO has some invalid values.")
        {
        }
    }
}
