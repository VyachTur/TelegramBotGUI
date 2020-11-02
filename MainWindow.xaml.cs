using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Newtonsoft.Json.Linq;
using Google.Cloud.Dialogflow.V2;
using Newtonsoft.Json;
using System.IO;


namespace TelegramBotGUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        TgBot_Client client;

        public MainWindow() {
            InitializeComponent();

            client = new TgBot_Client(this);


            //Messages msg = new Messages { MessageText = "Пробное сообщение!", MessageTime = DateTime.Now.ToString() };

            //listMessages.Items.Add(msg);

            //ChatUser usr = new ChatUser(1, "Петр");

            //listUsers.Items.Add(usr);

        }

        // Действие по нажатию на кнопку btnSendMessage
        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            client.sendMessage(txtMessage.Text);
        }

        // Действие по нажатию на Enter в поле txtMessage
        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) client.sendMessage(txtMessage.Text);
        }
    }
}
