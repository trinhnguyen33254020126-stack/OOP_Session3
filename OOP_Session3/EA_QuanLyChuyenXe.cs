using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Session3
{
    internal class EA_QuanLyChuyenXe
    {
        public class ChuyenXe
        {
            public string MaSoChuyen { get; set; }
            public string HoTenTaiXe { get; set; }
            public string SoXe { get; set; }
            public double DoanhThu { get; set; }

            public ChuyenXe(string ma, string ten, string xe, double dt)
            {
                MaSoChuyen = ma;
                HoTenTaiXe = ten;
                SoXe = xe;
                DoanhThu = dt;
            }

            public virtual void XuatThongTin()
            {
                Console.Write($"Ma chuyen: {MaSoChuyen} | Tai xe: {HoTenTaiXe} | So xe: {SoXe} | Doanh thu: {DoanhThu:N0} VND");
            }
        }

        public class NoiThanhChuyenXe : ChuyenXe
        {
            public int SoTuyen { get; set; }
            public double SoKm { get; set; }

            public NoiThanhChuyenXe(string ma, string ten, string xe, double dt, int tuyen, double km)
                : base(ma, ten, xe, dt)
            {
                SoTuyen = tuyen;
                SoKm = km;
            }

            public override void XuatThongTin()
            {
                base.XuatThongTin();
                Console.WriteLine($" | So tuyen: {SoTuyen} | So km: {SoKm}");
            }
        }

        public class NgoaiThanhChuyenXe : ChuyenXe
        {
            public string NoiDen { get; set; }
            public int SoNgay { get; set; }

            public NgoaiThanhChuyenXe(string ma, string ten, string xe, double dt, string den, int ngay)
                : base(ma, ten, xe, dt)
            {
                NoiDen = den;
                SoNgay = ngay;
            }

            public override void XuatThongTin()
            {
                base.XuatThongTin();
                Console.WriteLine($" | Noi den: {NoiDen} | So ngay: {SoNgay}");
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                List<NoiThanhChuyenXe> dsNoiThanh = new List<NoiThanhChuyenXe>
            {
                new NoiThanhChuyenXe("NT01", "Nguyen Van A", "29B-12345", 1500000, 10, 45.5),
                new NoiThanhChuyenXe("NT02", "Tran Van B", "29B-67890", 2000000, 15, 60.0)
            };

                List<NgoaiThanhChuyenXe> dsNgoaiThanh = new List<NgoaiThanhChuyenXe>
            {
                new NgoaiThanhChuyenXe("NG01", "Le Van C", "30A-11111", 5000000, "Da Nang", 3),
                new NgoaiThanhChuyenXe("NG02", "Pham Van D", "30A-22222", 7500000, "Nha Trang", 5)
            };

                double tongDoanhThuNoiThanh = 0;
                double tongDoanhThuNgoaiThanh = 0;

                Console.WriteLine("=== DANH SACH CHUYEN XE NOI THANH ===");
                foreach (var cx in dsNoiThanh)
                {
                    cx.XuatThongTin();
                    tongDoanhThuNoiThanh += cx.DoanhThu;
                }

                Console.WriteLine("\n=== DANH SACH CHUYEN XE NGOAI THANH ===");
                foreach (var cx in dsNgoaiThanh)
                {
                    cx.XuatThongTin();
                    tongDoanhThuNgoaiThanh += cx.DoanhThu;
                }

                double tongDoanhThuTatCa = tongDoanhThuNoiThanh + tongDoanhThuNgoaiThanh;

                Console.WriteLine("\n================ KET QUA ================");
                Console.WriteLine($"Tong doanh thu chuyen xe noi thanh : {tongDoanhThuNoiThanh:N0} VND");
                Console.WriteLine($"Tong doanh thu chuyen xe ngoai thanh: {tongDoanhThuNgoaiThanh:N0} VND");
                Console.WriteLine($"Tong doanh thu tat ca chuyen xe    : {tongDoanhThuTatCa:N0} VND");
            }
        }
    }
}

