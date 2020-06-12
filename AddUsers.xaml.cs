using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Page
    {
        public AddUsers()
        {
            InitializeComponent();
        }
        public static class Glob
        {
            public static string nuser = "Usernames.txt";
            public static string nassword = "Passwords.txt";
            public static string[] dupe = File.ReadAllLines("Usernames.txt");
            public static bool dupename = false;
        }
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Login());
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Glob.dupename = false;
            foreach (string name in Glob.dupe)
            {
                if (name == newname.Text)
                {
                    Glob.dupename = true;
                }
            }
            if (Glob.dupename)
            {
                MessageBox.Show("Username Taken");
            }
            else
            {
                string newuser = "\n" + newname.Text;
                string newpassword = "\n" + newpass.Text;
                //File.AppendAllText(Login.GlobalStuff.names, newuser);
                using (StreamWriter sw2 = File.AppendText("Usernames.txt"))
                {
                    sw2.WriteLine(newuser);
                }
                Login.GlobalStuff.names = File.ReadAllLines("Usernames.txt");
                //File.AppendAllText(Glob.nassword, newpassword);
                using (StreamWriter sw3 = File.AppendText("Passwords.txt"))
                {
                    sw3.WriteLine(newpassword);
                }
                Login.GlobalStuff.pass = File.ReadAllLines("Passwords.txt");
                using (StreamWriter sw = File.AppendText("Leaderboard.txt"))
                {
                    sw.WriteLine(Convert.ToString(0));
                }
                Leaderboard.GlobalLeaderboard.LeaderboardFile = File.ReadAllLines("Leaderboard.txt");
                MessageBox.Show("User Added");
                Login.GlobalStuff.user = newname.Text;
                this.NavigationService.Navigate(new Page1());
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Username
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            //Password
        }
    }
}
