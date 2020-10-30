using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appointmentcalendar.CommonUtils
{
    public class Functions
    {
        public static string JSONtoStringConvertMethod(object thisObject)
        {         
            string jsonString = JsonConvert.SerializeObject(thisObject);
            return jsonString;
        }
    }
}
