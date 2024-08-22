
using Businnes.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Businnes.Data.Models
{
    public class UsuarioVm 
    {
        public Guid UsuarioId { get; set; } = Guid.NewGuid();
        public string PrimeiroNome { get;  set; } = string.Empty;
        public string SegundoNome { get;  set; } = string.Empty;
        public string NomeCompleto { get { return this.PrimeiroNome + this.SegundoNome; } }
        public string Telefone { get;  set; } = string.Empty;
        public string CPF { get;  set; } = string.Empty;
        public string Email { get;  set; } = string.Empty;
        public string Senha { get;  set; } = string.Empty;
        public Role Role { get;  set; }
        public string? Token { get; set; }

        public static Role GetRole(string role)
        {
            switch (role)
            {
                case "Gerente":
                    return Role.Gerente;
                default:
                    return Role.Colaborador;
            }

        }
        public static string GetRoleDisplayName(Role role)
        {
            var displayAttribute = typeof(Role)
                .GetField(role.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                as DisplayAttribute[];

            return displayAttribute != null && displayAttribute.Length > 0
                ? displayAttribute[0].Name
                : role.ToString();
        }
    }
}
