namespace Sela.Task.API.Models.DTO
{
    public class TokenDetail
    {
        public TokenDetail(string Token)
        {
            this.Token = Token;
        }

        public string Token { get; set; }
    }
}
