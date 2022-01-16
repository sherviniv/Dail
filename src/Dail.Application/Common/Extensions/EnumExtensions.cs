using System.ComponentModel;
using System.Reflection;

namespace Dail.Application.Common.Extensions;

public static class EnumExtensions
{
    public static string GetDescriptionAttr<T>(this T source)
    {
        var srcStr = source!.ToString() ?? "";

        FieldInfo fi = source.GetType().GetField(srcStr) ?? default!;

        if (fi == null)
        {
            return srcStr;
        }

        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
            typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0) return attributes[0].Description;
        else return srcStr;
    }
}