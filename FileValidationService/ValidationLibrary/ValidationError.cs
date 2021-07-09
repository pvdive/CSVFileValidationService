namespace FormatValidator
{
    /// <summary>
    /// Provides defails of an error found during validation.
    /// </summary>
    public class ValidationError
    {
        private string _message;

        internal ValidationError(int at, string message)
        {
            _message = message;
        }

        public string Message
        {
            get { return _message; }
        }
        
        public int Column
        {
            get;
            internal set;
        }
    }
}
