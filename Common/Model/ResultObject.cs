using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Consulting.Common.Model
{
    public class ResultObject
    {
        public ResultObject()
        {
            ServerErrors = new List<ServerErr>();
        }
        public IList<ServerErr> ServerErrors { get; set; }

        [JsonPropertyName("result")]
        public object Result { get; set; }
    }


    public class resultObject
    {
        public resultObject()
        {
            serverErrors = new List<ServerError>();
        }
        public IList<ServerError> serverErrors { get; set; }

        [JsonPropertyName("Result")]
        public object Result { get; set; }
    }

}
