using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Session3
{
    internal class QuanLyThuVien
    {
        public abstract class Sach
        {
            public string MaSach { get; set; }
            public DateTime NgayNhap { get; set; }
            public double DonGia { get; set; }
            public int SoLuong { get; set; }
            public string NhaXuatBan { get; set; }

            public Sach() { }

            public Sach(string maSach, DateTime ngayNhap, double donGia, int soLuong, string nhaXuatBan)
            {
                MaSach = maSach;
                NgayNhap = ngayNhap;
                DonGia = donGia;
                SoLuong = soLuong;
                NhaXuatBan = nhaXuatBan;
            }

            public abstract double TinhThanhTien();

            public virtual void XuatThongTin()
            {
                Console.Write($"Mã: {MaSach} | Ngày nhập: {NgayNhap:dd/MM/yyyy} | Đơn giá: {DonGia:N0} | Số lượng: {SoLuong} | NXB: {NhaXuatBan}");
            }
        }

        public class SachGiaoKhoa : Sach
        {
            public string TinhTrang { get; set; }

            public SachGiaoKhoa() { }

            public SachGiaoKhoa(string maSach, DateTime ngayNhap, double donGia, int soLuong, string nhaXuatBan, string tinhTrang)
                : base(maSach, ngayNhap, donGia, soLuong, nhaXuatBan)
            {
                TinhTrang = tinhTrang;
            }

            public override double TinhThanhTien()
            {
                if (TinhTrang.Equals("mới", StringComparison.OrdinalIgnoreCase))
                {
                    return SoLuong * DonGia;
                }
                else
                {
                    return SoLuong * DonGia * 0.5;
                }
            }

            public override void XuatThongTin()
            {
                base.XuatThongTin();
                Console.WriteLine($" | Tình trạng: {TinhTrang} | Thành tiền: {TinhThanhTien():N0}");
            }
        }

        public class SachThamKhao : Sach
        {
            public double Thue { get; set; }

            public SachThamKhao() { }

            public SachThamKhao(string maSach, DateTime ngayNhap, double donGia, int soLuong, string nhaXuatBan, double thue)
                : base(maSach, ngayNhap, donGia, soLuong, nhaXuatBan)
            {
                Thue = thue;
            }

            public override double TinhThanhTien()
            {
                return (SoLuong * DonGia) + Thue;
            }

            public override void XuatThongTin()
            {
                base.XuatThongTin();
                Console.WriteLine($" | Thuế: {Thue:N0} | Thành tiền: {TinhThanhTien():N0}");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                List<Sach> danhSachSach = new List<Sach>
            {
                new SachGiaoKhoa("GK01", new DateTime(2023, 1, 10), 15000, 10, "Kim Đồng", "mới"),
                new SachGiaoKhoa("GK02", new DateTime(2023, 2, 15), 20000, 5, "Giáo Dục", "cũ"),
                new SachGiaoKhoa("GK03", new DateTime(2023, 3, 20), 12000, 8, "Kim Đồng", "cũ"),

                new SachThamKhao("TK01", new DateTime(2023, 4, 05), 50000, 4, "Trẻ", 10000),
                new SachThamKhao("TK02", new DateTime(2023, 5, 12), 45000, 6, "Giáo Dục", 15000),
                new SachThamKhao("TK03", new DateTime(2023, 6, 18), 60000, 3, "Trẻ", 12000)
            };

                double tongTienGK = danhSachSach.OfType<SachGiaoKhoa>().Sum(s => s.TinhThanhTien());
                double tongTienTK = danhSachSach.OfType<SachThamKhao>().Sum(s => s.TinhThanhTien());

                Console.WriteLine("=== TỔNG THÀNH TIỀN THEO LOẠI ===");
                Console.WriteLine($"Tổng thành tiền Sách Giáo Khoa: {tongTienGK:N0} VNĐ");
                Console.WriteLine($"Tổng thành tiền Sách Tham Khảo: {tongTienTK:N0} VNĐ\n");

                Console.Write("Nhập tên Nhà xuất bản K cần tìm sách giáo khoa: ");
                string nhaXuatBanK = Console.ReadLine();

                Console.WriteLine($"\n=== DANH SÁCH SÁCH GIÁO KHOA CỦA NXB '{nhaXuatBanK}' ===");
                var dsGKTheoNXB = danhSachSach
                    .OfType<SachGiaoKhoa>()
                    .Where(s => s.NhaXuatBan.Equals(nhaXuatBanK, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (dsGKTheoNXB.Count > 0)
                {
                    foreach (var sgk in dsGKTheoNXB)
                    {
                        sgk.XuatThongTin();
                    }
                }
                else
                {
                    Console.WriteLine($"Không tìm thấy sách giáo khoa nào của NXB '{nhaXuatBanK}'.");
                }

                double maxThanhTien = danhSachSach.Max(s => s.TinhThanhTien());
                var dsSachMax = danhSachSach.Where(s => s.TinhThanhTien() == maxThanhTien).ToList();

                Console.WriteLine($"\n=== SÁCH CÓ THÀNH TIỀN CAO NHẤT ({maxThanhTien:N0} VNĐ) ===");
                foreach (var sach in dsSachMax)
                {
                    sach.XuatThongTin();
                }

                Console.ReadLine();
            }
        }
    }
}
