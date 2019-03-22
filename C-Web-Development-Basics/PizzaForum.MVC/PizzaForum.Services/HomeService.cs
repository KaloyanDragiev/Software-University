namespace PizzaForum.Services
{
    using System.Collections.Generic;
    using Models.ViewModels;
    using System;
    using System.Linq;
    using System.Globalization;

    public class HomeService : BaseService
    {
        public IEnumerable<TopicViewModel> GetAllTopics()
        {
            ICollection<TopicViewModel> topicVMs = new HashSet<TopicViewModel>();
            var topics = Context.Topics.OrderByDescending(t => t.PublishDate).Take(10);
            foreach (var topic in topics)
            {
                var topicVM = new TopicViewModel
                {
                    AuthorId = topic.Author.Id,
                    AuthorName = topic.Author.Username,
                    CategoryName = topic.Category.Name,
                    Date = GetDateString(topic.PublishDate),
                    RepliesCount = topic.Replies.Count,
                    TopicId = topic.Id,
                    TopicTitle = topic.Title
                };
                topicVMs.Add(topicVM);
            }
            return topicVMs;
        }

        private string GetDateString(DateTime? publishDate)
        {
            return publishDate.Value.ToString("d MMM yyyy", CultureInfo.InvariantCulture);
        }

        public IEnumerable<NormalUserCategoryViewModel> GetCategoryList()
        {
            var categoriesVM = new HashSet<NormalUserCategoryViewModel>();
            var categories = Context.Categories.ToList();

            foreach (var category in categories)
            {
                var categoryVm = new NormalUserCategoryViewModel
                {
                    Name = category.Name
                };
                categoriesVM.Add(categoryVm);
            }
            return categoriesVM;
        }
    }
}