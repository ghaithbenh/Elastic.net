using System.ComponentModel.DataAnnotations;

namespace ElasticDotnet.Domain.Entities;
public class Keyword
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public required string Word { get; set; }

    [StringLength(255)]
    [Required]
    public int Count { get; set; } = 0;
}
