using QuickTrip.Utilities.Enums;
using System.ComponentModel;
using System.Text;

namespace QuickTrip;

public abstract class Menu<TEnum>
{
    protected void ShowMenuOptions()
    {
        var bldr = new StringBuilder();

        foreach (var option in Enum.GetValues(typeof(TEnum)))
        {
            if ((int)option == 0) continue;
            bldr.AppendLine($" {(int)option}. {DisplayName((TEnum)option)}");
        }

        Console.WriteLine(bldr);
    }

    private string DisplayName(TEnum val)
    {
        DescriptionAttribute[] attributes = (DescriptionAttribute[])val
           .GetType()
           .GetField(val.ToString())
           .GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : val.ToString();
    }
}
