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
    public sealed partial class BusResult : Page
    {
        public BusResult()
        {
            this.InitializeComponent();
            result();
        }
        public async void result()
        {
            List<bus_timetable> list_res = new List<bus_timetable>();

            Debug.WriteLine("In result");
            String route = "", result = "", realDay;
            Debug.WriteLine(((App)Application.Current).d);
            Debug.WriteLine(((App)Application.Current).s);
            realDay = ((App)Application.Current).day;

            
            if (((App)Application.Current).s == "IITJ" || ((App)Application.Current).s == "college" ||
                    ((App)Application.Current).d == "GPRA" || ((App)Application.Current).d == "hostel")
            {
                route = "1";
                result = "IITJ to GPRA";
                ((App)Application.Current).s = "college";
                ((App)Application.Current).d = "hostel";
            }

            else if (((App)Application.Current).d == "IITJ" || ((App)Application.Current).d == "college" ||
                    ((App)Application.Current).s == "GPRA" || ((App)Application.Current).s == "hostel")
            {
                route = "0";
                result = "GPRA to IITJ";
                ((App)Application.Current).s = "hostel";
                ((App)Application.Current).d = "college";
            }
            Debug.WriteLine("Results are " + route + result + ((App)Application.Current).s + ((App)Application.Current).d);

            if (((App)Application.Current).s == "null" && ((App)Application.Current).d == "null")
            {
                Debug.WriteLine("In first If" + ((App)Application.Current).time);
                if (((App)Application.Current).time == 0)
                {
                    List<bus_timetable> allPersons = await App.MobileService.GetTable<bus_timetable>().
                    Where(bus_timetable => bus_timetable.day == ((App)Application.Current).day).
                    Where(bus_timetable => bus_timetable.route == "0").ToListAsync();

                    string res = "GPRA to IITJ";

                    foreach (bus_timetable b in allPersons)
                    {
                        res += "\n\nDay :" + realDay + "\t\ttime :" + b.time;
                    }

                    List<bus_timetable> allPersons1 = await App.MobileService.GetTable<bus_timetable>().
                    Where(bus_timetable => bus_timetable.day == ((App)Application.Current).day).
                    Where(bus_timetable => bus_timetable.route == "1").ToListAsync();

                    res += "\nIITJ to GPRA";

                    foreach (bus_timetable b in allPersons1)
                    {
                        res += "\n\nDay :" + realDay + "\t\ttime :" + b.time;
                    }
                    //var m1 = new MessageDialog(res).ShowAsync();
                    SongList.ItemsSource = allPersons;
                    SongList.ItemsSource = allPersons1;
                }

                else
                {
                    Debug.WriteLine("First if second else");
                    List<bus_timetable> allPersons = await App.MobileService.GetTable<bus_timetable>().
                    Where(bus_timetable => bus_timetable.day == ((App)Application.Current).day).
                    Where(bus_timetable => bus_timetable.route == "0").
                    Where(bus_timetable => bus_timetable.time >= ((App)Application.Current).time).
                    OrderBy(bus_timetable => bus_timetable.time).ToListAsync();
                                        
                    list_res.Add(allPersons.First());                    

                    result = "GPRA to IITJ";

                    foreach (bus_timetable b in allPersons)
                    {
                        result += "\n\nDay :" + realDay + "\t\ttime :" + b.time;
                        break;
                    }

                    List<bus_timetable> allPersons1 = await App.MobileService.GetTable<bus_timetable>().
                    Where(bus_timetable => bus_timetable.day == ((App)Application.Current).day).
                    Where(bus_timetable => bus_timetable.route == "0").
                    Where(bus_timetable => bus_timetable.time >= ((App)Application.Current).time).
                    OrderBy(bus_timetable => bus_timetable.time).ToListAsync();

                    //list_res.Add(allPersons1.First());

                    result += "\nIITJ to GPRA";

                    foreach (bus_timetable b in allPersons1)
                    {
                        result += "\n\nDay :" + realDay + "\t\ttime :" + b.time;
                        break;
                    }
                    //var m1 = new MessageDialog(result).ShowAsync();
                    SongList.ItemsSource = list_res;
                    
                }
            }

            else
            {
                Debug.WriteLine("In else");
                if (((App)Application.Current).time == 0)
                {
                    Debug.WriteLine("In second if");
                    List<bus_timetable> allPersons = await App.MobileService.GetTable<bus_timetable>().
                    Where(bus_timetable => bus_timetable.day == ((App)Application.Current).day).
                    ToListAsync();

                    result = "GPRA to IITJ";

                    foreach (bus_timetable b in allPersons)
                    {
                        result += "\n\nDay :" + realDay + "\t\ttime :" + b.time;
                    }
                    Debug.WriteLine(((App)Application.Current).day);

                    List<bus_timetable> allPersons1= await App.MobileService.GetTable<bus_timetable>().
                    Where(bus_timetable => bus_timetable.day == ((App)Application.Current).day).
                    Where(bus_timetable => bus_timetable.route == "1").ToListAsync();

                    result += "\nIITJ to GPRA";

                    foreach (bus_timetable b in allPersons1)
                    {
                        result += "\n\nDay :" + realDay + "\t\ttime :" + b.time;
                    }
                    //var m1 = new MessageDialog(result).ShowAsync();
                    SongList.ItemsSource = allPersons;
                    SongList.ItemsSource = allPersons1;

                }
                else
                {
                    List<bus_timetable> allPersons = await App.MobileService.GetTable<bus_timetable>().
                    Where(bus_timetable => bus_timetable.day == ((App)Application.Current).day).
                    Where(bus_timetable => bus_timetable.route == route).
                    Where(bus_timetable => bus_timetable.time >= ((App)Application.Current).time).
                    OrderBy(bus_timetable => bus_timetable.time).ToListAsync();

                    list_res.Add(allPersons.First());

                    foreach (bus_timetable b in allPersons)
                    {
                        result += "\n\nDay :" + realDay + "\t\ttime :" + b.time;
                        break;
                    }

                    //var m1 = new MessageDialog(result).ShowAsync();
                    SongList.ItemsSource = list_res;                    
                }
            }
                           
        }

        private async void SongList_Loaded(object sender, RoutedEventArgs e)
        {
            List<bus_timetable> allPersons = await App.MobileService.GetTable<bus_timetable>().ToListAsync();

            SongList.ItemsSource = allPersons;
        }
    }
}
