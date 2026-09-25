namespace ThucHanh02;

class Program
{
    static void Main()
    {
        int chon;
        do
        {
            Console.WriteLine("\nTHUC HANH 02 - LAP TRINH HUONG DOI TUONG C#");
            Console.WriteLine("1. Tinh tuoi sinh vien");
            Console.WriteLine("2. Point");
            Console.WriteLine("3. Person va PersonList");
            Console.WriteLine("4. Phan so");
            Console.WriteLine("5. Don thuc");
            Console.WriteLine("6. Day so nguyen");
            Console.WriteLine("7. Mang 2 chieu");
            Console.WriteLine("8. Da thuc");
            Console.WriteLine("9. Day phan so");
            Console.WriteLine("10. Tong luong phong ban");
            Console.WriteLine("11. Luong nhan vien cong ty");
            Console.WriteLine("12. Tinh diem thi sinh");
            Console.WriteLine("0. Thoat");
            chon = NhapInt("Chon chuc nang: ");
            switch (chon)
            {
                case 1: BaiTuoi(); break;
                case 2: BaiPoint(); break;
                case 3: BaiPerson(); break;
                case 4: BaiPhanSo(); break;
                case 5: BaiDonThuc(); break;
                case 6: BaiDaySo(); break;
                case 7: BaiMaTran(); break;
                case 8: BaiDaThuc(); break;
                case 9: BaiDayPhanSo(); break;
                case 10: BaiPhongBan(); break;
                case 11: BaiLuongCongTy(); break;
                case 12: BaiThiSinh(); break;
            }
        } while (chon != 0);
    }

    public static int NhapInt(string s)
    {
        int n;
        while (true) { Console.Write(s); if (int.TryParse(Console.ReadLine(), out n)) return n; Console.WriteLine("Nhap sai."); }
    }
    public static double NhapDouble(string s)
    {
        double n;
        while (true) { Console.Write(s); if (double.TryParse(Console.ReadLine(), out n)) return n; Console.WriteLine("Nhap sai."); }
    }
    public static string NhapChuoi(string s) { Console.Write(s); return Console.ReadLine() ?? ""; }

    static void BaiTuoi()
    {
        string ten = NhapChuoi("Nhap ho ten: ");
        int namSinh = NhapInt("Nhap nam sinh: ");
        Console.WriteLine($"Sinh vien {ten} co {DateTime.Now.Year - namSinh} tuoi.");
    }
    static void BaiPoint()
    {
        Point a = new Point(); a.Input("A");
        Point b = new Point(); b.Input("B");
        Console.WriteLine($"A = {a}, B = {b}");
        Console.WriteLine($"A + B = {a + b}, A - B = {a - b}, -A = {-a}");
        Console.WriteLine($"Khoang cach: {a.Distance(b)}");
        Console.WriteLine($"Trung diem: {Point.Middle(a, b)}");
        ArrayPoint ds = new ArrayPoint(); ds.Add(a); ds.Add(b);
        Console.WriteLine("ArrayPoint: " + ds);
    }
    static void BaiPerson()
    {
        int n = NhapInt("Nhap so nguoi: ");
        PersonList ds = new PersonList();
        for (int i = 0; i < n; i++) { Person p = new Person(); p.Input(); ds.Add(p); }
        Console.WriteLine("Danh sach:"); ds.Output();
        Console.WriteLine("Nguoi con song:"); ds.LivingPeople().Output();
    }
    static void BaiPhanSo()
    {
        Fraction a = Fraction.Input("Phan so thu 1");
        Fraction b = Fraction.Input("Phan so thu 2");
        Console.WriteLine($"a = {a}, b = {b}");
        Console.WriteLine($"a + b = {a + b}\na - b = {a - b}\na * b = {a * b}\na / b = {a / b}");
        Console.WriteLine(a > b ? "a > b" : a < b ? "a < b" : "a = b");
    }
    static void BaiDonThuc()
    {
        Monomial p = new Monomial(NhapDouble("Nhap he so a: "), NhapInt("Nhap so mu n: "));
        double x = NhapDouble("Nhap x: ");
        Console.WriteLine($"P(x) = {p}\nP({x}) = {p.Value(x)}\nP'(x) = {p.Derivative()}");
    }
    static void BaiDaySo()
    {
        IntSequence a = new IntSequence(); a.Input();
        Console.WriteLine("Day so: " + a);
        Console.WriteLine("Cac so chan: " + string.Join(" ", a.EvenNumbers()));
    }
    static void BaiMaTran()
    {
        IntMatrix a = new IntMatrix(NhapInt("Nhap so dong: "), NhapInt("Nhap so cot: "));
        a.Input(); Console.WriteLine("Mang vua nhap:"); a.Output();
        Console.WriteLine("Cac so nguyen to: " + string.Join(" ", a.PrimeNumbers()));
    }
    static void BaiDaThuc()
    {
        Polynomial p = new Polynomial(); p.Input();
        double x = NhapDouble("Nhap x: ");
        Console.WriteLine($"P(x) = {p}\nP({x}) = {p.Value(x)}");
    }
    static void BaiDayPhanSo()
    {
        int n = NhapInt("Nhap so phan so: ");
        FractionList ds = new FractionList();
        for (int i = 0; i < n; i++) ds.Add(Fraction.Input($"Phan so thu {i + 1}"));
        Console.WriteLine("Tong cac phan so: " + ds.Sum());
    }
    static void BaiPhongBan()
    {
        int n = NhapInt("Nhap so nhan vien: ");
        Department phong = new Department();
        for (int i = 0; i < n; i++)
            phong.Add(new BasicEmployee(NhapChuoi("Ho ten: "), (decimal)NhapDouble("Muc luong: "), NhapInt("So ngay vang: ")));
        Console.WriteLine($"Tong luong phong ban: {phong.TotalSalary():N0} VND");
    }
    static void BaiLuongCongTy()
    {
        int n = NhapInt("Nhap so nhan vien: ");
        List<CompanyEmployee> ds = new List<CompanyEmployee>();
        for (int i = 0; i < n; i++)
        {
            string ma = NhapChuoi("Ma nhan vien: "); string ten = NhapChuoi("Ho ten: ");
            int loai = NhapInt("1. Kinh doanh  2. San xuat: ");
            if (loai == 1) ds.Add(new BusinessEmployee(ma, ten, (decimal)NhapDouble("Luong co ban: "), NhapInt("So hop dong: ")));
            else ds.Add(new ProductionEmployee(ma, ten, NhapInt("So san pham: ")));
        }
        foreach (CompanyEmployee nv in ds) Console.WriteLine($"{nv.Name}: {nv.Salary():N0} VND");
    }
    static void BaiThiSinh()
    {
        int n = NhapInt("Nhap so thi sinh: ");
        List<Candidate> ds = new List<Candidate>();
        for (int i = 0; i < n; i++)
        {
            string sbd = NhapChuoi("So bao danh: "); string ten = NhapChuoi("Ho ten: ");
            double b1 = NhapDouble("Diem bai 1: "), b2 = NhapDouble("Diem bai 2: "), b3 = NhapDouble("Diem bai 3: ");
            if (NhapInt("1. Chuyen  2. Sieu cup: ") == 1) ds.Add(new SpecializedCandidate(sbd, ten, b1, b2, b3, NhapDouble("Diem tieng Anh: ")));
            else ds.Add(new SuperCupCandidate(sbd, ten, b1, b2, b3, NhapDouble("Diem CSDL: ")));
        }
        foreach (Candidate ts in ds) Console.WriteLine($"{ts.Id} - {ts.Name}: {ts.Total():0.##} diem");
    }
}

class Point
{
    public double X { get; set; }
    public double Y { get; set; }
    public Point() { X = 0; Y = 0; }
    public Point(double x, double y) { X = x; Y = y; }
    public void Input(string ten) { X = Program.NhapDouble($"Nhap x cua {ten}: "); Y = Program.NhapDouble($"Nhap y cua {ten}: "); }
    public double Distance(Point p) => Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
    public static double Distance(Point a, Point b) => a.Distance(b);
    public Point Middle(Point p) => new Point((X + p.X) / 2, (Y + p.Y) / 2);
    public static Point Middle(Point a, Point b) => a.Middle(b);
    public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
    public static Point operator -(Point a, Point b) => new Point(a.X - b.X, a.Y - b.Y);
    public static Point operator -(Point a) => new Point(-a.X, -a.Y);
    public override string ToString() => $"({X}; {Y})";
}

class ArrayPoint
{
    List<Point> data = new List<Point>();
    public Point this[int i] { get => data[i]; set => data[i] = value; }
    public void Add(Point p) => data.Add(p);
    public override string ToString() => string.Join(" ", data);
}

class Person
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public int Yob { get; set; }
    public int Yod { get; set; }
    public Person() { }
    public Person(Person p) { Id = p.Id; Name = p.Name; Yob = p.Yob; Yod = p.Yod; }
    public void Input() { Id = Program.NhapChuoi("Ma: "); Name = Program.NhapChuoi("Ho ten: "); Yob = Program.NhapInt("Nam sinh: "); Yod = Program.NhapInt("Nam mat (0 neu con song): "); }
    public void Output() => Console.WriteLine($"{Id} - {Name} - {Yob} - {(IsLiving() ? "Con song" : "Da mat")}");
    public bool IsLiving() => Yod == 0;
}

class PersonList
{
    List<Person> data = new List<Person>();
    public PersonList() { }
    public PersonList(PersonList ds) { data = ds.data.Select(p => new Person(p)).ToList(); }
    public void Add(Person p) => data.Add(p);
    public PersonList LivingPeople() { PersonList kq = new PersonList(); foreach (Person p in data) if (p.IsLiving()) kq.Add(new Person(p)); return kq; }
    public void Output() { foreach (Person p in data) p.Output(); }
}

class Fraction
{
    public long Tu { get; set; }
    public long Mau { get; set; }
    public Fraction() : this(0, 1) { }
    public Fraction(Fraction p) : this(p.Tu, p.Mau) { }
    public Fraction(long tu, long mau) { if (mau == 0) throw new ArgumentException("Mau so phai khac 0"); Tu = tu; Mau = mau; Simplify(); }
    static long Gcd(long a, long b) { a = Math.Abs(a); b = Math.Abs(b); while (b != 0) (a, b) = (b, a % b); return a; }
    void Simplify() { if (Mau < 0) { Tu = -Tu; Mau = -Mau; } long g = Gcd(Tu, Mau); Tu /= g; Mau /= g; }
    public static Fraction Input(string s) => new Fraction(Program.NhapInt($"Nhap tu {s}: "), Program.NhapInt($"Nhap mau {s}: "));
    public static Fraction operator +(Fraction a, Fraction b) => new Fraction(a.Tu * b.Mau + b.Tu * a.Mau, a.Mau * b.Mau);
    public static Fraction operator -(Fraction a, Fraction b) => new Fraction(a.Tu * b.Mau - b.Tu * a.Mau, a.Mau * b.Mau);
    public static Fraction operator -(Fraction a) => new Fraction(-a.Tu, a.Mau);
    public static Fraction operator +(Fraction a) => new Fraction(a);
    public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.Tu * b.Tu, a.Mau * b.Mau);
    public static Fraction operator /(Fraction a, Fraction b) => new Fraction(a.Tu * b.Mau, a.Mau * b.Tu);
    public static bool operator >(Fraction a, Fraction b) => a.Tu * b.Mau > b.Tu * a.Mau;
    public static bool operator <(Fraction a, Fraction b) => a.Tu * b.Mau < b.Tu * a.Mau;
    public static bool operator >=(Fraction a, Fraction b) => a.Tu * b.Mau >= b.Tu * a.Mau;
    public static bool operator <=(Fraction a, Fraction b) => a.Tu * b.Mau <= b.Tu * a.Mau;
    public static bool operator ==(Fraction? a, Fraction? b) => ReferenceEquals(a, b) || (a is not null && b is not null && a.Tu == b.Tu && a.Mau == b.Mau);
    public static bool operator !=(Fraction? a, Fraction? b) => !(a == b);
    public override bool Equals(object? obj) => obj is Fraction p && this == p;
    public override int GetHashCode() => HashCode.Combine(Tu, Mau);
    public override string ToString() => Mau == 1 ? Tu.ToString() : $"{Tu}/{Mau}";
}

class Monomial
{
    public double A { get; set; }
    public int N { get; set; }
    public Monomial(double a, int n) { A = a; N = Math.Max(0, n); }
    public double Value(double x) => A * Math.Pow(x, N);
    public Monomial Derivative() => N == 0 ? new Monomial(0, 0) : new Monomial(A * N, N - 1);
    public override string ToString() => N == 0 ? A.ToString() : N == 1 ? $"{A}x" : $"{A}x^{N}";
}

class IntSequence
{
    List<int> data = new List<int>();
    public int this[int i] { get => data[i]; set => data[i] = value; }
    public void Input() { int n = Program.NhapInt("Nhap n: "); for (int i = 0; i < n; i++) data.Add(Program.NhapInt($"a[{i}] = ")); }
    public IEnumerable<int> EvenNumbers() => data.Where(x => x % 2 == 0);
    public override string ToString() => string.Join(" ", data);
}

class IntMatrix
{
    int[,] data;
    public IntMatrix(int n, int m) { data = new int[n, m]; }
    public int this[int i, int j] { get => data[i, j]; set => data[i, j] = value; }
    public void Input() { for (int i = 0; i < data.GetLength(0); i++) for (int j = 0; j < data.GetLength(1); j++) data[i, j] = Program.NhapInt($"a[{i},{j}] = "); }
    public void Output() { for (int i = 0; i < data.GetLength(0); i++) { for (int j = 0; j < data.GetLength(1); j++) Console.Write(data[i, j] + "\t"); Console.WriteLine(); } }
    public IEnumerable<int> PrimeNumbers() { for (int i = 0; i < data.GetLength(0); i++) for (int j = 0; j < data.GetLength(1); j++) if (IsPrime(data[i, j])) yield return data[i, j]; }
    static bool IsPrime(int n) { if (n < 2) return false; for (int i = 2; i * i <= n; i++) if (n % i == 0) return false; return true; }
}

class Polynomial
{
    List<Monomial> data = new List<Monomial>();
    public Monomial this[int i] { get => data[i]; set => data[i] = value; }
    public void Input() { int n = Program.NhapInt("Nhap bac da thuc: "); for (int i = 0; i <= n; i++) data.Add(new Monomial(Program.NhapDouble($"He so x^{i}: "), i)); }
    public double Value(double x) => data.Sum(p => p.Value(x));
    public override string ToString() => string.Join(" + ", data.Where(p => p.A != 0).Reverse());
}

class FractionList
{
    List<Fraction> data = new List<Fraction>();
    public Fraction this[int i] { get => data[i]; set => data[i] = value; }
    public void Add(Fraction p) => data.Add(p);
    public Fraction Sum() => data.Aggregate(new Fraction(), (tong, p) => tong + p);
}

class BasicEmployee
{
    public string Name { get; }
    public decimal SalaryBase { get; }
    public int AbsenceDays { get; }
    public BasicEmployee(string name, decimal salaryBase, int absenceDays) { Name = name; SalaryBase = salaryBase; AbsenceDays = absenceDays; }
    public decimal Salary() => SalaryBase - AbsenceDays * 100000;
}

class Department
{
    List<BasicEmployee> data = new List<BasicEmployee>();
    public void Add(BasicEmployee nv) => data.Add(nv);
    public decimal TotalSalary() => data.Sum(nv => nv.Salary());
}

abstract class CompanyEmployee
{
    public string Id { get; }
    public string Name { get; }
    protected CompanyEmployee(string id, string name) { Id = id; Name = name; }
    public abstract decimal Salary();
}

class BusinessEmployee : CompanyEmployee
{
    decimal salaryBase; int contracts;
    public BusinessEmployee(string id, string name, decimal salaryBase, int contracts) : base(id, name) { this.salaryBase = salaryBase; this.contracts = contracts; }
    public override decimal Salary() => salaryBase + contracts * 500000;
}

class ProductionEmployee : CompanyEmployee
{
    int products;
    public ProductionEmployee(string id, string name, int products) : base(id, name) { this.products = products; }
    public override decimal Salary() { decimal luong = products * 1000; return products > 3000 ? luong * 1.05m : luong; }
}

abstract class Candidate
{
    public string Id { get; }
    public string Name { get; }
    protected double Bai1, Bai2, Bai3;
    protected Candidate(string id, string name, double bai1, double bai2, double bai3) { Id = id; Name = name; Bai1 = bai1; Bai2 = bai2; Bai3 = bai3; }
    public abstract double Total();
}

class SpecializedCandidate : Candidate
{
    double english;
    public SpecializedCandidate(string id, string name, double b1, double b2, double b3, double english) : base(id, name, b1, b2, b3) { this.english = english; }
    public override double Total() => Bai1 + Bai2 + Bai3 + (english >= 9 ? 2 : english >= 7 ? 1 : 0);
}

class SuperCupCandidate : Candidate
{
    double database;
    public SuperCupCandidate(string id, string name, double b1, double b2, double b3, double database) : base(id, name, b1, b2, b3) { this.database = database; }
    public override double Total() => Bai1 + Bai2 + Bai3 + database;
}
