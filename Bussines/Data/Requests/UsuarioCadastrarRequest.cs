namespace Bussines.Data.Requests
{
    public record UsuarioCadastrarRequest(string PrimeiroNome, string SegundoNome, string Telefone, string CPF, string Email, string Senha);
}
