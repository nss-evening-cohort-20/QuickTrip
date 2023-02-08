using System.ComponentModel;
using System.Text;

namespace QuickTrip;

public class PropertyModule : IMainMenuModule
{
    private enum PropertyMenuOptions
    {
        None = 0,
        [Description("Add District")] District,
        [Description("Add Store")] Store,
        [Description("Go Back")] Back
    }

    public void Execute()
    {
        ShowPropertyMenu();
        GetSelection();
        //ExecuteSelection();
    }

    private void GetSelection()
    {
        throw new NotImplementedException();
    }

    private void ShowPropertyMenu()
    {
        var bldr = new StringBuilder();

        foreach (var option in Enum.GetValues<PropertyMenuOptions>())
        {
            if ((int)option == 0) continue;
            bldr.AppendLine($" {(int)option}. {option.DisplayName()}");
        }

        Console.WriteLine(bldr);
    }
}
