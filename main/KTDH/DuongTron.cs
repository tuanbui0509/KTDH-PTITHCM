using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTDH
{
    class DuongTron
    {
        public int tdx, tdy, bk;
        public HT ht;
        void Ve8Diem(int x, int y, int x1, int y1, int r, Bitmap bmp, Color a)
        {
            //trục tọa độ x của máy và thực giống nhau, nhưng trục y thì ngược lại, đi xuống là chiều dương
            if (y - y1 >= 0 && y - y1 < 685 && x + x1 < 1018 && x + x1 >= 0) bmp.SetPixel(x + x1, y - y1, a);
            //trên phải, y+, x+ , do lấy tọa độ là góc trên trái của cửa sổ ; y+ do y1 là trừ dần
            if ((y + y1 < 685) && (x + x1 < 1018) && (y + y1 >= 0) && (x + x1 >= 0)) bmp.SetPixel(x + x1, y + y1, a);
            // dưới phải x+, y-: y- là do y1 trừ dần
            if ((x - x1) >= 0 && (y + y1) < 685 && (x - x1) < 1018 && (y + y1) >= 0) bmp.SetPixel(x - x1, y + y1, a); // dưới trái , x- , y-
            if (x - x1 >= 0 && y - y1 >= 0 && y - y1 < 685 && x - x1 < 1018) bmp.SetPixel(x - x1, y - y1, a);    // trên trái, x-, y+

            if ((y - x1 >= 0) && (x + y1 < 1018) && y - x1 < 685 && (x + y1 >= 0)) bmp.SetPixel(x + y1, y - x1, a); //phải trên x- , y-
            if (x + y1 < 1018 && y + x1 < 685 && x + y1 >= 0 && y + x1 >= 0) bmp.SetPixel(x + y1, y + x1, a); //phải dưới x-, y+
            if (x - y1 >= 0 && y + x1 < 685 && x - y1 < 1018 && y + x1 >= 0) bmp.SetPixel(x - y1, y + x1, a);   //trái dưới x+, y+
            if (x - y1 >= 0 && y - x1 >= 0 && y - x1 < 685 && x - y1 < 1018) bmp.SetPixel(x - y1, y - x1, a); // trái trên x+, y-

        }

        public void MidpointDuongTron(int x, int y, int r, Bitmap bmp, Color a)
        {
            int x1 = 0, y1 = r;
            double p;
            Ve8Diem(x, y, x1, y1, r, bmp, a);
            if (x < 1018 && y < 685 && x >= 0 && y >= 0) bmp.SetPixel(x, y, a); // tâm hình tròn, vượt quá kích thước cửa sổ thì k vẽ 
            while (x1 < ((r * Math.Sqrt(2)) / 2)) // Vẽ 1/8 đường tròn 
            {
                x1++;
                p = (x1) * (x1) + (y1 - 0.5) * (y1 - 0.5) - r * r;
                if (p >= 0) y1--; //y1 là điểm trên cùng của đtr, p>=0 thì trừ theo thuật toán
                Ve8Diem(x, y, x1, y1, r, bmp, a);
            }
        }

        public void MidpointNuaDuongTron(int x, int y, int r, Bitmap bmp, Color a)
        {
            int x1 = 0, y1 = r;
            double p;
            Ve8Diem(x, y, x1, y1, r, bmp, a);
            if (x < 1018 && y < 685 && x >= 0 && y >= 0) bmp.SetPixel(x, y, a); // tâm hình tròn, vượt quá kích thước cửa sổ thì k vẽ 
            int i = 0;
            while (x1 < ((r * Math.Sqrt(2)) / 2)) // Vẽ 1/8 đường tròn 
            {
                if (i == 10)
                {
                    break;
                }
                x1++;
                p = (x1) * (x1) + (y1 - 0.5) * (y1 - 0.5) - r * r;
                if (p >= 0) y1--; //y1 là điểm trên cùng của đtr, p>=0 thì trừ theo thuật toán
                Ve8Diem(x, y, x1, y1, r, bmp, a);
                i++;
            }
        }
    }
}
