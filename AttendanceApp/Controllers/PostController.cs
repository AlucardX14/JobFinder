using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AttendanceApp.DAL;
using AttendanceApp.Models;
using PagedList;

namespace AttendanceApp.Controllers
{
    public class PostController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Posts
        public ActionResult Index(string sortOrder)
        {
            var posts = from p in db.Posts
                select p;

            posts = posts.OrderByDescending(p => p.ID);

            IndexPostViewModel indexView = new IndexPostViewModel();
            indexView.Posts = posts.ToList();
            indexView.GlobalParams = db.GlobalParams.Any() ? db.GlobalParams.FirstOrDefault() : new GlobalParams();

            return View(indexView);
        }

        public ViewResult CategoryFilter(int? page, string category)
        {

            var posts = from p in db.Posts
                        where p.Category.Equals(category)
                        select p;

            posts = posts.OrderByDescending(p => p.ID);

            int pageSize = db.GlobalParams.FirstOrDefault().CategoryPagingSize;
            int pageNumber = (page ?? 1);
            return View(posts.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        [Authorize(Roles = "Admin")]
        public ActionResult Management()
        {
            var posts = from p in db.Posts
                        select p;

            posts = posts.OrderByDescending(p => p.ID);

            return View(posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            CreatePostViewModel createView = new CreatePostViewModel();
            createView.CategoryList = new SelectList(db.Categories, "Name", "Name");

            return View(createView);
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            CreatePostViewModel createView = new CreatePostViewModel();
            createView.Category = post.Category;
            createView.Company = post.Company;
            createView.Description = post.Description;
            createView.Location = post.Location;
            createView.Position = post.Position;
            createView.Title = post.Title;

            createView.CategoryList = new SelectList(db.Categories, "Name", "Name");

            return View(createView);
        }



        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Category,Location,Position,Company,Title,Description")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
