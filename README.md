# School Management System (ASP.NET MVC)

This project is a complete web-based School Management System developed as part of the .NET subject at **Marwadi University**.  
It aims to simplify daily school operations by providing an intuitive and well-structured interface to manage Teachers, Students, Classes, and Attendance.

---

## 👨‍💻 Team Members

- **Naman Jain** – Enrollment No: *92301703016*  
- **Harsh Kumar** – Enrollment No: *92301703070*  
- **Nimit Marwadi** – Enrollment No: *92301703043*  

---

## 🎯 Project Overview

The School Management System allows school administrators and teachers to efficiently manage essential academic and administrative workflows. The system is designed using **ASP.NET MVC**, **C#**, and **Entity Framework**, with a responsive UI built using **Bootstrap**.

---

## 🚀 Tech Stack

### Frontend
- HTML5, CSS3, Bootstrap 5
- JavaScript & jQuery
- Razor View Engine

### Backend
- ASP.NET MVC 5
- C#
- Entity Framework 6 (Code First Approach)

### Database
- SQL Server / LocalDB

---

## ✅ Features

### ✔ Teacher Management  
Add, edit, view, and delete teacher details.  

### ✔ Student Management  
Manage student information including name, age, class, and related details.  

### ✔ Class Management  
Create and assign classes to teachers and manage student-class mapping.

### ✔ Attendance System  
Mark student attendance and filter records based on date and class.  

### ✔ Authentication  
Role-based login (Admin / Teacher) for secure access.

### ✔ Dashboard  
Visual overview of system data (teacher count, student count, class count, attendance summary).

---

## 🏗 System Workflow

1. Admin logs into the system.
2. Admin creates classes, teacher profiles, and student profiles.
3. Teachers can mark attendance for students.
4. Admin can filter and review attendance and student records.
5. The dashboard gives consolidated analytics.

---

## 📌 Relationships Between Entities

- A **Teacher** can manage one or more Classes.
- A **Class** contains multiple Students.
- A **Student** has multiple Attendance entries.
- Teachers and Admin are authenticated users with different access levels.

---

## 🧠 How It Works (Brief Explanation)

- Controllers handle user requests and call database operations via Entity Framework.
- Models represent the data structure and relationships.
- Views render dynamic pages using Razor syntax.
- Entity Framework generates/updates database tables automatically using Code First.
- Bootstrap ensures fully responsive and consistent UI styling.

---

## 🛠 Future Enhancements

- Student result module
- Fee management system
- Timetable module
- Export options (PDF/Excel)
- School notifications (SMS/Email)

---

## 🙌 Acknowledgement

This project was developed under the **DNT subject** as part of the curriculum at **Marwadi University**, with guidance and support from faculty members.

---
