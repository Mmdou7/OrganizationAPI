namespace Organization.Domain.Common.Utilities; 
[AttributeUsage(AttributeTargets.Property)] 
public class NavigationAttribute : Attribute
{
    public Type? AssociatedType { get; }
    public string AssociatedProperty { get; set; }
    public NavigationAttribute(Type? associatedType, string associatedProperty)
    {
        AssociatedType = associatedType;
        AssociatedProperty = associatedProperty;
    }
}
