using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace QL_GIAODUC_ONLINE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] EmailModel model)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("daohuy1692003@gmail.com", "hvpk oxhw ocye kuxn"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("daohuy1692003@gmail.com"),
                    Subject = model.Subject,
                    Body = model.Body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(model.ToEmail);

                // Add attachment if provided
                if (model.Attachment != null && model.Attachment.Length > 0 && 
                    !string.IsNullOrEmpty(model.AttachmentName) && 
                    !string.IsNullOrEmpty(model.AttachmentContentType))
                {
                    using (var ms = new MemoryStream(model.Attachment))
                    {
                        var attachment = new Attachment(ms, model.AttachmentName, model.AttachmentContentType);
                        mailMessage.Attachments.Add(attachment);
                    }
                }

                await smtpClient.SendMailAsync(mailMessage);

                return Ok(new { message = "Email sent successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Failed to send email", error = ex.Message });
            }
        }
    }

    public class EmailModel
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public byte[]? Attachment { get; set; }
        public string? AttachmentName { get; set; } 
        public string? AttachmentContentType { get; set; }
    }
}
