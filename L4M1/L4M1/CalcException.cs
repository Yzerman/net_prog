using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4M1
{
    class CalcException : Exception
    {
        public DateTime ExceptionTime { get; set; }
        public CalcException() : base() { }
        public CalcException(string message) : base(message) { }
        public CalcException(string message, Exception innerException) : base(message, innerException) { }
        public CalcException(string message, DateTime ExceptionTime) : base(message) {

            this.ExceptionTime = ExceptionTime;
        }
    }
}
