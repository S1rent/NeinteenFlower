using NeinteenFlower.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NeinteenFlower.WebService
{
    /// <summary>
    /// Summary description for NeinteenFlowerWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NeinteenFlowerWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string CheckUserEmailExist(string email)
        {
            return CommonHandler.shared.CheckUserEmailExist(email);
        }

        [WebMethod]
        public string ValidatePassword(bool isEmployee, string email, string password)
        {
            return CommonHandler.shared.ValidatePassword(isEmployee, email, password);
        }
    }
}
