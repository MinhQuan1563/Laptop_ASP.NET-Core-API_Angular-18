namespace WAAL.Application.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendSmsAsync(string number, string message);
    }
}
