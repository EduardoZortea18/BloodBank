using BloodBank.Domain.Events;
using MediatR;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

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
            var from = new EmailAddress("email@email.com.com", "BloodBank");
            var subject = "STOCK LEVEL";
            var to = new EmailAddress("email@email.com", "BloodBank");
            var plainTextContent = string.Concat("The minimum level was reached for blood stock: ", notification.BloodType, notification.RhFactor.ToString());
            var htmlContent = $"<strong>The minimum level was reached for blood stock: {plainTextContent}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            _ = await client.SendEmailAsync(msg);
        }
    }
}
