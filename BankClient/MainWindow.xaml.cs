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

namespace WpfClient
{
    public partial class MainWindow : Window
    {
        private DataServerInterface foob;
        public MainWindow()
        {
            InitializeComponent();



            ChannelFactory<BankServer.DataServerInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();
            //Set the URL and create the connection!

            string URL = "net.tcp://localhost:8100/DataService";

            foobFactory = new ChannelFactory<DataServerInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();
            //Also, tell me how many entries are in the DB.
            TotalItemsBox.Text = foob.GetNumEntries().ToString();

        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            string firstName = "", lastName = "";
            int bal = 0;
            uint acct = 0, pin = 0;

            index = int.Parse(Index.Text);

            foob.GetValuesForEntry(index, out acct, out pin, out bal, out firstName, out lastName);

            FirstNameBox.Text = firstName;
            LastNameBox.Text = lastName;
            BalanceBox.Text = bal.ToString("C");
            AcctNoBox.Text = acct.ToString();
            PinBox.Text = pin.ToString("D4");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
