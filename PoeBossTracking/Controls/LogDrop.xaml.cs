using PoeBossTracking.Classes.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace PoeBossTracking.Controls
{
    /// <summary>
    /// Interaction logic for LogDrop.xaml
    /// </summary>
    public partial class LogDrop : UserControl
    {
        public LogDrop()
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

        private void comboBoxBoss_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PoeBossTracking.Classes.DataControlHelper.PopulateItemsComboBox(comboBoxItemPool, ((Boss)comboBoxBoss.SelectedItem).bossName);
            }
            catch (HttpRequestException exception)
            {
                //gracefully deal with inability to pull boss list. Should notify user of issue and close application.
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
