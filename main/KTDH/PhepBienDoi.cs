using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTDH
{
    class PhepBienDoi
    {
        public Point TinhTien(int x, int y, int trx, int tryy) // x,y điểm cần tịnh tiến// trx, try khoảng cách tịnh tiến theo 2 chiều
        {
            Point a = new Point();
            int[] h = new int[3]; h[0] = h[1] = h[2] = 0;
            int[] b = new int[3]; b[0] = x; b[1] = y; b[2] = 1;
            int[,] c = new int[3, 3];
            c[0, 0] = 1; c[0, 1] = 0; c[0, 2] = 0;
            c[1, 0] = 0; c[1, 1] = 1; c[1, 2] = 0;
            c[2, 0] = trx; c[2, 1] = tryy; c[2, 2] = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    h[i] += (b[j] * c[j, i]);
                }
            }
            a.X = h[0]; a.Y = h[1];
            return a;
        }
        public Point Quay(int x, int y, int tamx, int tamy, double goc) //x,y: điểm cần quay. tamx,tamy: tâm của phép quay
        {
            int x1 = x - (tamx + 500), y1 = y - (tamy + 350);  // Đưa tâm quay về góc trái trên của màn hình
                                                               // lấy khoảng cách từ điểm đến tâm để nhân với ma trận, 
                                                               //nếu k trừ sẽ lấy tâm là góc trái trên của tọa độ máy tính            
            Point a = new Point();
            int[] h = new int[3]; h[0] = h[1] = h[2] = 0;
            int[] b = new int[3]; b[0] = x1; b[1] = y1; b[2] = 1;
            double[,] c = new double[3, 3];
            goc = Math.PI * goc / 180;
            c[0, 0] = Math.Cos(goc); c[0, 1] = Math.Sin(goc); c[0, 2] = 0;
            c[1, 0] = -Math.Sin(goc); c[1, 1] = Math.Cos(goc); c[1, 2] = 0;
            c[2, 0] = 0; c[2, 1] = 0; c[2, 2] = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    decimal ta = Math.Round((decimal)(b[j] * c[j, i]));
                    h[i] += (int)ta;
                }
            }
            a.X = h[0] + tamx + 500; a.Y = h[1] + tamy + 350;     // cộng lại với tọa độ tâm sẽ được điểm sau khi quay.
            return a;
        }
        public Point TyLe(int x, int y, int trx, int tryy, int trx1, int tryy1)
        // x,y điểm cần Phóng// trx, try hệ số phóng to (âm là thu nhỏ) //trx1,tryy1: vị trí gốc của hình sau khi biến đổi
        {
            Point a = new Point();
            int[] h = new int[3]; 
            h[0] = h[1] = h[2] = 0;
            tryy = -tryy; // trục y của máy tính ngược với trục y của người dùng
            int[] b = new int[3]; 
            b[0] = x - trx1; 
            b[1] = y - tryy1; b[2] = 1;
            int[,] c = new int[3, 3];
            c[0, 0] = trx; c[0, 1] = 0; c[0, 2] = 0;
            c[1, 0] = 0; c[1, 1] = tryy; c[1, 2] = 0;
            c[2, 0] = 0; c[2, 1] = 0; c[2, 2] = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    h[i] += (b[j] * c[j, i]);
                }
            }
            if (trx < 0)
            {
                h[0] /= trx; h[0] /= trx; h[0] = -h[0];
            }
            if (tryy < 0)
            {
                h[1] /= tryy; h[1] /= tryy; h[1] = -h[1];
            }
            a.X = h[0] + trx1; a.Y = h[1] + tryy1;
            return a;
        }
        public Point DoiXung(int x, int y, int x1, int y1, int x2, int y2) //x,y :điểm cần đối xứng //x1,y1 x2,y2: trục đối xứng
        {
            Point a = new Point();
            if (x2 == 0 && y2 == 0)
            {
                x -= 500; y -= 350;
                if (x1 == 0 && y1 == 0) // gốc tọa độ
                {
                    a.X = -x; a.Y = -y;
                }
                else if (x1 == 0 && y1 != 0) // trục tung
                {
                    a.X = -x; a.Y = y;
                }
                else if (x1 != 0 && y1 == 0) // trục hoành
                {
                    a.X = x; a.Y = -y;
                }
                else //đường thẳng bất kỳ qua gốc tọa độ trừ 2 trục chính 
                {
                    x += 500; y += 350;     //cộng lại để đưa vào phép quay, do ở trên trừ mất rồi :((
                    double acb;
                    y1 = -y1;   //Lấy đúng giá trị của y1 để tính góc. Ở VeHinhCoBan lấy -y1 để phục vụ các phép đx khác
                    acb = Math.Atan((float)y1 / x1);
                    acb = acb * 180 / (Math.PI);
                    a = Quay(x, y, 0, 0, acb);  //Phép quay là lấy đúng tọa độ của điểm
                    a.X -= 500; a.Y -= 350; //Lấy tọa độ người dùng để đối xứng
                    a.Y = -a.Y;             //Do quay về trùng Ox, nên đối xứng qua Ox
                    a.X += 500; a.Y += 350;     //Cộng lại tọa độ thưc.
                    a = Quay(a.X, a.Y, 0, 0, -acb);
                    a.X -= 500; a.Y -= 350; //Quay xong trừ lại, do ở dưới nó cộng kìa :((
                }
                a.X += 500; a.Y += 350;
            }
            else
            {
                if (x1 == 0 && y1 == 0) //Đối xứng qua 1 điểm
                {
                    //y2 = -y2; //trục y ngược chiều dương
                    x2 *= 10; y2 *= 10; //ban đầu là hệ tọa độ người dùng, x10 để quy đổi thành hệ tọa độ của máy 
                    x2 += 500; y2 += 350;   //Tâm đối xứng lúc đầu là do người dùng nhập vào. Nó thuộc tọa độ người dùng.
                                            //Cộng với tâm của trục tọa độ sẽ ra tọa độ chính xác của điểm đó theo tọa độ máy. 
                    x -= x2; y -= y2;   // Đưa  về góc trái trên màn hình để thực hiện đối xứng. 
                                        //(Đưa phép đối xứng về đối xứng qua gốc tọa độ)
                    a.X = -x; a.Y = -y; //
                    a.X += x2; a.Y += y2; //Ssau  khi đối xứng xong tịnh tiến về lại vị trí thực.                    
                }
                else
                {
                    y1 = -y1;   ////
                    y2 = -y2;   //Phần Vecoban cho nó ngược dấu mất rồi. Nên phải đưa nó về lại đúng ban đầu để tính
                    float kcOx = 0, kcOy = 0;
                    double acb;
                    if (y1 == y2 && x1 != x2) // song song Ox
                    {
                        y1 = -y1;   // y1 > 0 thì mình cộng đoạn y1 nó sẽ về trùng trục Ox(do ở dưới làm phép trừ :)))
                        kcOy = y1 * 10;       //đưa về đơn vị của máy tính. (người dùng 1dv = 10px máy)
                        acb = 0;        //góc quay = 0. Do song song Ox.
                    }
                    else if (x1 == x2 && y1 != y2)   //Song song Oy
                    {
                        kcOx = x1 * 10;
                        acb = 90;           // vuông góc Ox.
                    }
                    else if (y1 != 0 && y2 != 0 && ((float)(x1) / y1 == (float)(x2) / y2))     //Đi qua tâm O
                    {
                        acb = Math.Atan((float)y1 / x1);    //tìm góc quay
                        acb = acb * 180 / (Math.PI);
                    }
                    else
                    {
                        x1 *= 10; x2 *= 10; y1 *= 10; y2 *= 10; //chuyển về pixel thực
                        int A = y2 - y1, B = x1 - x2, C = x2 * y1 - x1 * y2;
                        kcOy = (float)(-C / B); kcOx = 0;   // Khoảng cách từ đt đến gốc O là x = 0, y = kcOy; Thay x = 0 vào -> y
                                                            //kcOy = -kcOy;       // y ngược dương, nên cộng thành trừ và ngc lại 

                        y1 -= (int)kcOy;
                        y2 -= (int)kcOy;   //tịnh tiến đt để đt đi qua gốc O 
                        A = y2 - y1; B = x1 - x2; C = x2 * y1 - x1 * y2;
                        float y3 = (float)(-A * 2 - C) / B; // tìm tọa độ y3, tại x3 = 2 của đt sau khi tịnh tiến để tìm góc.
                        acb = Math.Atan((float)y3 / 2);       // tìm góc của đt với trục Ox. y3/x3, x3 = 2;
                        acb = acb * 180 / (Math.PI);        // chuyển radian
                    }
                    float xv = x, yv = y;
                    xv += kcOx; yv += kcOy;
                    a = Quay((int)xv, (int)yv, 0, 0, acb);  //Phép quay là lấy đúng tọa độ của điểm
                    a.X -= 500; a.Y -= 350; //Lấy tọa độ thực để đối xứng
                    a.Y = -a.Y;             //Do quay về trùng Ox, nên đối xứng qua Ox
                    a.X += 500; a.Y += 350;     //Cộng lại tọa độ thưc.
                    a = Quay(a.X, a.Y, 0, 0, -acb);
                    a.X -= (int)kcOx; a.Y -= (int)kcOy;
                }
            }
            return a;
        }

        public Point mutiply(double[] a, double[,] b)
        {
            /*double[] c = new double[3] { 0, 0, 0 };
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    c[i] += a[j] * b[j, i];
            return new Point((int)Math.Round(c[0]), (int)Math.Round(c[1]));*/

            return new Point((int)Math.Round(a[0] * b[0, 0] + a[1] * b[1, 0] + a[2] * b[2, 0]),
                (int)Math.Round(a[0] * b[0, 1] + a[1] * b[1, 1] + a[2] * b[2, 1]));
        }

        public Point rotate(Point p, double gocQuay)
        {
            double[,] a = new double[3, 3] { { Math.Cos(Math.PI * gocQuay / 180),  Math.Sin(Math.PI * gocQuay / 180), 0 },
                                             { -Math.Sin(Math.PI * gocQuay / 180),   Math.Cos(Math.PI * gocQuay / 180) , 0 },
                                             { 0,  0, 1} };
            double[] b = new double[3] { p.X, p.Y, 1 };
            return mutiply(b, a);
        }

        public Point rotate(Point p, Point q, double gocQuay) // quay p quanh q
        {
            return tinhTien(rotate(tinhTien(p, -q.X, -q.Y), gocQuay), q.X, q.Y);
        }

        public Point tinhTien(Point p, int dx, int dy)
        {
            double[] a = new double[3] { p.X, p.Y, 1 };

            double[,] b = new double[3, 3] { { 1,  0 , 0 },
                                             { 0,  1 , 0 },
                                             { dx,  dy, 1} };
            return mutiply(a, b);
        }
    }
}
