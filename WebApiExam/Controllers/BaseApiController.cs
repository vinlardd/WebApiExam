using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExam.Controllers
{
    public class BaseController
    {
        protected string connectionstring;
        protected RestClient Client;
        protected RestRequest Request;
        protected RestResponse Response;
        public BaseController(string connectionstring)
        {
            this.connectionstring = connectionstring;
            Client = new RestClient(connectionstring);
        }
    }
}
