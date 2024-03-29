﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using COIS_3850H_Project.Core;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Application = System.Windows.Application;
using Label = System.Windows.Controls.Label;
using Point = System.Windows.Point;
using SolidColorBrush = System.Windows.Media.SolidColorBrush;
using System.Drawing;
using System.Windows.Controls.Primitives;

namespace COIS_3850H_Project.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        
        public HomePage()
        {
            InitializeComponent();

        }

        public void Form_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left)
            {
                return;
            }
            downPoint = new Point(Mouse.GetPosition(Application.Current.MainWindow).X, Mouse.GetPosition(Application.Current.MainWindow).Y);
        }

        public void Form_MouseMove(object sender, MouseEventArgs e)
        {

            if (downPoint == new Point(0, 0))
            {
                return;
            }
            var location = new Point(Left + Mouse.GetPosition(Application.Current.MainWindow).X - downPoint.X, Top + Mouse.GetPosition(Application.Current.MainWindow).Y - downPoint.Y);
            Left = location.X;
            Top = location.Y;
        }

        public void Form_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left)
            {
                return;
            }
            downPoint = new Point(0, 0);
        }

        public Point downPoint = new Point(0, 0);


        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
        private void minButton_Click(object sender, RoutedEventArgs e)
        {
            HomePage home = new HomePage();
            home.WindowState= WindowState.Minimized;
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            //values from card info text boxes and combo box
            string cardName = CardName.Text;
            string cardColour = colorCombo.SelectedValue.ToString();
            int cardLimit = Convert.ToInt32(textboxLimit.Text);

            //new Card object
            Card testCard = new Card(cardName, cardColour, cardLimit);

            //Converting Card Digits into one String to display to User:
            //first half of Card Number to String: "7 55555"
            string a = string.Concat(testCard.CreditCardNum[0], " ", testCard.CreditCardNum[1], testCard.CreditCardNum[2], testCard.CreditCardNum[3], testCard.CreditCardNum[4], testCard.CreditCardNum[5], " ");

            //second half of Card Number to String
            //start at first account number digit, add each following account number digit to string
            string b = Convert.ToString(testCard.CreditCardNum[6]);

            //for (int i = 7; i < testCard.CreditCardNum.Length - 1; i++)
            for (int i = 7; i < testCard.Random69 + 7; i++)
            {
                b = b + Convert.ToString(testCard.CreditCardNum[i]);
            }

            //check dig
            string c = string.Concat(" ", testCard.CreditCardNum[6 + testCard.Random69]);
            //string c = string.Concat(" ", testCard.CreditCardNum[testCard.CreditCardNum.Length-1]);

            //combine the above strings / parts of card number into one String "ccNumber"
            string ccNumber = a + b + c;
            //Console.WriteLine(ccNumber);
            //Console.ReadLine();

            // Adds a radio button with the credit card numbers to the stack panel.
            System.Windows.Controls.RadioButton createdCard = new System.Windows.Controls.RadioButton();
            createdCard.Content = ccNumber;
            CreatedCards.Children.Add(createdCard);

            //MessageBox.Show(string.Format("Your Card Number is: \r\n{0}", ccNumber));
        }

        private void myCardsButton_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void paymentButton_Click(object sender, RoutedEventArgs e)
        {
            Payment paymentPage = new Payment();
            paymentPage.Show();
            this.Close();
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Close();
        }

        private void listView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void activityButton_Click(object sender, RoutedEventArgs e)
        {
            UsageStatisticsPage usageStatisticsPage = new UsageStatisticsPage();
            usageStatisticsPage.Show();
            this.Close();
        }

        private void minButton_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
