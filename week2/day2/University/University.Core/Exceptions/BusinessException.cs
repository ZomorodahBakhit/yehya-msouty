
namespace University.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public Dictionary<string, List<string>> Errors;
        public BusinessException(string message, Dictionary<string, List<string>> errors) : base(message)
        {
            Errors = new Dictionary<string, List<string>>();
            Errors = errors;
        }
        public BusinessException(Dictionary<string, List<string>> errors)
        : base("One or more validation errors occurred.")
        {
            this.Errors = errors ?? new Dictionary<string, List<string>>();
        }
    }
}
