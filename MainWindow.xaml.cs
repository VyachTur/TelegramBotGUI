﻿using System;
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


            //Border bord = new Border {
            //    BorderBrush = Brushes.Black,
            //    BorderThickness = new Thickness(1),
            //    CornerRadius = new CornerRadius(10),
            //    Margin = new Thickness(5),
            //    Background = Brushes.LightGray
            //};

            //TextBlock txtBl = new TextBlock() {
            //    Text = "Сообщениецццццццццццццццццццццццццццццццццццццццццццццццццццццццццц",
            //    MaxWidth = 400,
            //    TextWrapping = TextWrapping.Wrap
            //};

            //bord.Child = txtBl;

            Messages msg = new Messages { MessageText = "Пробное сообщениецццццwwwwww  wwwwwwwwwwwwwццццццццццц", MessageTime = DateTime.Now.ToShortTimeString() };


            listMessages.Items.Add(msg);

        }
    }
}
