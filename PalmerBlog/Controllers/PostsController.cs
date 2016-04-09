using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PalmerBlog.Models;

namespace PalmerBlog.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.OrderByDescending(post => post.Date).ToList());
        }


        // GET: Posts for Editing
        [Authorize (Roles = "Admin")]
        public ActionResult Admin()
        {
            return View(db.Posts.OrderByDescending(post => post.Date).ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(string Slug)
        {
            if (String.IsNullOrWhiteSpace(Slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.FirstOrDefault(p => p.Slug == Slug);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,Excerpt,MediaURL")] Post post)
        {
            if (ModelState.IsValid)
            {
                var Slug = StringUtilities.URLFriendly(post.Title);
                if(String.IsNullOrWhiteSpace(Slug))
                {
                    ModelState.AddModelError("Title", "Invalid title.");
                    return View(post);
                }
                if(db.Posts.Any(p=>p.Slug == Slug))
                {
                    ModelState.AddModelError("Title", "The title must be unique.");
                    return View(post);
                }
                post.Slug = Slug;
                post.Date = System.DateTimeOffset.Now;
                post.Published = true;
                if (post.Excerpt == null)
                {
                    var value = post.Content;
                    post.Excerpt = StringUtilities.Shorten(value);
                }
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        [Authorize(Roles = "Admin")]
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
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Slug,Content,Excerpt,MediaURL")] Post post)
        {
            if (ModelState.IsValid)
            {
                var PostId = post.Id;       
                var Title = post.Title;
                var Slug = StringUtilities.URLFriendly(post.Title);
                var SlugAlreadyExists = db.Posts.Where(p => p.Id == PostId && p.Slug == Slug).Select(p => p.Slug);
                if (String.IsNullOrWhiteSpace(Slug))
                {
                    ModelState.AddModelError("Title", "Invalid title.");
                    return View(post);
                }               
                if (!SlugAlreadyExists.Any())
                {
                    if (db.Posts.Any(p => p.Slug == Slug))
                    {
                        ModelState.AddModelError("Title", "The title must be unique.");
                        return View(post);
                    }
                }
                post.Slug = Slug;
                post.Modified = System.DateTimeOffset.Now;
                if (post.Excerpt == null)
                {
                    var value = post.Content;
                    post.Excerpt = StringUtilities.Shorten(value);
                }
                post.Published = true;
                db.Posts.Attach(post);
                db.Entry(post).Property("Title").IsModified = true;
                db.Entry(post).Property("Slug").IsModified = true;
                db.Entry(post).Property("Content").IsModified = true;
                db.Entry(post).Property("Excerpt").IsModified = true;
                db.Entry(post).Property("MediaURL").IsModified = true;
                //db.Entry(post).State = EntityState.Modified;              
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
