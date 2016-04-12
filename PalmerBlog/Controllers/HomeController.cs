using Microsoft.AspNet.Identity;
using PalmerBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PalmerBlog.Controllers
{   
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyPage()
        {
            ViewBag.Message = "This is my page.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact([Bind(Include = "Id,Name,Email,Message,Phone,MessageSent")] Contact contact)
        {
            {
                contact.MessageSent = DateTime.Now;

                var svc = new EmailService();
                var msg = new IdentityMessage();
                msg.Subject = "New Message from Portfolio Website";
                msg.Body = "Message: " + contact.Message + "<br><br>From: " + contact.Name + "<br><br>E-mail: " + contact.Email + "<br><br>Phone Number: " + contact.Phone;
                await svc.SendAsync(msg);

                return View(contact);
            }
        }
    }
}