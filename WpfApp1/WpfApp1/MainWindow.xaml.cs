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
using WpfApp1.BASADataSetTableAdapters;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        usrTableAdapter users = new usrTableAdapter();
        ordersTableAdapter orders = new ordersTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            usrDataGrid.ItemsSource = users.GetData();

            ComboBox1.ItemsSource = orders.GetData();
            ComboBox1.DisplayMemberPath = "total_amount";
        }
      

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ComboBox1.SelectedItem as DataRowView).Row[1];
            MessageBox.Show(cell.ToString());
        }
    }
}
