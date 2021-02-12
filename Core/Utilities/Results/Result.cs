using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //ctor
        public Result(bool succes, string message):this(succes)
        {
            Message = message;
        }
        //ctor - overload
        public Result(bool succes)
        {
            Success = succes;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
