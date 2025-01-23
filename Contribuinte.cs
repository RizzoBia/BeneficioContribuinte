using System.ComponentModel.DataAnnotations;
using System.Resources;
using BeneficioContribuinte.Resources;
using BeneficioContribuinte.Enums;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;

namespace BeneficioContribuinte.Models
{
    public class Contribuinte
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "CNPJ")]
        [MaxLength(20)]
        public string CNPJ { get; set; } = string.Empty;

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "Razão Social")]
        [MaxLength(200)]
        public string RazaoSocial { get; set; } = string.Empty;

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "Data de Abertura")]
        [DataType(DataType.Date)]
        public DateOnly DataAbertura { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "Regime de Tributação")]
        [MaxLength(50)]
        public string RegimeTributacao { get; set; } = string.Empty;

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "Possui Benefício")]
        public bool PossuiBeneficio { get; set; }
        public int? BeneficioId { get; set; }
        public Beneficio? Beneficio { get; set; }
    }
}
