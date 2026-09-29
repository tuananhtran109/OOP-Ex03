# Lab03-04: Đa Hình và Kết Tập (Polymorphism & Aggregation) trong C#

**Sinh viên:** Trần Tuấn Anh  
**MSSV:** 202418834  
**Môn học:** Lập trình Hướng đối tượng (OOP)

## Giới thiệu
Dự án này là bài tập thực hành Lab03-04 nhằm mô phỏng hệ thống quản lý nhân sự và các nhóm dự án trong một công ty. Chương trình được viết bằng ngôn ngữ **C#** (Console Application), tập trung vào việc áp dụng các nguyên lý cốt lõi của Lập trình hướng đối tượng (OOP):

1. **Đóng gói (Encapsulation):** Bảo vệ các thuộc tính dữ liệu thông qua giới hạn truy cập và quy tắc kiểm tra (không âm, không rỗng).
2. **Kế thừa (Inheritance):** Lớp `SoftwareEngineer` kế thừa các đặc tính cơ bản từ lớp `Employee`.
3. **Đa hình (Polymorphism):** Ghi đè (Override) các phương thức ảo (`virtual`) như `DisplayInfo()` và `CalculateMonthlyCost()`. Nạp chồng phương thức (Method Overloading) khi tính lương hoặc thêm nhân viên.
4. **Kết tập (Aggregation):** Thể hiện mối quan hệ liên kết yếu giữa `ProjectTeam` và `Employee` (nhân viên có thể thuộc nhiều nhóm, và khi nhóm giải tán thì nhân viên vẫn tồn tại).

## Cấu trúc Mã nguồn
- `Employee.cs`: Lớp cơ sở định nghĩa nhân sự thông thường.
- `SoftwareEngineer.cs`: Lớp kế thừa từ `Employee`, bổ sung ngôn ngữ lập trình và phụ cấp.
- `ProjectTeam.cs`: Lớp quản lý đội ngũ, điều phối danh sách nhân sự (List) và chức vụ Leader.
- `Program.cs`: File thực thi chính, chứa **Menu tương tác gồm 15 kịch bản kiểm thử** chi tiết.

## Cách Chạy Chương Trình
Để chạy dự án, bạn cần cài đặt [.NET SDK](https://dotnet.microsoft.com/download) (phiên bản 10.0 trở lên, tùy cấu hình trong file `.csproj`).

1. Mở Terminal / Command Prompt tại thư mục chứa mã nguồn.
2. Gõ lệnh sau để khởi chạy:
   ```bash
   dotnet run
   ```
3. Một Menu sẽ hiện ra, bạn chỉ cần nhập số từ `1` đến `15` để xem chi tiết từng bài test, hoặc nhập `0` để chạy toàn bộ cùng lúc.
