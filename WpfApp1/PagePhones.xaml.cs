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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для PagePhones.xaml
    /// </summary>
    public partial class PagePhones : Page
    {
        private TictonicEntities context = new TictonicEntities();


        public PagePhones()
        {
            InitializeComponent();
            PhonesDG.ItemsSource = context.Phones.ToList();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                Phones phone = new Phones();
                phone.Brand = TextBox1.Text;
                phone.Model = TextBox2.Text;

                context.Phones.Add(phone);
                context.SaveChanges();
                PhonesDG.ItemsSource = context.Phones.ToList();

                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Значения не могут быть пустыми!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (PhonesDG.SelectedItem != null)
            {
                context.Phones.Remove((Phones)PhonesDG.SelectedItem);
                context.SaveChanges();
                PhonesDG.ItemsSource = context.Phones.ToList();

                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Выбери объект!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (PhonesDG.SelectedItem != null)
            {
                if (TextBox1.Text != "" && TextBox2.Text != "")
                {
                    Phones selected = (Phones)PhonesDG.SelectedItem;
                    var obj = context.Phones.First(x => x.ID == selected.ID);

                    obj.Brand = TextBox1.Text;
                    obj.Model = TextBox2.Text;

                    context.SaveChanges();
                    PhonesDG.ItemsSource = context.Phones.ToList();

                    TextBox1.Text = "";
                    TextBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Значения не могут быть пустыми!");
                }
            }
            else
            {
                MessageBox.Show("Выбери объект!");
            }
        }

        private void PhonesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            Phones selected = PhonesDG.SelectedItem as Phones;
            if (selected != null)
            {
                TextBox1.Text = selected.Brand;
                TextBox2.Text = selected.Model;
            }
        }
    }
}
