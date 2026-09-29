/****************/
/* Mã sinh viên: 202418834*/
/* Họ tên: Trần Tuấn Anh  */
/****************/

using System;

namespace Lab03_04
{
    /// <summary>
    /// Lớp SoftwareEngineer đại diện cho một kỹ sư phần mềm.
    /// Trách nhiệm: Quản lý thông tin kỹ sư với ngôn ngữ chính và phụ cấp.
    /// Kế thừa công khai từ Employee.
    /// </summary>
    public class SoftwareEngineer : Employee
    {
        public string PrimaryLanguage { get; protected set; }
        public double TechnicalAllowance { get; protected set; }

        // Constructors
        public SoftwareEngineer(string id, string fullName, string primaryLanguage) 
            : base(id, fullName)
        {
            if (string.IsNullOrWhiteSpace(primaryLanguage))
            {
                throw new ArgumentException("Ngôn ngữ chính không rỗng.");
            }
            PrimaryLanguage = primaryLanguage;
            TechnicalAllowance = 0;
        }

        public SoftwareEngineer(string id, string fullName, double baseSalary, string primaryLanguage, double technicalAllowance)
            : base(id, fullName, baseSalary)
        {
            if (string.IsNullOrWhiteSpace(primaryLanguage))
            {
                throw new ArgumentException("Ngôn ngữ chính không rỗng.");
            }
            if (technicalAllowance < 0)
            {
                throw new ArgumentException("Phụ cấp không âm.");
            }
            PrimaryLanguage = primaryLanguage;
            TechnicalAllowance = technicalAllowance;
        }

        // Ghi đè phương thức (Method Overriding)
        public override double CalculateMonthlyCost()
        {
            return base.CalculateMonthlyCost() + TechnicalAllowance;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[SE] ID: {Id}, Name: {FullName}, Salary: {BaseSalary}, Lang: {PrimaryLanguage}, Allowance: {TechnicalAllowance}");
        }

        ~SoftwareEngineer()
        {
            Console.WriteLine($"[Destructor] Đã hủy đối tượng SoftwareEngineer: {Id} - {FullName}");
        }
    }
}
