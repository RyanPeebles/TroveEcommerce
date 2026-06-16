using Microsoft.AspNetCore.Identity.UI.Services;

namespace TroveApi.Services
{
    public class LocalEmailSender : IEmailSender
    {
        private readonly ILogger<LocalEmailSender> _logger;

        public LocalEmailSender(ILogger<LocalEmailSender> logger)
        {
            _logger = logger;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _logger.LogInformation("=========================================");
            _logger.LogInformation($"✉️ LOCAL EMAIL SENT TO: {email}");
            _logger.LogInformation($"📌 SUBJECT: {subject}");
            _logger.LogInformation($"🔗 MESSAGE BODY:\n{htmlMessage}");
            _logger.LogInformation("=========================================");

            return Task.CompletedTask;
        }
    }    
}
