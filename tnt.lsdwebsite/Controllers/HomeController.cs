using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tnt.lsdwebsite.Models;

namespace tnt.lsdwebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
