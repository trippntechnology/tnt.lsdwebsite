using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using tnt.lsdwebsite.Models;

namespace tnt.lsdwebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(ContactFormModel form)
        {
            if (ModelState.IsValid)
            {
                SmtpClient client = new SmtpClient();
                MailMessage mail = new MailMessage();
                mail.To.Add("email@gmail.com");
                mail.Subject = "LSD";
                mail.Body = form.name + "\n" +
                    form.businessName + "\n" +
                    form.email + "\n" +
                    form.phoneNumber + "\n\n" +
                    form.message;
                client.Send(mail);
            }
            return View();
        }
    }
}