namespace Dominio.Interfaces.Cryptograph;

public interface ICryptograph
{
    public string EncryptPassword(string password);
    public bool VerifyPassword(string password, string encryptedpassword);
}
