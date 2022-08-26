using BookStore.Models;
using BookStore.Models.Repsotrey;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookStoreRepostery<Book> bookRepostery;
        private readonly IBookStoreRepostery<Author> authorRepostory;

        public BookController(IBookStoreRepostery<Book> bookRepostery , 
             IBookStoreRepostery<Author> authorRepostory)
        {
            this.bookRepostery = bookRepostery;
            this.authorRepostory = authorRepostory;
        }
        // GET: BookController
        public ActionResult Index()
        {
            var books = bookRepostery.List();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book= bookRepostery.Find(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var model = new BookAuthorViewModel
        {
                Authors=authorRepostory.List().ToList()
           
           };
            return View(model);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModel model)
        {
            try

            {
                var Author = authorRepostory.Find(model.AuthorId);
                Book book = new Book
                {
                    ID= model.BookId, 
                    Discription= model.Discription,
                    Title= model.Title,
                    Author= Author

                };
                bookRepostery.Add(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookRepostery.Find(id);
            var AuthorId = book.Author == null ? book.Author.ID = 0 : book.Author.ID; 
            var viewModel = new BookAuthorViewModel
            {
                BookId= book.ID,
                Title=book.Title,
                Discription=book.Discription,
                AuthorId= book.Author.ID,
                Authors=authorRepostory.List().ToList()
            };
            return View(viewModel);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookAuthorViewModel viewModel)
        {
            try
            {
                var Authors = authorRepostory.Find(viewModel.AuthorId);
                Book book = new Book
                {
                   
                    Discription = viewModel.Discription,
                    Title = viewModel.Title,
                    Author = Authors

                };
                bookRepostery.Update(viewModel.BookId, book);
                return RedirectToAction(nameof(Edit));

            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var Book = bookRepostery.Find(id);
            
            return View(Book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {       
                bookRepostery.Delete(id);              
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
    }
}
