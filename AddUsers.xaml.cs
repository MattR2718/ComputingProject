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
            string newuser = "\n" + newname.Text;
            string newpassword = "\n" + newpass.Text;
            File.AppendAllText(Glob.nuser, newuser);
            File.AppendAllText(Glob.nassword, newpassword);
            MessageBox.Show("User Added");
            this.NavigationService.Navigate(new Page1());
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
