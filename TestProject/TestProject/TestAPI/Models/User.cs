using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class User
    {
        public int Id { get; set; }
      
        public string UserName { get; set; }
       
        public string Email { get; set; }
        
        public string Mobile { get; set; }
        public string Skills { get; set; }
        public string Hobby { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
