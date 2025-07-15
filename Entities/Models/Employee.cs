using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required field")]
        [MaxLength(ErrorMessage = "Name field is only 100 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required field")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Position is required field")]
        [MaxLength(20, ErrorMessage = "Position field is only 20 char acters")]
        public string? Position { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
