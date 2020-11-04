using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TelegramBotGUI
{
    /// <summary>
    /// Информация о чате с пользователем
    /// </summary>
    public class ChatUser : INotifyPropertyChanged, IEquatable<ChatUser>
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ChatUser() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="chatId">Идентификатор чата с пользователем</param>
        /// <param name="userName">Имя пользователя</param>
        public ChatUser(long chatId, string userName)
        {
            Id = chatId;
            UserName = userName;
            Msgs = new ObservableCollection<Messages>();
        }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { 
            get
            {
                return userName;
            }

            set
            {
                userName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserName)));
            }
        }

        /// <summary>
        /// Идентификатор чата пользователя
        /// </summary>
        public long Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;   // оповещение об изменении элемента

        /// <summary>
        /// Сравнение id двух пользователей
        /// </summary>
        /// <param name="other">Id чата "внешнего" пользователя</param>
        /// <returns>Равны ли АйДишники</returns>
        public bool Equals(ChatUser other) => other.Id == this.id;

        /// <summary>
        /// Сообщения данного пользователя
        /// </summary>
        public ObservableCollection<Messages> Msgs { get; set; }

        /// <summary>
        /// Добавление сообщения в коллекцию Msgs
        /// </summary>
        /// <param name="text">Текст добавляемого сообщения</param>
        public void AddMessage(Messages text) => Msgs.Add(text);

        private long id;            // идентификатор чата пользователя
        private string userName;    // имя пользователя
    }
}
