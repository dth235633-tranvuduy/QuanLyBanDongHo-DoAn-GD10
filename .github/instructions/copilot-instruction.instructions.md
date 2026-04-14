---
description: SEVEN TIME Watch Store Management Project - Copilot Instructions
applyTo: "**/*.cs" # Apply to all C# files in the project
---

# 🛠 SEVEN TIME - Project Instructions for Copilot

## 1. Context & Architecture

**Project Name:** SEVEN TIME Watch Store Management (LTQL_QLBHDongHo)

**Tech Stack:** C# WinForms (.NET), Entity Framework Core (EF Core), SQL Server

**Project Structure:**

- **Models/Data:** Contains entity classes (Entity) such as SanPham, HoaDon, ThongSoKyThuat, KhachHang, NhanVien
- **Forms:** Contains user interface components (e.g.: frmTrangChu, frmSanPham, frmHoaDon, frmBanHang, frmKhachHang)
- **Data:** Contains QLBHDbContext class to manage database connections

## 2. UI & Navigation Rules

**Child Form Navigation:** Use the OpenChildForm(Form childForm) method to display child forms within the panelBody of frmTrangChu.

**Naming Convention:**

- Input fields: `txt[FieldName]`, `dtp[FieldName]` (DateTimePicker), `cbo[FieldName]` (ComboBox)
- Buttons: `btn[Action]`
- Menu items: `mnu[FunctionName]`

## 3. Database & Logic Constraints

**Product Model:** When working with SanPham, prioritize using the **TenDongHo** property instead of XuatXu.

**Technical Specifications Form:** Includes fields: LoaiKinh (Glass Type), DoChiuNuoc (Water Resistance), LoaiDay (Band Type), KichThuocMat (Dial Size), BoMay (Movement), and especially **TenHang** (Brand Name).

**Relationships:**

- SanPham has a 1-1 relationship with ThongSoKyThuat
- SanPham belongs to a LoaiDongHo and a HangSanXuat
- HoaDon contains a list of ChiTietHoaDon
- KhachHang and NhanVien have specific roles in sales transactions

## 4. Coding Standards

**Entity Framework:** Use LINQ to query data through QLBHDbContext

**Error Handling:** Always wrap Database operations in try-catch blocks and display error MessageBox to users

**Migrations:** Always remind users to run `Add-Migration` and `Update-Database` in Package Manager Console after changing the Model

## 5. Specific Fixes (Avoid Recurring Errors)

**Property Verification:** Always check the existence of properties such as SoLuongBan, DonGiaBan in the ChiTietHoaDon class before accessing them

**Context Scope:** Do not use `using var context = ...` inside data loading functions for DataGridView to avoid ObjectDisposedException when lazy loading

## 6. UI & Designer Guardrails (STRICT)

**Do NOT modify .Designer.cs files:** Never modify source code in Designer files. All UI changes must be made through Visual Studio Designer.

**Preserve Control Names:** Do not arbitrarily rename existing Controls (e.g., panelBody, btnTaoHoaDon, txtTenDongHo). If you cannot find a Control name, ask the user to confirm instead of creating a new name yourself.

**No Layout Logic Changes:** Do not add code that changes Location, Size, Anchor, or Dock properties of UI components unless specifically requested.

**Logic-Only Implementation:** When asked to implement features (such as Save, Delete, Search), focus only on processing data (Business Logic) and interacting with the Database (EF Core), then assign results to existing Controls.

## 7. Backend Logic Guidelines

**Event Handling:** Only write code inside event handler functions such as `_Click`, `_Load`, `_CellValueChanged`.

**Separation of Concerns:** Encourage writing separate data handling functions to be called from the UI, helping keep code clean and maintainable.

**Data Binding:** Use BindingSource or assign DataSource directly to DataGridView from LINQ query results instead of manipulating the Grid's column structure.
