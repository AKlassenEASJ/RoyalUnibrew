using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using AdminRURS.View;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RURS.HamburgerMenu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuPage : Page
    {
        public MenuPage()
        {
            this.InitializeComponent();
            NavigationService.NavigationFrame = NavFrame;
            NavigationService.Navigate(typeof(MainPage));
        }

        private void NavView_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
            }
            else
            {
                string itemTitle = args.InvokedItem as string;
                NavigationViewItemBase navItem =
                    (sender.MenuItemsSource as IEnumerable<NavigationViewItemBase>).First(x =>
                        x.Content as string == itemTitle);
                NavigationService.Navigate(navItem.Tag as Type);
            }
        }

        private void NavView_OnBackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            NavigationService.GoBack();
        }
    }
}
