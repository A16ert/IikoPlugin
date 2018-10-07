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

namespace IikoPaymentPlugin.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ClientInfoCell.xaml
    /// </summary>
    public partial class ClientInfoCell : UserControl
    {
        public static DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header), typeof(string), typeof(ClientInfoCell), new PropertyMetadata(string.Empty));

        public static DependencyProperty InfoTextProperty =
            DependencyProperty.Register(nameof(InfoText), typeof(string), typeof(ClientInfoCell), new PropertyMetadata(string.Empty));

        public ClientInfoCell()
        {
            InitializeComponent();
        }

        public string Header
        {
            get => (string)GetValue(HeaderProperty);

            set => SetValue(HeaderProperty, value);
        }

        public string InfoText
        {
            get => (string)GetValue(InfoTextProperty);

            set => SetValue(InfoTextProperty, value);
        }
    }
}
