using Eto.Drawing;
using Eto.Forms;
using System;
using System.Windows.Controls;

namespace EtoApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Title = "Grid Test";
            MinimumSize = new Size(500, 500);
            string imagepath = "C:\\Users\\Diakon\\Documents\\GitHub\\C-Snips\\EtoApp1\\hex.bmp";
            var content = new PixelLayout();
            var button = new Eto.Forms.Button();
            var image = new Bitmap(imagepath);
            button.Image = image;
            button.Size = new Size(50,50);
            content.Add(button, 0, 0);
            Content = content;
        }
    }
}
