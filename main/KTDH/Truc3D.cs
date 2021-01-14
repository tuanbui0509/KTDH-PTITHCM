using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTDH
{
    class Truc3D
    {
        public void VeTruc(Bitmap bmp,PaintEventArgs e)
        {
            //Luoi pixel
            for (int i = 5; i < 900; i += 5)
            {
                e.Graphics.DrawLine(Pens.LightGray, 0, i, 900, i);
            }

            for (int i = 5; i < 900; i += 5)
            {
                e.Graphics.DrawLine(Pens.LightGray, i, 0, i, 900);
            }
            //=======================================


            SolidBrush blackBrush = new SolidBrush(Color.Black);

            DuongThang dth = new DuongThang();
            e.Graphics.DrawLine(Pens.Black, 500, 350, 500, 3); //y
            dth.NetDut3D(500, 350, 500, 680, blackBrush, e);
            e.Graphics.DrawLine(Pens.Black, 495, 8, 500, 3);
            e.Graphics.DrawLine(Pens.Black, 505, 8, 500, 3);
            for(int i = 1; i<68;i++)
            {
                if(i<35)e.Graphics.DrawLine(Pens.Black, 497, i*10, 503, i*10);
                else e.Graphics.DrawLine(Pens.Gray, 497, i * 10, 503, i * 10);
            }


            e.Graphics.DrawLine(Pens.Black, 500, 350, 1010, 350);//x
            dth.NetDut3D(0, 350, 500, 350, blackBrush, e);
            e.Graphics.DrawLine(Pens.Black, 1005, 345, 1010, 350);
            e.Graphics.DrawLine(Pens.Black, 1005, 355, 1010, 350);
            for (int i = 2; i < 101; i++)
            {
                if(i<50) e.Graphics.DrawLine(Pens.Gray, i * 10, 347, i * 10, 353);
                else e.Graphics.DrawLine(Pens.Black, i * 10, 347, i * 10, 353);
            }


            e.Graphics.DrawLine(Pens.Black, 845, 5, 170, 680); //z
            dth.NetDut3D(500, 350, 500, 680, blackBrush, e);
            e.Graphics.DrawLine(Pens.Black, 170, 675, 170, 680);
            e.Graphics.DrawLine(Pens.Black, 175, 680, 170, 680);
            for (int i = 1; i < 33; i++)
            {
                e.Graphics.DrawLine(Pens.Black, 500-2 - (i * 10), 345+2 + (i * 10), 505 - 2 - (i * 10), 350 +2 + (i * 10));
                e.Graphics.DrawLine(Pens.Gray, 500+2 + (i * 10), 355 - 2 - (i * 10), 495+2 + (i * 10), 350-2 - (i * 10));
            }

            //e.Graphics.DrawImage(bmp, 0, 0);

        }
        public void XoaTruc(PaintEventArgs e)
        {

        }
    }
}
