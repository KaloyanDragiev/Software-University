namespace SimpleMVC.App.ServiceLayers
{
    using BindingModels;
    using Data;
    using Models;

    public class AddMessage
    {
        public void SendMessage(MessageBindingModel model)
        {
            using (var context = new SharpStoreContext())
            {
                Message message = new Message
                {
                    FullMessage = model.FullMessage,
                    Sender = model.Sender,
                    Subject = model.Subject
                };
                context.Messages.Add(message);
                context.SaveChanges();
            }
        }
    }
}