using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plane
{
    class PlaneException : Exception
    {
        public string PlaneMessage { get; set; }
        public string ExceptionSource { get; set; }

        public PlaneException()
            : base()
        {
            this.PlaneMessage = base.Message;
            this.ExceptionSource = base.Source;
        }

        public PlaneException(string message, string source)
        {
            this.PlaneMessage = message;
            this.ExceptionSource = source;
        }
    }
}
