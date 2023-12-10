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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Ex.Models;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Windows.Markup;

namespace Ex
{
    [Serializable]
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string json = File.ReadAllText(@"Cars.json");
        string c = "";
        public MainWindow()
        {
            InitializeComponent();
            CbSortDir.Items.Insert(0, "Направление сортировки");
            CbSortDir.Items.Add("По возрастанию");
            CbSortDir.Items.Add("По убыванию");

            CbSortField.Items.Insert(0, "Поле для сортировки");
            CbSortField.Items.Add("Фамилия");
            CbSortField.Items.Add("Страховая стоимость");
            CbSortField.Items.Add("Стоимость за 1 день");

            CbFilterBrand.Items.Insert(0, "Марка машины");
            CbFilterBrand.Items.Add("Porsche");
            CbFilterBrand.Items.Add("Audi");
            CbFilterBrand.Items.Add("BMW");
            CbFilterBrand.Items.Add("Chevrolet");
            CbFilterBrand.Items.Add("Citroen");
            CbFilterBrand.Items.Add("Daewoo");
            CbFilterBrand.Items.Add("Ford");
            CbFilterBrand.Items.Add("Haval");
            CbFilterBrand.Items.Add("Fiat");

            CbFilterColor.Items.Insert(0, "Цвет машины");
            CbFilterColor.Items.Add("алмаз");
            CbFilterColor.Items.Add("аметист");
            CbFilterColor.Items.Add("асфальт");
            CbFilterColor.Items.Add("баклажан");
            CbFilterColor.Items.Add("белый");
            CbFilterColor.Items.Add("бриз");
            CbFilterColor.Items.Add("вишня");
            CbFilterColor.Items.Add("гранат");
            CbFilterColor.Items.Add("графит");
            CbFilterColor.Items.Add("жемчуг");

            OutputJson();
        }

        public void OutputJson()

        {
            try
            {
                string json = File.ReadAllText(@"Cars.json");
                lstcars.ItemsSource = JsonConvert.DeserializeObject<List<Car>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Update()
        {
            var a = JsonConvert.DeserializeObject<List<Car>>(json);
            if (CbSortField.SelectedIndex > 0)
            {
                switch (CbSortField.SelectedIndex)
                {
                    case 1:
                        if (CbSortDir.SelectedIndex == 1)
                            a = a.OrderBy(p => p.surname).ToList();
                        if (CbSortDir.SelectedIndex == 2)
                            a = a.OrderByDescending(p => p.surname).ToList();
                        break;
                    case 2:
                        if (CbSortDir.SelectedIndex == 1)
                            a = a.OrderBy(p => p.insurance).ToList();
                        if (CbSortDir.SelectedIndex == 2)
                            a = a.OrderByDescending(p => p.insurance).ToList();
                        break;
                    case 3:
                        if (CbSortDir.SelectedIndex == 1)
                            a = a.OrderBy(p => p.oneday).ToList();
                        if (CbSortDir.SelectedIndex == 2)
                            a = a.OrderByDescending(p => p.oneday).ToList();
                        break;
                }
            }
            if (CbFilterBrand.SelectedIndex > 0)
            {
                switch (CbFilterBrand.SelectedIndex)
                {
                    case 1:
                        a = a.Where(p => p.brandcar.Equals("Porsche")).ToList();
                        break;
                    case 2:
                        a = a.Where(p => p.brandcar.Equals("Audi")).ToList();
                        break;
                    case 3:
                        a = a.Where(p => p.brandcar.Equals("BMW")).ToList();
                        break;
                    case 4:
                        a = a.Where(p => p.brandcar.Equals("Chevrolet")).ToList();
                        break;
                    case 5:
                        a = a.Where(p => p.brandcar.Equals("Citroen")).ToList();
                        break;
                    case 6:
                        a = a.Where(p => p.brandcar.Equals("Daewoo")).ToList();
                        break;
                    case 7:
                        a = a.Where(p => p.brandcar.Equals("Ford")).ToList();
                        break;
                    case 8:
                        a = a.Where(p => p.brandcar.Equals("Haval")).ToList();
                        break;
                    case 9:
                        a = a.Where(p => p.brandcar.Equals("Fiat")).ToList();
                        break;
                }
            }
            if (CbFilterColor.SelectedIndex > 0)
            {
                switch (CbFilterColor.SelectedIndex)
                {
                    case 1:
                        a = a.Where(p => p.colourcar.Equals("алмаз")).ToList();
                        break;
                    case 2:
                        a = a.Where(p => p.colourcar.Equals("аметист")).ToList();
                        break;
                    case 3:
                        a = a.Where(p => p.colourcar.Equals("асфальт")).ToList();
                        break;
                    case 4:
                        a = a.Where(p => p.colourcar.Equals("баклажан")).ToList();
                        break;
                    case 5:
                        a = a.Where(p => p.colourcar.Equals("белый")).ToList();
                        break;
                    case 6:
                        a = a.Where(p => p.colourcar.Equals("бриз")).ToList();
                        break;
                    case 7:
                        a = a.Where(p => p.colourcar.Equals("вишня")).ToList();
                        break;
                    case 8:
                        a = a.Where(p => p.colourcar.Equals("гранат")).ToList();
                        break;
                    case 9:
                        a = a.Where(p => p.colourcar.Equals("графит")).ToList();
                        break;
                    case 10:
                        a = a.Where(p => p.colourcar.Equals("жемчуг")).ToList();
                        break;
                }
            }
            if (CbFilterStartDate.SelectedDate != null)
            {
                a = a.Where(p => DateTime.Parse(p.beginning) >= CbFilterStartDate.SelectedDate).ToList();
                if (CbFilterEndDate.SelectedDate != null)
                {
                    if (CbFilterStartDate.SelectedDate > CbFilterEndDate.SelectedDate)
                        MessageBox.Show("Дата начала должна быть меньше даты окончания", " ", MessageBoxButton.OK);
                    else
                        a = a.Where(p => DateTime.Parse(p.end) <= CbFilterEndDate.SelectedDate).ToList();
                }
            }
            c = JsonConvert.SerializeObject(a);
            lstcars.ItemsSource = JsonConvert.DeserializeObject<List<Car>>(c);
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lstcars.SelectedItem is Car current)
            {
                var editing = new Editing(current);
                editing.Owner = this;
                editing.Show();
                Hide();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Adding adding = new Adding();
            adding.Show();
            Hide();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            CbSortDir.SelectedIndex = 0;
            CbSortField.SelectedIndex = 0;
            CbFilterBrand.SelectedIndex = 0;
            CbFilterColor.SelectedIndex = 0;
            CbFilterStartDate.SelectedDate = null;
            CbFilterEndDate.SelectedDate = null;
            lstcars.ItemsSource = JsonConvert.DeserializeObject<List<Car>>(json);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var a = JsonConvert.DeserializeObject<List<Car>>(json);
                c = JsonConvert.SerializeObject(a);
                var jsonFile = JsonConvert.SerializeObject(c);
                File.WriteAllText("newJson.json", jsonFile);
                MessageBox.Show("Файл сохранен в папку bin/Debug");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newJson = File.ReadAllText(@"DemoCars.json");
                lstcars.ItemsSource = JsonConvert.DeserializeObject<List<DemoCar>>(newJson);
                MessageBox.Show("Открыт файл DemoCars");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstcars.SelectedItem is Car current)
            {
                if (MessageBox.Show($"Вы точно хотите удалить выбранную заявку проката?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var a = JsonConvert.DeserializeObject<List<Car>>(json);
                        a.Remove(current);
                        c = JsonConvert.SerializeObject(a);
                        lstcars.ItemsSource = JsonConvert.DeserializeObject<List<Car>>(c);
                        MessageBox.Show("Данные удалены");
                        Update();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
    }
}
