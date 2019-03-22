﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Models.EntityModels
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
