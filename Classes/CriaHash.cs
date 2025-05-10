using System.Security.Cryptography;
using System.Text;

public static class CriaHash
{
    // Gera hash SHA256 a partir de uma string
    public static string GerarHash(string senha)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            // Converte a senha para bytes
            byte[] bytes = Encoding.UTF8.GetBytes(senha);

            // Gera o hash
            byte[] hashBytes = sha256.ComputeHash(bytes);

            // Converte o hash para string (hexadecimal)
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}