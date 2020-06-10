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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        public static class GlobalStuff
        {
            public static string[] names = new string["Usernames.txt".Length];
            public static string[] pass = new string["Passwords.txt".Length];
            public static int x = 0;
            public static string username;
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
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string password = box4.Password.ToString();
            box3.Text = password;
            if (reset.Text == "true")
            {
                GlobalStuff.x = 0;
                foreach (string linetxt in File.ReadLines("Usernames.txt"))
                {
                    GlobalStuff.names[GlobalStuff.x] = linetxt;
                    GlobalStuff.x++;
                }
                GlobalStuff.x = 0;
                
                foreach (string linepass in File.ReadLines("Passwords.txt"))
                {
                    GlobalStuff.pass[GlobalStuff.x] = linepass;
                    GlobalStuff.x++;
                }
                reset.Text = "false";
            }
            GlobalStuff.x = 0;
            string user = box2.Text;
            while (GlobalStuff.x != ((GlobalStuff.pass.Length) - 1))
            {
                if (GlobalStuff.pass[GlobalStuff.x] == password)
                {
                    if (GlobalStuff.names[GlobalStuff.x] == user)
                    {
                        this.NavigationService.Navigate(new Page1());
                        GlobalStuff.x = ((GlobalStuff.pass.Length) - 1);
                    }
                    else
                    {
                        box.Text = "Enter Username...";
                        GlobalStuff.x++;
                    }
                }
                else
                {
                    box.Text = "Enter Username...";
                    GlobalStuff.x++;
                }
            }
        }

        private void box_TextChanged(object sender, TextChangedEventArgs e)
        {
            GlobalStuff.username = box.Text;
            box2.Text = GlobalStuff.username;
        }

        private void box2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void box3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void reset_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddUsers());
        }
    }
}
