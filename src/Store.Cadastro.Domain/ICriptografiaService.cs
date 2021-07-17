namespace Store.Cadastro.Domain
{
    public interface ICriptografiaService
    {
        byte[] Encrypt(string text);
    }
}
