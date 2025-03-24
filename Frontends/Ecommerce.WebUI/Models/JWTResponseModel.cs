namespace Ecommerce.WebUI.Models
{
    public class JWTResponseModel
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
