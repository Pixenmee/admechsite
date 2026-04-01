using System.ComponentModel.DataAnnotations;
namespace AdMechSite.Models
{
    public class Escritura
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Titulo { get; set; }

        [Required]
        public string Conteudo { get; set; }
    }
}