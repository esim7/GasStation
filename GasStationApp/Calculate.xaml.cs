using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GasStationApp
{
    /// <summary>
    /// Логика взаимодействия для Calculate.xaml
    /// </summary>
    public partial class Calculate : Page
    {
        public Fuel fuel = new Fuel();
        public List<ShopItem> Items = new List<ShopItem>();
        public MainWindow Window;
        public int Result { get; set; } = 0;

        public Calculate(MainWindow Window, Fuel fuel, List<ShopItem> items)
        {
            InitializeComponent();
            this.Window = Window;
            this.fuel = fuel;
            fuelName.Content += fuel.Name;
            fuelCapacity.Content += fuel.Capacity.ToString();
            fuelPrice.Content += fuel.Price.ToString();
            this.Items = items;
            lvItems.ItemsSource = Items;
            Result = fuel.Capacity * fuel.Price;
            foreach(var item in Items)
            {
                Result += item.Price;
            }
            TotalPrice.Content += Result.ToString();
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Успешно оплачено!");
            Window.Close();
        }
    }
}
