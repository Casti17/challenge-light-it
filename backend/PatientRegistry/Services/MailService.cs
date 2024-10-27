using MimeKit;
using MailKit.Net.Smtp;

public class MailService
{
    public static async Task SendConfirmationEmailAsync(string toEmail)
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
                await client.AuthenticateAsync("639f6608ec23f8", "0aad770a8fd4c6");
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
