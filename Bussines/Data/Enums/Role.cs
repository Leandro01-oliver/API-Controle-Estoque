using System.ComponentModel.DataAnnotations;

namespace Businnes.Data.Enums
{
    public enum Role
    {
        [Display(Name = "Gerente")]
        Gerente = 1,
        [Display(Name = "Colaborador")]
        Colaborador
    }
}
