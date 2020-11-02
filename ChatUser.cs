using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Requests;

namespace TelegramBotGUI
{
    /// <summary>
    /// Информация о чате с пользователем
    /// </summary>
    public class ChatUser : INotifyPropertyChanged, IEquatable<ChatUser>
    {
        public ChatUser() { }

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

        public event PropertyChangedEventHandler PropertyChanged;   // оповещение об изменении форм отображения инфы

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

        public void AddMessage(Messages text) => Msgs.Add(text);

        private long id;            // идентификатор чата пользователя
        private string userName;    // имя пользователя
    }
}
