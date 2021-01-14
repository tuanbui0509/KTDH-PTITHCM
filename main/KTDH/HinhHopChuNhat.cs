using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using System.Windows.Forms;


namespace KTDH
{
    class HinhHopChuNhat
    {
        public void VeHinh(double x, double y, double z, double dai, double cao, double rong, Color c, Graphics g)
        {
            Line dAB, dAD, dAE, dCB, dCD, dFB, dHD, dHE, dFE, dFG, dHG, dCG;
            Point pointA = new Point((int)(x - z + 500), (int)(350 - y + z));
            Point pointB = new Point((int)(x - z + dai + 500), (int)(350 - y + z));
            Point pointC = new Point((int)(x - z + dai + 500), (int)(350 - y + z - cao));
            Point pointD = new Point((int)(x - z + 500), (int)(350 - y + z - cao));
            //tính toán ở đây
            Point pointE = new Point((int)(x - z - (rong * Math.Sqrt(2)) / 2 + 500), (int)(350 - y + z + (rong * Math.Sqrt(2)) / 2));
            Point pointF = new Point((int)(x - z + (dai - (rong * Math.Sqrt(2)) / 2) + 500), (int)(350 - y + z + (rong * Math.Sqrt(2)) / 2));
            Point pointG = new Point((int)(x - z + dai - (rong * Math.Sqrt(2)) / 2 + 500), (int)(350 - y + z - (cao - (rong * Math.Sqrt(2)) / 2)));
            Point pointH = new Point((int)(x - z - (rong * Math.Sqrt(2)) / 2 + 500), (int)(350 - y + z - (cao - (rong * Math.Sqrt(2)) / 2)));


            dAB = new Line(pointA.X, pointA.Y, pointB.X, pointB.Y, c);
            dAD = new Line(pointA.X, pointA.Y, pointD.X, pointD.Y, c);
            dAE = new Line(pointA.X, pointA.Y, pointE.X, pointE.Y, c);
            dCB = new Line(pointC.X, pointC.Y, pointB.X, pointB.Y, c);
            dCD = new Line(pointC.X, pointC.Y, pointD.X, pointD.Y, c);
            dFB = new Line(pointF.X, pointF.Y, pointB.X, pointB.Y, c);
            dHD = new Line(pointH.X, pointH.Y, pointD.X, pointD.Y, c);
            dHE = new Line(pointH.X, pointH.Y, pointE.X, pointE.Y, c);
            dFE = new Line(pointF.X, pointF.Y, pointE.X, pointE.Y, c);
            dFG = new Line(pointF.X, pointF.Y, pointG.X, pointG.Y, c);
            dHG = new Line(pointH.X, pointH.Y, pointG.X, pointG.Y, c);
            dCG = new Line(pointC.X, pointC.Y, pointG.X, pointG.Y, c);

            dAB.DDA_Line1(g, c); //3 chân đáy ban đầu là nét đứt 
            dAD.DDA_Line1(g, c);
            dAE.DDA_Line1(g, c);

            dCB.DDA_Line(g, c);
            dCD.DDA_Line(g, c);
            dCG.DDA_Line(g, c);
            dFB.DDA_Line(g, c);
            dFE.DDA_Line(g, c);

            dFG.DDA_Line(g, c);
            dHD.DDA_Line(g, c);
            dHE.DDA_Line(g, c);
            dHG.DDA_Line(g, c);

        }
    }
}
