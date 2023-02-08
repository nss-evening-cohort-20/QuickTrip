using QuickTrip.Utilities.Enums;
using System.ComponentModel;
using System.Text;

namespace QuickTrip;

public class MainMenu : Menu<MainMenuOptions>
{
    public MainMenu()
    {
        _option = MainMenuOptions.None;
        _module = null;
    }

    private MainMenuOptions _option;
    private IMainMenuModule? _module;

    public void Show()
    {
        while (true)
        {
            ShowMenuOptions();
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
}
