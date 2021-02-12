using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //ctor
        public SuccessResult() : base(true)
        {
        }
        //ctor - overload
        public SuccessResult(string message) : base(true, message)
        {
        }
    }
}

//ctor
//hiç parametre girilmediğinde -> base'deki tek parametreli ctor default true olarak çalışacak.

//ctor overload
//parametre olarak sadece message girildiğinde -> base'deki 2 parametreli ctor, success'i default true olarak çalışacak.