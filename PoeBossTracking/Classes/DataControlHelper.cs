using PoeBossTracking.Classes.dto;
using PoeBossTracking.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Windows.Controls;

namespace PoeBossTracking.Classes
{
    internal static class DataControlHelper
    {
        private static EndPointManager endPointManager = new EndPointManager();

        public static async void PopulateBossComboBox(ComboBox comboBox)
        {
            List<Boss> bossList = await endPointManager.GetAllBossesForCurrentLeague();

            comboBox.ItemsSource = bossList;
            comboBox.DisplayMemberPath = "bossName";
            comboBox.SelectedValuePath = "bossId";
        }

        public static async void PopulateItemsComboBox(ComboBox comboBox, string bossId)
        {
            List<Item> itemList = await endPointManager.GetAllDropsByBossId(bossId);

            comboBox.ItemsSource = itemList;
            comboBox.DisplayMemberPath = "itemName";
            comboBox.SelectedValuePath = "itemId";
        }

        public static async void PopulateKillsComboBox(ComboBox comboBox, string bossId, string userName)
        {
            List<LoggedKill> killList = await endPointManager.GetAllKillsByBossUser(bossId, userName);

            comboBox.ItemsSource = killList;
            comboBox.DisplayMemberPath = "killDate";
            comboBox.SelectedValuePath = "loggedKillId";
        }

        public static async void PopulateDropListGrid(Grid grid, string bossId)
        {
            List<Item> itemList = await endPointManager.GetAllDropsByBossId(bossId);

            int counter = 0;
            StackPanel stackPanel = new StackPanel { Orientation = Orientation.Vertical };

            foreach (var item in itemList)
            {
                KillDropLogRow newRow = new KillDropLogRow();
                newRow.ItemId = item.itemId;
                newRow.Name = "killDropLogRow" + counter;
                newRow.labelItemName.Content = item.itemName;

                counter++;

                stackPanel.Children.Add(newRow);
            }

            grid.Children.Add(stackPanel);
        }

        public static void ClearDropListGrid(StackPanel stackPanel)
        {
            foreach(KillDropLogRow item in stackPanel.Children)
            {
                item.intUpDownItemQuantity.Value = null;
                item.intUpDownItemValue.Value = null;
            }
        }

        /*public static bool LogNewKill(string bossId, string userName, DateTime selectedDate)
        {
            try
            {
                endPointManager.LogNewKillAsync(bossId, userName, selectedDate);
                return true;
            }
            catch (HttpRequestException e)
            {
                return false;
            }
        }*/

        /*public static bool LogNewDrop(string loggedKillId, string itemId, string itemValue)
        {
            try
            {
                endPointManager.LogNewDropAsync(loggedKillId, itemId, itemValue);
                return true;
            }
            catch (HttpRequestException e)
            {
                return false;
            }
        }*/

        public static List<KillDrop> BuildDropsList(UIElementCollection uiCollection)
        {
            List<KillDrop> dropList = new List<KillDrop>();

            foreach(KillDropLogRow item in uiCollection)
            {
                if (item.intUpDownItemQuantity.Value > 0)
                {
                    KillDrop drop = new KillDrop(item.ItemId, item.intUpDownItemValue.Value.ToString(), (int)item.intUpDownItemQuantity.Value);
                    dropList.Add(drop);
                }
            }

            return dropList;
        }

        public static bool LogKillAndDrops(string bossId, List<KillDrop> drops)
        {
            try
            { 
                endPointManager.LogKillAndDrops(bossId, GlobalVariables.Username, drops);
                return true;
            }
            catch (HttpRequestException e)
            {
                return false;
            }
        }
    }
}
