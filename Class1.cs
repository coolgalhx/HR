using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;



namespace HR_Management_System
{
    internal class Class1
    {
        // Source - https://stackoverflow.com/a
        // Posted by Keramat
        // Retrieved 2025-11-15, License - CC BY-SA 3.0

        private void textbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key== Key.Enter)
            {
                //cod for run
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            textbox1_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }

    }
}
