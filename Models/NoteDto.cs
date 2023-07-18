using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestovoeBack.Models
{
    public class NoteDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompanyId { get;set; }
        public CompanyDto Company { get; set; }
        public int? InvoiceNumber { get; set; }
        public string? Employee { get; set; }
    }
}
