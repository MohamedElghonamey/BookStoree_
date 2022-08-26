using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        public int ID { get; set; }
      
        public string Discription { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
    }
}
