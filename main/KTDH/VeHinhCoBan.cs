using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Math;
using System.Windows.Forms;

namespace KTDH
{
    public partial class VeHinhCoBan : Form
    {
        public VeHinhCoBan()
        {
            InitializeComponent();
        }

        //int init = 10;

        int TrucToaDo = 0;
        bool veHinh1 = false, veHinh2 = false, chDong1 = false, chDong2 = false, veHHCN = false, veHinhTru = false;
        int biendoiCD = 0, phepbiendoi = 0; bool bienDoi = false;
        bool quaoy = false, quaox = false, quao = false;
        int Demquaoy = 0, Demquaox = 0, Demquao = 0;
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        void Truc2D(PaintEventArgs e)
        {
            //Luoi pixel
            for (int i = 5; i < 900; i += 5)
            {
                e.Graphics.DrawLine(Pens.Gray, 0, i, 900, i);
            }

            for (int i = 5; i < 900; i += 5)
            {
                e.Graphics.DrawLine(Pens.Gray, i, 0, i, 900);
            }
            //=======================================
            e.Graphics.DrawLine(Pens.Black, 10, 350, 1000, 350); //trục Ox (,x1(điểm giữa màn hình),độ dài trục x,x2)
            e.Graphics.DrawLine(Pens.Black, 995, 345, 1000, 350);
            e.Graphics.DrawLine(Pens.Black, 995, 355, 1000, 350); //mũi tên dưới

            e.Graphics.DrawLine(Pens.Black, 500, 1, 500, 680); //trục Oy
            e.Graphics.DrawLine(Pens.Black, 495, 6, 500, 1);
            e.Graphics.DrawLine(Pens.Black, 505, 6, 500, 1);
            for (int i = 0; i < 980; i += 5)   //chia vạch
                e.Graphics.DrawLine(Pens.Black, 20 + i, 347, 20 + i, 353);

            for (int i = 0; i < 670; i += 5)
                e.Graphics.DrawLine(Pens.Black, 497, 10 + i, 503, 10 + i);
        }
        void XoaTruc2D(PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.White, 10, 350, 1000, 350); //trục Ox
            e.Graphics.DrawLine(Pens.White, 995, 345, 1000, 350);
            e.Graphics.DrawLine(Pens.White, 995, 355, 1000, 350);

            e.Graphics.DrawLine(Pens.White, 500, 1, 500, 680); //trục Oy
            e.Graphics.DrawLine(Pens.White, 495, 6, 500, 1);
            e.Graphics.DrawLine(Pens.White, 505, 6, 500, 1);
            for (int i = 0; i < 980; i += 5)   //chia vạch
                e.Graphics.DrawLine(Pens.White, 20 + i, 347, 20 + i, 353);

            for (int i = 0; i < 670; i += 5)
                e.Graphics.DrawLine(Pens.White, 497, 10 + i, 503, 10 + i);
        }

        void XoaTruc2DHinh1(PaintEventArgs e, Pen color)
        {
            e.Graphics.DrawLine(color, 10, 350, 1000, 350); //trục Ox
            e.Graphics.DrawLine(color, 995, 345, 1000, 350);
            e.Graphics.DrawLine(color, 995, 355, 1000, 350);

            e.Graphics.DrawLine(color, 500, 1, 500, 680); //trục Oy
            e.Graphics.DrawLine(color, 495, 6, 500, 1);
            e.Graphics.DrawLine(color, 505, 6, 500, 1);
            for (int i = 0; i < 980; i += 5)   //chia vạch
                e.Graphics.DrawLine(color, 20 + i, 347, 20 + i, 353);

            for (int i = 0; i < 670; i += 5)
                e.Graphics.DrawLine(color, 497, 10 + i, 503, 10 + i);
        }

        void ToaDoDiemNguoi(bool a)
        {
            diemA.Visible = diemB.Visible = diemC.Visible = diemD.Visible = diemE.Visible = diemF.Visible = diemG.Visible = a; // Hiển thị tọa độ ơ hình vẽ
            toadoA.Visible = toadoB.Visible = toadoC.Visible = toadoD.Visible = toadoE.Visible = toadoF.Visible = toadoG.Visible = a; // Hiển thị độ

        }

        void ToaDoDiem(bool a, bool b)
        {
            diemA.Visible = diemB.Visible = diemC.Visible = diemD.Visible = diemE.Visible = diemF.Visible = diemG.Visible
                = diemH.Visible = diemI.Visible = diemJ.Visible = diemK.Visible = diemL.Visible = diemM.Visible
                = diemN.Visible = diemO.Visible = diemP.Visible = diemQ.Visible = diemR.Visible = diemS.Visible = diemT.Visible
                = diemU.Visible = a; // Hiển thị tọa độ ơ hình vẽ
            toadoA.Visible = toadoB.Visible = toadoC.Visible = toadoD.Visible = toadoE.Visible = toadoF.Visible = toadoG.Visible = toadoH.Visible =
                toadoI.Visible = toadoJ.Visible = toadoK.Visible = toadoL.Visible = toadoM.Visible = toadoN.Visible = toadoO.Visible =
                toadoP.Visible = toadoQ.Visible = toadoR.Visible = toadoS.Visible = toadoT.Visible = toadoU.Visible = b; // Hiển thị độ
        }

        void ChiaDoDo2D(bool b)
        {
            t1.Visible = t2.Visible = t3.Visible = t4.Visible = t5.Visible = t6.Visible = t7.Visible = t8.Visible =
                t9.Visible = t10.Visible = t11.Visible = t12.Visible = t13.Visible = t14.Visible = t15.Visible = t16.Visible
                = t17.Visible = t18.Visible = t19.Visible = t20.Visible = t21.Visible = t22.Visible = t23.Visible =
                t24.Visible = t25.Visible = t26.Visible = t27.Visible = t28.Visible = t29.Visible = t30.Visible = t31.Visible
                 = t32.Visible = t33.Visible = b; // chia độ cho trục oxy
        }
        void ChiaDoDo3D(bool b)
        {
            t1.Visible = t2.Visible = t3.Visible = t4.Visible = t5.Visible = t6.Visible = t7.Visible = t8.Visible =
                t9.Visible = t10.Visible = t11.Visible = t12.Visible = t13.Visible = t14.Visible = t15.Visible = t16.Visible
                = t17.Visible = t18.Visible = t19.Visible = t20.Visible = t21.Visible = t22.Visible = t23.Visible =
                t24.Visible = t25.Visible = t26.Visible = t27.Visible = t28.Visible = t29.Visible = t30.Visible = t31.Visible
                = t32.Visible = t33.Visible = t34.Visible = t35.Visible = t36.Visible = t37.Visible =
                t38.Visible = t39.Visible = t40.Visible = t40.Visible = t41.Visible = t42.Visible =
                t43.Visible = t44.Visible = t45.Visible = t46.Visible = b;
        }


        //click vào ô 2D
        private void Ve2D_Click(object sender, EventArgs e)
        {
            bienDoi = false;
            chuyenDong1.Visible = chuyenDong2.Visible = tinhTienCon1.Visible = thucHienBienDoi.Visible
                = x1cd.Visible = y1cd.Visible = gocQuayCD.Visible = goc1CD.Visible = tinhTienCon2.Visible
                = x2cd.Visible = y2cd.Visible = chDong1 = chDong2 = veHinh1 = veHinh2 = false;
            biendoiCD = phepbiendoi = 0;
            tinhTienCD.Visible = quayCD.Visible = doiXungCD.Visible = tyLeCD.Visible = false;
            thongTinToaDo1.Visible = thongTinToaDo2.Visible = thongTinToaDo3.Visible = thongTinToaDo4.Visible = thongTinToaDo5.Visible
                = thongTinToaDo6.Visible = thongTinToaDo7.Visible = false;
            toadoX_3D.Visible = toadoY_3D.Visible = toadoZ_3D.Visible =
               daiHHCN.Visible = caoHHCN.Visible = rongHHCN.Visible = HHCN.Visible = HTru.Visible = false;
            hinhHCN.Visible = hinhTru.Visible = false;
            lb1.Visible = lb2.Visible = lb3.Visible = lb4.Visible = lb5.Visible = lb6.Visible = false;

            hinh1.Visible = hinh2.Visible = true;
            TrucToaDo = 1;
            ToaDoDiem(false, false);
            // khởi tạo tọa độ 2D

            heTrucToaDo.Visible = true;
            this.ve3D.Visible = true;
            this.ve2D.Visible = false;
            form3D.Visible = false;
            ChiaDoDo3D(false);
            ChiaDoDo2D(true);

            this.Refresh();

        }
        private void Ve3D_Click(object sender, EventArgs e)
        {
            bienDoi = false;
            chuyenDong1.Visible = chuyenDong2.Visible = tinhTienCon1.Visible = thucHienBienDoi.Visible
                = x1cd.Visible = y1cd.Visible = gocQuayCD.Visible = goc1CD.Visible = tinhTienCon2.Visible
                = x2cd.Visible = y2cd.Visible = false;
            biendoiCD = phepbiendoi = 0;
            tinhTienCD.Visible = quayCD.Visible = doiXungCD.Visible = tyLeCD.Visible = false;
            toadoX_3D.Visible = toadoY_3D.Visible = toadoZ_3D.Visible =
               daiHHCN.Visible = caoHHCN.Visible = rongHHCN.Visible = HHCN.Visible = thongTinToaDo1.Visible = thongTinToaDo2.Visible
               = thongTinToaDo3.Visible = thongTinToaDo4.Visible = thongTinToaDo5.Visible = thongTinToaDo6.Visible = thongTinToaDo7.Visible = false;
            hinhHCN.Visible = hinhTru.Visible = true;
            veHinh2 = chDong1 = chDong2 = veHinh1 = false;
            hinh1.Visible = hinh2.Visible = chuyenDong1.Visible = chuyenDong2.Visible = false;
            TrucToaDo = 2;

            ToaDoDiem(false, false); ChiaDoDo2D(false);

            ChiaDoDo3D(true);
            heTrucToaDo.Visible = true;
            this.ve3D.Visible = false;
            this.ve2D.Visible = true;
            this.Refresh();
        }

        private void Hinh1_Click(object sender, EventArgs e)
        {
            bienDoi = false;
            chuyenDong1.Visible = chuyenDong2.Visible = tinhTienCon1.Visible = thucHienBienDoi.Visible
                = x1cd.Visible = y1cd.Visible = gocQuayCD.Visible = goc1CD.Visible = tinhTienCon2.Visible
                = x2cd.Visible = y2cd.Visible = false;
            biendoiCD = 1; phepbiendoi = 0;
            tinhTienCD.Visible = quayCD.Visible = doiXungCD.Visible = tyLeCD.Visible = true;
            thongTinToaDo1.Visible = thongTinToaDo2.Visible
                = thongTinToaDo3.Visible = thongTinToaDo4.Visible = thongTinToaDo5.Visible = true;
            thongTinToaDo6.Visible = thongTinToaDo7.Visible = false;
            chuyenDong1.Visible = true; chuyenDong2.Visible = false;
            veHinh1 = true;
            chDong1 = chDong2 = veHinh2 = false;
            ChiaDoDo2D(true);
            ToaDoDiem(false, false);

            ToaDoDiem(true, true);
            thongTinToaDo1.Text = "Hình tròn tâm A, bán kính r = 20";
            thongTinToaDo2.Text = "Hình tròn tâm H, bán kính r = 20";
            thongTinToaDo3.Text = "Hình tròn tâm O, bán kính r = 20";
            thongTinToaDo4.Text = "";
            thongTinToaDo5.Text = "";
            diemP.Visible = diemR.Visible = diemQ.Visible = diemT.Visible = diemU.Visible = diemS.Visible = toadoU.Visible = toadoP.Visible
                = toadoR.Visible = toadoS.Visible = toadoT.Visible = toadoQ.Visible = false;
            this.Refresh();
        }

        void HienThiToaDo1(Point a, Point b, Point c, Point d, Point e, Point f, Point g, Point h, Point i,
            Point j, Point k, Point l, Point m, Point n, Point o)
        {
            //,Point u, Point v, Point w, Point x, Point y, Point z, Point aa           
            //Người trái
            diemA.Location = new Point(a.X + 1, a.Y);
            toadoA.Text = "A(" + (a.X - 500) / 10 + "," + (350 - a.Y) / 10 + ")";
            diemB.Location = new Point(b.X + 1, b.Y + 5);
            toadoB.Text = "B(" + (b.X - 500) / 10 + "," + (350 - b.Y) / 10 + ")";
            diemC.Location = new Point(c.X + 1, c.Y - 7);
            toadoC.Text = "C(" + (c.X - 500) / 10 + "," + (350 - c.Y) / 10 + ")";
            diemD.Location = new Point(d.X, d.Y + 1);
            toadoD.Text = "D(" + (d.X - 500) / 10 + "," + (350 - d.Y) / 10 + ")";
            diemE.Location = new Point(e.X - 10, e.Y + 1);
            toadoE.Text = "E(" + (e.X - 500) / 10 + "," + (350 - e.Y) / 10 + ")";
            diemF.Location = new Point(f.X - 3, f.Y + 5);
            toadoF.Text = "F(" + (f.X - 500) / 10 + "," + (350 - f.Y) / 10 + ")";
            diemG.Location = new Point(g.X - 3, g.Y + 5);
            toadoG.Text = "G(" + (g.X - 500) / 10 + "," + (350 - g.Y) / 10 + ")";
            //Người phải
            diemH.Location = new Point(h.X - 3, h.Y - 10);
            toadoH.Text = "H(" + (float)(h.X - 500) / 10 + "," + (float)(350 - h.Y) / 10 + ")";
            diemI.Location = new Point(i.X + 10, i.Y + 8);
            toadoI.Text = "I(" + (float)(i.X - 500) / 10 + "," + (float)(350 - i.Y) / 10 + ")";
            diemJ.Location = new Point(j.X - 18, j.Y + 1);
            toadoJ.Text = "J(" + (float)(j.X - 500) / 10 + "," + (float)(350 - j.Y) / 10 + ")";
            diemK.Location = new Point(k.X - 11, k.Y - 10);
            toadoK.Text = "K(" + (float)(k.X - 500) / 10 + "," + (float)(350 - k.Y) / 10 + ")";
            diemL.Location = new Point(l.X - 5, l.Y - 10);
            toadoL.Text = "L(" + (float)(l.X - 500) / 10 + "," + (float)(350 - l.Y) / 10 + ")";
            diemM.Location = new Point(m.X, m.Y - 10);
            toadoM.Text = "M(" + (float)(m.X - 500) / 10 + "," + (float)(350 - m.Y) / 10 + ")";
            diemN.Location = new Point(n.X + 1, n.Y - 9);
            toadoN.Text = "N(" + (float)(n.X - 500) / 10 + "," + (float)(350 - n.Y) / 10 + ")";
            //quả bóng
            diemO.Location = new Point(o.X + 1, o.Y + 1);
            toadoO.Text = "O(" + (float)(o.X - 500) / 10 + "," + (float)(350 - o.Y) / 10 + ")";
            toadoP.Visible = toadoR.Visible = toadoQ.Visible = diemU.Visible = toadoU.Visible = toadoP.Visible
                = toadoR.Visible = toadoS.Visible = toadoT.Visible = toadoQ.Visible = false;
        }

        void HienThiToaDoQuaBong(Point a, Point b, Point c, Point d, Point e, Point f, Point g, Point h, Point i,
           Point j, Point k, Point l, Point m, Point n, Point o)
        {
            //,Point u, Point v, Point w, Point x, Point y, Point z, Point aa           
            //Người trái
            diemA.Location = new Point(a.X + 1, a.Y);
            toadoA.Text = "A(" + (a.X - 500) / 10 + "," + (350 - a.Y) / 10 + ")";
            diemB.Location = new Point(b.X + 1, b.Y + 5);
            toadoB.Text = "B(" + (b.X - 500) / 10 + "," + (350 - b.Y) / 10 + ")";
            diemC.Location = new Point(c.X + 1, c.Y - 7);
            toadoC.Text = "C(" + (c.X - 500) / 10 + "," + (350 - c.Y) / 10 + ")";
            diemD.Location = new Point(d.X, d.Y + 1);
            toadoD.Text = "D(" + (d.X - 500) / 10 + "," + (350 - d.Y) / 10 + ")";
            diemE.Location = new Point(e.X - 10, e.Y + 1);
            toadoE.Text = "E(" + (e.X - 500) / 10 + "," + (350 - e.Y) / 10 + ")";
            diemF.Location = new Point(f.X - 3, f.Y + 5);
            toadoF.Text = "F(" + (f.X - 500) / 10 + "," + (350 - f.Y) / 10 + ")";
            diemG.Location = new Point(g.X - 3, g.Y + 5);
            toadoG.Text = "G(" + (g.X - 500) / 10 + "," + (350 - g.Y) / 10 + ")";
            //Người phải
            diemH.Location = new Point(h.X - 3, h.Y - 10);
            toadoH.Text = "H(" + (float)(h.X - 500) / 10 + "," + (float)(350 - h.Y) / 10 + ")";
            diemI.Location = new Point(i.X + 10, i.Y + 8);
            toadoI.Text = "I(" + (float)(i.X - 500) / 10 + "," + (float)(350 - i.Y) / 10 + ")";
            diemJ.Location = new Point(j.X - 18, j.Y + 1);
            toadoJ.Text = "J(" + (float)(j.X - 500) / 10 + "," + (float)(350 - j.Y) / 10 + ")";
            diemK.Location = new Point(k.X - 11, k.Y - 10);
            toadoK.Text = "K(" + (float)(k.X - 500) / 10 + "," + (float)(350 - k.Y) / 10 + ")";
            diemL.Location = new Point(l.X - 5, l.Y - 10);
            toadoL.Text = "L(" + (float)(l.X - 500) / 10 + "," + (float)(350 - l.Y) / 10 + ")";
            diemM.Location = new Point(m.X, m.Y - 10);
            toadoM.Text = "M(" + (float)(m.X - 500) / 10 + "," + (float)(350 - m.Y) / 10 + ")";
            diemN.Location = new Point(n.X + 1, n.Y - 9);
            toadoN.Text = "N(" + (float)(n.X - 500) / 10 + "," + (float)(350 - n.Y) / 10 + ")";
            //quả bóng
            diemO.Location = new Point(o.X + 1, o.Y + 1);
            toadoO.Text = "O(" + (float)(o.X - 500) / 10 + "," + (float)(350 - o.Y) / 10 + ")";

            toadoP.Visible = toadoR.Visible = toadoQ.Visible = diemU.Visible = toadoU.Visible = toadoP.Visible
                = toadoR.Visible = toadoS.Visible = toadoT.Visible = toadoQ.Visible = false;
        }

        private void Hinh2_Click(object sender, EventArgs e)
        {
            bienDoi = false;
            chuyenDong1.Visible = chuyenDong2.Visible = tinhTienCon1.Visible = thucHienBienDoi.Visible
                = x1cd.Visible = y1cd.Visible = gocQuayCD.Visible = goc1CD.Visible = tinhTienCon2.Visible
                = x2cd.Visible = y2cd.Visible = false;
            biendoiCD = 2; phepbiendoi = 0;
            tinhTienCD.Visible = quayCD.Visible = doiXungCD.Visible = tyLeCD.Visible = false;
            chuyenDong2.Visible = true;
            chuyenDong1.Visible = false; veHinh1 = false;
            veHinh2 = true; chDong1 = chDong2 = veHinh1 = false; ToaDoDiem(false, false); ChiaDoDo2D(true);
            thongTinToaDo1.Visible = thongTinToaDo2.Visible
                = thongTinToaDo3.Visible = thongTinToaDo4.Visible = thongTinToaDo5.Visible = thongTinToaDo6.Visible = thongTinToaDo7.Visible = true;
            ToaDoDiem(false, false);
            thongTinToaDo1.Text = "";
            thongTinToaDo2.Text = "";
            thongTinToaDo3.Text = "";
            thongTinToaDo4.Text = "";
            thongTinToaDo5.Text = "";
            thongTinToaDo6.Text = "";
            thongTinToaDo7.Text = "";

            ToaDoDiem(true, true);
            diemT.Visible = diemU.Visible = toadoT.Visible = toadoU.Visible = false;
            this.Refresh();
        }

        void HienThiToaDo2(Point[] a, Point[] b, Point moon)
        {

            diemA.Location = new Point(a[1].X - 3, a[1].Y - 15); toadoA.Text = "A(" + (float)(a[1].X - 500) / 10 + "," + (float)(350 - a[1].Y) / 10 + ")";
            diemB.Location = new Point(a[2].X, a[2].Y); toadoB.Text = "B(" + (float)(a[2].X - 500) / 10 + "," + (float)(350 - a[2].Y) / 10 + ")";
            diemC.Location = new Point(a[3].X + 5, a[3].Y - 2); toadoC.Text = "C(" + (float)(a[3].X - 500) / 10 + "," + (float)(350 - a[3].Y) / 10 + ")";
            diemD.Location = new Point(a[4].X, a[4].Y - 15); toadoD.Text = "D(" + (float)(a[4].X - 500) / 10 + "," + (float)(350 - a[4].Y) / 10 + ")";
            diemE.Location = new Point(a[5].X - 10, a[5].Y - 13); toadoE.Text = "E(" + (float)(a[5].X - 500) / 10 + "," + (float)(350 - a[5].Y) / 10 + ")";
            diemF.Location = new Point(a[6].X - 15, a[6].Y - 15); toadoF.Text = "F(" + (float)(a[6].X - 500) / 10 + "," + (float)(350 - a[6].Y) / 10 + ")";
            diemG.Location = new Point(a[7].X + 1, a[7].Y - 15); toadoG.Text = "G(" + (float)(a[7].X - 500) / 10 + "," + (float)(350 - a[7].Y) / 10 + ")";
            diemH.Location = new Point(a[8].X + 1, a[8].Y - 10); toadoH.Text = "H(" + (float)(a[8].X - 500) / 10 + "," + (float)(350 - a[8].Y) / 10 + ")";
            diemI.Location = new Point(a[9].X - 9, a[9].Y + 1); toadoI.Text = "I(" + (float)(a[9].X - 500) / 10 + "," + (float)(350 - a[9].Y) / 10 + ")";
            diemJ.Location = new Point(a[10].X + 1, a[10].Y - 2); toadoJ.Text = "J(" + (float)(a[10].X - 500) / 10 + "," + (float)(350 - a[10].Y) / 10 + ")";
            diemK.Location = new Point(a[11].X + 3, a[11].Y - 10); toadoK.Text = "K(" + (float)(a[11].X - 500) / 10 + "," + (float)(350 - a[11].Y) / 10 + ")";
            diemL.Location = new Point(a[12].X - 9, a[12].Y - 10); toadoL.Text = "L(" + (float)(a[12].X - 500) / 10 + "," + (float)(350 - a[12].Y) / 10 + ")";
            diemM.Location = new Point(b[0].X + 1, b[0].Y - 5); toadoM.Text = "M(" + (float)(b[0].X - 500) / 10 + "," + (float)(350 - b[0].Y) / 10 + ")";
            diemN.Location = new Point(b[1].X - 11, b[1].Y - 10); toadoN.Text = "N(" + (float)(b[1].X - 500) / 10 + "," + (float)(350 - b[1].Y) / 10 + ")";
            diemO.Location = new Point(b[2].X - 12, b[2].Y - 10); toadoO.Text = "O(" + (float)(b[2].X - 500) / 10 + "," + (float)(350 - b[2].Y) / 10 + ")";
            diemP.Location = new Point(b[3].X - 12, b[3].Y + 1); toadoP.Text = "P(" + (float)(b[3].X - 500) / 10 + "," + (float)(350 - b[3].Y) / 10 + ")";
            diemQ.Location = new Point(b[4].X + 1, b[4].Y); toadoQ.Text = "Q(" + (float)(b[4].X - 500) / 10 + "," + (float)(350 - b[4].Y) / 10 + ")";
            diemR.Location = new Point(b[5].X + 1, b[5].Y - 7); toadoR.Text = "R(" + (float)(b[5].X - 500) / 10 + "," + (float)(350 - b[5].Y) / 10 + ")";
            toadoT.Visible = toadoU.Visible = toadoV.Visible = toadoS.Visible = false;
        }

        private void hinhHCN_Click(object sender, EventArgs e)
        {
            diemA.Visible = diemB.Visible = diemC.Visible = diemD.Visible = diemE.Visible = diemF.Visible
                = toadoA.Visible = toadoB.Visible = toadoC.Visible = toadoD.Visible = toadoE.Visible = toadoF.Visible = false;
            HTru.Visible = false;
            toadoX_3D.Visible = toadoY_3D.Visible = toadoZ_3D.Visible =
                daiHHCN.Visible = caoHHCN.Visible = rongHHCN.Visible = HHCN.Visible = lb1.Visible = lb2.Visible =
                lb3.Visible = lb4.Visible = lb5.Visible = lb6.Visible = true; // Nhập dữ liệu
            thongTinToaDo1.Visible = thongTinToaDo2.Visible = thongTinToaDo3.Visible = thongTinToaDo4.Visible = thongTinToaDo5.Visible
                = thongTinToaDo6.Visible = thongTinToaDo7.Visible = false;
            lb4.Text = "Dài";
            lb5.Text = "Rộng";
            form3D.Visible = true;
            ChiaDoDo3D(false);
            veHinhTru = false; this.Refresh();
        }

        private void hinhTru_Click(object sender, EventArgs e)
        {
            lb1.Visible = lb2.Visible = lb3.Visible = lb4.Visible = lb5.Visible = true;
            lb6.Visible = false;
            diemA.Visible = diemB.Visible = diemC.Visible = diemD.Visible = diemE.Visible = diemF.Visible
                = diemG.Visible = diemH.Visible = toadoA.Visible = toadoB.Visible = toadoC.Visible = toadoD.Visible
                = toadoE.Visible = toadoF.Visible = toadoG.Visible = toadoH.Visible = false;
            veHHCN = false; caoHHCN.Visible = HHCN.Visible = false;
            toadoX_3D.Visible = toadoY_3D.Visible = toadoZ_3D.Visible =
               daiHHCN.Visible = rongHHCN.Visible = HTru.Visible = true;
            thongTinToaDo1.Visible = thongTinToaDo2.Visible = thongTinToaDo3.Visible = thongTinToaDo4.Visible = thongTinToaDo5.Visible
                = thongTinToaDo6.Visible = thongTinToaDo7.Visible = false;
            lb4.Text = "Bán kính";
            lb5.Text = "Chiều cao";
            form3D.Visible = true;
            ChiaDoDo3D(false);
            this.Refresh();

        }

        private void toaDoCacDiem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TinhTienCD_Click(object sender, EventArgs e)
        {
            quaO.Visible = quaOx.Visible = quaOy.Visible = false;

            bienDoi = false;
            chuyenDong1.Visible = chuyenDong2.Visible = false;
            tinhTienCon1.Visible = thucHienBienDoi.Visible = x1cd.Visible = y1cd.Visible = true;
            tinhTienCon1.Text = "Khoảng cách x, y:";
            gocQuayCD.Visible = goc1CD.Visible = false;
            tinhTienCon2.Visible = x2cd.Visible = y2cd.Visible = false;
            phepbiendoi = 1;

        }

        private void Quay_Click(object sender, EventArgs e)
        {
            quaO.Visible = quaOx.Visible = quaOy.Visible = false;

            bienDoi = false;
            chuyenDong1.Visible = chuyenDong2.Visible = false;
            tinhTienCon1.Visible = thucHienBienDoi.Visible = x1cd.Visible = y1cd.Visible = true;
            tinhTienCon1.Text = "Tâm quay(x,y):";
            gocQuayCD.Visible = goc1CD.Visible = true;
            tinhTienCon2.Visible = x2cd.Visible = y2cd.Visible = false;
            phepbiendoi = 2;
        }

        private void DoiXung_Click(object sender, EventArgs e)
        {

            tinhTienCon1.Visible = x1cd.Visible = y1cd.Visible = false;
            tinhTienCon2.Visible = x2cd.Visible = y2cd.Visible = false;
            gocQuayCD.Visible = goc1CD.Visible = false;
            //tinhTienCon1.Text = "Điểm 1 (x,y):";
            //tinhTienCon2.Text = "Điểm 2 (x,y):";
            quaO.Visible = quaOx.Visible = quaOy.Visible = thucHienBienDoi.Visible = true;
            phepbiendoi = 3;
        }

        private void TyLe_Click(object sender, EventArgs e)
        {
            quaO.Visible = quaOx.Visible = quaOy.Visible = false;
            bienDoi = false; chuyenDong1.Visible = chuyenDong2.Visible = false;
            tinhTienCon1.Visible = thucHienBienDoi.Visible = x1cd.Visible = y1cd.Visible = true;
            tinhTienCon1.Text = "Hệ số tỷ lệ x, y:";
            tinhTienCon2.Visible = x2cd.Visible = y2cd.Visible = false;
            gocQuayCD.Visible = goc1CD.Visible = false;
            phepbiendoi = 4;
        }

        private void VeHinhCoBan_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void diemA_Click(object sender, EventArgs e)
        {

        }

        private void diemB_Click(object sender, EventArgs e)
        {

        }

        private void d25_Click(object sender, EventArgs e)
        {

        }

        private void thongTinToaDo1_Click(object sender, EventArgs e)
        {

        }



        //private void quaO_Click_1(object sender, EventArgs e)
        //{
        //    y2cd.Text = x2cd.Text = y1cd.Text = x1cd.Text = "0";
        //    bienDoi = true;
        //}

        //private void quaOx_Click_1(object sender, EventArgs e)
        //{
        //    y2cd.Text = x2cd.Text = y1cd.Text = "0";
        //    x1cd.Text = "1";
        //    bienDoi = true;

        //}

        //private void quaOy_Click_1(object sender, EventArgs e)
        //{
        //    y2cd.Text = x2cd.Text = x1cd.Text = "0";
        //    y1cd.Text = "1";
        //    bienDoi = true;
        //}

        private void welcome_Click(object sender, EventArgs e)
        {
            bienDoi = false;
            chuyenDong1.Visible = chuyenDong2.Visible = tinhTienCon1.Visible = thucHienBienDoi.Visible
                = x1cd.Visible = y1cd.Visible = gocQuayCD.Visible = goc1CD.Visible = tinhTienCon2.Visible
                = x2cd.Visible = y2cd.Visible = chDong1 = chDong2 = veHinh1 = veHinh2 = false;
            biendoiCD = phepbiendoi = 0;
            tinhTienCD.Visible = quayCD.Visible = doiXungCD.Visible = tyLeCD.Visible = false;
            thongTinToaDo1.Visible = thongTinToaDo2.Visible = thongTinToaDo3.Visible = thongTinToaDo4.Visible = thongTinToaDo5.Visible
                = thongTinToaDo6.Visible = thongTinToaDo7.Visible = false;
            toadoX_3D.Visible = toadoY_3D.Visible = toadoZ_3D.Visible =
               daiHHCN.Visible = caoHHCN.Visible = rongHHCN.Visible = HHCN.Visible = HTru.Visible = false;
            hinhHCN.Visible = hinhTru.Visible = false;
            lb1.Visible = lb2.Visible = lb3.Visible = lb4.Visible = lb5.Visible = lb6.Visible = false;

            hinh1.Visible = hinh2.Visible = true;
            controlVe.Visible = toaDoCacDiem.Visible = true;
            welcome.Visible = panelWelcome.Visible = false;
            TrucToaDo = 1;
            ToaDoDiem(false, false);
            // khởi tạo tọa độ 2D
            ChiaDoDo3D(false);
            ChiaDoDo2D(true);
            heTrucToaDo.Visible = true;
            this.ve3D.Visible = true;
            this.ve2D.Visible = false;
            this.Refresh();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void panelWelcome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Htru_Click(object sender, EventArgs e)
        {
            if (toadoX_3D.Text.Length == 0 || toadoY_3D.Text.Length == 0 || toadoZ_3D.Text.Length == 0
                || daiHHCN.Text.Length == 0 || rongHHCN.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ các thông tin để vẽ!");
            }
            else if (IsNumber(toadoX_3D.Text) == false || IsNumber(toadoY_3D.Text) == false || IsNumber(toadoZ_3D.Text) == false
                || IsNumber(daiHHCN.Text) == false || IsNumber(rongHHCN.Text) == false)
            {
                MessageBox.Show("Bạn đã nhập sai thông tin!");
            }
            else
            {
                heTrucToaDo.Visible = false; veHinhTru = true; heTrucToaDo.Visible = true;
                form3D.Visible = false;
                ChiaDoDo3D(true);

            }
        }



        //private void hinh2_Click_2(object sender, EventArgs e)
        //{

        //}

        private void ThucHienBienDoi_Click(object sender, EventArgs e)
        {
            if (phepbiendoi == 1)
            {
                if (x1cd.Text.Length == 0 || y1cd.Text.Length == 0 || goc1CD.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ các thông tin để thực hiện tịnh tiến!");
                }
                else if (IsNumber(x1cd.Text) == false || IsNumber(y1cd.Text) == false || IsNumber(goc1CD.Text) == false)
                {
                    MessageBox.Show("Bạn đã nhập sai định dạng!");
                }
                else
                {
                    bienDoi = true; this.Refresh();
                }
            }
            else if (phepbiendoi == 2)
            {
                if (x1cd.Text.Length == 0 || y1cd.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ các thông tin để thực hiện quay!");
                }
                else if (IsNumber(x1cd.Text) == false || IsNumber(y1cd.Text) == false)
                {
                    MessageBox.Show("Bạn đã nhập sai định dạng!");
                }
                else
                {
                    bienDoi = true; this.Refresh();
                }
            }
            else if (phepbiendoi == 3)
            {
                if (x1cd.Text.Length == 0 || y1cd.Text.Length == 0 || x2cd.Text.Length == 0 || y2cd.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ các thông tin để thực hiện đối xứng!");
                }
                else if (IsNumber(x1cd.Text) == false || IsNumber(y1cd.Text) == false
                    || IsNumber(x2cd.Text) == false || IsNumber(y2cd.Text) == false)
                {
                    MessageBox.Show("Bạn đã nhập sai định dạng!");
                }
                else if ((x1cd.Text != "0" || x2cd.Text != "0" || y1cd.Text != "0" || y2cd.Text != "0")
                    && x1cd.Text == x2cd.Text && y1cd.Text == y2cd.Text)
                {
                    MessageBox.Show("Bạn đã nhập sai định dạng! Điểm đầu và điểm cuối phải khác nhau!");
                }
                else
                {
                    bienDoi = true; this.Refresh();
                }
            }
            else if (phepbiendoi == 4)
            {
                if (x1cd.Text.Length == 0 || y1cd.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ các thông tin để thực hiện phép tỷ lệ!");
                }
                else if (IsNumber(x1cd.Text) == false || IsNumber(y1cd.Text) == false)
                {
                    MessageBox.Show("Bạn đã nhập sai định dạng!");
                }
                else
                {
                    bienDoi = true; this.Refresh();
                }
            }
        }

        private void thucHienBienDoi_Click_1(object sender, EventArgs e)
        {
            if (phepbiendoi == 1)
            {
                if (x1cd.Text.Length == 0 || y1cd.Text.Length == 0 || goc1CD.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ các thông tin để thực hiện tịnh tiến!");
                }
                else if (IsNumber(x1cd.Text) == false || IsNumber(y1cd.Text) == false || IsNumber(goc1CD.Text) == false)
                {
                    MessageBox.Show("Bạn đã nhập sai định dạng!");
                }
                else
                {
                    bienDoi = true; this.Refresh();
                }
            }
            else if (phepbiendoi == 2)
            {
                if (x1cd.Text.Length == 0 || y1cd.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ các thông tin để thực hiện quay!");
                }
                else if (IsNumber(x1cd.Text) == false || IsNumber(y1cd.Text) == false)
                {
                    MessageBox.Show("Bạn đã nhập sai định dạng!");
                }
                else
                {
                    bienDoi = true; this.Refresh();
                }
            }
            else if (phepbiendoi == 3)
            {
                if (x1cd.Text.Length == 0 || y1cd.Text.Length == 0 || x2cd.Text.Length == 0 || y2cd.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ các thông tin để thực hiện đối xứng!");
                }
                else if (IsNumber(x1cd.Text) == false || IsNumber(y1cd.Text) == false
                    || IsNumber(x2cd.Text) == false || IsNumber(y2cd.Text) == false)
                {
                    MessageBox.Show("Bạn đã nhập sai định dạng!");
                }
                else if ((x1cd.Text != "0" || x2cd.Text != "0" || y1cd.Text != "0" || y2cd.Text != "0")
                    && x1cd.Text == x2cd.Text && y1cd.Text == y2cd.Text)
                {
                    MessageBox.Show("Bạn đã nhập sai định dạng! Điểm đầu và điểm cuối phải khác nhau!");
                }
                else
                {
                    bienDoi = true; this.Refresh();
                }
            }
            else if (phepbiendoi == 4)
            {
                if (x1cd.Text.Length == 0 || y1cd.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ các thông tin để thực hiện phép tỷ lệ!");
                }
                else if (IsNumber(x1cd.Text) == false || IsNumber(y1cd.Text) == false)
                {
                    MessageBox.Show("Bạn đã nhập sai định dạng!");
                }
                else
                {
                    bienDoi = true; this.Refresh();
                }
            }
        }

        private void quaOx_Click(object sender, EventArgs e)
        {
            y2cd.Text = x2cd.Text = y1cd.Text = "0";
            x1cd.Text = "1";
            bienDoi = true;
            quaox = true;
            quao = quaoy = false;

        }

        private void quaOy_Click(object sender, EventArgs e)
        {
            y2cd.Text = x2cd.Text = x1cd.Text = "0";
            y1cd.Text = "1";
            bienDoi = true;
            quaoy = true;
            quao = quaox = false;

        }

        private void quaO_Click(object sender, EventArgs e)
        {
            y2cd.Text = x2cd.Text = y1cd.Text = x1cd.Text = "0";
            bienDoi = true;
            quao = true;
            quaox = quaoy = false;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void HHCN_Click(object sender, EventArgs e)
        {
            if (toadoX_3D.Text.Length == 0 || toadoY_3D.Text.Length == 0 || toadoZ_3D.Text.Length == 0
                || daiHHCN.Text.Length == 0 || caoHHCN.Text.Length == 0 || rongHHCN.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ các thông tin để vẽ!");
            }
            else if (IsNumber(toadoX_3D.Text) == false || IsNumber(toadoY_3D.Text) == false || IsNumber(toadoZ_3D.Text) == false
               || IsNumber(daiHHCN.Text) == false || IsNumber(caoHHCN.Text) == false || IsNumber(rongHHCN.Text) == false)
            {
                MessageBox.Show("Bạn đã nhập sai thông tin!");
            }
            else
            {
                heTrucToaDo.Visible = false; veHHCN = true; heTrucToaDo.Visible = true;
                form3D.Visible = false;
                ChiaDoDo3D(true);

            }
        }

        private void ChuyenDong1_Click(object sender, EventArgs e)
        {
            tinhTienCD.Visible = quayCD.Visible = doiXungCD.Visible = tyLeCD.Visible = false;
            thongTinToaDo1.Visible = thongTinToaDo2.Visible = thongTinToaDo3.Visible = true;
            thongTinToaDo4.Visible = thongTinToaDo5.Visible =
            thongTinToaDo6.Visible = thongTinToaDo7.Visible = false;
            heTrucToaDo.Visible = false; chDong1 = true; heTrucToaDo.Visible = true;
            ChiaDoDo2D(false);
            ToaDoDiem(false, false);
            heTrucToaDo.BackColor = Color.Green;
        }

        private void ChuyenDong2_Click(object sender, EventArgs e)
        {
            tinhTienCD.Visible = quayCD.Visible = doiXungCD.Visible = tyLeCD.Visible = false;
            thongTinToaDo1.Visible = thongTinToaDo2.Visible
                = thongTinToaDo3.Visible = thongTinToaDo4.Visible = thongTinToaDo5.Visible
                = thongTinToaDo6.Visible = thongTinToaDo7.Visible = false;
            heTrucToaDo.Visible = false; chDong2 = true; heTrucToaDo.Visible = true;

            ToaDoDiem(false, false);
            ChiaDoDo2D(false);
        }

        public static void House(Point[] house, Bitmap bmp, PaintEventArgs e)
        {
            SolidBrush light = new SolidBrush(Color.Yellow);
            // Vòng lặp 100 lần ghi ra ký tự 'B'
            for (int i = 0; i < 100; i++)
            {
                // cua phong
                Rectangle rect11 = new Rectangle(house[12].X, house[12].Y, 50, 25);
                Rectangle rect12 = new Rectangle(house[12].X + 70, house[12].Y - 50, 50, 25);
                Rectangle rect13 = new Rectangle(house[12].X, house[12].Y - 100, 50, 25);
                e.Graphics.FillRectangle(light, rect11);
                e.Graphics.FillRectangle(light, rect12);
                e.Graphics.FillRectangle(light, rect13);
                e.Graphics.DrawImage(bmp, 0, 0);

                // Ngủ 100 mili giây
                Thread.Sleep(400);
            }

        }

        private void HeTrucToaDo_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush darkvioletBrush = new SolidBrush(Color.DarkViolet);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush skyblueBrush = new SolidBrush(Color.LightSkyBlue);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
            SolidBrush seagreenBrush = new SolidBrush(Color.LightSeaGreen);
            SolidBrush darkgreenBrush = new SolidBrush(Color.DarkGreen);
            SolidBrush linegreenBrush = new SolidBrush(Color.LimeGreen);
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            SolidBrush orangeBrush = new SolidBrush(Color.Orange);
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            SolidBrush purpleBrush = new SolidBrush(Color.Purple);
            SolidBrush khakiBrush = new SolidBrush(Color.Khaki);
            SolidBrush lightpinkBrush = new SolidBrush(Color.LightPink);
            SolidBrush deletefishnightBrush = new SolidBrush(Color.LightSeaGreen);
            SolidBrush deletefishdayBrush = new SolidBrush(Color.LightSkyBlue);
            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            SolidBrush light = new SolidBrush(Color.Yellow);
            Bitmap bmp = new Bitmap(1018, 685);
            heTrucToaDo.BackColor = Color.White;
            if (TrucToaDo == 1)
            {
                Ve2Hinh2D ve2 = new Ve2Hinh2D();
                if (chDong1) XoaTruc2DHinh1(e, Pens.Green);
                else Truc2D(e);
                if (veHinh1 == true)
                {
                    PhepBienDoi chd = new PhepBienDoi();
                    Point[] m = new Point[8];
                    Point[] z = new Point[8];
                    Point[] ball = new Point[2];
                    Line A1, A2, A3, A4, A5;
                    Line B1, B2, B3, B4, B5;
                    Point DauA = new Point();
                    Point DauB = new Point();
                    Point bong = new Point();
                    ELip hel1, hel2;

                    m[1].X = 700; m[1].Y = 230;
                    m[2].X = 700; m[2].Y = 250;
                    m[3].X = 700; m[3].Y = 300;
                    m[4].X = 670; m[4].Y = 260;
                    m[5].X = 730; m[5].Y = 260;
                    m[6].X = 680; m[6].Y = 350;
                    m[7].X = 720; m[7].Y = 350;

                    z[1].X = 220; z[1].Y = 230;
                    z[2].X = 220; z[2].Y = 250;
                    z[3].X = 220; z[3].Y = 300;
                    z[4].X = 190; z[4].Y = 260;
                    z[5].X = 250; z[5].Y = 260;
                    z[6].X = 200; z[6].Y = 350;
                    z[7].X = 240; z[7].Y = 350;

                    ball[1].X = 270;
                    ball[1].Y = 330;
                    #region Vẽ người và bóng
                    //Người bên trái
                    A1 = new Line(z[1].X, z[1].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                    A1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                    A2 = new Line(z[2].X, z[2].Y, z[4].X, z[4].Y, Color.Red); //tao AB 
                    A2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                    A3 = new Line(z[2].X, z[2].Y, z[5].X, z[5].Y, Color.Red); //tao AB 
                    A3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                    A4 = new Line(z[6].X, z[6].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                    A4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                    A5 = new Line(z[3].X, z[3].Y, z[7].X, z[7].Y, Color.Red); //tao AB 
                    A5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                    DauA.X = z[1].X;
                    DauA.Y = z[1].Y - 20;

                    hel1 = new ELip(DauA.X, DauA.Y, 20, 20);
                    hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);

                    B1 = new Line(m[1].X, m[1].Y, m[3].X, m[3].Y, Color.Red); //tao AB 
                    B1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                    B2 = new Line(m[2].X, m[2].Y, m[4].X, m[4].Y, Color.Red); //tao AB 
                    B2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                    B3 = new Line(m[2].X, m[2].Y, m[5].X, m[5].Y, Color.Red); //tao AB 
                    B3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                    B4 = new Line(m[6].X, m[6].Y, m[3].X, m[3].Y, Color.Red); //tao AB 
                    B4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                    B5 = new Line(m[3].X, m[3].Y, m[7].X, m[7].Y, Color.Red); //tao AB 
                    B5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                    DauB.X = m[1].X;
                    DauB.Y = m[1].Y - 20;
                    hel1 = new ELip(DauB.X, DauB.Y, 20, 20);
                    hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Blue);
                    //QUẢ BÓNG
                    bong.X = ball[1].X;
                    bong.Y = ball[1].Y;
                    hel1 = new ELip(bong.X, bong.Y, 20, 20);
                    hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);

                    #endregion
                    if (bienDoi == false)
                    {
                        // Tọa độ người 1, người 2, quả bóng
                        HienThiToaDo1(m[1], m[2], m[3], m[4], m[5], m[6], m[7], z[1], z[2], z[3], z[4], z[5], z[6], z[7],
                        ball[1]);
                    }

                    if (bienDoi == true)
                    {
                        // Tịnh tiến
                        if (phepbiendoi == 1)
                        {
                            Truc2D(e);
                            int hsx = Convert.ToInt32(x1cd.Text) * 10;
                            int hsy = Convert.ToInt32(y1cd.Text) * 10;
                            hsy = -hsy;
                            Point[] k1 = new Point[14];
                            m[1] = chd.TinhTien(m[1].X, m[1].Y, hsx, hsy);
                            m[2] = chd.TinhTien(m[2].X, m[2].Y, hsx, hsy);
                            m[3] = chd.TinhTien(m[3].X, m[3].Y, hsx, hsy);
                            m[4] = chd.TinhTien(m[4].X, m[4].Y, hsx, hsy);
                            m[5] = chd.TinhTien(m[5].X, m[5].Y, hsx, hsy);
                            m[6] = chd.TinhTien(m[6].X, m[6].Y, hsx, hsy);
                            m[7] = chd.TinhTien(m[7].X, m[7].Y, hsx, hsy);

                            z[1] = chd.TinhTien(z[1].X, z[1].Y, hsx, hsy);
                            z[2] = chd.TinhTien(z[2].X, z[2].Y, hsx, hsy);
                            z[3] = chd.TinhTien(z[3].X, z[3].Y, hsx, hsy);
                            z[4] = chd.TinhTien(z[4].X, z[4].Y, hsx, hsy);
                            z[5] = chd.TinhTien(z[5].X, z[5].Y, hsx, hsy);
                            z[6] = chd.TinhTien(z[6].X, z[6].Y, hsx, hsy);
                            z[7] = chd.TinhTien(z[7].X, z[7].Y, hsx, hsy);

                            ball[1] = chd.TinhTien(ball[1].X, ball[1].Y, hsx, hsy);

                            #region Vẽ người và bóng
                            //Người bên trái
                            A1 = new Line(z[1].X, z[1].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                            A1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A2 = new Line(z[2].X, z[2].Y, z[4].X, z[4].Y, Color.Red); //tao AB 
                            A2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A3 = new Line(z[2].X, z[2].Y, z[5].X, z[5].Y, Color.Red); //tao AB 
                            A3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A4 = new Line(z[6].X, z[6].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                            A4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A5 = new Line(z[3].X, z[3].Y, z[7].X, z[7].Y, Color.Red); //tao AB 
                            A5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            DauA.X = z[1].X;
                            DauA.Y = z[1].Y - 20;
                            //HT htA = new HT(DauA.X, DauA.Y, 20);
                            //htA.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Black);

                            hel1 = new ELip(DauA.X, DauA.Y, 20, 20);
                            hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);
                            B1 = new Line(m[1].X, m[1].Y, m[3].X, m[3].Y, Color.Red); //tao AB 
                            B1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B2 = new Line(m[2].X, m[2].Y, m[4].X, m[4].Y, Color.Red); //tao AB 
                            B2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B3 = new Line(m[2].X, m[2].Y, m[5].X, m[5].Y, Color.Red); //tao AB 
                            B3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B4 = new Line(m[6].X, m[6].Y, m[3].X, m[3].Y, Color.Red); //tao AB 
                            B4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B5 = new Line(m[3].X, m[3].Y, m[7].X, m[7].Y, Color.Red); //tao AB 
                            B5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            DauB.X = m[1].X;
                            DauB.Y = m[1].Y - 20;
                            //HT htB = new HT(DauB.X, DauB.Y, 20);
                            //htB.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Blue);
                            hel1 = new ELip(DauB.X, DauB.Y, 20, 20);
                            hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Blue);
                            //QUẢ BÓNG
                            bong.X = ball[1].X;
                            bong.Y = ball[1].Y;
                            //HT htC = new HT(bong.X, bong.Y, 20);
                            //htC.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Black);
                            hel1 = new ELip(bong.X, bong.Y, 20, 20);
                            hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Black);

                            #endregion

                            // Tọa độ người 1, người 2, quả bóng
                            HienThiToaDo1(m[1], m[2], m[3], m[4], m[5], m[6], m[7], z[1], z[2], z[3], z[4], z[5], z[6], z[7],
                            ball[1]);
                        }
                        //Phep quay
                        else if (phepbiendoi == 2)
                        {
                            int hsx = Convert.ToInt32(x1cd.Text) * 10, hsy = Convert.ToInt32(y1cd.Text) * 10,
                                gCD = Convert.ToInt32(goc1CD.Text);
                            hsy = -hsy;


                            m[1] = chd.Quay(m[1].X, m[1].Y, hsx, hsy, gCD);
                            m[2] = chd.Quay(m[2].X, m[2].Y, hsx, hsy, gCD);
                            m[3] = chd.Quay(m[3].X, m[3].Y, hsx, hsy, gCD);
                            m[4] = chd.Quay(m[4].X, m[4].Y, hsx, hsy, gCD);
                            m[5] = chd.Quay(m[5].X, m[5].Y, hsx, hsy, gCD);
                            m[6] = chd.Quay(m[6].X, m[6].Y, hsx, hsy, gCD);
                            m[7] = chd.Quay(m[7].X, m[7].Y, hsx, hsy, gCD);

                            z[1] = chd.Quay(z[1].X, z[1].Y, hsx, hsy, gCD);
                            z[2] = chd.Quay(z[2].X, z[2].Y, hsx, hsy, gCD);
                            z[3] = chd.Quay(z[3].X, z[3].Y, hsx, hsy, gCD);
                            z[4] = chd.Quay(z[4].X, z[4].Y, hsx, hsy, gCD);
                            z[5] = chd.Quay(z[5].X, z[5].Y, hsx, hsy, gCD);
                            z[6] = chd.Quay(z[6].X, z[6].Y, hsx, hsy, gCD);
                            z[7] = chd.Quay(z[7].X, z[7].Y, hsx, hsy, gCD);

                            ball[1] = chd.Quay(ball[1].X, ball[1].Y, hsx, hsy, gCD);


                            if (gCD < 120)
                            {
                                DauA.X = z[1].X + hsx + 20 ;
                                DauB.X = m[1].X + hsx +40;
                                DauA.Y = z[1].Y;
                                DauB.Y = m[1].Y + 20 + hsy;

                            }
                            else
                            {

                                DauA.X = z[1].X + hsx;
                                DauB.X = m[1].X + hsx;
                                DauA.Y = z[1].Y + 20;
                                DauB.Y = m[1].Y + 20;
                            }
                            #region Vẽ người và bóng
                            //Người bên trái
                            A1 = new Line(z[1].X, z[1].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                            A1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A2 = new Line(z[2].X, z[2].Y, z[4].X, z[4].Y, Color.Red); //tao AB 
                            A2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A3 = new Line(z[2].X, z[2].Y, z[5].X, z[5].Y, Color.Red); //tao AB 
                            A3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A4 = new Line(z[6].X, z[6].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                            A4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A5 = new Line(z[3].X, z[3].Y, z[7].X, z[7].Y, Color.Red); //tao AB 
                            A5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            //HT htA = new HT(DauA.X, DauA.Y, 20);
                            //htA.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Black);

                            hel1 = new ELip(DauA.X, DauA.Y, 20, 20);
                            hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);

                            B1 = new Line(m[1].X, m[1].Y, m[3].X, m[3].Y, Color.Red); //tao AB 
                            B1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B2 = new Line(m[2].X, m[2].Y, m[4].X, m[4].Y, Color.Red); //tao AB 
                            B2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B3 = new Line(m[2].X, m[2].Y, m[5].X, m[5].Y, Color.Red); //tao AB 
                            B3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B4 = new Line(m[6].X, m[6].Y, m[3].X, m[3].Y, Color.Red); //tao AB 
                            B4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B5 = new Line(m[3].X, m[3].Y, m[7].X, m[7].Y, Color.Red); //tao AB 
                            B5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            DauB.X = m[1].X;
                            DauB.Y = m[1].Y - 20;
                            //HT htB = new HT(DauB.X, DauB.Y, 20);
                            //htB.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Blue);
                            hel1 = new ELip(DauB.X, DauB.Y, 20, 20);
                            hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Blue);
                            //QUẢ BÓNG
                            bong.X = ball[1].X;
                            bong.Y = ball[1].Y;
                            //HT htC = new HT(bong.X, bong.Y, 20);
                            //htC.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Black);
                            hel1 = new ELip(bong.X, bong.Y, 20, 20);
                            hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);

                            #endregion

                            HienThiToaDo1(m[1], m[2], m[3], m[4], m[5], m[6], m[7], z[1], z[2], z[3], z[4], z[5], z[6], z[7],
                            ball[1]);
                        }
                        //phep doi xung
                        else if (phepbiendoi == 3)
                        {
                            int hsx = Convert.ToInt32(x1cd.Text), hsy = Convert.ToInt32(y1cd.Text),
                               hsx1 = Convert.ToInt32(x2cd.Text), hsy1 = Convert.ToInt32(y2cd.Text);
                            hsy = -hsy; hsy1 = -hsy1;
                            m[1] = chd.DoiXung(m[1].X, m[1].Y, hsx, hsy, hsx1, hsy1);
                            m[2] = chd.DoiXung(m[2].X, m[2].Y, hsx, hsy, hsx1, hsy1);
                            m[3] = chd.DoiXung(m[3].X, m[3].Y, hsx, hsy, hsx1, hsy1);
                            m[4] = chd.DoiXung(m[4].X, m[4].Y, hsx, hsy, hsx1, hsy1);
                            m[5] = chd.DoiXung(m[5].X, m[5].Y, hsx, hsy, hsx1, hsy1);
                            m[6] = chd.DoiXung(m[6].X, m[6].Y, hsx, hsy, hsx1, hsy1);
                            m[7] = chd.DoiXung(m[7].X, m[7].Y, hsx, hsy, hsx1, hsy1);

                            z[1] = chd.DoiXung(z[1].X, z[1].Y, hsx, hsy, hsx1, hsy1);
                            z[2] = chd.DoiXung(z[2].X, z[2].Y, hsx, hsy, hsx1, hsy1);
                            z[3] = chd.DoiXung(z[3].X, z[3].Y, hsx, hsy, hsx1, hsy1);
                            z[4] = chd.DoiXung(z[4].X, z[4].Y, hsx, hsy, hsx1, hsy1);
                            z[5] = chd.DoiXung(z[5].X, z[5].Y, hsx, hsy, hsx1, hsy1);
                            z[6] = chd.DoiXung(z[6].X, z[6].Y, hsx, hsy, hsx1, hsy1);
                            z[7] = chd.DoiXung(z[7].X, z[7].Y, hsx, hsy, hsx1, hsy1);


                            ball[1] = chd.DoiXung(ball[1].X, ball[1].Y, hsx, hsy, hsx1, hsy1);
                            if (quao)
                            {
                                DauA.Y = z[1].Y + 20;
                                DauB.Y = m[1].Y + 20;
                                quaox = quaoy = false;
                            }
                            else if (quaox)
                            {
                                DauB.Y = m[1].Y + 20;
                                DauA.Y = z[1].Y + 20;
                                quao = quaoy = false;
                            }
                            else if (quaoy)
                            {

                                DauB.Y = m[1].Y - 20;
                                DauA.Y = z[1].Y - 20;
                                quaox = quao = false;
                            }
                            #region Vẽ người và bóng
                            //Người bên trái
                            A1 = new Line(z[1].X, z[1].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                            A1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A2 = new Line(z[2].X, z[2].Y, z[4].X, z[4].Y, Color.Red); //tao AB 
                            A2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A3 = new Line(z[2].X, z[2].Y, z[5].X, z[5].Y, Color.Red); //tao AB 
                            A3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A4 = new Line(z[6].X, z[6].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                            A4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A5 = new Line(z[3].X, z[3].Y, z[7].X, z[7].Y, Color.Red); //tao AB 
                            A5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            DauA.X = z[1].X;
                            //HT htA = new HT(DauA.X, DauA.Y, 20);
                            //htA.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Red);

                            hel1 = new ELip(DauA.X, DauA.Y, 20, 20);
                            hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);

                            B1 = new Line(m[1].X, m[1].Y, m[3].X, m[3].Y, Color.Red); //tao AB 
                            B1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B2 = new Line(m[2].X, m[2].Y, m[4].X, m[4].Y, Color.Red); //tao AB 
                            B2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B3 = new Line(m[2].X, m[2].Y, m[5].X, m[5].Y, Color.Red); //tao AB 
                            B3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B4 = new Line(m[6].X, m[6].Y, m[3].X, m[3].Y, Color.Red); //tao AB 
                            B4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B5 = new Line(m[3].X, m[3].Y, m[7].X, m[7].Y, Color.Red); //tao AB 
                            B5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            DauB.X = m[1].X;
                            DauB.Y = m[1].Y - 20;
                            //HT htB = new HT(DauB.X, DauB.Y, 20);
                            //htB.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Blue);
                            hel1 = new ELip(DauB.X, DauB.Y, 20, 20);
                            hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Blue);
                            //QUẢ BÓNG
                            bong.X = ball[1].X;
                            bong.Y = ball[1].Y;
                            //HT htC = new HT(bong.X, bong.Y, 20);
                            //htC.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Red);
                            hel1 = new ELip(bong.X, bong.Y, 20, 20);
                            hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);

                            #endregion
                            // Tọa độ người 1, người 2, quả bóng
                            HienThiToaDo1(m[1], m[2], m[3], m[4], m[5], m[6], m[7], z[1], z[2], z[3], z[4], z[5], z[6], z[7],
                            ball[1]);
                        }
                        //Ty le
                        else if (phepbiendoi == 4)
                        {
                            int bkdx = 20, bkdy = 20; // bán kính của đầu, nếu hệ số tỉ lệ x,y khác nhau thì sẽ vẽ elip
                            int hsx = Convert.ToInt32(x1cd.Text), hsy = Convert.ToInt32(y1cd.Text),
                               hsx1 = m[7].X, hsy1 = 350, hsx2 = z[7].X, hsy2 = 350, hsx3 = ball[1].X, hsy3 = ball[1].Y + bkdy;

                            if (hsx >= 0)
                            {
                                bkdx *= hsx;
                            }
                            else
                            {
                                bkdx /= (-hsx);
                            }
                            if (hsy >= 0)
                            {
                                bkdy *= hsy;
                            }
                            else
                            {
                                bkdy /= (-hsy);
                            }
                            hsy = -hsy;

                            //Nguoi ben phai
                            m[1] = chd.TyLe(m[1].X, m[1].Y, hsx, hsy, hsx1, hsy1);
                            m[2] = chd.TyLe(m[2].X, m[2].Y, hsx, hsy, hsx1, hsy1);
                            m[3] = chd.TyLe(m[3].X, m[3].Y, hsx, hsy, hsx1, hsy1);
                            m[4] = chd.TyLe(m[4].X, m[4].Y, hsx, hsy, hsx1, hsy1);
                            m[5] = chd.TyLe(m[5].X, m[5].Y, hsx, hsy, hsx1, hsy1);
                            m[6] = chd.TyLe(m[6].X, m[6].Y, hsx, hsy, hsx1, hsy1);
                            m[7] = chd.TyLe(m[7].X, m[7].Y, hsx, hsy, hsx1, hsy1);
                            //Nguoi ben trai
                            z[1] = chd.TyLe(z[1].X, z[1].Y, hsx, hsy, hsx2, hsy2);
                            z[2] = chd.TyLe(z[2].X, z[2].Y, hsx, hsy, hsx2, hsy2);
                            z[3] = chd.TyLe(z[3].X, z[3].Y, hsx, hsy, hsx2, hsy2);
                            z[4] = chd.TyLe(z[4].X, z[4].Y, hsx, hsy, hsx2, hsy2);
                            z[5] = chd.TyLe(z[5].X, z[5].Y, hsx, hsy, hsx2, hsy2);
                            z[6] = chd.TyLe(z[6].X, z[6].Y, hsx, hsy, hsx2, hsy2);
                            z[7] = chd.TyLe(z[7].X, z[7].Y, hsx, hsy, hsx2, hsy2);
                            //Qua bong
                            ball[1] = chd.TyLe(ball[1].X, ball[1].Y, hsx, hsy, hsx3, hsy3);

                            #region Vẽ người và bóng
                            //Người bên trái
                            A1 = new Line(z[1].X, z[1].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                            A1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A2 = new Line(z[2].X, z[2].Y, z[4].X, z[4].Y, Color.Red); //tao AB 
                            A2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A3 = new Line(z[2].X, z[2].Y, z[5].X, z[5].Y, Color.Red); //tao AB 
                            A3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A4 = new Line(z[6].X, z[6].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                            A4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            A5 = new Line(z[3].X, z[3].Y, z[7].X, z[7].Y, Color.Red); //tao AB 
                            A5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                            DauA.X = z[1].X;
                            DauA.Y = z[1].Y - bkdy;
                            //HT htA = new HT(DauA.X, DauA.Y, 20);
                            //htA.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Red);

                            hel1 = new ELip(DauA.X, DauA.Y, bkdx, bkdy);
                            hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);

                            B1 = new Line(m[1].X, m[1].Y, m[3].X, m[3].Y, Color.Red); //tao AB 
                            B1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B2 = new Line(m[2].X, m[2].Y, m[4].X, m[4].Y, Color.Red); //tao AB 
                            B2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B3 = new Line(m[2].X, m[2].Y, m[5].X, m[5].Y, Color.Red); //tao AB 
                            B3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B4 = new Line(m[6].X, m[6].Y, m[3].X, m[3].Y, Color.Red); //tao AB 
                            B4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            B5 = new Line(m[3].X, m[3].Y, m[7].X, m[7].Y, Color.Red); //tao AB 
                            B5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                            DauB.X = m[1].X;
                            DauB.Y = m[1].Y - 20;
                            //HT htB = new HT(DauB.X, DauB.Y, 20);
                            //htB.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Blue);
                            hel1 = new ELip(DauB.X, DauB.Y, 20, 20);
                            hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Blue);
                            //QUẢ BÓNG
                            bong.X = ball[1].X;
                            bong.Y = ball[1].Y;
                            //HT htC = new HT(bong.X, bong.Y, 20);
                            //htC.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Red);
                            hel1 = new ELip(bong.X, bong.Y, bkdx, bkdy);
                            hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);

                            #endregion
                            // Tọa độ người 1, người 2, quả bóng
                            HienThiToaDo1(m[1], m[2], m[3], m[4], m[5], m[6], m[7], z[1], z[2], z[3], z[4], z[5], z[6], z[7],
                            ball[1]);
                            if (bkdx == bkdy)
                            {
                                thongTinToaDo1.Text = "Hình tròn tâm A, bán kính r = " + bkdx;
                                thongTinToaDo2.Text = "Hình chữ nhật HKJI";
                                thongTinToaDo3.Text = "Hình chữ nhật LMPQ";
                                thongTinToaDo4.Text = "Ngũ giác NRTSO";
                            }
                            else
                            {
                                thongTinToaDo1.Text = "Hình Elip A, bán kính R = " + bkdx + ", r = " + bkdy;
                                thongTinToaDo2.Text = "Hình chữ nhật HKJI";
                                thongTinToaDo3.Text = "Hình chữ nhật LMPQ";
                                thongTinToaDo4.Text = "Ngũ giác NRTSO";
                            }
                        }

                    }
                    if (chDong1 == true)
                    {

                        XoaTruc2DHinh1(e, Pens.Green);
                        DuongThang dth = new DuongThang();
                        DuongTron tron = new DuongTron();
                        Line gachTySo, flag1, flag2, flag3, flag4, flag5;
                        Point[] b = new Point[8];
                        Point[] c = new Point[8];
                        Point[] d = new Point[8];
                        heTrucToaDo.BackColor = Color.Green;
                        ve2.VeKhungThanhSan(whiteBrush, e);
                        #region Hiện bảng số
                       
                        hel1 = new ELip(275, 35, 20, 25);
                        hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);
                      
                        gachTySo = new Line(320, 35, 335, 35, Color.Red); //tao AB 
                        gachTySo.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 


                        //0
                        hel2 = new ELip(375, 35, 20, 25);
                        hel2.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);

                        // lá cờ Việt Nam
                        flag1 = new Line(100, 10, 200, 10, Color.Red); //tao AB 
                        flag2 = new Line(100, 10, 100, 60, Color.Red); //tao AB 
                        flag3 = new Line(100, 60, 200, 60, Color.Red); //tao AB 
                        flag4 = new Line(200, 60, 200, 10, Color.Red); //tao AB 
                        flag1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 
                        flag2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 
                        flag3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 
                        flag4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        for (int i = 10; i < 60; i++)
                        {
                            dth.MidpointLine(100, i, 200, i, redBrush, e);

                        }
                        flag1 = new Line(150, 20, 130, 50, Color.Yellow); //tao AB 
                        flag1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Yellow); // ve dt AB bang DDA 
                        flag2 = new Line(150, 20, 170, 50, Color.Yellow); //tao AB 
                        flag2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Yellow); // ve dt AB bang DDA 
                        flag3 = new Line(170, 50, 120, 30, Color.Yellow); //tao AB 
                        flag3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Yellow); // ve dt AB bang DDA 
                        flag4 = new Line(120, 30, 180, 30, Color.Yellow); //tao AB 
                        flag4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Yellow); // ve dt AB bang DDA 
                        flag5 = new Line(130, 50, 180, 30, Color.Yellow); //tao AB 
                        flag5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Yellow); // ve dt AB bang DDA 





                        // lá cờ Thái Lan
                        for (int i = 0; i <= 7; i++)
                        {
                            dth.MidpointLine(450, 10 + i, 550, 10 + i, redBrush, e);
                        }
                        for (int i = 0; i <= 8; i++)
                        {
                            dth.MidpointLine(450, 18 + i, 550, 18 + i, whiteBrush, e);
                        }
                        for (int i = 0; i <= 8; i++)
                        {
                            dth.MidpointLine(450, 45 + i, 550, 45 + i, whiteBrush, e);
                        }
                        for (int i = 0; i <= 7; i++)
                        {
                            dth.MidpointLine(450, 53 + i, 550, 53 + i, redBrush, e);
                        }

                        for (int i = 0; i < 14; i++)
                        {
                            dth.MidpointLine(450, 27 + i, 550, 27 + i, blueBrush, e);
                        }

                        #endregion

                        #region Xóa người A
                        //Người bên trái 
                        A1 = new Line(z[1].X, z[1].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                        A1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 

                        A2 = new Line(z[2].X, z[2].Y, z[4].X, z[4].Y, Color.Red); //tao AB 
                        A2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 

                        A3 = new Line(z[2].X, z[2].Y, z[5].X, z[5].Y, Color.Red); //tao AB 
                        A3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 

                        A4 = new Line(z[6].X, z[6].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                        A4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 

                        A5 = new Line(z[3].X, z[3].Y, z[7].X, z[7].Y, Color.Red); //tao AB 
                        A5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 


                        DauA.X = z[1].X;
                        DauA.Y = z[1].Y - 20;
                        HT htA1 = new HT(DauA.X, DauA.Y, 20);
                        htA1.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Green);
                        #endregion

                        #region Thực hiện vẽ người đá bóng

                        z[7].X = 180;
                        z[7].Y = 310;
                        z[5].X = 190;
                        z[5].Y = 280;

                        //Người bên trái 
                        A1 = new Line(z[1].X, z[1].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                        A1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        A2 = new Line(z[2].X, z[2].Y, z[4].X, z[4].Y, Color.Red); //tao AB 
                        A2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        A3 = new Line(z[2].X, z[2].Y, z[5].X, z[5].Y, Color.Red); //tao AB 
                        A3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        A4 = new Line(z[6].X, z[6].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                        A4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        A5 = new Line(z[3].X, z[3].Y, z[7].X, z[7].Y, Color.Red); //tao AB 
                        A5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 


                        DauA.X = z[1].X;
                        DauA.Y = z[1].Y - 20;
                        hel1 = new ELip(DauA.X, DauA.Y, 20, 20);
                        hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);

                        #endregion

                        #region Quả bóng chuyển động
                        int vitribongX = 0;
                        int vitribongY = 0;
                        //QUẢ BÓNG
                        bong.X = ball[1].X;
                        bong.Y = ball[1].Y;
                        hel1 = new ELip(bong.X, bong.Y, 20, 20);
                        hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Green);

                        for (int i = 270; i < 820; i += 50)
                        {

                            ball[1].X = i;
                            ball[1] = chd.TinhTien(ball[1].X, ball[1].Y, 0, 15);

                            bong.X = ball[1].X;
                            bong.Y = ball[1].Y;
                            hel1 = new ELip(bong.X, bong.Y, 20, 20);
                            hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);
                            if (i > 600)
                            {
                                ve2.VeKhungThanhSan(whiteBrush, e);

                            }

                            Thread.Sleep(300);

                         
                            hel1 = new ELip(bong.X, bong.Y, 20, 20);
                            hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Green);


                            vitribongX = ball[1].X;
                            vitribongY = ball[1].Y;
                            HienThiToaDoQuaBong(m[1], m[2], m[3], m[4], m[5], m[6], m[7], z[1], z[2], z[3], z[4], z[5], z[6], z[7],
                            ball[1]);

                        }
                        hel1 = new ELip(vitribongX+100, vitribongY+20, 20, 20);
                        hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);
                        ve2.VeKhungThanhSan(whiteBrush, e);

                        #endregion

                        #region Xóa người B
                        B1 = new Line(m[1].X, m[1].Y, m[3].X, m[3].Y, Color.Red); //tao AB 
                        B1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 

                        B2 = new Line(m[2].X, m[2].Y, m[4].X, m[4].Y, Color.Red); //tao AB 
                        B2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 

                        B3 = new Line(m[2].X, m[2].Y, m[5].X, m[5].Y, Color.Red); //tao AB 
                        B3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 

                        B4 = new Line(m[6].X, m[6].Y, m[3].X, m[3].Y, Color.Red); //tao AB 
                        B4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 

                        B5 = new Line(m[3].X, m[3].Y, m[7].X, m[7].Y, Color.Red); //tao AB 
                        B5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 

                        DauB.X = m[1].X;
                        DauB.Y = m[1].Y - 20;
                        hel1 = new ELip(DauB.X, DauB.Y, 20, 20);
                        hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Green);
                        #endregion

                        #region Người bay cản phá bóng thủ môn

                        int hsx = Convert.ToInt32("1"), hsy = Convert.ToInt32("0"),
                               hsx1 = Convert.ToInt32("0"), hsy1 = Convert.ToInt32("0");
                        hsy = -hsy; hsy1 = -hsy1;

                        
                        int A = hsy1 - hsy, B = hsx - hsx1, C = hsx1 * hsy - hsx * hsy1;
                        if (hsx != 0 || hsy != 0)
                        {
                            
                            HienThiToaDo1(m[1], m[2], m[3], m[4], m[5], m[6], m[7], z[1], z[2], z[3], z[4], z[5], z[6], z[7],
                            ball[1]);

                        }

                        m[1] = chd.DoiXung(m[1].X, m[1].Y, hsx, hsy, hsx1, hsy1);
                        m[2] = chd.DoiXung(m[2].X, m[2].Y, hsx, hsy, hsx1, hsy1);
                        m[3] = chd.DoiXung(m[3].X, m[3].Y, hsx, hsy, hsx1, hsy1);
                        m[4] = chd.DoiXung(m[4].X + 50, m[4].Y - 80, hsx, hsy, hsx1, hsy1);
                        m[5] = chd.DoiXung(m[5].X - 50, m[5].Y - 80, hsx, hsy, hsx1, hsy1);
                        m[6] = chd.DoiXung(m[6].X, m[6].Y, hsx, hsy, hsx1, hsy1);
                        m[7] = chd.DoiXung(m[7].X, m[7].Y, hsx, hsy, hsx1, hsy1);

                        //ve2.VeHinhNguoi(m[1].X, m[1].Y, m[2].X, m[2].Y, m[3].X, m[3].Y, m[4].X, m[4].Y, m[5].X, m[5].Y
                        //     , m[6].X, m[6].Y, m[7].X, m[7].Y, 20, 20, bmp, Color.Red);// người phải

                        B1 = new Line(m[1].X, m[1].Y, m[3].X, m[3].Y, Color.Red); //tao AB 
                        B1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                        B2 = new Line(m[2].X, m[2].Y, m[4].X, m[4].Y, Color.Red); //tao AB 
                        B2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                        B3 = new Line(m[2].X, m[2].Y, m[5].X, m[5].Y, Color.Red); //tao AB 
                        B3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                        B4 = new Line(m[6].X, m[6].Y, m[3].X, m[3].Y, Color.Red); //tao AB 
                        B4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                        B5 = new Line(m[3].X, m[3].Y, m[7].X, m[7].Y, Color.Red); //tao AB 
                        B5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Blue); // ve dt AB bang DDA 

                        int dxx = m[1].X;
                        int dxy = m[1].Y+20;
                        DauB.X = m[1].X;
                        DauB.Y = m[1].Y+20;
                        hel1 = new ELip(dxx, dxy, 20, 20);
                        hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Blue);
                        #endregion


                        #region Vẽ chữ VÀO 
                        //
                        //V
                        //Line v1, v2, v3, v4, v5, v6;
                        B1 = new Line(100, 500, 150, 650, Color.Red); //tao AB 
                        B1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        B2 = new Line(150, 650, 200, 500, Color.Red); //tao AB 
                        B2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        B3 = new Line(200, 650, 250, 500, Color.Red); //tao AB 
                        B3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        B4 = new Line(250, 500, 300, 650, Color.Red); //tao AB 
                        B4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        B5 = new Line(220, 600, 285, 600, Color.Red); //tao AB 
                        B5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        hel2 = new ELip(375, 575, 55, 70);
                        hel2.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);

                        B5 = new Line(270, 480, 200, 450, Color.Red); //tao AB 
                        B5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 



                        #endregion

                        #region Hien thi bang so
                     
                        hel1 = new ELip(275, 35, 20, 25);
                        hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Green);
                        A1 = new Line(275, 35, 300, 10, Color.Red); //tao AB 
                        A1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        A2 = new Line(300, 10, 300, 60, Color.Red); //tao AB 
                        A2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        //-
                        gachTySo = new Line(320, 35, 335, 35, Color.Red); //tao AB 
                        gachTySo.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        //0
                        hel2 = new ELip(375, 35, 20, 25);
                        hel2.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);

                        #endregion

                        #region Xóa người A
                        //Người bên trái 
                        A1 = new Line(z[1].X, z[1].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                        A1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 

                        A2 = new Line(z[2].X, z[2].Y, z[4].X, z[4].Y, Color.Red); //tao AB 
                        A2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 

                        A3 = new Line(z[2].X, z[2].Y, z[5].X, z[5].Y, Color.Red); //tao AB 
                        A3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 

                        A4 = new Line(z[6].X, z[6].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                        A4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 

                        A5 = new Line(z[3].X, z[3].Y, z[7].X, z[7].Y, Color.Red); //tao AB 
                        A5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Green); // ve dt AB bang DDA 


                        DauA.X = z[1].X;
                        DauA.Y = z[1].Y - 20;
                        hel1 = new ELip(DauA.X, DauA.Y, 20, 20);
                        hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Green);
                        #endregion

                        z[4].X = 190; z[4].Y = 200;
                        z[5].X = 260; z[5].Y = 200;
                        z[7].X = 240; z[7].Y = 350;

                        #region Vẽ người A
                        //Người bên trái 
                        A1 = new Line(z[1].X, z[1].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                        A1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        A2 = new Line(z[2].X, z[2].Y, z[4].X, z[4].Y, Color.Red); //tao AB 
                        A2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        A3 = new Line(z[2].X, z[2].Y, z[5].X, z[5].Y, Color.Red); //tao AB 
                        A3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        A4 = new Line(z[6].X, z[6].Y, z[3].X, z[3].Y, Color.Red); //tao AB 
                        A4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 

                        A5 = new Line(z[3].X, z[3].Y, z[7].X, z[7].Y, Color.Red); //tao AB 
                        A5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Red); // ve dt AB bang DDA 


                        DauA.X = z[1].X;
                        DauA.Y = z[1].Y - 20;
                        hel1 = new ELip(DauA.X, DauA.Y, 20, 20);
                        hel1.Midpoint_elip(this.heTrucToaDo.CreateGraphics(), Color.Red);
                        #endregion

                        chDong1 = false;
                        heTrucToaDo.BackColor = Color.White;
                        Thread.Sleep(3000);
                    }
                }

                else if (veHinh2 == true)
                {
                    Truc2D(e);
                    DuongThang dth = new DuongThang();
                    PhepBienDoi chd = new PhepBienDoi();
                    ELip el = new ELip();

                    if (chDong2 == true)
                    {
                        //To mau nen
                        Rectangle duong = new Rectangle(0, 0, 1000, 600);
                        e.Graphics.FillRectangle(khakiBrush, duong);
                        //Ho nuoc
                        Rectangle honuoc = new Rectangle(-300, 400, 1600, 400);
                        e.Graphics.FillEllipse(skyblueBrush, honuoc);
                    }



                    //
                    int bonusx = 200;
                    // Vẽ nhà 
                    Point[] house1 = new Point[14];
                    Point[] house2 = new Point[14];
                    Point[] house3 = new Point[14];
                    Point[] fish1 = new Point[6];
                    Point[] fish2 = new Point[6];
                    Point[] fish3 = new Point[6];
                    Point[] fish4 = new Point[6];
                    Point[] fish5 = new Point[6];
                    Point[] moon = new Point[2];

                    #region Con ca

                    //Ve con ca thu 1

                    //A
                    fish1[0].X = 350;
                    fish1[0].Y = 550;
                    //B
                    fish1[1].X = 350;
                    fish1[1].Y = 500;

                    //C
                    fish1[2].X = 300;
                    fish1[2].Y = 500;
                    //D

                    fish1[3].X = 300;
                    fish1[3].Y = 550;


                    fish1[5].X = 325;
                    fish1[5].Y = 525;
                    //TAM DAU CON CA
                    fish1[4].X = 375;
                    fish1[4].Y = ((fish1[0].Y + fish1[1].Y) / 2);
                    ve2.VeConCa(fish1[0], fish1[1], fish1[2], fish1[3], fish1[4], heTrucToaDo.CreateGraphics(), Color.Blue);


                    ////=========Ve con ca thu 2
                    ////A
                    fish2[0].X = 400;
                    fish2[0].Y = 685;
                    //B
                    fish2[1].X = 400;
                    fish2[1].Y = 635;

                    //C
                    fish2[2].X = 350;
                    fish2[2].Y = 635;
                    //D

                    fish2[3].X = 350;
                    fish2[3].Y = 685;


                    fish2[5].X = 375;
                    fish2[5].Y = 660;
                    //TAM DAU CON CA
                    fish2[4].X = 425;
                    fish2[4].Y = ((fish2[0].Y + fish2[1].Y) / 2);
                    ve2.VeConCa(fish2[0], fish2[1], fish2[2], fish2[3], fish2[4], heTrucToaDo.CreateGraphics(), Color.Orange);




                    //==========Ve con ca thu 3
                    ////A
                    fish3[0].X = 250;
                    fish3[0].Y = 625;
                    //B
                    fish3[1].X = 250;
                    fish3[1].Y = 575;

                    //C
                    fish3[2].X = 200;
                    fish3[2].Y = 575;
                    //D

                    fish3[3].X = 200;
                    fish3[3].Y = 625;


                    fish3[5].X = 225;
                    fish3[5].Y = 600;
                    //TAM DAU CON CA
                    fish3[4].X = 275;
                    fish3[4].Y = ((fish3[0].Y + fish3[1].Y) / 2);
                    ve2.VeConCa(fish3[0], fish3[1], fish3[2], fish3[3], fish3[4], heTrucToaDo.CreateGraphics(), Color.Yellow);


                    //==========Ve con ca thu 4
                    ////A
                    fish4[0].X = 150;
                    fish4[0].Y = 550;
                    //B
                    fish4[1].X = 150;
                    fish4[1].Y = 500;

                    //C
                    fish4[2].X = 100;
                    fish4[2].Y = 500;
                    //D

                    fish4[3].X = 100;
                    fish4[3].Y = 550;


                    fish4[5].X = 125;
                    fish4[5].Y = 525;
                    //TAM DAU CON CA
                    fish4[4].X = 175;
                    fish4[4].Y = ((fish4[0].Y + fish4[1].Y) / 2);
                    ve2.VeConCa(fish4[0], fish4[1], fish4[2], fish4[3], fish4[4], heTrucToaDo.CreateGraphics(), Color.Purple);

                    //Ve con ca thu 5
                    //A
                    fish5[0].X = 70;
                    fish5[0].Y = 670;
                    //B
                    fish5[1].X = 70;
                    fish5[1].Y = 620;

                    //C
                    fish5[2].X = 20;
                    fish5[2].Y = 620;
                    //D

                    fish5[3].X = 20;
                    fish5[3].Y = 670;


                    fish5[5].X = 45;
                    fish5[5].Y = 645;
                    //TAM DAU CON CA
                    fish5[4].X = 95;
                    fish5[4].Y = ((fish5[0].Y + fish5[1].Y) / 2);
                    ve2.VeConCa(fish5[0], fish5[1], fish5[2], fish5[3], fish5[4], heTrucToaDo.CreateGraphics(), Color.Khaki);


                    //Ve khung con ca
                    Point[] colorfish11 = { fish1[5], fish1[1], fish1[4], fish1[0] };
                    Point[] colorfish12 = { fish1[2], fish1[3], fish1[5] };

                    Point[] colorfish21 = { fish2[5], fish2[1], fish2[4], fish2[0] };
                    Point[] colorfish22 = { fish2[2], fish2[3], fish2[5] };

                    Point[] colorfish31 = { fish3[5], fish3[1], fish3[4], fish3[0] };
                    Point[] colorfish32 = { fish3[2], fish3[3], fish3[5] };

                    Point[] colorfish41 = { fish4[5], fish4[1], fish4[4], fish4[0] };
                    Point[] colorfish42 = { fish4[2], fish4[3], fish4[5] };

                    Point[] colorfish51 = { fish5[5], fish5[1], fish5[4], fish5[0] };
                    Point[] colorfish52 = { fish5[2], fish5[3], fish5[5] };
                    #endregion
                    #region Ngoi nha
                    Line h1, h2, h3, h4, h5, h6, h7, h8, h9, h10, h11;
                    //Ngoi nha 1
                    house1[1].X = 200;
                    house1[1].Y = 200;
                    house1[2].X = 400;
                    house1[2].Y = 200;
                    house1[3].X = 400;
                    house1[3].Y = 350;
                    house1[4].X = 200;
                    house1[4].Y = 350;
                    house1[9].X = 150;
                    house1[9].Y = 200;
                    house1[10].X = 300;
                    house1[10].Y = 100;
                    house1[11].X = 450;
                    house1[11].Y = 200;
                    house1[5].X = 280;
                    house1[5].Y = 290;
                    house1[6].X = 320;
                    house1[6].Y = 290;
                    house1[7].X = 320;
                    house1[7].Y = 350;
                    house1[8].X = 280;
                    house1[8].Y = 350;


                    h1 = new Line(house1[2].X, house1[2].Y, house1[3].X, house1[3].Y, Color.Red); //tao AB 
                    h1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    h2 = new Line(house1[1].X, house1[1].Y, house1[2].X, house1[2].Y, Color.Red); //tao AB 
                    h2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    h3 = new Line(house1[4].X, house1[4].Y, house1[3].X, house1[3].Y, Color.Red); //tao AB 
                    h3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    h4 = new Line(house1[1].X, house1[1].Y, house1[4].X, house1[4].Y, Color.Red); //tao AB 
                    h4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    h5 = new Line(house1[5].X, house1[5].Y, house1[6].X, house1[6].Y, Color.Red); //tao AB 
                    h5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    h6 = new Line(house1[6].X, house1[6].Y, house1[7].X, house1[7].Y, Color.Red); //tao AB 
                    h6.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    h7 = new Line(house1[7].X, house1[7].Y, house1[8].X, house1[8].Y, Color.Red); //tao AB 
                    h7.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    h8 = new Line(house1[8].X, house1[8].Y, house1[5].X, house1[5].Y, Color.Red); //tao AB 
                    h8.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    h9 = new Line(house1[9].X, house1[9].Y, house1[10].X, house1[10].Y, Color.Red); //tao AB 
                    h9.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    h10 = new Line(house1[10].X, house1[10].Y, house1[11].X, house1[11].Y, Color.Red); //tao AB 
                    h10.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    h11 = new Line(house1[9].X, house1[9].Y, house1[11].X, house1[11].Y, Color.Red); //tao AB 
                    h11.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 

                    Point[] Mainha = { house1[9], house1[10], house1[11] };




                    #endregion


                    Point[] coixoay1 = new Point[14];
                    Point[] coixoay2 = new Point[14];
                    Point[] coixoay3 = new Point[14];

                    Line cx1, cx2, cx3, cx4, cx5, cx6, cx7;
                   

                    Line thancoi, canh10, canh20, canh30, canh40, than1, than2, than3;
                    // thân
                    //than = new Line(700,350,700,200, Color.Red); //tao AB 
                    //than.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    //cánh

                    Point[] canh = new Point[5];
                    Point[] tam = new Point[2];
                    Point[] than = new Point[5];

                    canh[1].X = 600;
                    canh[1].Y = 150;

                    canh[2].X = 700;
                    canh[2].Y = 250;

                    canh[3].X = 800;
                    canh[3].Y = 150;

                    canh[4].X = 700;
                    canh[4].Y = 50;

                    tam[1].X = 700;
                    tam[1].Y = 150;

                    than[1].X = 650;
                    than[1].Y = 350;
                    than[2].X = 750;
                    than[2].Y = 350;
                    


                    canh10 = new Line(canh[1].X, canh[1].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                    canh10.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    canh20 = new Line(canh[2].X, canh[2].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                    canh20.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    canh30 = new Line(canh[3].X, canh[3].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                    canh30.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    canh40 = new Line(canh[4].X, canh[4].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                    canh40.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 

                    than1 = new Line(tam[1].X, tam[1].Y, than[1].X, than[1].Y, Color.Red);
                    than1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black);
                    than2 = new Line(tam[1].X, tam[1].Y, than[2].X, than[2].Y, Color.Red);
                    than2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black);
                    than3 = new Line(than[1].X, than[1].Y, than[2].X, than[2].Y, Color.Red);
                    than3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black);
                 



                    HienThiToaDo2(house1, fish1, moon[1]);




                    if (chDong2 == true)
                    {

                        //XoaTruc2DHinh1(e,Pens.White);
                        PhepBienDoi bienDoi = new PhepBienDoi();


                        //Tuong nha
                        e.Graphics.FillRectangle(skyblueBrush, house1[1].X, house1[1].Y, 200, 150);
                        //Cua nha
                        e.Graphics.FillRectangle(yellowBrush, house1[5].X, house1[5].Y, 40, 60);
                        //Mai nha
                        e.Graphics.FillPolygon(redBrush, Mainha);



                        h1 = new Line(house1[2].X, house1[2].Y, house1[3].X, house1[3].Y, Color.Red); //tao AB 
                        h1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                        h2 = new Line(house1[1].X, house1[1].Y, house1[2].X, house1[2].Y, Color.Red); //tao AB 
                        h2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                        h3 = new Line(house1[4].X, house1[4].Y, house1[3].X, house1[3].Y, Color.Red); //tao AB 
                        h3.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                        h4 = new Line(house1[1].X, house1[1].Y, house1[4].X, house1[4].Y, Color.Red); //tao AB 
                        h4.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                        h5 = new Line(house1[5].X, house1[5].Y, house1[6].X, house1[6].Y, Color.Red); //tao AB 
                        h5.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                        h6 = new Line(house1[6].X, house1[6].Y, house1[7].X, house1[7].Y, Color.Red); //tao AB 
                        h6.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                        h7 = new Line(house1[7].X, house1[7].Y, house1[8].X, house1[8].Y, Color.Red); //tao AB 
                        h7.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                        h8 = new Line(house1[8].X, house1[8].Y, house1[5].X, house1[5].Y, Color.Red); //tao AB 
                        h8.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                        h9 = new Line(house1[9].X, house1[9].Y, house1[10].X, house1[10].Y, Color.Red); //tao AB 
                        h9.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                        h10 = new Line(house1[10].X, house1[10].Y, house1[11].X, house1[11].Y, Color.Red); //tao AB 
                        h10.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                        h11 = new Line(house1[9].X, house1[9].Y, house1[11].X, house1[11].Y, Color.Red); //tao AB 
                        h11.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 




                        //To mau con ca

                        e.Graphics.FillPolygon(blueBrush, colorfish11);
                        e.Graphics.FillPolygon(blueBrush, colorfish12);

                        e.Graphics.FillPolygon(orangeBrush, colorfish21);
                        e.Graphics.FillPolygon(orangeBrush, colorfish22);


                        e.Graphics.FillPolygon(yellowBrush, colorfish31);
                        e.Graphics.FillPolygon(yellowBrush, colorfish32);


                        e.Graphics.FillPolygon(purpleBrush, colorfish41);
                        e.Graphics.FillPolygon(purpleBrush, colorfish42);


                        e.Graphics.FillPolygon(khakiBrush, colorfish51);
                        e.Graphics.FillPolygon(khakiBrush, colorfish52);









                        //Ve mat trang chuyen dong
                        int dem = 0;
                        for (int i = 40; i <= 740; i += 70)
                        {

                            moon[1].X = 10 + i;
                            moon[1].Y = 40;


                            HT mt = new HT(moon[1].X, moon[1].Y, 30 - dem);
                            mt.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Black);
                            Rectangle mattrang = new Rectangle(moon[1].X - 30 + dem, moon[1].Y - 30 + dem, 60 - (dem * 2), 60 - (dem * 2));
                            e.Graphics.FillEllipse(yellowBrush, mattrang);
                            Thread.Sleep(400);
                            mt.Midpoint_htron(this.heTrucToaDo.CreateGraphics(), Color.Khaki);
                            e.Graphics.FillEllipse(khakiBrush, mattrang);
                            dem = dem + 2;
                        }



                        //Ca chuyen dong
                        ve2.VeConCa(fish1[0], fish1[1], fish1[2], fish1[3], fish1[4], heTrucToaDo.CreateGraphics(), Color.LightSkyBlue);
                        e.Graphics.FillPolygon(skyblueBrush, colorfish11);
                        e.Graphics.FillPolygon(skyblueBrush, colorfish12);
                        for (int i = 50; i <= 400; i += 50)
                        {
                            //Cho vẽ con cá tiếp theo
                            //A
                            fish1[0] = chd.TinhTien(fish1[0].X, fish1[0].Y, 50, 0);
                            fish1[1] = chd.TinhTien(fish1[1].X, fish1[1].Y, 50, 0);
                            fish1[2] = chd.TinhTien(fish1[2].X, fish1[2].Y, 50, 0);
                            fish1[3] = chd.TinhTien(fish1[3].X, fish1[3].Y, 50, 0);
                            fish1[4] = chd.TinhTien(fish1[4].X, fish1[4].Y, 50, 0);
                            fish1[5] = chd.TinhTien(fish1[5].X, (fish1[0].Y + fish1[1].Y) / 2, 50, 0);

                            ve2.VeConCa(fish1[0], fish1[1], fish1[2], fish1[3], fish1[4], heTrucToaDo.CreateGraphics(), Color.Blue);


                            Point[] colorfish111 = { fish1[5], fish1[1], fish1[4], fish1[0] };
                            Point[] colorfish122 = { fish1[2], fish1[3], fish1[5] };

                            e.Graphics.FillPolygon(blueBrush, colorfish111);
                            e.Graphics.FillPolygon(blueBrush, colorfish122);
                            Thread.Sleep(200);
                            ve2.VeConCa(fish1[0], fish1[1], fish1[2], fish1[3], fish1[4], heTrucToaDo.CreateGraphics(), Color.LightSkyBlue);
                            e.Graphics.FillPolygon(skyblueBrush, colorfish111);
                            e.Graphics.FillPolygon(skyblueBrush, colorfish122);

                        }


                        //Chong chong quay
                        for (int i = 1; i < 12; i++)
                        {
                            canh[1] = bienDoi.rotate(canh[1], tam[1], i);
                            canh[2] = bienDoi.rotate(canh[2], tam[1], i);
                            canh[3] = bienDoi.rotate(canh[3], tam[1], i);
                            canh[4] = bienDoi.rotate(canh[4], tam[1], i);

                            canh10 = new Line(canh[1].X, canh[1].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                            canh10.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                            canh20 = new Line(canh[2].X, canh[2].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                            canh20.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                            canh30 = new Line(canh[3].X, canh[3].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                            canh30.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                            canh40 = new Line(canh[4].X, canh[4].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                            canh40.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 

                            Thread.Sleep(200);
                            canh10 = new Line(canh[1].X, canh[1].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                            canh10.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Khaki); // ve dt AB bang DDA 
                            canh20 = new Line(canh[2].X, canh[2].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                            canh20.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Khaki); // ve dt AB bang DDA 
                            canh30 = new Line(canh[3].X, canh[3].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                            canh30.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Khaki); // ve dt AB bang DDA 
                            canh40 = new Line(canh[4].X, canh[4].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                            canh40.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Khaki); // ve dt AB bang DDA 

                            //To lai mau 2 canh coi xoay
                            than1.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black);
                            than2.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black);
                        }
                        canh10 = new Line(canh[1].X, canh[1].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                        canh10.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                        canh20 = new Line(canh[2].X, canh[2].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                        canh20.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                        canh30 = new Line(canh[3].X, canh[3].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                        canh30.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                        canh40 = new Line(canh[4].X, canh[4].Y, tam[1].X, tam[1].Y, Color.Red); //tao AB 
                        canh40.DDA_Line(heTrucToaDo.CreateGraphics(), Color.Black); // ve dt AB bang DDA 
                    }
                }

            }
            //Vẽ 3D
            else if (TrucToaDo == 2)
            {
                Truc3D truc3D = new Truc3D();
                truc3D.VeTruc(bmp, e);

                if (veHHCN == true)
                {

                    HinhHopChuNhat hinhHop = new HinhHopChuNhat();
                    double x, y, z, dai, cao, rong;
                    x = Convert.ToDouble(toadoX_3D.Text);
                    y = Convert.ToDouble(toadoY_3D.Text);
                    z = Convert.ToDouble(toadoZ_3D.Text);
                    dai = Convert.ToDouble(daiHHCN.Text);
                    cao = Convert.ToDouble(caoHHCN.Text);
                    rong = Convert.ToDouble(rongHHCN.Text);
                    z /= 2;
                    x *= 10; y *= 10; z *= 10; dai *= 10; cao *= 10; rong *= 10;

                    hinhHop.VeHinh(x, y, z, dai, cao, rong, Color.Black, this.heTrucToaDo.CreateGraphics());

                    diemA.Location = new Point((int)(x - z + 500), (int)(350 - y + z));
                    diemB.Location = new Point((int)(x - z + dai + 500), (int)(350 - y + z));
                    diemC.Location = new Point((int)(x - z + dai + 500), (int)(350 - y + z - cao));
                    diemD.Location = new Point((int)(x - z + 500), (int)(350 - y + z - cao));
                    diemE.Location = new Point((int)(x - z - (rong * Math.Sqrt(2)) / 2 + 500), (int)(350 - y + z + (rong * Math.Sqrt(2)) / 2));
                    diemF.Location = new Point((int)(x - z + (dai - (rong * Math.Sqrt(2)) / 2) + 500), (int)(350 - y + z + (rong * Math.Sqrt(2)) / 2));
                    diemG.Location = new Point((int)(x - z + dai - (rong * Math.Sqrt(2)) / 2 + 500), (int)(350 - y + z - (cao - (rong * Math.Sqrt(2)) / 2)));
                    diemH.Location = new Point((int)(x - z - (rong * Math.Sqrt(2)) / 2 + 500), (int)(350 - y + z - (cao - (rong * Math.Sqrt(2)) / 2)));

                    x = x / 10; y = y / 10; z = (z * 2) / 10;

                    toadoA.Text = "A(" + x + "," + y + "," + z + ")";
                    toadoB.Text = "B(" + (x + dai / 10) + "," + y + "," + z + ")";
                    toadoD.Text = "D(" + x + "," + (y + cao / 10) + "," + z + ")";
                    toadoE.Text = "E(" + x + "," + y + "," + (z + rong / 10) + ")";
                    toadoC.Text = "C(" + (x + dai / 10) + "," + (y + cao / 10) + "," + z + ")";
                    toadoF.Text = "F(" + (x + dai / 10) + "," + y + "," + (z + rong / 10) + ")";
                    toadoH.Text = "H(" + x + "," + (y + cao / 10) + "," + (z + rong / 10) + ")";
                    toadoG.Text = "G(" + (x + dai / 10) + "," + (y + cao / 10) + "," + (z + rong / 10) + ")";

                    thongTinToaDo1.Text = thongTinToaDo2.Text = thongTinToaDo3.Text = thongTinToaDo4.Text = thongTinToaDo5.Text = thongTinToaDo6.Text = thongTinToaDo7.Text = "";
                    thongTinToaDo1.Visible = thongTinToaDo2.Visible = thongTinToaDo3.Visible = thongTinToaDo4.Visible = thongTinToaDo5.Visible = thongTinToaDo6.Visible =
                    diemA.Visible = diemB.Visible = diemC.Visible = diemD.Visible = diemE.Visible = diemF.Visible = diemG.Visible
                = diemH.Visible = toadoA.Visible = toadoB.Visible = toadoC.Visible = toadoD.Visible = toadoE.Visible = toadoF.Visible = toadoG.Visible = toadoH.Visible = true;

                }

                if (veHinhTru == true)
                {

                    HinhTruTron hinhTru = new HinhTruTron();
                    double x, y, z, bankinh, chieucao;
                    x = Convert.ToDouble(toadoX_3D.Text);
                    y = Convert.ToDouble(toadoY_3D.Text);
                    z = Convert.ToDouble(toadoZ_3D.Text);
                    //chiều rộng
                    bankinh = Convert.ToDouble(daiHHCN.Text);
                    chieucao = Convert.ToDouble(rongHHCN.Text);

                    double x1 = x, y1 = y, z1 = z, bk1 = bankinh, chieucao1 = chieucao;
                    x1 *= 10; y1 *= 10; z1 /= 2; z1 *= 10; bk1 *= 10; chieucao1 *= 10;
                    hinhTru.VeHinh(x1, y1, z1, bk1, chieucao1, heTrucToaDo.CreateGraphics());

                    diemF.Location = new Point((int)(x1 - z1 + 501), (int)(350 - y1 + z1));
                    diemB.Location = new Point((int)(x1 - z1 + bk1 + 501), (int)(350 - y1 + z1));
                    diemC.Location = new Point((int)(x1 - z1 + bk1 + 501), (int)(350 - y1 + z1 - chieucao1));
                    diemD.Location = new Point((int)(x1 - z1 - bk1 + 489), (int)(350 - y1 + z1));
                    diemE.Location = new Point((int)(x1 - z1 - bk1 + 489), (int)(350 - y1 + z1 - chieucao1));
                    diemA.Location = new Point((int)(x1 - z1 + 501), (int)(350 - y1 + z1 - chieucao1));

                    toadoA.Text = "F(" + x + "," + y + "," + z + ")";
                    toadoB.Text = "B(" + (bankinh + x) + "," + y + "," + z + ")";
                    toadoC.Text = "C(" + x + "," + (chieucao + y) + "," + z + ")";
                    toadoD.Text = "D(" + (x - bankinh) + "," + y + "," + z + ")";
                    toadoE.Text = "E(" + (x - bankinh) + "," + (y + chieucao) + "," + z + ")";
                    toadoF.Text = "A(" + x + "," + (y + chieucao) + "," + z + ")";
                    thongTinToaDo1.Text = "Hình Elip tâm O";
                    thongTinToaDo2.Text = "Bán kính R = " + bankinh + ", r = " + bankinh / 2;
                    thongTinToaDo3.Text = "Hình Elip tâm A";
                    thongTinToaDo4.Text = "Bán kính R = " + bankinh + ", r = " + bankinh / 2;
                    thongTinToaDo5.Text = "";
                    thongTinToaDo6.Text = "";
                    thongTinToaDo1.Visible = thongTinToaDo2.Visible = thongTinToaDo3.Visible = thongTinToaDo4.Visible = thongTinToaDo5.Visible = thongTinToaDo6.Visible =
                    diemA.Visible = diemB.Visible = diemC.Visible = diemD.Visible = diemE.Visible = diemF.Visible
                        = toadoA.Visible = toadoB.Visible = toadoC.Visible = toadoD.Visible = toadoE.Visible = toadoF.Visible = true;

                }
            }
            bmp.Dispose();
        }
    }
}


