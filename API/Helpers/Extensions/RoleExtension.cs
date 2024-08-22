using Businnes.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Helpers.Extensions
{
    public static class RoleExtensions
    {
        public static string GetDisplayName(this Role role) =>
            (role.GetType().GetField(role.ToString())?.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[])?[0]?.Name ?? role.ToString();
    }
}
