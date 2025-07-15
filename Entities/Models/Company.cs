using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Company
    {
        [Column("CompanyId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Company name is required field")]
        [MaxLength(100, ErrorMessage = "Maximum length for the name is 100 character")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Compnay address is required")]
        [MaxLength(100, ErrorMessage = "Maximum length for the address is 100 character")]
        public string? Address { get; set; }

        public string? Country { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
