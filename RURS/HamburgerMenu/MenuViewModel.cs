using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using ModelLibary.Models;
using RURS.Annotations;
using RURS.Model;
using RURS.View;
using RURS.ViewModel;
using ProcessOrdreViewModel = RURS.View.ProcessOrdreView;

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

        public ProcessOrdre ProcessOrdre { get; set; }
        public SelectedPOSingleton PoSingleton { get; set; }    
        public MenuViewModel()
        {
            NavigationItems = new ObservableCollection<NavigationViewItemBase>();

            GetNagivationItems();

            SelectedItem = NavigationItems.First(x => x.GetType() == typeof(NavigationViewItem));
            PoSingleton = SelectedPOSingleton.GetInstance();
            ProcessOrdre = PoSingleton.ActiveProcessOrdre;

        }

        private void GetNagivationItems()
        {
            NavigationItems.Add(new NavigationViewItem { Content = "Home", Icon = new SymbolIcon(Symbol.Home), Tag = typeof(MainPage) });
            //tilføj sider under her, ligesom oppeover
            NavigationItems.Add(new NavigationViewItem { Content = "Processordre", Icon = new SymbolIcon(Symbol.Add), Tag = typeof(ProcessOrdreView) });
            NavigationItems.Add(new NavigationViewItem {Content = "Pakke Kontrol", Icon = new SymbolIcon(Symbol.Shop), Tag = typeof(PakkeKontrolView)});
            NavigationItems.Add(new NavigationViewItem {Content = "Tappe Kontrol", Icon = new SymbolIcon(Symbol.Filter), Tag = typeof(TappeKontrolPage)});
            NavigationItems.Add(new NavigationViewItem {Content = "Vægt Kontrol", Icon = new SymbolIcon(Symbol.Filter), Tag = typeof(VaegtKontrolView)});
        }
    }
}
