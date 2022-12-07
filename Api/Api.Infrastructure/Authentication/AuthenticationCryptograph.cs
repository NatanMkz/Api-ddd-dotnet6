using System.Text;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Api.Infrastructure.Authentication;

public class CryptographToken
{
    public static string TraceFolder = @"c:\temp\";
    public string Criptografar(string response)
    {
        try
        {
            string nomeArquivo = "CriptografaTokenLog_" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm") + ".txt";
            using (FileStream fileStream = new(TraceFolder + nomeArquivo, FileMode.OpenOrCreate))
            {
                using (Aes aes = Aes.Create())
                {
                    byte[] key = Encoding.Default.GetBytes(response);
                    key.CopyTo(aes.Key, 0);


                    byte[] iv = aes.IV;
                    fileStream.Write(iv, 0, iv.Length);

                    using (CryptoStream cryptoStream = new(
                        fileStream,
                        aes.CreateEncryptor(),
                        CryptoStreamMode.Write))
                    {
                        using (StreamWriter encryptWriter = new(cryptoStream))
                        {
                            encryptWriter.WriteLine(response);
                        }
                    }
                }
            }
            string retorna = string.Empty;

            using (StreamReader r = new StreamReader(TraceFolder + nomeArquivo, Encoding.Unicode))
            {
                retorna = r.ReadToEnd();
            }

            Console.WriteLine("The file was encrypted.");
            return retorna;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"The encryption failed. {ex}");
            throw;
        }
    }
}