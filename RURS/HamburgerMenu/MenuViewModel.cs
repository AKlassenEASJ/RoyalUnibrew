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

namespace RURS.HamburgerMenu
{
    class MenuViewModel : INotifyPropertyChanged
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
           
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
