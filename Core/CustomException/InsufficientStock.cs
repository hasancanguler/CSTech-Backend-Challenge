namespace Core.CustomException
{
    public class InsufficientStock : IExceptionReadOnly
    {
        //this message can get from any source 
        //I want to show just custom errors
        public string message
        {
            get { return "Insufficient Stock"; }
        }

        public int errorCode
        {
            get { return StatusCodes.Status600InsufficientStock; }
        }

    }
}
