﻿namespace SimpleMVC.App.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Sender { get; set; }

        public string Subject { get; set; }

        public string FullMessage { get; set; }
    }
}