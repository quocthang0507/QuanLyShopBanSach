using System.Reflection.Emit;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel;

namespace BUS
{
    public class EventsBUS
    {
        /// <summary>
        /// Handle the appropriate keyboard events to prevent anything but numeric input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DigitTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
