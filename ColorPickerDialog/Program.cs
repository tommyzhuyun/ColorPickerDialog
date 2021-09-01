using System;
using System.Drawing;
using System.Windows.Forms;


namespace ColorPickerDialog
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Color Picker;
            ColorPicker.ColorPickers cp = new ColorPicker.ColorPickers(Color.White);
            if (cp.ShowDialog() == DialogResult.OK)
            {
                Picker = cp.SetColor;
                Console.WriteLine(ColorPicker.Plugin.HSV.HTMLString(Picker));
            }
            cp?.Dispose();

        }
    }
}
