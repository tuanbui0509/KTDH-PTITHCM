using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace KTDH
{
    public class HT
    {
        public int bkinh;
        public Point tam;
        public Color mau;
        public int b;

        public Point getdiemdau()
        {
            return this.tam;
        }
        public void setdiemcuoi(Point a)
        {
            this.tam = a;

        }
        public HT(int x1, int y1, int r)
        {
            tam = new Point(x1, y1);
            bkinh = r;

        }
        private void putpixel(int x, int y, Graphics grfx, Color c)
        {
            if (x < 0 || x > 1200 || y < 0 || y > 900) return;
            Pen p = new Pen(c);
            SolidBrush b = new SolidBrush(c);
            grfx.DrawRectangle(p, x, y, 2, 2);
            grfx.FillRectangle(b, x, y, 2, 2);
            grfx.DrawRectangle(p, x - 2, y - 2, 2, 2);
            grfx.FillRectangle(b, x - 2, y - 2, 2, 2);
            grfx.DrawRectangle(p, x, y - 2, 2, 2);
            grfx.FillRectangle(b, x, y - 2, 2, 2);
            grfx.DrawRectangle(p, x - 2, y, 2, 2);
            grfx.FillRectangle(b, x - 2, y, 2, 2);

        }

        private void put8pitxel(int x, int y, int cx, int cy, Graphics m, Color c)
        {
            putpixel(cx + x, cy + y, m, c);
            putpixel(cx + x, cy - y, m, c);
            putpixel(cx - x, cy + y, m, c);
            putpixel(cx - x, cy - y, m, c);
            putpixel(cx + y, cy + x, m, c);
            putpixel(cx + y, cy - x, m, c);
            putpixel(cx - y, cy + x, m, c);
            putpixel(cx - y, cy - x, m, c);
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

        public void Midpoint_htron(Graphics g, Color c)
        {
            int x, y, cx, cy, p, R;
            Color m = this.mau;
            cx = this.tam.X; cy = this.tam.Y;
            x = 0;
            y = R = this.bkinh;
            int maxX = round((float)(Math.Sqrt(2) / 2 * R));// x nằm trong khoảng từ 0 đến căn 2 chia 2
            // int maxX = Math.Sqrt(2) / 2 * R;
            p = 1 - R;
            put8pitxel(x, y, cx, cy, g, c);
            while (x <= maxX)
            {
                if (p < 0) p += 2 * x + 3;
                else { p += 2 * (x - y) + 5; y -= 5; }
                x += 5;
                put8pitxel(x, y, cx, cy, g, c);
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
