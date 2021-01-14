using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace KTDH
{
    public class Line
    {
        private Point diemdau;
        private Point diemcuoi;
        private Color mau;
        public double hesogoc, b1;
        public int b;

        public Point getdiemdau()
        {
            return this.diemdau;
        }

        public Point getdiemcuoi()
        {
            return this.diemcuoi;
        }

        public void setdiemcuoi(Point a)
        {
            this.diemcuoi = a;

        }
        public void setdiemdau(Point a)
        {
            this.diemdau = a;
        }
        public Color getmau()
        {
            return this.mau;
        }

        public void setmau(Color a)
        {
            this.mau = a;

        }


        public Line(int x1, int y1, int x2, int y2, Color m)
        {
            diemdau = new Point(x1, y1);
            diemcuoi = new Point(x2, y2);
            mau = m;
        }
        private void putpixel(int x, int y, Graphics grfx, Color c)
        {
            if (x < 0 || x > 1920 || y < 0 || y > 1080) return;
            Pen p = new Pen(c);
            SolidBrush b = new SolidBrush(c);// Brush dùng để tô vùng bên trong của một hình 
            // Lớp Brush là một lớp Abstract • Các lớp kế thừ từ lớp Brush 
            //Một Solid Brush là một brush dùng để tô một vùng với một màu đơn.
            grfx.DrawRectangle(p, x, y, 2,2);
            grfx.FillRectangle(b, x, y, 2,2);
            grfx.DrawRectangle(p, x - 2, y - 2,2, 2);
            grfx.FillRectangle(b, x - 2, y - 2,2, 2);
            grfx.DrawRectangle(p, x, y - 2,2, 2);
            grfx.FillRectangle(b, x, y - 2,2, 2);
            grfx.DrawRectangle(p, x - 2, y, 2,2);
            grfx.FillRectangle(b, x - 2, y, 2,2);

        }

        private void putpixel(int x, int y, Graphics grfx)
        {
            if (x < 0 || x > 1920 || y < 0 || y > 1080) return;
            Pen p = new Pen(Color.Black);
            SolidBrush b = new SolidBrush(Color.Black);// Brush dùng để tô vùng bên trong của một hình 
            // Lớp Brush là một lớp Abstract • Các lớp kế thừ từ lớp Brush 
            //Một Solid Brush là một brush dùng để tô một vùng với một màu đơn.
            grfx.DrawRectangle(p, x, y, 2,2);
            grfx.FillRectangle(b, x, y, 2,2);
            grfx.DrawRectangle(p, x - 2, y - 2,2, 2);
            grfx.FillRectangle(b, x - 2, y - 2,2, 2);
            grfx.DrawRectangle(p, x, y - 2,2, 2);
            grfx.FillRectangle(b, x, y - 2,2, 2);
            grfx.DrawRectangle(p, x - 2, y, 2,2);
            grfx.FillRectangle(b, x - 2, y, 2,2);
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
            if (tdm > 900) tdm = 900;
            return tdm;
        }
        public void DDA_Line(Graphics g, Color c) // Ve duong thang co dinh dang mau
        {
            Color m = mau;
            int Dx, Dy, count, temp_1, temp_2, dem = 1;
            //int temp_3, temp_4;
            Dx = diemcuoi.X - diemdau.X;
            Dy = diemcuoi.Y - diemdau.Y;
            if (Math.Abs(Dy) > Math.Abs(Dx)) count = Math.Abs(Dy);
            else count = Math.Abs(Dx);
            float x, y, delta_X, delta_Y;
            if (count > 0)
            {
                delta_X = Dx;
                delta_X /= count;
                delta_Y = Dy;
                delta_Y /= count;
                x = diemdau.X;
                y = diemdau.Y;
                do
                {
                    temp_1 = round(x);
                    temp_2 = round(y);
                    putpixel(temp_1, temp_2, g, c);
                    // temp_3 = temp_1;
                    // temp_4 = temp_2;
                    x += delta_X;
                    y += delta_Y;
                    --count;
                    dem++;
                } while (count != -1);

            }
        }
        private void putpixel1(int x, int y, Graphics grfx, Color c)
        {
            if (x < 0 || x > 1920 || y < 0 || y > 1080) return;
            Pen p = new Pen(c);
            SolidBrush b = new SolidBrush(c);
            grfx.DrawRectangle(p, x, y, 2,2);

        }
        public void DDA_Line1(Graphics g, Color c) // Ve duong thang co dinh dang mau
        {
            Color m = mau;
            int Dx, Dy, count, temp_1, temp_2, dem = 1;
            //int temp_3, temp_4;
            Dx = diemcuoi.X - diemdau.X;
            Dy = diemcuoi.Y - diemdau.Y;
            if (Math.Abs(Dy) > Math.Abs(Dx)) count = Math.Abs(Dy);
            else count = Math.Abs(Dx);
            float x, y, delta_X, delta_Y;
            if (count > 0)
            {
                delta_X = Dx;
                delta_X /= count;
                delta_Y = Dy;
                delta_Y /= count;
                x = diemdau.X;
                y = diemdau.Y;
                do
                {

                    temp_1 = round(x);
                    temp_2 = round(y);

                    putpixel1(temp_1, temp_2, g,c);

                    x += delta_X;
                    y += delta_Y;
                    --count;
                    dem++;
                } while (count != -1);

            }
        }
        public static Point toado1(int x, int y)//lon ra nho
        {
            return (new Point(x / 5 - 40, 40 - y / 5));//voi x va y deu chia het cho 5
        }
        public static Point toado2(int x, int y)//nho ra lon
        {

            return (new Point(x * 5 + 500, 350 - 5 * y));
        }
    }
}
