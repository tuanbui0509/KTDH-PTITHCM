using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace KTDH
{
    public class ELip
    {
        public Point tam;
        public int a, b;

        public ELip()
        {

        }
        public ELip(int x1, int y1, int a, int b)
        {
            this.tam = new Point(x1, y1);
            this.a = a;
            this.b = b;

        }
        void Ve4diem(int xc, int yc, int x, int y, SolidBrush color, PaintEventArgs e)//ve 4 diem doi xung. xc, yc:tâm. x,y: x,y1 ở hàm dưới
        {

            //=================================Sua lai======================
            if (xc + x >= 0 && xc + x < 1018 && yc + y >= 0 && yc + y < 685) e.Graphics.FillRectangle(color, xc + x, yc + y, 5, 5); //phần 4
            if (xc - x >= 0 && xc - x < 1018 && yc + y >= 0 && yc + y < 685) e.Graphics.FillRectangle(color, xc - x, yc + y, 5, 5); // phần 3

            if (xc - x >= 0 && xc - x < 1018 && yc - y >= 0 && yc - y < 685) e.Graphics.FillRectangle(color, xc - x, yc - y, 5, 5); //phần 2
            if (xc + x >= 0 && xc + x < 1018 && yc - y >= 0 && yc - y < 685) e.Graphics.FillRectangle(color, xc + x, yc - y, 5, 5); //phần 1

        }
        public void HinhELip(int x, int y, int a, int b, SolidBrush color, PaintEventArgs e) // tâm x,y : rộng a, cao b;
        {
            float a2, b2;
            double p;
            int x1 = 0, y1 = b;
            a2 = a * a;
            b2 = b * b;

            if (x >= 0 && x < 1018 && y >= 0 && y < 685) e.Graphics.FillRectangle(color, x, y, 5, 5);
            Ve4diem(x, y, x1, y1, color, e);

            //ve nhanh thu 1(tu tren xuong )
            while (((float)b2 / a2) * x1 <= y1)
            {
                p = b2 * (x1 + 1) * (x1 + 1) + a2 * (y1 - 0.5) * (y1 - 0.5) - a2 * b2;
                if (p >= 0)
                {
                    y1--;
                }
                x1++;
                Ve4diem(x, y, x1, y1, color, e);
            }
            //ve nhanh thu 2(tu duoi len )
            y1 = 0;
            x1 = a;

            Ve4diem(x, y, x1, y1, color, e);
            // p = 2 * ((float)a2 / b2) - 2 * a + 1;
            while (((float)a2 / b2) * y1 <= x1)
            {
                p = b2 * (x1 - 0.5) * (x1 - 0.5) + a2 * (y1 + 1) * (y1 + 1) - a2 * b2;
                if (p >= 0)
                {
                    x1--;
                }
                y1++;
                Ve4diem(x, y, x1, y1, color, e);
            }
        }


        void Ve2diem(int xc, int yc, int x, int y, SolidBrush color, PaintEventArgs e)//ve 4 diem doi xung. xc, yc:tâm. x,y: x,y1 ở hàm dưới
        {
            if (xc - x >= 0 && xc - x < 1018 && yc - y >= 0 && yc - y < 685) e.Graphics.FillRectangle(color, xc - x, yc - y, 5, 5);

            if (xc - x >= 0 && xc - x < 1018 && yc + y >= 0 && yc + y < 685) e.Graphics.FillRectangle(color, xc - x, yc + y, 5, 5);


        }


        void Ve2diemtren(int xc, int yc, int x, int y, SolidBrush color, PaintEventArgs e)//ve 4 diem doi xung. xc, yc:tâm. x,y: x,y1 ở hàm dưới
        {
            if (xc - x >= 0 && xc - x < 1018 && yc - y >= 0 && yc - y < 685) e.Graphics.FillRectangle(color, xc - x, yc - y, 5, 5);
            if (xc + x >= 0 && xc + x < 1018 && yc - y >= 0 && yc - y < 685) e.Graphics.FillRectangle(color, xc + x, yc - y, 5, 5); //phần 1

        }
        public void NuaELip(int x, int y, int a, int b, SolidBrush color, PaintEventArgs e) // tâm x,y : rộng a, cao b;
        {
            float a2, b2;
            double p;
            int x1 = 0, y1 = b;
            a2 = a * a;
            b2 = b * b;

            if (x >= 0 && x < 1018 && y >= 0 && y < 685) e.Graphics.FillRectangle(color, x, y, 5, 5);
            Ve2diem(x, y, x1, y1, color, e);

            //ve nhanh thu 1(tu tren xuong )
            while (((float)b2 / a2) * x1 <= y1)
            {
                p = b2 * (x1 + 1) * (x1 + 1) + a2 * (y1 - 0.5) * (y1 - 0.5) - a2 * b2;
                if (p >= 0)
                {
                    y1--;
                }
                x1++;
                Ve2diem(x, y, x1, y1, color, e);
            }
            //ve nhanh thu 2(tu duoi len )
            y1 = 0;
            x1 = a;

            Ve2diem(x, y, x1, y1, color, e);
            // p = 2 * ((float)a2 / b2) - 2 * a + 1;
            while (((float)a2 / b2) * y1 <= x1)
            {
                p = b2 * (x1 - 0.5) * (x1 - 0.5) + a2 * (y1 + 1) * (y1 + 1) - a2 * b2;
                if (p >= 0)
                {
                    x1--;
                }
                y1++;
                Ve2diem(x, y, x1, y1, color, e);
            }
        }

        public void NuaELipTren(int x, int y, int a, int b, SolidBrush color, PaintEventArgs e) // tâm x,y : rộng a, cao b;
        {
            float a2, b2;
            double p;
            int x1 = 0, y1 = b;
            a2 = a * a;
            b2 = b * b;

            if (x >= 0 && x < 1018 && y >= 0 && y < 685) e.Graphics.FillRectangle(color, x, y, 5, 5);
            Ve2diemtren(x, y, x1, y1, color, e);

            //ve nhanh thu 1(tu tren xuong )
            while (((float)b2 / a2) * x1 <= y1)
            {
                p = b2 * (x1 + 1) * (x1 + 1) + a2 * (y1 - 0.5) * (y1 - 0.5) - a2 * b2;
                if (p >= 0)
                {
                    y1--;
                }
                x1++;
                Ve2diemtren(x, y, x1, y1, color, e);
            }
            //ve nhanh thu 2(tu duoi len )
            y1 = 0;
            x1 = a;

            Ve2diemtren(x, y, x1, y1, color, e);
            // p = 2 * ((float)a2 / b2) - 2 * a + 1;
            while (((float)a2 / b2) * y1 <= x1)
            {
                p = b2 * (x1 - 0.5) * (x1 - 0.5) + a2 * (y1 + 1) * (y1 + 1) - a2 * b2;
                if (p >= 0)
                {
                    x1--;
                }
                y1++;
                Ve2diemtren(x, y, x1, y1, color, e);
            }
        }
        public void NetDut(int x, int y, int a, int b, SolidBrush color, PaintEventArgs e) // tâm x,y : rộng a, cao b;
        {
            float a2, b2;
            double p;
            int x1 = 0, y1 = b;
            a2 = a * a;
            b2 = b * b;

            if (x >= 0 && x < 1018 && y >= 0 && y < 685) e.Graphics.FillRectangle(color, x, y, 5, 5);
            Ve4diem(x, y, x1, y1, color, e);

            //ve nhanh thu 1(tu tren xuong )
            while (((float)b2 / a2) * x1 <= y1)
            {
                p = b2 * (x1 + 1) * (x1 + 1) + a2 * (y1 - 0.5) * (y1 - 0.5) - a2 * b2;
                if (p >= 0)
                {
                    y1--;
                }
                x1++;
                Ve4diem(x, y, x1, y1, color, e);
            }
            //ve nhanh thu 2(tu duoi len )
            y1 = 0;
            x1 = a;

            Ve4diem(x, y, x1, y1, color, e);
            p = 2 * ((float)a2 / b2) - 2 * a + 1;
            while (((float)a2 / b2) * y1 <= x1)
            {
                p = b2 * (x1 - 0.5) * (x1 - 0.5) + a2 * (y1 + 1) * (y1 + 1) - a2 * b2;
                if (p >= 0)
                {
                    x1--;
                }
                y1++;
                Ve4diem(x, y, x1, y1, color, e);
            }
        }

        private void putpixel(int x, int y, Graphics grfx, Color c)
        {
            if (x < 0 || x > 900 || y < 0 || y > 900) return;
            Pen p = new Pen(c);
            SolidBrush b = new SolidBrush(c);
            grfx.DrawEllipse(p, x, y, 2, 2);
            grfx.FillEllipse(b, x, y, 2, 2);
            grfx.DrawEllipse(p, x - 2, y - 2, 2, 2);
            grfx.FillEllipse(b, x - 2, y - 2, 2, 2);
            grfx.DrawEllipse(p, x, y - 2, 2, 2);
            grfx.FillEllipse(b, x, y - 2, 2, 2);
            grfx.DrawEllipse(p, x - 2, y, 2, 2);
            grfx.FillEllipse(b, x - 2, y, 2, 2);

        }
        public int round(double tds)
        {
            int tdm;
            double sodu = tds % 5;
            if (sodu != 0)
            {
                if (sodu >= 3) tdm = (int)(tds + 5 - sodu);
                else tdm = (int)(tds - sodu);
            }
            else tdm = (int)tds;
            if (tdm > 400) tdm = 400;
            return tdm;
        }

        private void put4pitxel(int x, int y, int cx, int cy, Graphics m, Color c)
        {
            putpixel(x + cx, y + cy, m, c);
            putpixel(-x + cx, y + cy, m, c);
            putpixel(x + cx, -y + cy, m, c);
            putpixel(-x + cx, -y + cy, m, c);
        }
        public void Midpoint_elip(Graphics g, Color c)
        {
            int x, y, cx, cy, a, b;
            cx = tam.X; cy = tam.Y;
            a = this.a; b = this.b;

            x = 0; y = b;
            int A, B;
            A = a * a;
            B = b * b;
            double p = B + A / 4 - A * b;
            x = 0;
            y = b;
            int Dx = 0;
            int Dy = 2 * A * y;
            put4pitxel(x, y, cx, cy, g, c);

            while (Dx < Dy)
            {
                x++;
                Dx += 2 * B;
                if (p < 0)
                    p += B + Dx;
                else
                {
                    y--;
                    Dy -= 2 * A;
                    p += B + Dx - Dy;
                }
                //  putcolor1(s.round(x), s.round(y), cx, cy, m);
                if (x % 5 == 0) put4pitxel(x, round(y), cx, cy, g, c);


            }
            p = Math.Round(B * (x + 0.5f) * (x + 0.5f) + A * (y - 1) * (y - 1) - A * B);
            while (y > 0)
            {
                y--;
                Dy -= A * 2;
                if (p > 0)
                    p += A - Dy;
                else
                {
                    x++;
                    Dx += B * 2;
                    p += A - Dy + Dx;
                }
                ///  putcolor1(s.round(x), s.round(y), cx, cy, m);
                if (x % 5 == 0) put4pitxel(x, round(y), cx, cy, g, c);

            }

        }
        private void putpixel1(int x, int y, Graphics grfx, Color c)
        {
            if (x < 0 || x > 900 || y < 0 || y > 900) return;
            Pen p = new Pen(c);
            SolidBrush b = new SolidBrush(c);
            grfx.DrawEllipse(p, x, y, 1, 1);
        }

        private void put4pitxel1(int x, int y, int cx, int cy, Graphics m, Color c)
        {
            putpixel(x + cx, y + cy, m, c);
            putpixel(-x + cx, y + cy, m, c);
            putpixel1(x + cx, -y + cy, m, c);
            putpixel1(-x + cx, -y + cy, m, c);
        }

        public void Midpoint_elip1(Graphics g, Color c) // vẽ hình elip dưới có cả nét đứt 
        {
            int x, y, cx, cy, a, b;
            cx = tam.X; cy = tam.Y;
            a = this.a; b = this.b;

            x = 0; y = b;
            int A, B;
            A = a * a;
            B = b * b;
            double p = B + A / 4 - A * b;
            x = 0;
            y = b;
            int Dx = 0;
            int Dy = 2 * A * y;
            put4pitxel1(x, y, cx, cy, g, c);

            while (Dx < Dy)
            {
                x++;
                Dx += 2 * B;
                if (p < 0)
                    p += B + Dx;
                else
                {
                    y--;
                    Dy -= 2 * A;
                    p += B + Dx - Dy;
                }

                if (x % 5 == 0) put4pitxel1(x, round(y), cx, cy, g, c);


            }
            p = Math.Round(B * (x + 0.5f) * (x + 0.5f) + A * (y - 1) * (y - 1) - A * B);
            while (y > 0)
            {
                y--;
                Dy -= A * 2;
                if (p > 0)
                    p += A - Dy;
                else
                {
                    x++;
                    Dx += B * 2;
                    p += A - Dy + Dx;
                }

                if (x % 5 == 0) put4pitxel1(x, round(y), cx, cy, g, c);

            }

        }
        public static Point toado1(int x, int y)//lon ra nho
        {
            return (new Point(x / 5 - 40, 40 - y / 5));//voi x va y deu chia het cho 5
        }
        public static Point toado2(int x, int y)//nho ra lon
        {

            return (new Point(x * 5 + 200, 200 - 5 * y));
        }

        // nua hinh elip
        public void NetDut(int x, int y, int a, int b, Graphics g, Color cl) // tâm x,y : rộng a, cao b;
        {
            float a2, b2;
            double p;
            int x1 = 0, y1 = b;
            a2 = a * a;
            b2 = b * b;

            if (x >= 0 && x < 1018 && y >= 0 && y < 685) this.putpixel(x, y, g, cl);
            //Ve4diem(x, y, x1, y1, bmp, cl, true);
            put4pitxel(x, y, x1, y1, g, cl);

            //ve nhanh thu 1(tu tren xuong )
            while (((float)b2 / a2) * x1 <= y1)
            {
                p = b2 * (x1 + 1) * (x1 + 1) + a2 * (y1 - 0.5) * (y1 - 0.5) - a2 * b2;
                if (p >= 0)
                {
                    y1--;
                }
                x1++;
                put4pitxel(x, y, x1, y1, g, cl);

            }
            //ve nhanh thu 2(tu duoi len )
            y1 = 0;
            x1 = a;
            put4pitxel(x, y, x1, y1, g, cl);

            p = 2 * ((float)a2 / b2) - 2 * a + 1;
            while (((float)a2 / b2) * y1 <= x1)
            {
                p = b2 * (x1 - 0.5) * (x1 - 0.5) + a2 * (y1 + 1) * (y1 + 1) - a2 * b2;
                if (p >= 0)
                {
                    x1--;
                }
                y1++;
                put4pitxel(x, y, x1, y1, g, cl);

            }
        }
    }
}
