using System;
using System.ComponentModel.DataAnnotations;
namespace ShiftManagement.Web.Models
{
    public class Affiliate
    {
        public Guid Id { get; set; }


        [Required]
        [StringLength(50)]
        public string? Name { get; set; }


        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }


        [Required]
        [StringLength(10)]
        public string? Document {  get; set; }


        [DataType(DataType.Date)]
        [Display(Name= "BirthDay")]
        public DateTime Birthdate { get; set; }


        public bool Active { get; set; }
    }
}
