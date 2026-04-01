using System;
using System.ComponentModel.DataAnnotations;
namespace AdMechSite.Models
{
    public class Seguidor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Range(1, 10)]
        public int GrauDeDevocao { get; set; }

        [Display(Name = "Parte Substituída")]
        public string ParteSubstituida { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataIniciacao { get; set; }
    }
}