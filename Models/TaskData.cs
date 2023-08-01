using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskBookWebApp.Areas.Identity.Data;

namespace TaskBookWebApp.Models
{
    public class TaskData
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [Required]
        [MaxLength(20)]
        public String Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string AssignedBy { get; set; }
        [Required]
        [MaxLength(30)]
        public string AssignedTo { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName ="decimal(4,1)")]
        public Decimal Duration { get; set; }
        [Required]
        public string Status { get; set; }

        //Foreign key reference to the user who created the task
        public string CreatorId { get; set; }

    }
}
