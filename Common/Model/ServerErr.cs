using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Common.Model
{
    public class ServerErr
    {
        public string Hint { get; set; }
        public string Type { get; set; }
        public string StackTrace { get; set; }
        public string ControllerName { get; set; }
    }

    public class ServerError
    {
        public string hint { get; set; }
        public string type { get; set; }
        public string stackTrace { get; set; }
        public string controllerName { get; set; }

    }
}
