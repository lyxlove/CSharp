using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCWK_DEMO
{
    public static class ExtendMethod
    {
        public static int ToIntPd(this string s)
        {
            int i;
            if (!string.IsNullOrEmpty(s) && int.TryParse(s,out i))
            {
                return i;
            }
            return 3;
        }
    }
}
