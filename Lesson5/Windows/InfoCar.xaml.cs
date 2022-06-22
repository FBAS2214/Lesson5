using Lesson5.Models;
using System.Windows;

namespace Lesson5
{
    public partial class InfoCar : Window
    {
        public Car? Car { get; set; }

        public InfoCar()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
