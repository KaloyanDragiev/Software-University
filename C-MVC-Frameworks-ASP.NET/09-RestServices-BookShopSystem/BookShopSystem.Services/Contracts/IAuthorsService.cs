﻿using System.Collections.Generic;
using BookShopSystem.Models.BindingModels.Authors;
using BookShopSystem.Models.ViewModels.Authors;

namespace BookShopSystem.Services.Contracts
{
    public interface IAuthorsService
    {
        AuthorDetailsViewModel GetAuthorDetails(int id);
        bool ContainsAuthor(int id);
        void AddNewAuthor   (AddAuthorBindingModel aabm);
        bool ContainsBook(int id);
        IEnumerable<AuthorBooksViewModel> GetAuthorBookDetails(int id);
    }
}