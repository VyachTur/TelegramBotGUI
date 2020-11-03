using System.Windows;
using System.Windows.Input;


namespace TelegramBotGUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        TgBot_Client client;

        public MainWindow() {
            InitializeComponent();

            client = new TgBot_Client(this);

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

        // Обработчик закрытия главного окна программы
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.jsonSerializedMessages();
        }

        // Обработчик загрузки главного окна программы
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var answer = MessageBox.Show("Загрузить историю сообщений?", "Загрузка", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (answer == MessageBoxResult.Yes)
            {
                client.jsonDeserializedMessages();
            }
        }
    }
}
