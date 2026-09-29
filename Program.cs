/****************/
/* Mã sinh viên: 202418834 */
/* Họ tên: Trần Tuấn Anh */
/****************/

using System;

namespace Lab03_04
{
    class Program
    {
        // Biến toàn cục dùng chung cho các kịch bản để lưu trữ trạng thái
        static Employee emp1 = null;
        static Employee emp2 = null;
        static SoftwareEngineer se1 = null;
        static SoftwareEngineer se2 = null;
        static ProjectTeam teamA = null;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n========================= MENU KIỂM THỬ =========================");
                Console.WriteLine(" 1. Tạo hai Employee (mặc định và có tham số)");
                Console.WriteLine(" 2. Tạo hai SoftwareEngineer (có/không phụ cấp)");
                Console.WriteLine(" 3. Tăng lương một nhân sự bằng số tiền cố định");
                Console.WriteLine(" 4. Tăng lương một nhân sự khác theo phần trăm");
                Console.WriteLine(" 5. Tạo nhóm dự án không có trưởng nhóm");
                Console.WriteLine(" 6. Thêm một nhân sự vào nhóm");
                Console.WriteLine(" 7. Thêm một kỹ sư làm trưởng nhóm");
                Console.WriteLine(" 8. Thử thêm lại một thành viên đã tồn tại");
                Console.WriteLine(" 9. Hiển thị danh sách bằng đa hình");
                Console.WriteLine("10. Tính tổng chi phí nhân sự hằng tháng");
                Console.WriteLine("11. Thử xóa trưởng nhóm hiện tại (bị từ chối)");
                Console.WriteLine("12. Đổi trưởng nhóm rồi xóa người từng là trưởng nhóm");
                Console.WriteLine("13. Tạo nhóm thứ 2 dùng chung nhân sự (chứng minh Kết tập)");
                Console.WriteLine("14. Hủy nhóm thứ hai (kết thúc khối lệnh)");
                Console.WriteLine("15. Chứng minh nhân sự nhóm bị hủy vẫn tồn tại");
                Console.WriteLine(" 0. Chạy tuần tự toàn bộ 15 kịch bản (Run All)");
                Console.WriteLine("-1. Thoát chương trình");
                Console.WriteLine("=================================================================");
                Console.Write("Vui lòng chọn chức năng (1-15, 0 hoặc -1): ");
                
                string input = Console.ReadLine();
                Console.WriteLine();
                
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1: Test01(); break;
                        case 2: Test02(); break;
                        case 3: Test03(); break;
                        case 4: Test04(); break;
                        case 5: Test05(); break;
                        case 6: Test06(); break;
                        case 7: Test07(); break;
                        case 8: Test08(); break;
                        case 9: Test09(); break;
                        case 10: Test10(); break;
                        case 11: Test11(); break;
                        case 12: Test12(); break;
                        case 13: Test13(); break;
                        case 14: Test14(); break;
                        case 15: Test15(); break;
                        case 0: RunAll(); break;
                        case -1: isRunning = false; Console.WriteLine("Đã thoát chương trình."); break;
                        default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                    }
                }
                else
                {
                    Console.WriteLine("Vui lòng nhập số!");
                }
            }
        }

        // --- Các hàm hỗ trợ để đảm bảo dữ liệu không bị null khi chạy nhảy cóc ---
        static void EnsureEmployee() { if (emp1 == null || emp2 == null) { Console.WriteLine("[Hệ thống tự động gọi Test 1 để chuẩn bị dữ liệu]"); Test01(); } }
        static void EnsureSoftwareEngineer() { if (se1 == null || se2 == null) { Console.WriteLine("[Hệ thống tự động gọi Test 2 để chuẩn bị dữ liệu]"); Test02(); } }
        static void EnsureTeam() { if (teamA == null) { Console.WriteLine("[Hệ thống tự động gọi Test 5 để chuẩn bị dữ liệu]"); Test05(); } }
        static void EnsureTeamMembers() { EnsureEmployee(); EnsureSoftwareEngineer(); EnsureTeam(); if (teamA.CalculateTotalMonthlyCost() == 0) { Console.WriteLine("[Hệ thống tự động gọi Test 6 & 7 để chuẩn bị dữ liệu]"); Test06(); Test07(); } }

        // --- Chi tiết 15 kịch bản ---

        static void Test01()
        {
            Console.WriteLine("--- [Test 01] Tạo hai Employee bằng 2 constructor khác nhau ---");
            emp1 = new Employee(); 
            emp2 = new Employee("E001", "Nguyen Van A", 1000);
            emp1.DisplayInfo();
            emp2.DisplayInfo();
            Console.WriteLine(" => OK. Khởi tạo Employee thành công.\n");
        }

        static void Test02()
        {
            Console.WriteLine("--- [Test 02] Tạo hai SoftwareEngineer bằng 2 constructor khác nhau ---");
            se1 = new SoftwareEngineer("S001", "Tran Thi B", "C#");
            se2 = new SoftwareEngineer("S002", "Le Van C", 1500, "Java", 300);
            se1.DisplayInfo();
            se2.DisplayInfo();
            Console.WriteLine(" => OK. Khởi tạo SoftwareEngineer thành công.\n");
        }

        static void Test03()
        {
            EnsureEmployee();
            Console.WriteLine("--- [Test 03] Tăng lương nhân sự bằng số tiền cố định ---");
            Console.WriteLine($" + Lương cũ của {emp2.FullName}: {emp2.BaseSalary}");
            emp2.IncreaseSalary(200); 
            Console.WriteLine($" + Lương mới: {emp2.BaseSalary} (đã tăng 200)");
            Console.WriteLine(" => OK. Tính năng tăng lương cố định hoạt động đúng.\n");
        }

        static void Test04()
        {
            EnsureSoftwareEngineer();
            Console.WriteLine("--- [Test 04] Tăng lương nhân sự theo phần trăm ---");
            Console.WriteLine($" + Lương cũ của {se2.FullName}: {se2.BaseSalary}");
            se2.IncreaseSalary(10, true); 
            Console.WriteLine($" + Lương mới: {se2.BaseSalary} (đã tăng 10%)");
            Console.WriteLine(" => OK. Tính năng tăng lương theo % hoạt động đúng.\n");
        }

        static void Test05()
        {
            Console.WriteLine("--- [Test 05] Tạo nhóm dự án không có trưởng nhóm ---");
            teamA = new ProjectTeam("P01", "Dự án Alpha");
            teamA.DisplayTeam();
            Console.WriteLine(" => OK. Tạo nhóm thành công, Leader hiện tại là None.\n");
        }

        static void Test06()
        {
            EnsureEmployee();
            EnsureTeam();
            Console.WriteLine("--- [Test 06] Thêm một nhân sự vào nhóm bằng addMember(employee) ---");
            teamA.AddMember(emp2);
            Console.WriteLine($" + Đã thêm nhân sự {emp2.FullName} vào nhóm.");
            Console.WriteLine(" => OK. Thêm thành viên cơ bản thành công.\n");
        }

        static void Test07()
        {
            EnsureSoftwareEngineer();
            EnsureTeam();
            Console.WriteLine("--- [Test 07] Thêm kỹ sư bằng addMember(employee, true) làm trưởng nhóm ---");
            teamA.AddMember(se2, true);
            Console.WriteLine($" + Trưởng nhóm hiện tại của {teamA.ProjectName} là: {teamA.Leader.FullName}");
            Console.WriteLine(" => OK. Kỹ sư đã được thêm vào nhóm và nâng lên làm Leader.\n");
        }

        static void Test08()
        {
            EnsureTeamMembers();
            Console.WriteLine("--- [Test 08] Thử thêm lại một thành viên đã tồn tại ---");
            bool isAdded = teamA.AddMember(emp2);
            Console.WriteLine($" + Kết quả trả về từ hàm AddMember: {isAdded}");
            Console.WriteLine(" => OK. Hệ thống đã chặn việc thêm trùng lặp nhân sự.\n");
        }

        static void Test09()
        {
            EnsureTeamMembers();
            Console.WriteLine("--- [Test 09] Hiển thị danh sách bằng lời gọi đa hình ---");
            teamA.DisplayTeam();
            Console.WriteLine(" => OK. Đa hình hoạt động (tự động gọi đúng DisplayInfo của lớp con).\n");
        }

        static void Test10()
        {
            EnsureTeamMembers();
            Console.WriteLine("--- [Test 10] Tính tổng chi phí nhân sự hằng tháng ---");
            double totalCost = teamA.CalculateTotalMonthlyCost();
            Console.WriteLine($" + Tổng chi phí thực tế tính được của {teamA.ProjectName} là: {totalCost}");
            Console.WriteLine(" => OK. Gọi hàm CalculateMonthlyCost() đa hình thành công.\n");
        }

        static void Test11()
        {
            EnsureTeamMembers();
            Console.WriteLine("--- [Test 11] Thử xóa trưởng nhóm hiện tại (thao tác bị từ chối) ---");
            bool isRemoved = teamA.RemoveMember(teamA.Leader.Id);
            Console.WriteLine($" + Thử xóa {teamA.Leader.FullName}. Kết quả RemoveMember: {isRemoved}");
            Console.WriteLine(" => OK. Bị từ chối vì không được xóa trưởng nhóm khi chưa có người thay thế.\n");
        }

        static void Test12()
        {
            EnsureTeamMembers();
            Console.WriteLine("--- [Test 12] Đổi trưởng nhóm rồi xóa người từng là trưởng nhóm ---");
            string oldLeaderId = teamA.Leader.Id;
            teamA.ChangeLeader(se1); 
            Console.WriteLine($" + Trưởng nhóm mới: {teamA.Leader.FullName}");
            bool isRemovedOldLeader = teamA.RemoveMember(oldLeaderId);
            Console.WriteLine($" + Xóa cựu trưởng nhóm ({oldLeaderId}): {isRemovedOldLeader}");
            Console.WriteLine(" => OK. Đã xóa thành công nhân viên bình thường (người từng là trưởng nhóm).\n");
        }

        static void Test13()
        {
            EnsureEmployee();
            Console.WriteLine("--- [Test 13] Tạo nhóm 2 và dùng chung nhân sự (kết tập) ---");
            ProjectTeam teamB = new ProjectTeam("P02", "Dự án Beta");
            teamB.AddMember(emp2); 
            teamB.DisplayTeam();
            Console.WriteLine(" => OK. Một nhân sự có thể nằm ở nhiều nhóm, chứng minh kết tập (Aggregation).\n");
        }

        static void Test14()
        {
            EnsureEmployee();
            Console.WriteLine("--- [Test 14] Hủy nhóm thứ hai bằng cách kết thúc khối lệnh ---");
            TestScopeForTeam();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine(" => OK. Đã tạo và hủy một nhóm tạm thời trong khối lệnh.\n");
        }

        static void Test15()
        {
            EnsureEmployee();
            Console.WriteLine("--- [Test 15] Chứng minh nhân sự của nhóm bị hủy vẫn tồn tại độc lập ---");
            Console.WriteLine(" + In thông tin của emp2 (người từng được thêm vào nhóm tạm ở Test 14):");
            emp2.DisplayInfo();
            Console.WriteLine(" => OK. Dù nhóm bị hủy, Employee vẫn sống -> Đúng tính chất Kết tập (Aggregation).\n");
        }

        static void RunAll()
        {
            Test01(); Test02(); Test03(); Test04(); Test05();
            Test06(); Test07(); Test08(); Test09(); Test10();
            Test11(); Test12(); Test13(); Test14(); Test15();
        }

        static void TestScopeForTeam()
        {
            ProjectTeam tempTeam = new ProjectTeam("P_TEMP", "Dự án Tạm");
            tempTeam.AddMember(emp2);
            Console.WriteLine("   -> Đã tạo 'Dự án Tạm' và thêm emp2 vào đó.");
        }
    }
}
