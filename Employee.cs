/****************/
/* Mã sinh viên: 202418834 */
/* Họ tên: Trần Tuấn Anh */
/****************/


using System;

namespace Lab03_04
{
    /// <summary>
    /// Lớp Employee đại diện cho một nhân sự thông thường.
    /// Trách nhiệm: Lưu trữ thông tin cơ bản của nhân sự và tính toán lương cơ bản.
    /// </summary>
    public class Employee
    {
        // Thuộc tính
        public string Id { get; protected set; }
        public string FullName { get; protected set; }
        public double BaseSalary { get; protected set; }

        // Constructors
        public Employee()
        {
            Id = "UNKNOWN";
            FullName = "Unnamed employee";
            BaseSalary = 0;
        }

        public Employee(string id, string fullName)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Mã và họ tên không được rỗng.");
            }
            Id = id;
            FullName = fullName;
            BaseSalary = 0;
        }

        public Employee(string id, string fullName, double baseSalary)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Mã và họ tên không được rỗng.");
            }
            if (baseSalary < 0)
            {
                throw new ArgumentException("Lương cơ bản không âm.");
            }
            Id = id;
            FullName = fullName;
            BaseSalary = baseSalary;
        }

        // Nạp chồng phương thức (Method Overloading)
        public void IncreaseSalary(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Giá trị tăng phải dương.");
            BaseSalary += amount;
        }

        public void IncreaseSalary(double value, bool byPercentage)
        {
            if (value <= 0)
                throw new ArgumentException("Giá trị tăng phải dương.");
            
            if (byPercentage)
            {
                BaseSalary += BaseSalary * (value / 100.0);
            }
            else
            {
                BaseSalary += value;
            }
        }

        // Các phương thức khác (Virtual)
        public virtual double CalculateMonthlyCost()
        {
            return BaseSalary;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {FullName}, Base Salary: {BaseSalary}");
        }

        // Destructor trong C# (Finalizer) để quan sát vòng đời
        ~Employee()
        {
            Console.WriteLine($"[Destructor] Đã hủy đối tượng Employee: {Id} - {FullName}");
        }
    }
}
