﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RURS.HamburgerMenu
{
    class NavigationService
    {
            public static Frame NavigationFrame { get; set; }

            public static void Navigate(Type pageType)
            {
                NavigationFrame.Navigate(pageType);
                ChangeMenuSelection();
            }

            public static void GoBack()
            {
                NavigationFrame.GoBack();
                ChangeMenuSelection();
            }

            private static void ChangeMenuSelection()
            {
                if ((Windows.UI.Xaml.Window.Current.Content as Frame).Content is MenuPage mp)
                {
                    MenuViewModel VM = mp.DataContext as MenuViewModel;
                    Type t = NavigationFrame.Content.GetType();
                    NavigationViewItemBase tmp = (VM.NavigationItems as IEnumerable<NavigationViewItemBase>).FirstOrDefault(x => (x.Tag as Type) == t);
                    if (tmp != null)
                        VM.SelectedItem = tmp;
                }
            }
        }
    }
