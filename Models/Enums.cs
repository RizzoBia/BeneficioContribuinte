using System.ComponentModel.DataAnnotations;

namespace BeneficioContribuinte.Enums
{
    public enum RegimeTributacao
    {
        [Display(Name = "Variável")]
        Variavel,

        [Display(Name = "MEI")]
        MEI,

        [Display(Name = "MEEPP")]
        MEEPP
    }

    public enum PossuiBeneficio
    {
        [Display(Name = "Sim")]
        Sim = 1,
        [Display(Name = "Não")]
        Nao = 0
    }
}