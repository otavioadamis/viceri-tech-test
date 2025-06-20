using System.ComponentModel.DataAnnotations;

namespace SuperHeroes.Data.Utils
{
    public static class ValidarNascimento
    {
        public static ValidationResult? ValidarDataNascimento(DateTime data, ValidationContext context)
        {
            return data > DateTime.Today
                ? new ValidationResult("Data de nascimento não pode ser no futuro.")
                : ValidationResult.Success;
        }
    }

}
