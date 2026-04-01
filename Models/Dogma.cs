using System.ComponentModel.DataAnnotations;
namespace AdMechSite.Models
{

    public class Dogma
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }
    }
}