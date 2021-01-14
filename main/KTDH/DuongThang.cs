using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace KTDH
{

    //Vẽ đường thẳng
    class DuongThang
    {
        void HoanVi(ref int a, ref int b)
        {
            int t;
            t = a;
            a = b;
            b = t;
        }
        void MidpointLineXY(int x1, int y1, int x2, int y2, SolidBrush color, PaintEventArgs e, bool nd) //x++ , y++ Dx>=Dy 
        {
            if (x1 > x2)
            {
                HoanVi(ref x1, ref x2);
                HoanVi(ref y1, ref y2);
            }
            int x = x1, y = y1, Dy = y2 - y1; //Khoi tao các giá trị ban đầu
            if (x1 < 1018 && y1 < 685 && x1 >= 0 && y1 >= 0) e.Graphics.FillRectangle(color, x1, y1, 5, 5); // vẽ điểm pixel đầu tiên
            double p;
            float A = y2 - y1, B = -(x2 - x1), C = x2 * y1 - x1 * y2;
            while (x < x2)
            {
                if (y1 < y2 && Dy != 0) //Xét trục tọa độ theo hệ thống
                {
                    p = A * (x + 1) + B * (y + 0.5) + C;
                    if (p >= 0) y++; // chọn điểm yi+1
                }
                else if (y1 > y2 && Dy != 0) // y1>y2 trục toạ độ ngược
                {
                    p = A * (x + 1) + B * (y - 0.5) + C;
                    if (p <= 0) y--; // chọn yi-1
                }
                x++;
                if (x < 1018 && y < 685 && x >= 0 && y >= 0)
                {
                    if (nd == true && (x % 6 == 0 || (x + 1) % 6 == 0 || (x - 1) % 6 == 0)) e.Graphics.FillRectangle(color, x, y, 5, 5);
                    else e.Graphics.FillRectangle(color, x, y, 5, 5);
                }
            }
        }
        void MidpointLineYX(int x1, int y1, int x2, int y2, SolidBrush color, PaintEventArgs e, bool nd) //y++ , x++ Dy>Dx 
        {
            if (y1 > y2)
            {
                HoanVi(ref x1, ref x2);
                HoanVi(ref y1, ref y2);
            }
            int x = x1, y = y1, Dx = x2 - x1;
            if (x1 < 1018 && y1 < 685 && x1 >= 0 && y1 >= 0) e.Graphics.FillRectangle(color, x1, y1, 5, 5);
            double p;
            float A = y2 - y1, B = -(x2 - x1), C = x2 * y1 - x1 * y2;
            while (y < y2)
            {
                if (x1 < x2 && Dx != 0) // Đi xuống
                {
                    p = A * (x + 0.5) + B * (y + 1) + C;
                    if (p <= 0) x++;
                }
                else
                if (x1 > x2 && Dx != 0) // Đi lên
                {
                    p = A * (x - 0.5) + B * (y + 1) + C;
                    if (p >= 0) x--;
                }
                y++;
                if (x < 1018 && y < 685 && x >= 0 && y >= 0)
                {
                    if (nd == true && (y % 6 == 0 || (y + 1) % 6 == 0 || (y - 1) % 6 == 0)) e.Graphics.FillRectangle(color, x, y, 5, 5);
                    else e.Graphics.FillRectangle(color, x, y, 5, 5);
                }
            }
        }
        public void MidpointLine(int x1, int y1, int x2, int y2, SolidBrush color, PaintEventArgs e)
        {
            int Dx = Math.Abs(x2 - x1), Dy = Math.Abs(y2 - y1);

            if (Dx >= Dy) MidpointLineXY(x1, y1, x2, y2, color, e, false);
            else if (Dx < Dy) MidpointLineYX(x1, y1, x2, y2, color, e, false);
        }
        public void NetDut(int x1, int y1, int x2, int y2, SolidBrush color, PaintEventArgs e)
        {
            int Dx = Math.Abs(x2 - x1), Dy = Math.Abs(y2 - y1);

            if (Dx >= Dy) MidpointLineXY(x1, y1, x2, y2, color, e, true);
            else if (Dx < Dy) MidpointLineYX(x1, y1, x2, y2, color, e, true);
        }

        void MidpointLineXY3D(int x1, int y1, int x2, int y2, SolidBrush color, PaintEventArgs e, bool nd) //x++ , y++ Dx>=Dy 
        {
            if (x1 > x2)
            {
                HoanVi(ref x1, ref x2);
                HoanVi(ref y1, ref y2);
            }
            int x = x1, y = y1, Dy = y2 - y1; //Khoi tao các giá trị ban đầu
            if (x1 < 1018 && y1 < 685 && x1 >= 0 && y1 >= 0) e.Graphics.FillRectangle(color, x1, y1,1,1); // vẽ điểm pixel đầu tiên
            double p;
            float A = y2 - y1, B = -(x2 - x1), C = x2 * y1 - x1 * y2;
            while (x < x2)
            {
                if (y1 < y2 && Dy != 0) //Xét trục tọa độ theo hệ thống
                {
                    p = A * (x + 1) + B * (y + 0.5) + C;
                    if (p >= 0) y++; // chọn điểm yi+1
                }
                else if (y1 > y2 && Dy != 0) // y1>y2 trục toạ độ ngược
                {
                    p = A * (x + 1) + B * (y - 0.5) + C;
                    if (p <= 0) y--; // chọn yi-1
                }
                x++;
                if (x < 1018 && y < 685 && x >= 0 && y >= 0)
                {
                    if (nd == true && (x % 6 == 0 || (x + 1) % 6 == 0 || (x - 1) % 6 == 0)) e.Graphics.FillRectangle(color, x, y,1,1);
                    else e.Graphics.FillRectangle(color, x, y,1,1);
                }
            }
        }
        void MidpointLineYX3D(int x1, int y1, int x2, int y2, SolidBrush color, PaintEventArgs e, bool nd) //y++ , x++ Dy>Dx 
        {
            if (y1 > y2)
            {
                HoanVi(ref x1, ref x2);
                HoanVi(ref y1, ref y2);
            }
            int x = x1, y = y1, Dx = x2 - x1;
            if (x1 < 1018 && y1 < 685 && x1 >= 0 && y1 >= 0) e.Graphics.FillRectangle(color, x1, y1, 1, 1);
            double p;
            float A = y2 - y1, B = -(x2 - x1), C = x2 * y1 - x1 * y2;
            while (y < y2)
            {
                if (x1 < x2 && Dx != 0) // Đi xuống
                {
                    p = A * (x + 0.5) + B * (y + 1) + C;
                    if (p <= 0) x++;
                }
                else
                if (x1 > x2 && Dx != 0) // Đi lên
                {
                    p = A * (x - 0.5) + B * (y + 1) + C;
                    if (p >= 0) x--;
                }
                y++;
                if (x < 1018 && y < 685 && x >= 0 && y >= 0)
                {
                    if (nd == true && (y % 6 == 0 || (y + 1) % 6 == 0 || (y - 1) % 6 == 0)) e.Graphics.FillRectangle(color, x, y, 1, 1);
                    else e.Graphics.FillRectangle(color, x, y, 1, 1);
                }
            }
        }

        public void NetDut3D(int x1, int y1, int x2, int y2, SolidBrush color, PaintEventArgs e)
        {
            int Dx = Math.Abs(x2 - x1), Dy = Math.Abs(y2 - y1);

            if (Dx >= Dy) MidpointLineXY3D(x1, y1, x2, y2, color, e, true);
            else if (Dx < Dy) MidpointLineYX3D(x1, y1, x2, y2, color, e, true);
        }

    }
}

