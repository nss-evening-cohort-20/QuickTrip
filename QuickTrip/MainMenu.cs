using System.ComponentModel;
using System.Text;

namespace QuickTrip;

public class MainMenu
{
    public MainMenu()
    {
        _option = MainMenuOptions.None;
        _module = null;
    }

    private enum MainMenuOptions //add new menu options to ExecuteSelection() method
    {
        None = 0,
        [Description("Manage Districts/Stores")] ManageProperty,
        [Description("Manage Employees")] HR,
        [Description("Enter Sales")] EnterSales,
        [Description("Reports")] Reports,
        Exit,
    }

    private MainMenuOptions _option;
    private IMainMenuModule? _module;

    public void Show()
    {
        while (true)
        {
            ShowOptions();
            GetSelection();
            if (_option == MainMenuOptions.Exit) { break; }
            ExecuteSelection();
        }
    }

    private void ExecuteSelection()
    {
        switch (_option)
        {
            case MainMenuOptions.ManageProperty:
                _module = new PropertyModule();
                break;
            case MainMenuOptions.HR:
                _module = new HRModule();
                break;
            case MainMenuOptions.EnterSales:
                //_module = new SalesModule();
                break;
            case MainMenuOptions.Reports:
                //_module = new ReportModule();
                break;
            default:
                break;

        }
        
        _module?.Execute();
        _module = null;
    }

    private void GetSelection()
    {
        Console.Write(" >> ");

        while (true)
        {
            if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int input)
                && (input > 0 || input < Enum.GetValues<MainMenuOptions>().Length))
            {
                Console.WriteLine(input);
                _option = (MainMenuOptions)input;
                break;
            }
        }
    }

    private void ShowOptions()
    {
        var bldr = new StringBuilder();

        foreach (var option in Enum.GetValues<MainMenuOptions>())
        {
            if ((int)option == 0) continue;
            bldr.AppendLine($" {(int)option}. {option.DisplayName()}");
        }

        Console.WriteLine(bldr);
    }
}
