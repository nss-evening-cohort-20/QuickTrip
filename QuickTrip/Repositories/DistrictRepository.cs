using QuickTrip.Models;

namespace QuickTrip.Repositories;

public class DistrictRepository
{
    private static List<District> _districts = new()
    { 
        new District { Id = 313, Name = "West Coast"},
        new District { Id = 205, Name = "Midwest"},
        new District { Id = 464, Name = "Southwest"},
        new District { Id = 110, Name = "Northeast"},
    };

    public List<District> GetAll()
    {
        return _districts;
    }

    public District? GetById(int id)
    {
        return _districts.Find(d => d.Id == id);
    }

    public void Add(District district)
    {
        _districts.Add(district);
    }
}
