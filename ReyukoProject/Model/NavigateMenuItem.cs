using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyukoProject.Model
{

    public class NavigateMenuItem
    {
        public NavigateMenuItem()
        {
            SubMenus = new ObservableCollection<NavigateMenuItem>();
        }

        public string Title { get; set; }
        public string IconPath { get; set; }

        public ObservableCollection<NavigateMenuItem> SubMenus { get; set; }
    }
}
