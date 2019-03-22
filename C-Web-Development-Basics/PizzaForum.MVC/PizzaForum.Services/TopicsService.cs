namespace PizzaForum.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.ViewModels;
    using Data.Models;
    using Models.BindingModels;
    using System;
    using System.Globalization;

    public class TopicsService : BaseService
    {
        public IEnumerable<NewTopicViewModel> GetAllTopicCategories()
        {
            var newTopicVMs = new HashSet<NewTopicViewModel>();
            var allCategories = Context.Categories.ToList();
            foreach (var category in allCategories)
            {
                var topicVM = new NewTopicViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                };
                newTopicVMs.Add(topicVM);
            }
            return newTopicVMs;
        }

        public bool CreateNewTopic(TopicBindingModel tbm, User user)
        {
            if (!ValidateTopic(tbm))
            {
                return false;
            }

            Topic topic = new Topic
            {
                Author = user,
                Category = Context.Categories.Find(tbm.CategoryId),
                Content = tbm.Content,
                PublishDate = DateTime.Now,
                Title = tbm.Title
            };
            Context.Topics.Add(topic);
            Context.SaveChanges();
            return true;
        }

        private bool ValidateTopic(TopicBindingModel tbm)
        {
            if (tbm.Title.Length > 30)
            {
                return false;
            }
            if (tbm.Content.Length > 5000)
            {
                return false;
            }
            return true;
        }

        public TopicDetailsViewModel GetTopicDetails(int id)
        {
            Topic desiredTopic = Context.Topics.Find(id);
            TopicDetailsViewModel tdvm = new TopicDetailsViewModel
            {
                AuthorId = desiredTopic.Author.Id,
                AuthorName = desiredTopic.Author.Username,
                Content = desiredTopic.Content,
                Date = GetDateString(desiredTopic.PublishDate),
                TopicId = desiredTopic.Id,
                TopicTitle = desiredTopic.Title,
                Replies = desiredTopic.Replies.Select(r => new ReplyViewModel
                {
                    AuthorId = r.Author.Id,
                    AuthorName = r.Author.Username,
                    Content = r.Content,
                    Date = GetDateString(r.PublishDate),
                    ImageUrl = r.ImageUrl
                })
            };
            return tdvm;
        }

        private string GetDateString(DateTime? publishDate)
        {
            return publishDate.Value.ToString("d MMM yyyy", CultureInfo.InvariantCulture);
        }

        public void AddReplyToTopic(ReplyBindingModel rbm, User currentUser)
        {
            Topic topic = Context.Topics.Find(rbm.TopicId);

            Reply reply = new Reply
            {
                Author = currentUser,
                Content = rbm.Content,
                ImageUrl = rbm.ImageUrl,
                PublishDate = DateTime.Now,
            };

            topic.Replies.Add(reply);
            Context.SaveChanges();
        }
    }
}