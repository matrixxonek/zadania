using System.Security.Cryptography;
using System.Text;

Console.WriteLine("Podaj hasło");
string? password = Console.ReadLine();
Console.WriteLine("Twoje haslo to:" + password);

/*string CreateMD5Hash(string input)
{
    MD5 md5 = System.Security.Cryptography.MD5.Create();
    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input); //zamienia kazdy znak na ascii
    byte[] hashBytes = md5.ComputeHash(inputBytes); //generuje tablice zahashowanych bajtow ascii z hasla

    StringBuilder sb = new StringBuilder(); //służy do tworzenia stringów
    for (int i = 0; i < hashBytes.Length; i++)
    {
        sb.Append(hashBytes[i].ToString("X2")); //tworzy string ze wszystkich bajtow z tablicy w zapisie szesnastkowym
    }
    return sb.ToString();
}*/
static string ComputeSha256Hash(string rawData)
{
    // Create a SHA256   
    using (SHA256 sha256Hash = SHA256.Create()) //tworzy instancje sha256
    {
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData)); //tworzy tablice zhaszowanych bajtow

        // Convert byte array to a string   
        StringBuilder builder = new StringBuilder(); //nowy stringbuilder
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2")); //tworzy string ze wszystkich bajtow z tablicy w zapisie szesnastkowym
        }
        return builder.ToString();
    }
}
//Console.WriteLine(CreateMD5Hash(password));
Console.WriteLine(ComputeSha256Hash(password));
//a
