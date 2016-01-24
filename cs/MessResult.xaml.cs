using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SDKTemplate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MessResult : Page
    {
       
        public MessResult()
        {
            this.InitializeComponent();
            result();
        }

        public async void result()
        {
            if(((App)Application.Current).interval == "all")
            {
                Debug.WriteLine("day is " + ((App)Application.Current).day);
                List<mess_menu> allPersons = await App.MobileService.GetTable<mess_menu>().
                    Where(mess_menu => mess_menu.day == ((App)Application.Current).day).ToListAsync();
                Debug.WriteLine(((App)Application.Current).day);
                string res = "";

                foreach (mess_menu b in allPersons)
                {
                    res += "\n\nDay :" + b.day + "\nroute :" + b.type + "\ntime :" + b.food;
                }
                //var m1 = new MessageDialog(res).ShowAsync();
                SongList.ItemsSource = allPersons;
            }

            else
            {
                List<mess_menu> allPersons = await App.MobileService.GetTable<mess_menu>().
                    Where(mess_menu => mess_menu.type == ((App)Application.Current).interval).
                    Where(mess_menu => mess_menu.day == ((App)Application.Current).day).ToListAsync();
                string res = "";

                foreach (mess_menu b in allPersons)
                {
                    res += "\n\nDay :" + b.day + "\nroute :" + b.type + "\ntime :" + b.food;
                }
                //var m1 = new MessageDialog(res).ShowAsync();
                SongList.ItemsSource = allPersons;
            }
        }
                      
    }
}
