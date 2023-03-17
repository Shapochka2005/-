using System;
using System.Collections.Generic;
using System.Data;
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
        int? sum = 12;
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
    }
}