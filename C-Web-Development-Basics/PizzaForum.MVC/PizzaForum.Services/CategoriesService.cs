namespace PizzaForum.Services
{
    using System.Collections.Generic;
    using Models.ViewModels;
    using System.Linq;
    using Data.Models;
    using Models.BindingModels;
    using System;
    using System.Globalization;

    public class CategoriesService : BaseService
    {
        public IEnumerable<CategoryViewModel> GetAdminCategories()
        {
            var categories = Context.Categories.ToList();
            var categoriesVMs = new HashSet<CategoryViewModel>();
            foreach (var category in categories)
            {
                CategoryViewModel cvm = new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                };
                categoriesVMs.Add(cvm);
            }
            return categoriesVMs;
        }

        public void AddNewCategory(EditCategoryBindingModel ncbm)
        {
            Category category = new Category
            {
                Name = ncbm.Name
            };
            Context.Categories.Add(category);
            Context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var categoryToRemove = Context.Categories.Find(id);
            Context.Categories.Remove(categoryToRemove);
            Context.SaveChanges();
        }

        public CategoryViewModel ShowCurrentCategoryName(int id)
        {
            Category currentCategory = Context.Categories.Find(id);
            CategoryViewModel cvm = new CategoryViewModel
            {
                Name = currentCategory.Name,
                Id = currentCategory.Id
            };
            return cvm;
        }

        public void EditCategoryName(EditCategoryBindingModel ecbm)
        {
            Category categoryToChange = Context.Categories.Find(ecbm.Id);
            categoryToChange.Name = ecbm.Name;
            Context.SaveChanges();
        }

        public IEnumerable<TopicViewModel> ShowCategoryTopics(string categoryName)
        {
            var topicVMs = new HashSet<TopicViewModel>();
            Category desiredCategory = Context.Categories.FirstOrDefault(c => c.Name == categoryName);

            foreach (var topic in desiredCategory.Topics)
            {
                TopicViewModel topicEntity = new TopicViewModel
                {
                    AuthorId = topic.Author.Id,
                    AuthorName = topic.Author.Username,
                    CategoryName = desiredCategory.Name,
                    Date = GetDateString(topic.PublishDate),
                    RepliesCount = topic.Replies.Count,
                    TopicId = topic.Id,
                    TopicTitle = topic.Title
                };
                topicVMs.Add(topicEntity);
            }
            return topicVMs;
        }

        private string GetDateString(DateTime? publishDate)
        {
            return publishDate.Value.ToString("d MMM yyyy", CultureInfo.InvariantCulture);
        }
    }
}