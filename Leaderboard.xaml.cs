using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
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

namespace ComputingProject
{
    /// <summary>
    /// Interaction logic for Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : Page
    {
        public Leaderboard()
        {
            InitializeComponent();
            
            for (int d = 0; d < GlobalLeaderboard.LeaderboardFile.Length; d++)
            {
                GlobalLeaderboard.Leaderboardsort[d] = Convert.ToInt32(GlobalLeaderboard.LeaderboardFile[d]);
            }
            Array.Sort(GlobalLeaderboard.Leaderboardsort);
            for (int t = 1; t < 6; t++)
            {
                GlobalLeaderboard.scorearray[t-1] = GlobalLeaderboard.Leaderboardsort[(GlobalLeaderboard.Leaderboardsort.Length) - t];
            }
            for (int f = 0; f != 5; f++)
            {
                GlobalLeaderboard.namedupestopper[f] = 0;
            }

            int h = 0;
            int l = 0;
            do
            {
                l = 0;
                do
                {
                    if (GlobalLeaderboard.LeaderboardFile[h] == Convert.ToString(GlobalLeaderboard.scorearray[l]) & GlobalLeaderboard.namedupestopper[l] == 0)
                    {
                        GlobalLeaderboard.namearray[l] = Login.GlobalStuff.names[h];
                        GlobalLeaderboard.namedupestopper[l] = 1;
                        l = 5;
                    }
                    l++;
                }
                while (l < 5);
                h++;
            }
            while (h < GlobalLeaderboard.Leaderboardsort.Length);

            first.Text = "First: " + GlobalLeaderboard.namearray[0] + " - " + GlobalLeaderboard.scorearray[0];
            second.Text = "Second: " + GlobalLeaderboard.namearray[1] + " - " + GlobalLeaderboard.scorearray[1];
            third.Text = "Third: " + GlobalLeaderboard.namearray[2] + " - " + GlobalLeaderboard.scorearray[2];
            fourth.Text = "Fourth: " + GlobalLeaderboard.namearray[3] + " - " + GlobalLeaderboard.scorearray[3];
            fifth.Text = "Fifth: " + GlobalLeaderboard.namearray[4] + " - " + GlobalLeaderboard.scorearray[4];
        }
        public static class GlobalLeaderboard
        {
            public static string[] LeaderboardFile = File.ReadAllLines("Leaderboard.txt");
            public static int[] Leaderboardsort = new int[GlobalLeaderboard.LeaderboardFile.Length];
            public static int c;
            public static int o = 0;
            public static int[] scorearray = new int[5];
            public static int[] namedupestopper = new int[5];
            public static string[] namearray = new string[5];

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page1());
        }

        private void first_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void second_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void third_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void fourth_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void fifth_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            for (int d = 0; d < GlobalLeaderboard.LeaderboardFile.Length; d++)
            {
                GlobalLeaderboard.Leaderboardsort[d] = Convert.ToInt32(GlobalLeaderboard.LeaderboardFile[d]);
            }
            Array.Sort(GlobalLeaderboard.Leaderboardsort);
            for (int t = 1; t < 6; t++)
            {
                GlobalLeaderboard.scorearray[t - 1] = GlobalLeaderboard.Leaderboardsort[(GlobalLeaderboard.Leaderboardsort.Length) - t];
            }
            for (int f = 0; f != 5; f++)
            {
                GlobalLeaderboard.namedupestopper[f] = 0;
            }

            int h = 0;
            int l = 0;
            do
            {
                l = 0;
                do
                {
                    if (GlobalLeaderboard.LeaderboardFile[h] == Convert.ToString(GlobalLeaderboard.scorearray[l]) & GlobalLeaderboard.namedupestopper[l] == 0)
                    {
                        GlobalLeaderboard.namearray[l] = Login.GlobalStuff.names[h];
                        GlobalLeaderboard.namedupestopper[l] = 1;
                        l = 5;
                    }
                    l++;
                }
                while (l < 5);
                h++;
            }
            while (h < GlobalLeaderboard.Leaderboardsort.Length);

            first.Text = "First: " + GlobalLeaderboard.namearray[0] + " - " + GlobalLeaderboard.scorearray[0];
            second.Text = "Second: " + GlobalLeaderboard.namearray[1] + " - " + GlobalLeaderboard.scorearray[1];
            third.Text = "Third: " + GlobalLeaderboard.namearray[2] + " - " + GlobalLeaderboard.scorearray[2];
            fourth.Text = "Fourth: " + GlobalLeaderboard.namearray[3] + " - " + GlobalLeaderboard.scorearray[3];
            fifth.Text = "Fifth: " + GlobalLeaderboard.namearray[4] + " - " + GlobalLeaderboard.scorearray[4];
        }
    }
}
