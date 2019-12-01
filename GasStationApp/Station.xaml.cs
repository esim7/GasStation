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
    /// Логика взаимодействия для Station.xaml
    /// </summary>
    public partial class Station : Page
    {
        public Fuel fuel;
        List<ShopItem> Items;
        public MainWindow Window;
        public Station(MainWindow Window)
        {
            InitializeComponent();
            this.Window = Window;
            fuel = new Fuel();
            Items = new List<ShopItem>();
        }

        public void ShowPrice()
        {
           
        }

        private void FueldList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void textBox_FuelCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void calculatePrice_button(object sender, RoutedEventArgs e)
        {
            if(FueldList.SelectedItem != null && textBox_FuelCount.Text != null)
            {
                if (FueldList.SelectedIndex == 0)
                {
                    fuel.Name = FuelPrice.АИ92.ToString();
                    fuel.Price = (int)FuelPrice.АИ92;
                }
                else if (FueldList.SelectedIndex == 1)
                {
                    fuel.Name = FuelPrice.АИ95.ToString();
                    fuel.Price = (int)FuelPrice.АИ95;
                }
                else if (FueldList.SelectedIndex == 2)
                {
                    fuel.Name = FuelPrice.АИ98.ToString();
                    fuel.Price = (int)FuelPrice.АИ98;
                }
                else if (FueldList.SelectedIndex == 3)
                {
                    fuel.Name = FuelPrice.ДТ.ToString();
                    fuel.Price = (int)FuelPrice.АИ98;
                }
                try
                {
                    fuel.Capacity = Int32.Parse(textBox_FuelCount.Text);
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Указано неверное значение поля Количество литров");
                }
                
                Window.frame.Navigate(new Calculate(Window, fuel, Items));
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
            
        }

        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            var item = new ShopItem();
            item.Name = comboBox_ShopItems.SelectedItem.ToString().Replace("System.Windows.Controls.Label: ", string.Empty);
            if (comboBox_ShopItems.SelectedIndex == 0)
            {
                item.Price = (int)ItemPrice.Snickers;
            }
            else if (comboBox_ShopItems.SelectedIndex == 1)
            {
                item.Price = (int)ItemPrice.Pepsi;
            }
            else if (comboBox_ShopItems.SelectedIndex == 2)
            {
                item.Price = (int)ItemPrice.RedBull;
            }
            else if (comboBox_ShopItems.SelectedIndex == 3)
            {
                item.Price = (int)ItemPrice.Lays;
            }
            Items.Add(item);
            MessageBox.Show("Товар успешно добавлен в корзину!");
        }
    }
}
