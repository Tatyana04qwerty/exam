using Ex.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace Ex
{
    /// <summary>
    /// Логика взаимодействия для Adding.xaml
    /// </summary>
    public partial class Adding : Window
    {
        private static Car _current = new Car();
        public Adding()
        {
            InitializeComponent();
            DataContext = _current;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string json1 = File.ReadAllText(@"Cars.json");
                var a = JsonConvert.DeserializeObject<List<Car>>(json1);
                _current.surname = tbsurname.Text;
                _current.name = tbname.Text;
                _current.patronymic = tbpatronymic.Text;
                _current.brandcar = tbbrandcar.Text;
                _current.colourcar = tbcolourcar.Text;
                _current.insurance = Convert.ToDouble(tbinsurance.Text);
                _current.oneday = Convert.ToDouble(tboneday.Text);
                _current.beginning = dpbeginning.Text;
                _current.end = dpend.Text;
                a.Add(_current);

                string json = JsonConvert.SerializeObject(a);
                File.WriteAllText("Cars.json", json);
                //File.WriteAllText("Cars.json", json);

                var rez = MessageBox.Show("Данные загружены", " ", MessageBoxButton.OK);
                if (rez == MessageBoxResult.OK)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {
            double oneday = Convert.ToDouble(tboneday.Text);
            DateTime start = dpbeginning.SelectedDate.Value.Date;
            DateTime finish = dpend.SelectedDate.Value.Date;
            TimeSpan difference = finish.Subtract(start);
            int days = Convert.ToInt32(difference.TotalDays);
            double insuranceFee = Convert.ToDouble(tbinsurance.Text) / 10;
            double res = oneday * Convert.ToInt32(days) + insuranceFee;
            Counted.Content = res.ToString();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Hide();
        }
    }
}
