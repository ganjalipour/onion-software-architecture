using System;

namespace Consulting.Common
{
    public class RequestAttribute : Attribute
    {
        public int RequestType { get; set; }

        public RequestAttribute(int requestType )
        {
            RequestType = requestType; 
        }

       
    }
}
