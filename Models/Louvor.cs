using System.ComponentModel.DataAnnotations;
namespace AdMechSite.Models
{

    public class Louvor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Titulo { get; set; }

        [Required]
        public string Letra { get; set; }
    }
}