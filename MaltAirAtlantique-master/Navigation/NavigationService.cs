﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MaltAirAtlantique.Navigation
{

        public sealed class NavigationService : INavigationService
        {
            public void Navigate(Type sourcePage)
            {
                //var frame = (Frame)Window.;
                //frame.Navigate(sourcePage);
            }

            public void Navigate(Type sourcePage, object parameter)
            {
                //var frame = (Frame)Window.Current.Content;
                //frame.Navigate(sourcePage, parameter);
            }

            public void GoBack()
            {
                //var frame = (Frame)Window.Current.Content;
                //frame.GoBack();
            }
        }
 
}
