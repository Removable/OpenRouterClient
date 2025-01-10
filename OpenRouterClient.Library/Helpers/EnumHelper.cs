using System.ComponentModel;

namespace OpenRouterClient.Library.Helpers;

public static class EnumHelper
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        if (field == null)
        {
            return value.ToString();
        }

        var attributes = field.GetCustomAttributes(false);
        if (attributes.Length == 0)
        {
            return value.ToString();
        }

        var attribute = (DescriptionAttribute)attributes[0];
        return attribute.Description;
    }
}