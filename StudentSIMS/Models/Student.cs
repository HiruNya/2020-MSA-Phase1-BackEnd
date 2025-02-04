using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSIMS
{
    public class Student
    {
        [Key]
        [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
        public int studentId { get; set; }
        [Required, MaxLength(100)]
        public string firstName { get; set; }
        public string middleName { get; set; }
        [Required]
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public int phoneNumber { get; set; }
        [Timestamp]
        public DateTime timeCreated { get; set; }
    }
}