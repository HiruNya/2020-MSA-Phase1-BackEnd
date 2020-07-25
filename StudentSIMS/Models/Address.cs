using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSIMS
{
    public class Address
    {
        [Key]
        [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
        public int addressId { get; set; }
        public int studentId { get; set; }
        public int streetNumber { get; set; }
        public string street { get; set; }
        public string suburb { get; set; }
        public string city { get; set; }
        public int postcode { get; set; }
        public string country { get; set; }
    }
}