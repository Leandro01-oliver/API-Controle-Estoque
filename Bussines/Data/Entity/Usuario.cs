using Businnes.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class Usuario
    {
        [Key]
        public Guid UsuarioId { get; set; }
        public string PrimeiroNome { get; private set; } = string.Empty;
        public string SegundoNome { get; private set; } = string.Empty;
        public string NomeCompleto { get { return this.PrimeiroNome + this.SegundoNome; } }
        public string Telefone { get; private set; } = string.Empty;
        public string CPF { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Senha { get; private set; } = string.Empty;
        public Role Role { get; private set; }
        public string? Token { get; set; }

    }
}
