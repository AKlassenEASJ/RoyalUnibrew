using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using RURS.Annotations;
using RURS.View;
using RURS.ViewModel;

namespace RURS.HamburgerMenu
{
    public class MenuViewModel : VMBase
    {
        public ObservableCollection<NavigationViewItemBase> NavigationItems { get; set; }

        private NavigationViewItemBase _selectedItem;

        public NavigationViewItemBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public MenuViewModel()
        {
            NavigationItems = new ObservableCollection<NavigationViewItemBase>();

            GetNagivationItems();

            SelectedItem = NavigationItems.First(x => x.GetType() == typeof(NavigationViewItem));

        }

        private void GetNagivationItems()
        {
            NavigationItems.Add(new NavigationViewItem { Content = "Home", Icon = new SymbolIcon(Symbol.Home), Tag = typeof(MainPage) });
            //tilføj sider under her, ligesom oppeover
            NavigationItems.Add(new NavigationViewItem { Content = "Processordre", Icon = new SymbolIcon(Symbol.Add), Tag = typeof(ProcessOrdrePage) });
            NavigationItems.Add(new NavigationViewItem {Content = "Tappe Kontrol", Icon = new SymbolIcon(Symbol.Filter), Tag = typeof(TappeKontrolPage)});
        }
    }
}
