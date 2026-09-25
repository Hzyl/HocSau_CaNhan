namespace ThucHanh01;

class Program
{
    static void Main()
    {
        int chon;
        do
        {
            Console.WriteLine("\nTHUC HANH 01 - NGON NGU LAP TRINH C#");
            Console.WriteLine("1. Nhap va xuat ho ten");
            Console.WriteLine("2. Tinh x mu y");
            Console.WriteLine("3. Menu so thuc");
            Console.WriteLine("4. Max, nguyen to, hoan vi, min max");
            Console.WriteLine("5. Xu ly chuoi");
            Console.WriteLine("6. Sinh vien");
            Console.WriteLine("7. Nhan vien");
            Console.WriteLine("8. Mang so nguyen");
            Console.WriteLine("9. Sap xep ho ten");
            Console.WriteLine("10. Mang 2 chieu");
            Console.WriteLine("0. Thoat");
            chon = NhapInt("Chon chuc nang: ");
            switch (chon)
            {
                case 1: BaiHoTen(); break;
                case 2: BaiLuyThua(); break;
                case 3: BaiMenuSoThuc(); break;
                case 4: BaiPhuongThuc(); break;
                case 5: BaiChuoi(); break;
                case 6: BaiSinhVien(); break;
                case 7: BaiNhanVien(); break;
                case 8: BaiMang(); break;
                case 9: BaiSapXepTen(); break;
                case 10: BaiMang2Chieu(); break;
            }
        } while (chon != 0);
    }

    static string NhapChuoi(string thongBao)
    {
        Console.Write(thongBao);
        return Console.ReadLine() ?? "";
    }

    static int NhapInt(string thongBao)
    {
        int n;
        while (true)
        {
            Console.Write(thongBao);
            if (int.TryParse(Console.ReadLine(), out n)) return n;
            Console.WriteLine("Du lieu khong hop le, vui long nhap lai.");
        }
    }

    static double NhapDouble(string thongBao)
    {
        double n;
        while (true)
        {
            Console.Write(thongBao);
            if (double.TryParse(Console.ReadLine(), out n)) return n;
            Console.WriteLine("Du lieu khong hop le, vui long nhap lai.");
        }
    }

    static void BaiHoTen()
    {
        string hoTen = NhapChuoi("Nhap ho ten cua ban: ");
        Console.WriteLine("Chao ban " + hoTen + "!");
    }

    static void BaiLuyThua()
    {
        int x = NhapInt("Nhap so nguyen x: ");
        int y = NhapInt("Nhap so nguyen y: ");
        Console.WriteLine($"Ket qua {x} mu {y} la: {Math.Pow(x, y)}");
    }

    static void BaiMenuSoThuc()
    {
        double x = 0, y = 0;
        int chon;
        do
        {
            Console.WriteLine("\nMENU\n1. Nhap hai gia tri so thuc cho x, y\n2. Tinh x^y\n3. Tinh can bac 2 cua x va y\n4. Thoat");
            chon = NhapInt("Chon chuc nang: ");
            if (chon == 1)
            {
                x = NhapDouble("Nhap x: ");
                y = NhapDouble("Nhap y: ");
            }
            else if (chon == 2) Console.WriteLine($"{x}^{y} = {Math.Pow(x, y)}");
            else if (chon == 3)
            {
                Console.WriteLine(x >= 0 ? $"Can bac 2 cua x = {Math.Sqrt(x)}" : "x khong co can bac 2 thuc");
                Console.WriteLine(y >= 0 ? $"Can bac 2 cua y = {Math.Sqrt(y)}" : "y khong co can bac 2 thuc");
            }
        } while (chon != 4);
    }

    static int Max(int a, int b, int c) => Math.Max(a, Math.Max(b, c));

    static bool LaSoNguyenTo(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i++) if (n % i == 0) return false;
        return true;
    }

    static void HoanVi(ref double a, ref double b) => (a, b) = (b, a);

    static void TimMinMax(double a, double b, double c, out double min, out double max)
    {
        min = Math.Min(a, Math.Min(b, c));
        max = Math.Max(a, Math.Max(b, c));
    }

    static void BaiPhuongThuc()
    {
        int a = NhapInt("Nhap a: ");
        int b = NhapInt("Nhap b: ");
        int c = NhapInt("Nhap c: ");
        Console.WriteLine("Gia tri lon nhat: " + Max(a, b, c));
        int n = NhapInt("Nhap n de kiem tra nguyen to: ");
        Console.WriteLine(LaSoNguyenTo(n) ? "La so nguyen to" : "Khong phai so nguyen to");
        double x = NhapDouble("Nhap x: ");
        double y = NhapDouble("Nhap y: ");
        HoanVi(ref x, ref y);
        Console.WriteLine($"Sau khi hoan vi: x = {x}, y = {y}");
        TimMinMax(a, b, c, out double min, out double max);
        Console.WriteLine($"Min = {min}, Max = {max}");
    }

    static void BaiChuoi()
    {
        string s = NhapChuoi("Nhap chuoi: ").Trim();
        string dao = new string(s.Reverse().ToArray());
        string[] tu = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine(s.SequenceEqual(dao) ? "Chuoi doi xung" : "Chuoi khong doi xung");
        Console.WriteLine("Chuoi dao: " + dao);
        Console.WriteLine("Chuoi thuong: " + s.ToLower());
        Console.WriteLine("Chuoi hoa: " + s.ToUpper());
        Console.WriteLine("So tu: " + tu.Length);
    }

    static void BaiSinhVien()
    {
        SinhVien sv = new SinhVien();
        sv.Nhap();
        sv.Xuat();
    }

    static void BaiNhanVien()
    {
        NhanVien nv = new NhanVien();
        nv.Nhap();
        nv.Xuat();
    }

    static void BaiMang()
    {
        int n = NhapInt("Nhap so phan tu: ");
        int[] a = new int[n];
        for (int i = 0; i < n; i++) a[i] = NhapInt($"a[{i}] = ");
        Console.WriteLine("Mang: " + string.Join(" ", a));
        Console.WriteLine($"Max = {a.Max()}, Min = {a.Min()}");
        Console.WriteLine("Cac so nguyen to: " + string.Join(" ", a.Where(LaSoNguyenTo)));
    }

    static void BaiSapXepTen()
    {
        int n = NhapInt("Nhap so nguoi: ");
        string[] ds = new string[n];
        for (int i = 0; i < n; i++) ds[i] = NhapChuoi($"Ho ten nguoi thu {i + 1}: ");
        Array.Sort(ds);
        Console.WriteLine("Danh sach sau sap xep:");
        foreach (string ten in ds) Console.WriteLine(ten);
    }

    static void BaiMang2Chieu()
    {
        int n = NhapInt("Nhap so dong: ");
        int m = NhapInt("Nhap so cot: ");
        int[,] a = new int[n, m];
        Random rd = new Random();
        List<int> chan = new List<int>();
        List<int> le = new List<int>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                a[i, j] = rd.Next(10, 101);
                if (a[i, j] % 2 == 0) chan.Add(a[i, j]); else le.Add(a[i, j]);
                Console.Write(a[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Mang chan: " + string.Join(" ", chan));
        Console.WriteLine("Mang le: " + string.Join(" ", le));
    }
}

class SinhVien
{
    public string MaSinhVien { get; set; } = "";
    public string HoTen { get; set; } = "";
    public string DiaChi { get; set; } = "";
    public int NamHoc { get; set; }

    public void Nhap()
    {
        Console.Write("Nhap ma sinh vien: "); MaSinhVien = Console.ReadLine() ?? "";
        Console.Write("Nhap ho ten: "); HoTen = Console.ReadLine() ?? "";
        Console.Write("Nhap dia chi: "); DiaChi = Console.ReadLine() ?? "";
        Console.Write("Nhap nam hoc: "); NamHoc = int.Parse(Console.ReadLine() ?? "0");
    }

    public void Xuat() => Console.WriteLine($"Ma SV: {MaSinhVien}\nHo ten: {HoTen}\nDia chi: {DiaChi}\nNam hoc: {NamHoc}");
}

class NhanVien
{
    public string HoTen { get; set; } = "";
    public decimal MucLuong { get; set; }
    public int SoNgayVang { get; set; }

    public void Nhap()
    {
        Console.Write("Nhap ho ten: "); HoTen = Console.ReadLine() ?? "";
        Console.Write("Nhap muc luong: "); MucLuong = decimal.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhap so ngay vang: "); SoNgayVang = int.Parse(Console.ReadLine() ?? "0");
    }

    public decimal TinhLuong() => MucLuong - SoNgayVang * 100000;
    public void Xuat() => Console.WriteLine($"Nhan vien: {HoTen}\nLuong: {TinhLuong():N0} VND");
}
