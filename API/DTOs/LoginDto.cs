using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class LoginDto
    {

        
        public String Username { get; set; }  

        
        public String password { get; set; }  
        
    }
}