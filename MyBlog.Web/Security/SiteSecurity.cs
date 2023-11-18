using System.Security.Cryptography;
using System.Text;

namespace MyBlog.Web.Security;
public static class SiteSecurity
{
    public static string FixEmail(string email) => email.Trim().ToLower().Replace(" ", "");

    public static string EncodePasswordMd5(string Password)
    {
        Byte[] originlBytes;
        Byte[] encodeedBytes;
        MD5 md5;
        md5 = new MD5CryptoServiceProvider();
        originlBytes = ASCIIEncoding.Default.GetBytes(Password);
        encodeedBytes = md5.ComputeHash(originlBytes);
        return BitConverter.ToString(encodeedBytes);
    }
}