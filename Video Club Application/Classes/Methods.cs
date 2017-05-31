using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Club_Application
{
    class Methods
    {
        public static string Quote(string s)
        {
            string retv = s.Replace("'", "''").Replace("\"", @"""").Replace("--", "");
            return "'" + @retv + "'";
        }

        public static void Bind(ComboBox cbx, List<Category> list)
        {
            cbx.BeginUpdate();
            cbx.DataSource = null;
            cbx.DataSource = list;
            cbx.ValueMember = "id";
            cbx.DisplayMember = "name";
            cbx.EndUpdate();
        }
    }
}
