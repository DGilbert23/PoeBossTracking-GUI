using PoeBossTracking.Classes.dto;
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

        public static async void PopulateItemsComboBox(ComboBox comboBox, string bossName)
        {
            List<Item> itemList = await endPointManager.GetAllDropsByBossName(bossName);

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

        public static bool LogNewKill(string bossId, string userName, DateTime selectedDate)
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
        }

        public static bool LogNewDrop(string loggedKillId, string itemId, string itemValue)
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
        }
    }
}
