using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Mvc.Models
{
    [Table("Tinhdiem")]
    public class Tinhdiem
    {
        [Key]
        public string DiemA { get; set; }
        public string DiemB { get; set; }
        public string DiemC { get; set; }
    }
}