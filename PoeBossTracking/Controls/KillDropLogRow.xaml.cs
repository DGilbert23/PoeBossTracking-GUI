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

namespace PoeBossTracking.Controls
{
    /// <summary>
    /// Interaction logic for KillDropLogRow.xaml
    /// </summary>
    public partial class KillDropLogRow : UserControl
    {
        private string itemId;
        public string ItemId { get { return itemId; } set { itemId = value; } }

        public KillDropLogRow()
        {
            InitializeComponent();
        }
    }
}
