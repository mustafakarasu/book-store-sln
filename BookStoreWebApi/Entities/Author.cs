using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace BookStoreWebApi.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Book> Books { get; set; }
    }
}
