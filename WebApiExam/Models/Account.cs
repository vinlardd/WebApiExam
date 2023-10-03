using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExam.Models
{
    public class Account
    {
        public Guid IdAccount { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FIO { get; set; }
    }
}
