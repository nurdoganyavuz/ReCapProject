using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //ctor-1
        public SuccessDataResult(T data, string message) : base (data, true, message)
        {

        }
        //ctor-2
        public SuccessDataResult(T data) : base(data, true)
        {

        }
        //ctor-3
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }
        //ctor-4
        public SuccessDataResult() : base(default, true)
        {
        }

        
    }
}
//DataResult ile yürütülen işlemler *başarılı* ise işlem sonucunu default TRUE döndürecek sınıf.