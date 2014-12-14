using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_Lab2
{
    static class InputDialog
    {
        public static String Show(String Title)
        {
            InputBox ib = new InputBox(Title);

            ib.ShowDialog();

            return ib.Edit;
        }
    }
}
