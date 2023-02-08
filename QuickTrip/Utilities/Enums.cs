using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTrip.Utilities.Enums
{
    public enum PropertyMenuOptions
    {
        None = 0,
        [Description("Add District")] District,
        [Description("Add Store")] Store,
        [Description("Go Back")] Back
    }

    public enum MainMenuOptions
    {
        None = 0,
        [Description("Manage Districts/Stores")] ManageProperty,
        [Description("Manage Employees")] HR,
        [Description("Enter Sales")] EnterSales,
        [Description("Reports")] Reports,
        Exit,
    }
}
