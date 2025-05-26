using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Mvc.Models

{
    [Table("Caobathaison")]
    public class Caobathaison
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sdt { get; set; }

}
}