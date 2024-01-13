using Organization.Domain.Common.Models;
using Organization.Domain.Common.Utilities;

namespace Organization.Domain.Models;
[TableName("tblEmployees")]
public sealed class Employee : IDbEntity
{
    [PrimaryKey]
    [ColumnName("Id")]
    public string Id { get; set; } = ShortGuid.NewGuid();

    [ColumnName("Name")]
    public string? Name { get; set; }

    [ColumnName("Age")]
    public int Age { get; set; }

    [ColumnName("Position")]
    public string? Position { get; set; }
    [ForeignKey]
    [ColumnName("CompanyId")]
    public string CompanyId { get; set; } = string.Empty;

    [ColumnName("IsDeleted")]
    public bool IsDeleted { get; set; }

    [ColumnName("createdOn")]
    public DateTime CreatedOn { get; set; }

    [ColumnName("ModifiedOn")]
    public DateTime ModifiedOn { get; set; }

    [ColumnName("Salary")]
    public decimal Salary { get; set; }
}
