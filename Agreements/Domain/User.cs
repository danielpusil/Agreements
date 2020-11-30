using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User:IdentityUser 
    {
        public string FullName{get;set;}
    }
}