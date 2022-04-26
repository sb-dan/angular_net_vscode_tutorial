using System.ComponentModel.DataAnnotations;

namespace Website.Data.Tutorial.Schema;

public class BaseEntity
{

    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? ModifiedBy { get; set; }


    public DateTimeOffset? ModifiedDate { get; set; }

    [StringLength(50)]
    public string RecordBy { get; set; } = null!;

    public DateTimeOffset RecordDate { get; set; }

}
