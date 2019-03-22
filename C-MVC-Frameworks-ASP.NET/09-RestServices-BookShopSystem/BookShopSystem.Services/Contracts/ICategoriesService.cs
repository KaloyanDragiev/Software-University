﻿using BookShopSystem.Models.BindingModels.Categories;
using BookShopSystem.Models.ViewModels.Categories;

namespace BookShopSystem.Services.Contracts
{
    using System.Collections.Generic;

    public interface ICategoriesService
    {
        IEnumerable<AllCategoriesViewModel> GetAllCategories();
        bool ContainsCategory(int id);
        AllCategoriesViewModel GetCategoryInfo(int id);
        bool CategoryNameAlreadyExists(EditCategoryBindingModel ecbm);
        void UpdateCategoryName(int id, EditCategoryBindingModel ecbm);
        void DeleteCategory(int id);
        void AddNewCategory(EditCategoryBindingModel acbm);
    }
}