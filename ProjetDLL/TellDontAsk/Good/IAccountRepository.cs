namespace ProjetDLL.TellDontAsk.Good
{
    public interface IAccountRepository
    {
        Account FindById(int id);
        void Save(Account c);
    }
}