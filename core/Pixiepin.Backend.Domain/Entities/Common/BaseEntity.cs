using System.ComponentModel.DataAnnotations.Schema;

namespace Pixiepin.Backend.Domain.Entities.Common;

public abstract class BaseEntity {
    [Column("id")]
    public required Guid Id { get; set; }
    [Column("createdAt")]
    public DateTime CreatedAt { get; set; }
    [Column("updatedAt")]
    public DateTime? UpdatedAt { get; set; }
    [Column("isDeleted")]
    public bool IsDeleted { get; set; }
}
