using MimeKit;
using MailKit.Net.Smtp;

public class MailService
{
    public IConfiguration Configuration { get; }

    private readonly string _accountId;
    private readonly string _accountPassword;

    public MailService(IConfiguration configuration)
    {
        _accountId = configuration["Mailtrap:AccountId"];
        _accountPassword = configuration["Mailtrap:AccountPassword"];
    }

    public async Task SendConfirmationEmailAsync(string toEmail)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Clinic", "noreply@clinic.com"));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = "Patient Registration Confirmation";
        message.Body = new TextPart("plain")
        {
            Text = "Thank you for registering as a patient."
        };

        using (var client = new SmtpClient())
        {
            try
            {
                await client.ConnectAsync("sandbox.smtp.mailtrap.io", 587, false);
                await client.AuthenticateAsync(_accountId, _accountPassword);
                await client.SendAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }
    }
}
