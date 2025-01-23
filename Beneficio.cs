using BeneficioContribuinte.Resources;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace BeneficioContribuinte.Models
{
    public class Beneficio
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [StringLength(100)]
        [Display(Name = "Nome do Benefício")]
        public required string Nome { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Messages))]
        [Range(0, 100)]
        [Display(Name = "Percentual de Desconto")]
        public decimal PercentualDesconto { get; set; }

        public int QuantidadeContribuintes { get; set; }
    }
}