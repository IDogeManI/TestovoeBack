using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestovoeBack.Models
{
    public class CompanyDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Phone { get; set; }
        public List<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
        public List<HistoryDto> Histories { get; set; } = new List<HistoryDto>();
        public List<NoteDto> Notes { get; set; } = new List<NoteDto>();

    }
}
