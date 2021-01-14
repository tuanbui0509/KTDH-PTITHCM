using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTDH
{
    class HinhTruTron
    {
        Line d1, d2;
        ELip tamA, tamO;
        public void VeHinh(double x1, double y1, double z1, double bk1, double chieucao1, Graphics g)
        {

            Point pointB = new Point((int)(x1 - z1 + bk1 + 501), (int)(350 - y1 + z1));
            Point pointC = new Point((int)(x1 - z1 + bk1 + 501), (int)(350 - y1 + z1 - chieucao1));
            Point pointD = new Point((int)(x1 - z1 - bk1 + 489), (int)(350 - y1 + z1));
            Point pointE = new Point((int)(x1 - z1 - bk1 + 489), (int)(350 - y1 + z1 - chieucao1));

            //TAM O
            Point pointO = new Point((int)(x1 - z1 + 501), (int)(350 - y1 + z1));
            //TAM A
            Point pointA = new Point((int)(x1 - z1 + 501), (int)(350 - y1 + z1 - chieucao1));

            //VE 2 DUONG THANG
            d1 = new Line(pointE.X, pointE.Y, pointD.X, pointD.Y, Color.Black);
            d2 = new Line(pointC.X, pointC.Y, pointB.X, pointB.Y, Color.Black);
            d1.DDA_Line(g, Color.Black); //4 chân đáy ban đầu là nét đứt 
            d2.DDA_Line(g, Color.Black);
            // ve hinh elip
            tamA = new ELip(pointA.X, pointA.Y, (int)bk1, (int)chieucao1);
            tamA.Midpoint_elip(g, Color.Black);

            //tamA.NetDut(pointA.X, pointA.Y, (int)bk1, (int)chieucao1, g, Color.Red);

            //tam O duoi
            tamO = new ELip(pointO.X, pointO.Y, (int)bk1, (int)chieucao1);
            tamO.Midpoint_elip1(g, Color.Black);

        }
    }
}
