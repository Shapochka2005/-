using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using Pract2.baseDataSetTableAdapters;

namespace Pract2
{
    public partial class MainWindow : Window
    {
        usersTableAdapter usr = new usersTableAdapter();
        ordersTableAdapter orders = new ordersTableAdapter();
        int userId = 0;
        int sum = 0;
        public MainWindow()
        {
            InitializeComponent();
            usersDataGrid.ItemsSource = usr.GetData();
            grid2.ItemsSource = orders.GetData();

            ComboBox1.ItemsSource = usr.GetData();
            ComboBox1.DisplayMemberPath = "username";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            usr.InsertQuery(usernamebox.Text, emailbox.Text);
            usersDataGrid.ItemsSource = usr.GetData();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sum = Convert.ToInt32(TextAdd.Text);
            orders.InsertQuery1(userId, Text1.Text, sum);
            grid2.ItemsSource = orders.GetData();
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ComboBox1.SelectedItem as DataRowView).Row[0];
            userId = (int)cell;
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (usersDataGrid.SelectedItem as DataRowView).Row[0];
            usr.DeleteUser(Convert.ToInt32(id));
            usersDataGrid.ItemsSource = usr.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id1 = (grid2.SelectedItem as DataRowView).Row[0];
            orders.DeleteOrder(Convert.ToInt32(id1));
            grid2.ItemsSource = orders.GetData();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            object id2 = (usersDataGrid.SelectedItem as DataRowView).Row[0];
            usr.UpdateQuery1(usernamebox.Text, emailbox.Text, Convert.ToInt32(id2));
            usersDataGrid.ItemsSource = usr.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id3 = (grid2.SelectedItem as DataRowView).Row[0];
            object cell = (ComboBox1.SelectedItem as DataRowView).Row[0];
            userId = Convert.ToInt32(cell);
            orders.UpdateQuery2(userId, Text1.Text, Convert.ToInt32(TextAdd.Text), Convert.ToInt32(id3));
            grid2.ItemsSource = orders.GetData();
        }

        private void usersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            usernamebox.Text = (usersDataGrid.SelectedItem as DataRowView).Row[1].ToString();
            emailbox.Text = (usersDataGrid.SelectedItem as DataRowView).Row[2].ToString();
        }

        private void grid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox1.SelectedItem = (usersDataGrid.SelectedItem as DataRowView).Row[0];
            Text1.Text = (grid2.SelectedItem as DataRowView).Row[2].ToString();
            TextAdd.Text = (grid2.SelectedItem as DataRowView).Row[3].ToString();
        }
    }
}