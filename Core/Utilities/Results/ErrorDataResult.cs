using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //ctor-1
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }
        //ctor-2
        public ErrorDataResult(T data) : base(data, false)
        {
        }
        //ctor-3
        public ErrorDataResult(string message) : base(default, false, message)
        {
        }
        //ctor-4
        public ErrorDataResult() : base(default, false)
        {
        }
    }
}
//DataResult ile yürütülen işlemler *başarısız* ise işlem sonucunu default FALSE döndürecek sınıf.