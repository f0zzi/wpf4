using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace wpf4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        ObservableCollection<Color_item> color_list = new ObservableCollection<Color_item>();
        public MainWindow()
        {
            InitializeComponent();
            lbColors.ItemsSource = color_list;
            Slider_ValueChanged(null, null);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rectangle.Fill = new SolidColorBrush(Color.FromArgb(
                Convert.ToByte(Convert.ToBoolean(cbAlpha.IsChecked) ? slAlpha.Value : 255),
                Convert.ToByte(slRed.Value),
                Convert.ToByte(slGreen.Value),
                Convert.ToByte(slBlue.Value)));
            Color_item tmp = new Color_item(Color.FromArgb(
                Convert.ToByte(Convert.ToBoolean(cbAlpha.IsChecked) ? slAlpha.Value : 255),
                Convert.ToByte(slRed.Value),
                Convert.ToByte(slGreen.Value),
                Convert.ToByte(slBlue.Value)));
            btAdd.IsEnabled = !color_list.Contains(tmp);
        }

        private void Cb_Checked(object sender, RoutedEventArgs e)
        {
            Slider_ValueChanged(null, null);
        }
        private void Slider_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Convert.ToBoolean(e.NewValue) == false)
                (sender as Slider).Value = 0;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            color_list.Remove((Color_item)(sender as Button).DataContext);
            Slider_ValueChanged(null, null);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Color_item tmp = new Color_item(Color.FromArgb(
                Convert.ToByte(Convert.ToBoolean(cbAlpha.IsChecked) ? slAlpha.Value : 255),
                Convert.ToByte(slRed.Value),
                Convert.ToByte(slGreen.Value),
                Convert.ToByte(slBlue.Value)));
            if (!color_list.Contains(tmp))
                color_list.Add(tmp);
            btAdd.IsEnabled = !color_list.Contains(tmp);
        }
    }
}
