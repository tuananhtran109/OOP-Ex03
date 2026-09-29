# Báo Cáo Thực Hành Lab 03-04: Đa Hình và Kết Tập (C#)

**Mã sinh viên:** 202418834
**Họ tên:** Trần Tuấn Anh

## 1. Link Github


## 2. Sơ đồ thiết kế (Class Diagram)

```mermaid
classDiagram
    class Employee {
        # Id : string
        # FullName : string
        # BaseSalary : double
        + Employee()
        + Employee(id: string, fullName: string)
        + Employee(id: string, fullName: string, baseSalary: double)
        + IncreaseSalary(amount: double) : void
        + IncreaseSalary(value: double, byPercentage: bool) : void
        + CalculateMonthlyCost() : double
        + DisplayInfo() : void
        + ~Employee()
    }

    class SoftwareEngineer {
        # PrimaryLanguage : string
        # TechnicalAllowance : double
        + SoftwareEngineer(id: string, fullName: string, primaryLanguage: string)
        + SoftwareEngineer(id: string, fullName: string, baseSalary: double, primaryLanguage: string, technicalAllowance: double)
        + CalculateMonthlyCost() : double
        + DisplayInfo() : void
        + ~SoftwareEngineer()
    }

    class ProjectTeam {
        - ProjectCode : string
        - ProjectName : string
        - Leader : Employee
        - Members : List~Employee~
        + ProjectTeam(projectCode: string, projectName: string)
        + ProjectTeam(projectCode: string, projectName: string, leader: Employee)
        + AddMember(employee: Employee) : bool
        + AddMember(employee: Employee, makeLeader: bool) : bool
        + RemoveMember(employeeId: string) : bool
        + ChangeLeader(employee: Employee) : bool
        + Contains(employeeId: string) : bool
        + CalculateTotalMonthlyCost() : double
        + DisplayTeam() : void
        + ~ProjectTeam()
    }

    Employee <|-- SoftwareEngineer : Kế thừa (Inheritance)
    ProjectTeam o-- Employee : Kết tập (Aggregation)
    ProjectTeam --> Employee : Leader (Association)
```

## 3. Hình ảnh chạy thử chương trình

![alt text](image.png)
![alt text](image-1.png)
![alt text](image-2.png)

