using BookStore.Models;
using BookStore.Models.Repsotrey;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        public IBookStoreRepostery<Author> AuthorRepostory { get; }

        public AuthorController(IBookStoreRepostery<Author> AuthorRepostory)
        {
            this.AuthorRepostory = AuthorRepostory;
        }
        // GET: AuthorController
        public ActionResult Index()
        {
            var Authors = AuthorRepostory.List();
            return View(Authors);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            var author = AuthorRepostory.Find(id);
            return View(author);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            try
            {
                AuthorRepostory.Add(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            var author = AuthorRepostory.Find(id);
            return View(author);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author author)
        {
            try
            {
                AuthorRepostory.Update(id, author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            var author = AuthorRepostory.Find(id);
            
            return View(author);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Author author)
        {
            try
            {
                AuthorRepostory.Delete(id); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
