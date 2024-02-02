namespace Sela.Task.API.Exceptions
{
    public class DuplicateTaskDetailException : Exception
    {
        public DuplicateTaskDetailException(string message)
        : base(message)
        {
        }
    }
}
