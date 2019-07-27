using System;
using System.Collections.Generic;
using System.Text;

namespace KV.DLL
{
    public class Response<T>
    {
        public int Code { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
