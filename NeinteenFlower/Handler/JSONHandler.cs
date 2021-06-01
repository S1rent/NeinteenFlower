using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class JSONHandler
    {
        public static JSONHandler shared = new JSONHandler();
        private JSONHandler() { }

        public string Encode(object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public T Decode<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}