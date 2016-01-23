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
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SDKTemplate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BusSchedule : Page
    {
        public BusSchedule()
        {
            this.InitializeComponent();
        }

        private async void InsertData_click(object sender, RoutedEventArgs e)

        {

            bus_timetable b1 = new bus_timetable

            {

                day = dayTxt.Text,

                time = timeTxt.Text,

                route = routeTxt.Text

            };

            await App.MobileService.GetTable<bus_timetable>().InsertAsync(b1);


            var m1 = new MessageDialog("Data Inserted").ShowAsync();

            dayTxt.Text = "";

            timeTxt.Text = "";

            routeTxt.Text = "";

        }

        private async void Retrive_Click(object sender, RoutedEventArgs e)

        {

            List<bus_timetable> allPersons = await App.MobileService.GetTable<bus_timetable>().ToListAsync();

            string res = "";

            foreach (bus_timetable b in allPersons)

            {

                res += "\n\nDay :" + b.day + "\nroute :" + b.route + "\ntime :" + b.time;

            }

            var m1 = new MessageDialog(res).ShowAsync();

        }

    }
}
