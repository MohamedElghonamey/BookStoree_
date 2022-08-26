using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repsotrey
{
    public class BookRepostory : IBookStoreRepostery<Book>
    {
        List<Book> books;

        public BookRepostory()
        {
            books = new List<Book>()
              {
                  new Book
                  {
                      ID =1,
                      Title="C#",
                      Discription="Programming Lang",
                        Author=new Author()
                  },
                   new Book
                  {
                      ID =2,
                      Title="C++",
                      Discription="Programming Lang1",
                      Author=new Author()
                  },
                    new Book
                  {
                      ID =3,
                      Title="Java",
                      Discription="Programming ",
                        Author=new Author()
                  }
              };
            
        }
        public void Add(Book entity)
        {
            books.Add(entity);    
        }

        public void Delete(int ID)
        {
     var book=books.SingleOrDefault(b=>b.ID==ID);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var  book = books.SingleOrDefault(b => b.ID == id );
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public void Update(int id, Book NewBooks)
        {
            var book =Find(id);
            book.Author = NewBooks.Author;
            book.Title=NewBooks.Title;  
            book.Discription=NewBooks.Discription;  

        }

        
    }
}
