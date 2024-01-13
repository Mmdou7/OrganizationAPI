using Organization.Domain.Common.Models;
using Organization.Domain.Common.Utilities;

namespace Organization.Domain.Models;

[TableName("tblCompanies")]
public sealed class Company : IDbEntity
{
    [PrimaryKey]
    [ColumnName("Id")]
    public string Id { get; set; } = ShortGuid.NewGuid();

    [ColumnName("Name")]
    public string? Name { get; set; }

    [ColumnName("Address")]
    public string? Address { get; set; }

    [ColumnName("Country")]
    public string? Country { get; set; }

    [ColumnName("IsDeleted")]
    public bool IsDeleted { get; set; }
    [Navigation(typeof(Employee), "CompanyId")]
    public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
}
