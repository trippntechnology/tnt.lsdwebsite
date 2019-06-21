using System.Diagnostics;
using System.Net;
using System.Net.Mail;
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

        public IActionResult About()
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


                MailMessage mail = new MailMessage(form.businessName,"to@email.com");
                mail.Subject = "LSD - "+form.businessName;
                mail.Body = form.name + "\n" +
                    form.businessName + "\n" +
                    form.email + "\n" +
                    form.phoneNumber + "\n\n" +
                    form.message;

                SmtpClient client = new SmtpClient("smtp.gmail.com",587);
                client.Credentials = new NetworkCredential("from@email.com", "pass");
                client.EnableSsl = true;


                client.Send(mail);
            }
            return View();
        }
    }
}
