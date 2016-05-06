using System.ComponentModel.DataAnnotations;

namespace DemoTwitter.WEB.CustomAtributtes
{
    public class CustomAtributtes : RegularExpressionAttribute
    {
        public CustomAtributtes() : base(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
        {
             }
    }
}