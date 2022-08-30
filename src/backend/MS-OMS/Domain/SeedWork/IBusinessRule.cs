namespace Domain._SeedWork
{
    public interface IBusinessRule
    {
        bool IsValid();

        string Message { get; }
    }
}