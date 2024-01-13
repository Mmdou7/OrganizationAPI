
using Organization.Domain.Common.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Organization.Application.Common.Utilities;

public static class Extensions
{
    public static string GetDbTableName(this Type type)
    {
        return type.GetCustomAttribute<TableNameAttribute>()?.NameValue ?? string.Empty;
    }

    public static string GetDbTableColumnNames(this Type type, string[] selectedProperties)
    {
        if (selectedProperties.Length < 1)
            return string.Join(",", type.GetProperties().Select(p => p.GetDbColumnName())).TrimEnd(',');
        else
            return string.Join("," , type.GetProperties().Where(p => selectedProperties.ToLowerInvariant().Contains(p.Name.ToLowerInvariant())).Select(p=>p.GetDbColumnName())).TrimEnd(',');
    }

    public static string GetColumnValuesForInsert<T>(this Type type, T obj)
    {
        return string.Join("," ,type.GetColumnProperties().Select(p => $"'{p.GetValue(obj)}'"));
    }

    public static string GetColumnValuesForUpdate<T>(this Type type, T obj)
    {
        return string.Join(",", type.GetNonPrimaryKeyColumnProperties().Select(p => $"{p.GetDbColumnName()} = '{p.GetValue(obj)}'"));
    }

    public static string GetDbColumnName(this PropertyInfo propertyInfo)
    {
        return propertyInfo.GetCustomAttribute<ColumnNameAttribute>()?.NameValue ?? string.Empty;
    }

    public static IEnumerable<string> ToLowerInvariant(this string[] source)
    {
        foreach(var item in source)
        {
            yield return item.ToLowerInvariant();
        }
    }

    public static IEnumerable<PropertyInfo> GetColumnProperties(this Type type)
    {
        return type.GetProperties().Where(p => p.GetCustomAttribute<AssociationAttribute>() is null);
    }

    public static IEnumerable<PropertyInfo> GetNonPrimaryKeyColumnProperties(this Type type)
    {
        return type.GetProperties().Where(p=>p.GetCustomAttribute<PrimaryKeyAttribute>() is null && p.GetCustomAttribute<AssociationAttribute>() is null);
    }

    public static IEnumerable<AssociatedType> GetAssociatedTypes(this Type type)
    {
        foreach (var assciatedAttribute in type.GetProperties().Where(p => p.GetCustomAttribute<NavigationAttribute>() is not null).Select(p => p.GetCustomAttribute<NavigationAttribute>()))
            yield return new AssociatedType(assciatedAttribute.AssociatedType, assciatedAttribute.AssociatedType.GetProperty(assciatedAttribute.AssociatedProperty));
    }
}
