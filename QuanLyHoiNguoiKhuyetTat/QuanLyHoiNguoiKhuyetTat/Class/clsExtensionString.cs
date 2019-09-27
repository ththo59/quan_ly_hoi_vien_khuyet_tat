using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DauThau.Class
{
    static class clsExtensionString
    {
        public static string Ex_getLastName(this String fullName)
        {
            string[] names = fullName.Split(' ');
            string lastName = names.Last();
            return lastName;
        }
    }
}
