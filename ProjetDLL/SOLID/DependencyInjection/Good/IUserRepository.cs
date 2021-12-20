namespace ProjetDLL.SOLID.DependencyInjection.Good
{
    public interface IUserRepository
    {
        User GetById(int id);
    }
}