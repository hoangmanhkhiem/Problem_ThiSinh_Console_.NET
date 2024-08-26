using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Bài tập 1_0: Xây dựng lớp thí sinh:
//Thuộc tính: sbd, ht, m1, m2, m3
//Phương thức: tạo, nhập, tính tổng điểm
//Xây dựng lớp Tuyển sinh kế thừa từ lớp thí sinh:
//Thuộc tính bổ sung: Khu vực
//Phương thức: Nhập, xuất, Tính tổng điểm:
//M1 + m2 + m2 + điểmKV; nếu KV là 1 thì điểmKV là 0, nếu KV là 2 thì điểm KV là 1, nếu KV là 3 thì điểmKV là 2. 
//Viết chương trình nhập thông tin cho n thí sinh (sbd, ht, m1, m2, m3, khu vực dự thi (1,2,3)). In Nhập điểm chuẩn và in danh sách trúng tuyển.

namespace ThiSinh
{
    class ThiSinh
    {
        private string sbd, ht;
        private double m1, m2, m3;
        public ThiSinh()
        {
            sbd = ht = "";
            m1 = m2 = m3 = 0;
        }
        public ThiSinh(string sbd, string ht, double m1, double m2, double m3)
        {
            this.sbd = sbd;
            this.ht = ht;
            this.m1 = m1;
            this.m2 = m2;
            this.m3 = m3;
        }

        public virtual void Nhap()
        {
            Console.Write("Nhap sbd: "); sbd = Console.ReadLine().Trim();
            Console.Write("Nhap ho ten: "); ht = Console.ReadLine().Trim();
            nhaplai:
            try
            {
                Console.Write("Nhap diem 1: "); 
                m1 = double.Parse(Console.ReadLine().Trim());
                if(m1 < 0 || m1 > 10) throw new Exception("Diem khong hop le");
                Console.Write("Nhap diem 2: "); 
                m2 = double.Parse(Console.ReadLine().Trim());
                if(m2 < 0 || m2 > 10) throw new Exception("Diem khong hop le");
                Console.Write("Nhap diem 3: "); 
                m3 = double.Parse(Console.ReadLine().Trim());
                if(m3 < 0 || m3 > 10) throw new Exception("Diem khong hop le");
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi: {0}", e.Message);
                goto nhaplai;
            }

        }

        public virtual void Xuat()
        {
            Console.WriteLine("SBD: {0}", sbd);
            Console.WriteLine("Ho ten: {0}", ht);
            Console.WriteLine("Diem 1: {0}", m1);
            Console.WriteLine("Diem 2: {0}", m2);
            Console.WriteLine("Diem 3: {0}", m3);
        }

        public virtual double TinhTongDiem()
        {
            return m1 + m2 + m3;
        }
    }
    class TuyenSinh : ThiSinh
    {
        private int khuVuc;
        public TuyenSinh() : base()
        {
            khuVuc = 0;
        }
        public TuyenSinh(string sbd, string ht, double m1, double m2, double m3, int khuVuc) : base(sbd, ht, m1, m2, m3)
        {
            this.khuVuc = khuVuc;
        }
        public void Nhap()
        {
            base.Nhap();
            nhaplai:
            try
            {
                Console.Write("Nhap khu vuc: "); khuVuc = int.Parse(Console.ReadLine().Trim());
                if (khuVuc < 1 || khuVuc > 3) throw new Exception("Khu vuc khong hop le");
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi: {0}", e.Message);
                goto nhaplai;
            }
            
        }
        public void Xuat() 
        {
            base.Xuat();
            Console.WriteLine("Khu vuc: {0}", khuVuc);
        }
        public double TinhTongDiem ()
        {
            double diemKV = 0;
            if (khuVuc == 1) diemKV = 0;
            if (khuVuc == 2) diemKV = 1;
            if (khuVuc == 3) diemKV = 2;
            return base.TinhTongDiem() + diemKV;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Nhap so thi sinh: "); n = int.Parse(Console.ReadLine().Trim());
            TuyenSinh[] ts = new TuyenSinh[n];
            for (int i = 0; i < n; i++)
            {
                ts[i] = new TuyenSinh();
                ts[i].Nhap();
            }
            Console.WriteLine("Nhap diem chuan: ");
            double diemChuan = double.Parse(Console.ReadLine().Trim());
            Console.WriteLine("Danh sach trung tuyen: ");
            for (int i = 0; i < n; i++)
            {
                if (ts[i].TinhTongDiem() >= diemChuan)
                {
                    ts[i].Xuat();
                    Console.WriteLine("Tong diem: {0}", ts[i].TinhTongDiem());
                }
            }
            Console.ReadLine();
        }
    }
}
