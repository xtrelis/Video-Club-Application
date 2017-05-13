using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Club_Application
{
    class Methods
    {
        public static string Quote(string s)
        {
            string retv = s.Replace("'", "''").Replace("\"", @"""").Replace("--", "");
            return "'" + @retv + "'";
        }
    }
}
