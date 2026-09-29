/****************/
/* Mã sinh viên: 202418834 */
/* Họ tên: Trần Tuấn Anh */
/****************/

using System;
using System.Collections.Generic;

namespace Lab03_04
{
    /// <summary>
    /// Lớp ProjectTeam quản lý dự án và nhân sự.
    /// Trách nhiệm: Quản lý danh sách thành viên và trưởng nhóm, tính toán tổng chi phí.
    /// </summary>
    public class ProjectTeam
    {
        public string ProjectCode { get; private set; }
        public string ProjectName { get; private set; }
        
        // Liên kết không sở hữu
        public Employee Leader { get; private set; }
        private List<Employee> Members;

        // Constructors
        public ProjectTeam(string projectCode, string projectName)
        {
            ProjectCode = projectCode;
            ProjectName = projectName;
            Members = new List<Employee>();
        }

        public ProjectTeam(string projectCode, string projectName, Employee leader)
            : this(projectCode, projectName)
        {
            // Thiết lập trưởng nhóm và tự động đưa vào danh sách thành viên
            Leader = leader;
            Members.Add(leader);
        }

        // Nạp chồng phương thức AddMember
        public bool AddMember(Employee employee)
        {
            if (Contains(employee.Id))
            {
                Console.WriteLine($"Nhân sự {employee.Id} đã có trong nhóm.");
                return false;
            }
            Members.Add(employee);
            return true;
        }

        public bool AddMember(Employee employee, bool makeLeader)
        {
            bool added = false;
            if (!Contains(employee.Id))
            {
                Members.Add(employee);
                added = true;
            }

            if (makeLeader)
            {
                Leader = employee;
            }
            return added; // Trả về true nếu nhân sự MỚI được thêm, false nếu đã có (chỉ đổi leader)
        }

        // Các phương thức khác
        public bool RemoveMember(string employeeId)
        {
            if (Leader != null && Leader.Id == employeeId)
            {
                Console.WriteLine($"Không được xóa trưởng nhóm {employeeId} khi chưa chọn trưởng nhóm thay thế.");
                return false;
            }

            Employee target = Members.Find(e => e.Id == employeeId);
            if (target != null)
            {
                Members.Remove(target);
                return true;
            }
            return false;
        }

        public bool ChangeLeader(Employee employee)
        {
            // Trưởng nhóm mới phải được thêm vào nhóm nếu chưa phải thành viên
            if (!Contains(employee.Id))
            {
                Members.Add(employee);
            }
            Leader = employee;
            return true;
        }

        public bool Contains(string employeeId)
        {
            return Members.Exists(e => e.Id == employeeId);
        }

        public double CalculateTotalMonthlyCost()
        {
            double total = 0;
            foreach (var member in Members)
            {
                total += member.CalculateMonthlyCost();
            }
            return total;
        }

        public void DisplayTeam()
        {
            Console.WriteLine($"--- Project: {ProjectName} ({ProjectCode}) ---");
            Console.WriteLine($"Leader: {(Leader != null ? Leader.FullName : "None")}");
            Console.WriteLine($"Members ({Members.Count}):");
            foreach (var member in Members)
            {
                member.DisplayInfo();
            }
            Console.WriteLine("--------------------------------------");
        }

        ~ProjectTeam()
        {
            // Chỉ hủy cấu trúc danh sách liên kết nội bộ, 
            // không được hủy các đối tượng Employee.
            // C# quản lý bộ nhớ tự động, nên việc này chỉ mang tính hình thức chứng minh 
            // ta không chủ động Dispose các thành viên bên trong.
            Members.Clear();
            Console.WriteLine($"[Destructor] Đã hủy cấu trúc nhóm {ProjectName}.");
        }
    }
}
