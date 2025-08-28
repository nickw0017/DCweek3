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
using System.ServiceModel;
using BankServer;
using SharedContracts;

namespace WpfClient
{
    public partial class MainWindow : Window
    {
        private DataServerInterface foob;
        public MainWindow()
        {
            InitializeComponent();

            var tcp = new NetTcpBinding
            {
                Security = { Mode = SecurityMode.None },
            };

            string URL = "net.tcp://localhost:8100/DataService";

            var foobFactory = new ChannelFactory<DataServerInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();

            try
            {
                TotalItemsBox.Text = foob.GetNumEntries().ToString();
            }
            catch (FaultException<ServiceFault> fx)
            {
                MessageBox.Show($"{fx.Detail.Code}: {fx.Detail.Message}", "Server Fault");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Client Error");
            }


        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Index.Text, out int index))
            {
                MessageBox.Show("Index must be a whole number");
                return;
            }

            try
            {
                string firstName = "", lastName = "";
                int bal = 0;
                uint acct = 0, pin = 0;

                foob.GetValuesForEntry(index, out acct, out pin, out bal, out firstName, out lastName);

                FirstNameBox.Text = firstName;
                LastNameBox.Text = lastName;
                BalanceBox.Text = bal.ToString("C");
                AcctNoBox.Text = acct.ToString();
                PinBox.Text = pin.ToString("D4");
            }
            catch (FaultException<ServiceFault> fx)
            {
                MessageBox.Show($"{fx.Detail.Code}: {fx.Detail.Message}", "Server Fault");
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Cant reach the server, Server may not be running", "Connection error");
            }
            catch (CommunicationException ex)
            {
                MessageBox.Show("Communication Problem: " + ex.Message, "Network Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Client Error");
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
