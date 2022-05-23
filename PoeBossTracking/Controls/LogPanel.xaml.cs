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

namespace PoeBossTracking.Controls
{
    /// <summary>
    /// Interaction logic for LogPanel.xaml
    /// </summary>
    public partial class LogPanel : UserControl
    {
        public LogPanel()
        {
            InitializeComponent();
        }

        private void buttonLogKill_Click(object sender, RoutedEventArgs e)
        {
            if (panelLogKill.Visibility == Visibility.Collapsed)
            {
                panelLogKill.Visibility = Visibility.Visible;
                panelLogDrop.Visibility = Visibility.Collapsed;

            }
        }

        private void buttonLogDrop_Click(object sender, RoutedEventArgs e)
        {
            if (panelLogDrop.Visibility == Visibility.Collapsed)
            {
                panelLogKill.Visibility = Visibility.Collapsed;
                panelLogDrop.Visibility = Visibility.Visible;
            }
        }
    }
}
