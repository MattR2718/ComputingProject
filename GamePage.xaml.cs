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
using System.IO;
using System.Security.RightsManagement;

namespace ComputingProject
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage()
        {
            InitializeComponent();
        }
        public static class GlobalGame
        {
            public static string[] SongsandArtists = File.ReadAllLines("SongAndArtists.txt");
            public const int SongStartI = 5;
            public static int SongEnd;
            public static string Song;
            public static string SongClue;
            public const int ArtistStartI = 46;
            public static int ArtistEnd;
            public static string Artist;
            public static Random rnd = new Random();
            public static int x = rnd.Next(100);
            public static string spaces;
            public static int score = 0;
            public static bool retry = false;
        }
        public static void newquestion()
        {
            GlobalGame.Artist = "";
            for (int i = GlobalGame.ArtistStartI; i != GlobalGame.SongsandArtists[GlobalGame.x].Length; i++)
            {
                GlobalGame.Artist = GlobalGame.Artist + GlobalGame.SongsandArtists[GlobalGame.x][i];
            }
            GlobalGame.Song = "";
            GlobalGame.spaces = "";
            for (int j = GlobalGame.SongStartI; GlobalGame.spaces != "  "; j++)
            {
                GlobalGame.Song = GlobalGame.Song + GlobalGame.SongsandArtists[GlobalGame.x][j];
                GlobalGame.spaces = Convert.ToString(GlobalGame.SongsandArtists[GlobalGame.x][j + 1]) + Convert.ToString(GlobalGame.SongsandArtists[GlobalGame.x][j + 2]);
            }
        }
        public static void createclue()
        {
            GlobalGame.SongClue = "";
            bool bracket = false;
            for (int k = 0; k != GlobalGame.Song.Length; k++)
            {
                if (k == 0 || GlobalGame.Song[k-1] == 32 || GlobalGame.Song[k-1] == 40)
                {
                    if (GlobalGame.Song[k] == 40)
                    {
                        bracket = true;
                    }
                    GlobalGame.SongClue = GlobalGame.SongClue + GlobalGame.Song[k] + " ";
                }
            }
            if (bracket)
            {
                GlobalGame.SongClue = GlobalGame.SongClue + " " + ")";
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Start Button
            GuessCounter1.Text = "Guesses Left: 2";
            GlobalGame.score = 0;
            newquestion();
            createclue();
            ArtistDisplay.Text = "Artist: " + GlobalGame.Artist;
            SongClue.Text = "Song Clue: " + GlobalGame.SongClue;
            //SongsTestDisplay.Text = GlobalGame.SongsandArtists[GlobalGame.x];
            GlobalGame.retry = false;
            //GlobalGame.x = GlobalGame.rnd.Next(100);
        }
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page1());
            MessageBox.Show("Game Over \n Final Score: " + GlobalGame.score);
            for (int y = 0; y < Login.GlobalStuff.names.Length; y++)
            {
                if (Login.GlobalStuff.names[y] == Login.GlobalStuff.user)
                {
                    if (Convert.ToInt32(Leaderboard.GlobalLeaderboard.LeaderboardFile[y]) < GamePage.GlobalGame.score)
                    {
                        Leaderboard.GlobalLeaderboard.LeaderboardFile[y] = Convert.ToString(GamePage.GlobalGame.score);
                        File.WriteAllLines("Leaderboard.txt", Leaderboard.GlobalLeaderboard.LeaderboardFile);
                    }
                }
            }
        }

        private void Score_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GuessCounter1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ArtistDisplay_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SongClue_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UserGuess_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SubmitButt_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalGame.retry == false)
            {
                if (UserGuess.Text == GlobalGame.Song)
                {
                    GlobalGame.score = GlobalGame.score + 3;
                    MessageBox.Show("Correct...+3 points");
                    Score.Text = "Score: " + GlobalGame.score;
                    GlobalGame.x = GlobalGame.rnd.Next(100);
                    newquestion();
                    createclue();
                    ArtistDisplay.Text = "Artist: " + GlobalGame.Artist;
                    SongClue.Text = "Song Clue: " + GlobalGame.SongClue;
                    UserGuess.Text = "";
                    //SongsTestDisplay.Text = GlobalGame.SongsandArtists[GlobalGame.x];
                }
                else
                {
                    GlobalGame.retry = true;
                    MessageBox.Show("Incorrect...One attempt left");
                    GuessCounter1.Text = "Guesses Left: 1";
                    UserGuess.Text = "";
                }
                //GlobalGame.x = GlobalGame.rnd.Next(100);
            }
            else if (GlobalGame.retry == true)
            {
                if (UserGuess.Text == GlobalGame.Song)
                {
                    GlobalGame.score = GlobalGame.score + 1;
                    MessageBox.Show("Correct...+1 point");
                    Score.Text = "Score: " + GlobalGame.score;
                    GlobalGame.x = GlobalGame.rnd.Next(100);
                    newquestion();
                    createclue();
                    ArtistDisplay.Text = "Artist: " + GlobalGame.Artist;
                    SongClue.Text = "Song Clue: " + GlobalGame.SongClue;
                    UserGuess.Text = "";
                    //SongsTestDisplay.Text = GlobalGame.SongsandArtists[GlobalGame.x];
                    GlobalGame.retry = false;
                    GuessCounter1.Text = "Guesses Left: 2";
                }
                else
                {
                    this.NavigationService.Navigate(new Page1());
                    MessageBox.Show("Game Over \n Final Score: " + GlobalGame.score);
                    for (int y = 0; y < Login.GlobalStuff.names.Length; y++)
                    {
                        if (Login.GlobalStuff.names[y] == Login.GlobalStuff.user)
                        {
                            if (Convert.ToInt32(Leaderboard.GlobalLeaderboard.LeaderboardFile[y]) < GamePage.GlobalGame.score)
                            {
                                Leaderboard.GlobalLeaderboard.LeaderboardFile[y] = Convert.ToString(GamePage.GlobalGame.score);
                                File.WriteAllLines("Leaderboard.txt", Leaderboard.GlobalLeaderboard.LeaderboardFile);
                            }
                        }
                    }
                }
            }
        }
        private void SongsTestDisplay_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
