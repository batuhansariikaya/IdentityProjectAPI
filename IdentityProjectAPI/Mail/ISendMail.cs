namespace IdentityProjectAPI.Mail
{
    public interface ISendMail
    {
        void Send(string mail,string code);
    }
}
