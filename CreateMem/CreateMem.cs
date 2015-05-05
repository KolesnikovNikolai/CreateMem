using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateMems
{
    public class CreateMem
    {
        Bitmap bmp = null;
        String up = null;
        String down = null;
        public void LoadImage(string p)
        {
            bmp = new Bitmap(p);
        }

        public Bitmap getImage()
        {
            return bmp;
        }

        public void SaveImage(string p)
        {
            bmp.Save(p, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        public void SetUpText(string p)
        {
            up = p;
        }

        public object getUpText()
        {
            return up;
        }

        public void SetDownText(string str)
        {
            down = str;
        }

        public object getDownText()
        {
            return down;
        }

        public void SetTextOnImage(int p1, int p2, int p3, int p4, string p5)
        {
            Graphics g1 = Graphics.FromImage(bmp);
                //рисуем

                // Create font and brush.
            Font drawFont = new Font("Lucida Console", 16);
                SolidBrush drawBrush = new SolidBrush(Color.White);

                Rectangle drawRect = new Rectangle(p1, p2, p3, p4);

                // Draw rectangle to screen.
                Pen blackPen = new Pen(Color.Empty);
                g1.DrawRectangle(blackPen, p1, p2, p3, p4);

                // Set format of string.
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;

                // Draw string to screen.
               //g1.DrawString(p5, drawFont, drawBrush, drawRect, drawFormat);
                TextFormatFlags flags = TextFormatFlags.WordBreak;
                TextRenderer.DrawText(g1, p5, drawFont, drawRect, Color.Empty, Color.White, flags);
                g1.DrawRectangle(blackPen, Rectangle.Round(drawRect));
                
        }


        public void SetTextOnImageUp()
        {
            Graphics g1 = Graphics.FromImage(bmp);
            //рисуем

            // Create font and brush.
            Font drawFont = new Font("Lucida Console", 16);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            Rectangle drawRect = new Rectangle(10, 10, bmp.Width-20, 30);

            // Draw rectangle to screen.
            Pen blackPen = new Pen(Color.Empty);
            g1.DrawRectangle(blackPen, 10, 10, bmp.Width - 20, 30);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;

            // Draw string to screen.
            TextRenderer.DrawText(g1, up, drawFont, drawRect, Color.Empty, Color.White);
        }

        public void SetTextOnImageDown()
        {
            Graphics g1 = Graphics.FromImage(bmp);
            //рисуем

            // Create font and brush.
            Font drawFont = new Font("Lucida Console", 16);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            Rectangle drawRect = new Rectangle(10, bmp.Height - 40, bmp.Width - 20, 30);

            // Draw rectangle to screen.
            Pen blackPen = new Pen(Color.Empty);
            g1.DrawRectangle(blackPen, 10, bmp.Height - 40, bmp.Width - 20, 30);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;

            // Draw string to screen.
            TextRenderer.DrawText(g1, down, drawFont, drawRect, Color.Empty, Color.White);
        }
    }
}
