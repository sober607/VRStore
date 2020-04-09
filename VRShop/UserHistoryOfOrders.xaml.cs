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

namespace VRShop
{
    /// <summary>
    /// Логика взаимодействия для UserHistoryOfOrders.xaml
    /// </summary>
    public partial class UserHistoryOfOrders : Window
    {
        public UserHistoryOfOrders()
        {
            InitializeComponent();
            using (Model1 db = new Model1())
            {
                UserHistoryOfOrdersDatagrid.ItemsSource = db.OrderedProducts.Where(p => p.OrderConfirmed == true).ToList();
            }
        }
    }
}
