using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WinUI
{
    /// <summary>
    /// Interaction logic for JoinNetworkView.xaml
    /// </summary>
    public partial class JoinNetworkView : Window
    {
        Regex wholeStringRegex = new Regex("^[0-9a-fxA-FX]+$");

        public JoinNetworkView()
        {
            InitializeComponent();
        }

        public string NetworkID { get; set; } = "";
        public bool AllowDefault { get; set; } = false;
        public bool AllowGlobal { get; set; } = false;
        public bool AllowManaged { get; set; } = true;

        private void joinButton_Click(object sender, RoutedEventArgs e)
        {
            APIHandler.Instance.JoinNetwork(this.Dispatcher, NetworkID, AllowManaged, AllowGlobal, AllowDefault);

            Close();
        }

        private void joinNetworkBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            joinButton.IsEnabled = joinNetworkBox.Text.Length == 16 && wholeStringRegex.IsMatch(joinNetworkBox.Text);
        }
    }
}
