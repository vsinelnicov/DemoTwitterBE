using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoTwitter.CustomAtributtes
{
    public class CustomAtributtes : RegularExpressionAttribute
    {
        public CustomAtributtes() : base(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
        {
             }
    }
}