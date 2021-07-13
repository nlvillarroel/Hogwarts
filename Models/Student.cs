using System;
using System.ComponentModel.DataAnnotations;

namespace Students.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20,ErrorMessage ="maxlenght=20")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Characters only")]
        public string Name { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "maxlenght=20")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Characters only")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "maxlenght=10")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Use Numbers only")]
        public string LegalId { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "maxlenght=2")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Use Numbers only")]
        public string Age { get; set; }

        [Required]
        [MaxLength(1, ErrorMessage = "maxlenght=1")]
        [RegularExpression("[0-3]", ErrorMessage = "Invalid House Value.  Possible Values:Gryffindor=0, Hufflepuff=1, Ravenclaw=2, Slytherin=3)")]
        public string House { get; set; }
    }
}
