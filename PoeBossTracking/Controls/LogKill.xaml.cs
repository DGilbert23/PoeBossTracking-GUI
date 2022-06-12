using PoeBossTracking.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
    /// Interaction logic for LogKill.xaml
    /// </summary>
    public partial class LogKill : UserControl
    {
        public LogKill()
        {
            InitializeComponent();
            try
            {
                PoeBossTracking.Classes.DataControlHelper.PopulateBossComboBox(comboBoxBoss);
            }
            catch (HttpRequestException e)
            {
                //gracefully deal with inability to pull boss list. Should notify user of issue and close application.
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*if (PoeBossTracking.Classes.DataControlHelper.LogNewKill(comboBoxBoss.SelectedValue.ToString(), GlobalVariables.Username, datePickerKillDate.SelectedDate.Value))
            {
                labelLogError.Visibility = Visibility.Collapsed;
                labelLogSuccess.Visibility = Visibility.Visible;
            }
            else
            {
                labelLogError.Visibility = Visibility.Visible;
                labelLogSuccess.Visibility = Visibility.Collapsed;
            }
            */
        }
    }
}
