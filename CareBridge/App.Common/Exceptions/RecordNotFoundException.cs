namespace App.Common.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string message = "Record not found.") : base(message) { }
    }
}
