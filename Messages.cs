using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotGUI
{

    /// <summary>
    /// Сообщение от пользователя
    /// </summary>
    public class Messages
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Время отправки
        /// </summary>
        public string MessageTime {
            get
            {
                return messageTime.ToShortTimeString().ToString();
            }

            set
            {
                DateTime.TryParse(value, out DateTime dTime);
                messageTime = dTime;
            }
        }

        private DateTime messageTime;   // время отправки сообщения
    }
}
