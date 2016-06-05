using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoWebsite.Models;

namespace UmbracoWebsite.Controllers
{
    public class ContactPostController : SurfaceController
    {
        [HttpPost]
        public ActionResult Submit(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["submit-status"] = "There was an error while sending the request";
                return CurrentUmbracoPage();
            }
                

                /// Work with form data here
                MailMessage message = new MailMessage(); // Create new object MailMessage
                message.From = new MailAddress(model.Email); // Set sender
                message.To.Add(new MailAddress("niels-odgaard@hotmail.com")); // Set receiver. You can set more receivers just adding this line with a new e-mail address
                message.Subject = model.Name; // Set subject name
                message.IsBodyHtml = true; // Set true for HTML body
                message.Body = model.Message; // Set body content
                message.Priority = MailPriority.Normal;
                SmtpClient client = new SmtpClient(); // Create new object SMTP Client
                client.Credentials = new System.Net.NetworkCredential("postmaster@mytesting.mailgun.org", "76kxh2x4a449"); // Credentials of your e-mail
                client.Port = 587; // Use 465 for personal accounts and 587 for business accounts (Googls Apps)
                client.Host = "smtp.mailgun.org"; // Set host
                client.EnableSsl = true; // Enable secure connection
                client.Send(message); // Send the message

            //Add a message in TempData which will be available 
            //in the View after the redirect 
           
            TempData.Add("CustomMessage", "Your form was successfully submitted at " + DateTime.Now);
            return RedirectToCurrentUmbracoPage();


        }
    }
}