using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients.UI.ViewModel
{
    public static class ViewModelLocator
    {
        public static MapViewModel MapViewModel { get; } = new MapViewModel();
    }
}
