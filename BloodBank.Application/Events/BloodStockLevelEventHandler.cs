using BloodBank.Domain.Events;
using MediatR;
using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.Extensions.Configuration;

namespace BloodBank.Application.Events
{
    public class BloodStockLevelEventHandler : INotificationHandler<BloodStockLevelEvent>
    {
        private readonly IConfiguration _configuration;

        public BloodStockLevelEventHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Handle(BloodStockLevelEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("\n \n MINIMUM LEVEL REACHED \n \n" + notification);
            var apiKey = _configuration.GetSection("SendGridKey").Value;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("eduardozortea9@gmail.com", "Eduardo BloodBank");
            var subject = "STOCK LEVEL";
            var to = new EmailAddress("eduardo.zortea.dev@gmail.com", "Eduardo Zortea");
            var plainTextContent = "The minimum level was reached for blood stock: " + notification.BloodType + notification.RhFactor.ToString();
            var htmlContent = "<strong>\"The minimum level was reached for blood stock: \" + notification.BloodType + notification.RhFactor.ToString()</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            _ = await client.SendEmailAsync(msg);
        }
    }
}
