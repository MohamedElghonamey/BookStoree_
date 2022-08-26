using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repsotrey
{
    public class AuthorRepostory : IBookStoreRepostery<Author>
    {
        IList<Author> authors;
        public AuthorRepostory()
        {
            authors = new List<Author>()
            {
                new Author{ID=1, FullName = "Mohamed Mostafa "},
                  new Author{ID=2, FullName = "Hesham Ahmed "},
                    new Author{ID=3, FullName = "Mahmoud Ahmed "}
            };
        }
        public void Add(Author entity)
        {
            authors.Add(entity);    
        }

        public void Delete(int ID)
        {
            var author = Find(ID);
            authors.Remove(author); 
        }

        public Author Find(int ID)
        {
            var author = authors.SingleOrDefault(a => a.ID == ID);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public void Update(int id, Author newAuthor)
        {
           var author = Find(id);
            author.FullName= newAuthor.FullName;    
        }
    }
}
