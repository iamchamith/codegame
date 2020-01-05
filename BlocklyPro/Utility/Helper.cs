using System;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BlocklyPro.Utility
{
    public class Helper
    {
        public static bool Confirm(string title = "Confirm?", string message = "Confirm")
        {
            var dr = MessageBox.Show(message, title, MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
        public static void Info(string title = "Info", string message = "")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK,
              MessageBoxIcon.Information);
        }
        public static void Error(string title = "Error", Exception ex = null)
        {
            MessageBox.Show(ex?.Message, title, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        public static string ObjectToString<T>(T item)
        {
            return JsonConvert.SerializeObject(item);
        }
    }
}
