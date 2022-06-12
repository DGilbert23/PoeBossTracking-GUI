using PoeBossTracking.Classes;
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
    /// Interaction logic for LogKillAndDrops.xaml
    /// </summary>
    public partial class LogKillAndDrops : UserControl
    {
        public LogKillAndDrops()
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
            scrollGrid.Children.Clear();
            DataControlHelper.PopulateDropListGrid(scrollGrid, comboBoxBoss.SelectedValue.ToString());
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            List<KillDrop> dropList = new List<KillDrop>();
            dropList = DataControlHelper.BuildDropsList(((StackPanel)scrollGrid.Children[0]).Children);
            if (DataControlHelper.LogKillAndDrops(comboBoxBoss.SelectedValue.ToString(), dropList))
            {
                Console.WriteLine("did it");
                DataControlHelper.ClearDropListGrid((StackPanel)scrollGrid.Children[0]);
            }
            else
                Console.WriteLine("didnt it");
        }
    }
}
