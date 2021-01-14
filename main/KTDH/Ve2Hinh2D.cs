using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTDH
{
    class Ve2Hinh2D
    {
        //public void VeHinhNguoi(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4,
        //    int x5, int y5, int x6, int y6, int x7, int y7, int R, int r, Bitmap bmp, Color a)
        //{
        //    DuongTron dtr = new DuongTron();
        //    DuongThang dt = new DuongThang();
        //    ELip el = new ELip();
        //    Line AB;
        //    if (R == r)
        //    {
        //        dtr.MidpointDuongTron(x1, y1, Math.Abs(R), bmp, a); // đầu
        //    }
        //    else
        //    {
        //        el.HinhELip(x1, y1, Math.Abs(R), Math.Abs(r), bmp, a);
        //    }
        //    dt.MidpointLine(x2, y2, x3, y3, bmp, a); //mình

        //    dt.MidpointLine(x2, y2, x4, y4, bmp, a); // tay trái
        //    dt.MidpointLine(x2, y2, x5, y5, bmp, a); // tay phải

        //    dt.MidpointLine(x6, y6, x3, y3, bmp, a); // chân trái
        //    dt.MidpointLine(x3, y3, x7, y7, bmp, a); // chân phải


        //}



        //public void VeQuaBong(int x1, int y1, int R, int r, Bitmap bmp, Color a)
        //{
        //    DuongTron dtr = new DuongTron();
        //    ELip el = new ELip();
        //    if (R == r)
        //    {
        //        dtr.MidpointDuongTron(x1, y1, Math.Abs(R), bmp, a); // đầu
        //    }
        //    else
        //    {
        //        el.HinhELip(x1, y1, Math.Abs(R), Math.Abs(r), bmp, a);
        //    }
        //}

        public void VeNgoiNha(Point x1, Point x2, Point x3, Point x4, Point x5, Point x6, Point x7, Point x8, Point x9, Point x10,
            Point x11, Point x12, Point x13, Graphics g, Color a)
        {
            //DuongThang dt = new DuongThang();

            int bonusVertical = 70;
            int bonusHorizontal = 0;
            for (int i = 0; i < 4; i++)
            {
                bonusHorizontal = i * 50;
                ////ve than nha
                //dt.MidpointLine(x1.X, x1.Y, x2.X, x2.Y, bmp, a);
                //dt.MidpointLine(x2.X, x2.Y, x3.X, x3.Y, bmp, a);
                //dt.MidpointLine(x3.X, x3.Y, x4.X, x4.Y, bmp, a);
                //dt.MidpointLine(x4.X, x4.Y, x1.X, x1.Y, bmp, a);
                ////ve cua nha
                //dt.MidpointLine(x5.X, x5.Y, x6.X, x6.Y, bmp, a);
                //dt.MidpointLine(x6.X, x6.Y, x7.X, x7.Y, bmp, a);
                //dt.MidpointLine(x7.X, x7.Y, x8.X, x8.Y, bmp, a);
                //dt.MidpointLine(x8.X, x8.Y, x5.X, x5.Y, bmp, a);
                ////Ve cua so trai
                //dt.MidpointLine(x9.X, x9.Y - bonusHorizontal, x10.X, x10.Y - bonusHorizontal, bmp, a);
                //dt.MidpointLine(x10.X, x10.Y - bonusHorizontal, x11.X, x11.Y - bonusHorizontal, bmp, a);
                //dt.MidpointLine(x11.X, x11.Y - bonusHorizontal, x12.X, x12.Y - bonusHorizontal, bmp, a);
                //dt.MidpointLine(x12.X, x12.Y - bonusHorizontal, x9.X, x9.Y - bonusHorizontal, bmp, a);

                //ve than nha
                Line d12 = new Line(x1.X, x1.Y, x2.X, x2.Y, a);
                Line d23 = new Line(x2.X, x2.Y, x3.X, x3.Y, a);
                Line d34 = new Line(x3.X, x3.Y, x4.X, x4.Y, a);
                Line d41 = new Line(x4.X, x4.Y, x1.X, x1.Y, a);
                //ve cua nha
                Line d56 = new Line(x5.X, x5.Y, x6.X, x6.Y, a);
                Line d67 = new Line(x6.X, x6.Y, x7.X, x7.Y, a);
                Line d78 = new Line(x7.X, x7.Y, x8.X, x8.Y, a);
                Line d85 = new Line(x8.X, x8.Y, x5.X, x5.Y, a);
                //Ve cua so trai
                Line d910t = new Line(x9.X, x9.Y - bonusHorizontal, x10.X, x10.Y - bonusHorizontal, a);
                Line d1011t = new Line(x10.X, x10.Y - bonusHorizontal, x11.X, x11.Y - bonusHorizontal, a);
                Line d1112t = new Line(x11.X, x11.Y - bonusHorizontal, x12.X, x12.Y - bonusHorizontal, a);
                Line d129t = new Line(x12.X, x12.Y - bonusHorizontal, x9.X, x9.Y - bonusHorizontal, a);
                //Ve cua so phai
                Line d910p = new Line(x9.X + bonusVertical, x9.Y - bonusHorizontal, x10.X + bonusVertical, x10.Y - bonusHorizontal, a);
                Line d1011p = new Line(x10.X + bonusVertical, x10.Y - bonusHorizontal, x11.X + bonusVertical, x11.Y - bonusHorizontal, a);
                Line d1112p = new Line(x11.X + bonusVertical, x11.Y - bonusHorizontal, x12.X + bonusVertical, x12.Y - bonusHorizontal, a);
                Line d129p = new Line(x12.X + bonusVertical, x12.Y - bonusHorizontal, x9.X + bonusVertical, x9.Y - bonusHorizontal, a);

                //dt.MidpointLine(x9.X + bonusVertical, x9.Y -  bonusHorizontal, x10.X + bonusVertical, x10.Y -  bonusHorizontal, bmp, a);
                //dt.MidpointLine(x10.X + bonusVertical, x10.Y -  bonusHorizontal, x11.X + bonusVertical, x11.Y -  bonusHorizontal, bmp, a);
                //dt.MidpointLine(x11.X + bonusVertical, x11.Y -  bonusHorizontal, x12.X + bonusVertical, x12.Y -  bonusHorizontal, bmp, a);
                //dt.MidpointLine(x12.X + bonusVertical, x12.Y -  bonusHorizontal, x9.X + bonusVertical, x9.Y -  bonusHorizontal, bmp, a);
                d12.DDA_Line(g, a);
                d23.DDA_Line(g, a);
                d34.DDA_Line(g, a);
                d41.DDA_Line(g, a);

                d56.DDA_Line(g, a);
                d67.DDA_Line(g, a);
                d78.DDA_Line(g, a);
                d85.DDA_Line(g, a);

                d910t.DDA_Line(g, a);
                d1011t.DDA_Line(g, a);
                d1112t.DDA_Line(g, a);
                d129t.DDA_Line(g, a);

                d910p.DDA_Line(g, a);
                d1011p.DDA_Line(g, a);
                d1112p.DDA_Line(g, a);
                d129p.DDA_Line(g, a);

            }


            // Ve mai nha
            //dt.MidpointLine(x1.X, x1.Y, x13.X, x13.Y, bmp, a);
            //dt.MidpointLine(x13.X, x13.Y, x4.X, x4.Y, bmp, a);

        }


        public void VeConCa(Point a, Point b, Point c, Point d, Point o, Graphics g, Color color)
        {
            //DuongTron dtr = new DuongTron();
            //ELip el = new ELip();
            Line dt1 = new Line(a.X, a.Y, c.X, c.Y, color);
            Line dt2 = new Line(b.X, b.Y, d.X, d.Y, color);
            Line dt3 = new Line(c.X, c.Y, d.X, d.Y, color);
            Line dt4 = new Line(a.X, a.Y, o.X, o.Y, color);
            Line dt5 = new Line(b.X, b.Y, o.X, o.Y, color);

            // ve khung ca
            dt1.DDA_Line(g, color);
            dt2.DDA_Line(g, color);
            dt3.DDA_Line(g, color);
            dt4.DDA_Line(g, color);
            dt5.DDA_Line(g, color);

            //dt2.MidpointLine(b.X, b.Y, d.X, d.Y, bmp, color);
            //dt3.MidpointLine(c.X, c.Y, d.X, d.Y, bmp, color);
            //dt4.MidpointLine(a.X, a.Y, o.X, o.Y, bmp, color);
            //dt5.MidpointLine(b.X, b.Y, o.X, o.Y, bmp, color);
            //el.HinhELip(o.X, o.Y, 25, 25, bmp, color);



        }

        Line d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12;
        public void VeKhungThanhSan(SolidBrush color, PaintEventArgs e)
        {
            DuongThang dth = new DuongThang();
            ELip el = new ELip();
            //Vẽ khung thành
            //Nhỏ
            dth.MidpointLine(900, 150, 800, 150, color, e);
            dth.MidpointLine(800, 150, 800, 550, color, e);
            dth.MidpointLine(800, 550, 900, 550, color, e);
            dth.MidpointLine(900, 150, 900, 550, color, e);
            //Lớn
            dth.MidpointLine(900, 125, 650, 125, color, e);
            dth.MidpointLine(650, 125, 650, 575, color, e);
            dth.MidpointLine(650, 575, 900, 575, color, e);
            dth.MidpointLine(900, 125, 900, 575, color, e);
            //Ngoài cùng
            dth.MidpointLine(900, 75, 500, 75, color, e);
            dth.MidpointLine(500, 75, 500, 625, color, e);
            dth.MidpointLine(500, 625, 900, 625, color, e);
            dth.MidpointLine(900, 75, 900, 625, color, e);

            for (int i = 150; i < 550; i += 10)
            {
                dth.MidpointLine(900, i, 800, i, color, e);
            }

            for (int i = 800; i < 900; i += 10)
            {
                dth.MidpointLine(i, 150, i, 550, color, e);
            }

            //vẽ nữa hình elip vào vạch sân

            el.NuaELip(500, 350, 60, 80, color, e);
            // 350,600

        }

    }
}
