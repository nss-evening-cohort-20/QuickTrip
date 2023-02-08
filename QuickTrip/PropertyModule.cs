using QuickTrip.Models;
using QuickTrip.Repositories;
using QuickTrip.Utilities.Enums;
using System.Text;

namespace QuickTrip;

public class PropertyModule : Menu<PropertyMenuOptions>, IMainMenuModule
{
    public PropertyModule()
    {
        _selection = PropertyMenuOptions.None;
        _districtRepo = new DistrictRepository();
    }

    

    private PropertyMenuOptions _selection;
    private readonly DistrictRepository _districtRepo;

    public void Execute()
    {
        ShowPropertyMenu();
        GetSelection();
        ExecuteSelection();
    }

    private void ExecuteSelection()
    {
        switch (_selection)
        {
            case PropertyMenuOptions.District:
                District? district = GetNewDistrictInfo();
                if (district != null)
                {
                    _districtRepo.Add(district);
                }
                break;
            case PropertyMenuOptions.Store: break;

            case PropertyMenuOptions.Back: break;
            default:
                break;
        }
    }

    private District? GetNewDistrictInfo()
    {
        var districts = _districtRepo.GetAll().OrderBy(d => d.Id);

        if (!districts.Any())
        {
            Console.WriteLine("There are currently no districts.  Make the first one!");
        }
        else
        {
            var text = new StringBuilder();
            text.AppendLine("Districts:");
            foreach (var district in districts)
            {
                text.AppendLine($"   #{district.Id} - {district.Name}");
            }
            Console.WriteLine(text);
        }
        
        return null;
    }

    private void GetSelection()
    {
        Console.Write(" >> ");

        while (true)
        {
            if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int input)
                && (input > 0 || input < Enum.GetValues<PropertyMenuOptions>().Length))
            {
                Console.WriteLine(input);
                _selection = (PropertyMenuOptions)input;
                break;
            }
        }
    }

    private void ShowPropertyMenu()
    {
        
    }
}
