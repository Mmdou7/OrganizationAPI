
using System.Reflection;

namespace Organization.Domain.Common.Utilities;

public class AssociatedType
{
    public Type Type { get; }
    public PropertyInfo ForeignKeyProperty { get; }
    public AssociatedType(Type type , PropertyInfo propertyInfo)
    {
        Type = type;
        ForeignKeyProperty = propertyInfo;
    }
}
