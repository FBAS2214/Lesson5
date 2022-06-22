using Lesson5.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lesson5
{
    // INotifyPropertyChanged
    // Dependency Property



    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // public Car Car { get; set; }

        public ObservableCollection<Car>? Cars { get; set; }





        public string SomeText
        {
            get { return (string)GetValue(SomeTextProperty); }
            set { SetValue(SomeTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SomeText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SomeTextProperty =
            DependencyProperty.Register("SomeText", typeof(string), typeof(MainWindow));





        //private string? someText;
        //public string? SomeText
        //{
        //    get { return someText; }
        //    set
        //    {
        //        someText = value;
        //        OnPropertyRaised();
        //    }
        //}



        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Cars = new ObservableCollection<Car>
            {
                new Car {
                    Vendor = "BMW",
                    Model = "X6",
                    Year = 2022
                },
                new Car {
                    Vendor = "LADA",
                    Model = "2107",
                    Year = 2004
                },
                new Car {
                    Vendor = "Mercedes",
                    Model = "Mayback",
                    Year = 2021
                }
            };

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // this.Resources["primaryColor"] = Brushes.RoyalBlue;

            // MessageBox.Show(SomeText);

            Cars?.Add(new Car { Vendor = "Kia", Model = "Cerato", Year = 2013 });
        }



        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var window = new InfoCar();
            window.Car = (sender as ListBox)?.SelectedItem as Car;
            window.ShowDialog();
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyRaised([CallerMemberName] string propertyname = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
