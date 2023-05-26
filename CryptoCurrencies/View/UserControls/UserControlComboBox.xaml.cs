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

namespace View
{
    public partial class UserControlTextBox : UserControl
    {
        public UserControlTextBox()
        {
            InitializeComponent();

        }
        private void LoadData()
        {
            // Завантажте дані, які будуть використовуватися для автодоповнення
            List<string> similarNames = new List<string> { "Bitcoin", "Ethereum", "Litecoin", "Ripple", "Bitcoin Cash", "Cardano" };

            // Налаштуйте фільтрацію
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(similarNames);
            view.Filter = Filter;

            // Налаштуйте комбо-бокс на підставі завантажених даних
            comboBox.ItemsSource = similarNames;
        }

        private bool Filter(object item)
        {
            if (string.IsNullOrEmpty(comboBox.Text))
                return true;
            else
                return ((string)item).IndexOf(comboBox.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
