using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSIMS
{
    public class Address
    {
        [Key]
        [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
        public int addressId { get; set; }
        [Required]
        public int studentId { get; set; }
        [Required]
        public int streetNumber { get; set; }
        [Required]
        public string street { get; set; }
        public string suburb { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public int postcode { get; set; }
        [Required]
        public string country { get; set; }
    }
}