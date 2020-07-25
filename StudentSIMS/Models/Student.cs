using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSIMS
{
    public class Student
    {
        [Key]
        [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
        public int studentId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
    }
}