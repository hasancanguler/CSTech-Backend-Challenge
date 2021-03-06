namespace Core.CustomException
{
    interface IExceptionReadOnly
    {
        public int errorCode { get;  }
        public string message { get;  }
    }
}
