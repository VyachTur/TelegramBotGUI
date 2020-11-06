using System.Windows;
using System.Windows.Input;


// Программа реализует телеграм-бота и сервисного бота.
// С помощью графического интерфейса сервисного бота можно отправлять сервисные сообщения
// пользователю с которым общается телеграм-бот. Чаты отображаются на панели слева, сообщения
// из чатов на пенели справа. В нижней части формы сервисного бота можно писать сообщения и
// отправлять их в выбраный чат (выбор чата происходит нажатием на нужное имя пользователя
// на панели слева).
// Для запуска телеграм-бота необходимо ввести токен своего телеграм-бота в строковый атрибут pathToken
// конструктора класса реализующего телеграм-бота TgBot_Clietn (см. файл TgBot_Client.cs).
//
// Для корректной работы клиента DialogFlow:
// Впервые открыв проект, необходимо запустить его построение (Build -> BuildSolution).
// Далее, после загрузки необходимых библиотек, мы закрываем Visual Studio и удаляем папку bin из директории проекта.
// После снова открываем проект и нажимаем Start.
// В последствии данных манипуляций проделывать не надо.

namespace TelegramBotGUI {
    /// <summary>
    /// Логика дял взаимодействия с MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        TgBot_Client client;    // клиент телеграм-бота

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainWindow() {
            InitializeComponent();

            client = new TgBot_Client(this);

        }

        /// <summary>
        /// Действие по нажатию на кнопку btnSendMessage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            client.sendMessage(txtMessage.Text);
        }

        /// <summary>
        /// Действие по нажатию на Enter в поле txtMessage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) client.sendMessage(txtMessage.Text);
        }

        /// <summary>
        /// Обработчик закрытия главного окна программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.jsonSerializedMessages();
        }

        /// <summary>
        /// Обработчик загрузки главного окна программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
