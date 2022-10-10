using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaiTap3.Migrations
{
    public partial class bt3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCaHoc = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TgianBatDau = table.Column<TimeSpan>(type: "time", nullable: false),
                    TgianKetThuc = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaHocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhoaDaoTaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhoa = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaDaoTaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LichNghis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNgayNghi = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NgayNghi = table.Column<DateTime>(type: "datetime", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime", nullable: false),
                    Isdelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichNghis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LienHes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SDT = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    TinNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LienHes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDiems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiDiem = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    HeSo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDiems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThuNgays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThuNgayCuThe = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsDelete = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuNgays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToBoMons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenToBoMon = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToBoMons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LopHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLop = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TenLop = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    KhoaDaoTao = table.Column<int>(type: "int", nullable: false),
                    NgayKhaiGiang = table.Column<DateTime>(type: "datetime", nullable: false),
                    SoLuongHocVienDangCo = table.Column<int>(type: "int", nullable: false),
                    SoLuongHocVienToiDa = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    HocPhi = table.Column<float>(type: "real", nullable: false),
                    Isdelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopHocs_KhoaDaoTaos_KhoaDaoTao",
                        column: x => x.KhoaDaoTao,
                        principalTable: "KhoaDaoTaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonHocs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaMonHoc = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TenMonHoc = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    KhoaDaoTao = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHocs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MonHocs_KhoaDaoTaos_KhoaDaoTao",
                        column: x => x.KhoaDaoTao,
                        principalTable: "KhoaDaoTaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMonHoc = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    LoaiDiem = table.Column<int>(type: "int", nullable: false),
                    SoCotDiem = table.Column<int>(type: "int", nullable: false),
                    SoCotDiemBatBuoc = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diems_LoaiDiems_LoaiDiem",
                        column: x => x.LoaiDiem,
                        principalTable: "LoaiDiems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HocViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ho = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TenDemVaTen = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    Sdt = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    PhuHuynh = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    HinhDaiDien = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    MaDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HocViens_Roles_role",
                        column: x => x.role,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiDung = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiDungs_Roles_role",
                        column: x => x.role,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThuHocPhis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLopHoc = table.Column<int>(type: "int", nullable: false),
                    MucThuPhi = table.Column<float>(type: "real", nullable: false),
                    GiamGia = table.Column<float>(type: "real", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Isdelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuHocPhis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThuHocPhis_LopHocs_MaLopHoc",
                        column: x => x.MaLopHoc,
                        principalTable: "LopHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiangViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasoThue = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TenDemVaTen = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    SDT = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DayMonChinh = table.Column<int>(type: "int", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isdelete = table.Column<bool>(type: "bit", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiangViens_MonHocs_DayMonChinh",
                        column: x => x.DayMonChinh,
                        principalTable: "MonHocs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiangViens_Roles_role",
                        column: x => x.role,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhongHoc = table.Column<int>(type: "int", nullable: false),
                    Thu = table.Column<int>(type: "int", nullable: false),
                    Ca = table.Column<int>(type: "int", nullable: false),
                    MonHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichHocs_CaHocs_Ca",
                        column: x => x.Ca,
                        principalTable: "CaHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichHocs_LopHocs_PhongHoc",
                        column: x => x.PhongHoc,
                        principalTable: "LopHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichHocs_MonHocs_MonHoc",
                        column: x => x.MonHoc,
                        principalTable: "MonHocs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LichHocs_ThuNgays_Thu",
                        column: x => x.Thu,
                        principalTable: "ThuNgays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HocVien_Diems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_HocVien = table.Column<int>(type: "int", nullable: false),
                    ID_MonHoc = table.Column<int>(type: "int", nullable: false),
                    ID_LoaiDiem = table.Column<int>(type: "int", nullable: false),
                    SoDiem = table.Column<float>(type: "real", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DiemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocVien_Diems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HocVien_Diems_Diems_DiemId",
                        column: x => x.DiemId,
                        principalTable: "Diems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HocVien_Diems_HocViens_ID_HocVien",
                        column: x => x.ID_HocVien,
                        principalTable: "HocViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HocVien_Diems_LoaiDiems_ID_LoaiDiem",
                        column: x => x.ID_LoaiDiem,
                        principalTable: "LoaiDiems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HocVien_Diems_MonHocs_ID_MonHoc",
                        column: x => x.ID_MonHoc,
                        principalTable: "MonHocs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lop_HocViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_HocVien = table.Column<int>(type: "int", nullable: false),
                    MaLop = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime", nullable: false),
                    TrangThaiHocPhi = table.Column<bool>(type: "bit", nullable: false),
                    Isdelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop_HocViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lop_HocViens_HocViens_Id_HocVien",
                        column: x => x.Id_HocVien,
                        principalTable: "HocViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lop_HocViens_LopHocs_MaLop",
                        column: x => x.MaLop,
                        principalTable: "LopHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung_QUyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NguoiDug = table.Column<int>(type: "int", nullable: false),
                    ID_Quyen = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung_QUyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiDung_QUyens_NguoiDungs_ID_NguoiDug",
                        column: x => x.ID_NguoiDug,
                        principalTable: "NguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NguoiDung_QUyens_Quyens_ID_Quyen",
                        column: x => x.ID_Quyen,
                        principalTable: "Quyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichDays",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonHoc = table.Column<int>(type: "int", nullable: false),
                    LopHoc = table.Column<int>(type: "int", nullable: false),
                    Thu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ca = table.Column<int>(type: "int", nullable: false),
                    GiaoVien = table.Column<int>(type: "int", nullable: false),
                    Isdelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichDays", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LichDays_GiangViens_GiaoVien",
                        column: x => x.GiaoVien,
                        principalTable: "GiangViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichDays_LopHocs_LopHoc",
                        column: x => x.LopHoc,
                        principalTable: "LopHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LichDays_MonHocs_MonHoc",
                        column: x => x.MonHoc,
                        principalTable: "MonHocs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Luongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_GiangVien = table.Column<int>(type: "int", nullable: false),
                    NgayNhanLuong = table.Column<DateTime>(type: "datetime", nullable: false),
                    TeacherSalary = table.Column<double>(type: "float", nullable: false),
                    TienLuong = table.Column<float>(type: "real", nullable: false),
                    TroCap = table.Column<float>(type: "real", nullable: false),
                    TongTienNhan = table.Column<float>(type: "real", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Luongs_GiangViens_ID_GiangVien",
                        column: x => x.ID_GiangVien,
                        principalTable: "GiangViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThuHocPhiChiTiets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_MaLop = table.Column<int>(type: "int", nullable: false),
                    ID_MaHocVien = table.Column<int>(type: "int", nullable: false),
                    ID_MaGiangVien = table.Column<int>(type: "int", nullable: false),
                    SoTien = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuHocPhiChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThuHocPhiChiTiets_GiangViens_ID_MaGiangVien",
                        column: x => x.ID_MaGiangVien,
                        principalTable: "GiangViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThuHocPhiChiTiets_HocViens_ID_MaHocVien",
                        column: x => x.ID_MaHocVien,
                        principalTable: "HocViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ThuHocPhiChiTiets_LopHocs_ID_MaLop",
                        column: x => x.ID_MaLop,
                        principalTable: "LopHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diems_LoaiDiem",
                table: "Diems",
                column: "LoaiDiem");

            migrationBuilder.CreateIndex(
                name: "IX_GiangViens_DayMonChinh",
                table: "GiangViens",
                column: "DayMonChinh");

            migrationBuilder.CreateIndex(
                name: "IX_GiangViens_role",
                table: "GiangViens",
                column: "role");

            migrationBuilder.CreateIndex(
                name: "IX_HocVien_Diems_DiemId",
                table: "HocVien_Diems",
                column: "DiemId");

            migrationBuilder.CreateIndex(
                name: "IX_HocVien_Diems_ID_HocVien",
                table: "HocVien_Diems",
                column: "ID_HocVien");

            migrationBuilder.CreateIndex(
                name: "IX_HocVien_Diems_ID_LoaiDiem",
                table: "HocVien_Diems",
                column: "ID_LoaiDiem");

            migrationBuilder.CreateIndex(
                name: "IX_HocVien_Diems_ID_MonHoc",
                table: "HocVien_Diems",
                column: "ID_MonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_HocViens_role",
                table: "HocViens",
                column: "role");

            migrationBuilder.CreateIndex(
                name: "IX_LichDays_GiaoVien",
                table: "LichDays",
                column: "GiaoVien");

            migrationBuilder.CreateIndex(
                name: "IX_LichDays_LopHoc",
                table: "LichDays",
                column: "LopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LichDays_MonHoc",
                table: "LichDays",
                column: "MonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LichHocs_Ca",
                table: "LichHocs",
                column: "Ca");

            migrationBuilder.CreateIndex(
                name: "IX_LichHocs_MonHoc",
                table: "LichHocs",
                column: "MonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LichHocs_PhongHoc",
                table: "LichHocs",
                column: "PhongHoc");

            migrationBuilder.CreateIndex(
                name: "IX_LichHocs_Thu",
                table: "LichHocs",
                column: "Thu");

            migrationBuilder.CreateIndex(
                name: "IX_Lop_HocViens_Id_HocVien",
                table: "Lop_HocViens",
                column: "Id_HocVien");

            migrationBuilder.CreateIndex(
                name: "IX_Lop_HocViens_MaLop",
                table: "Lop_HocViens",
                column: "MaLop");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocs_KhoaDaoTao",
                table: "LopHocs",
                column: "KhoaDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_Luongs_ID_GiangVien",
                table: "Luongs",
                column: "ID_GiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocs_KhoaDaoTao",
                table: "MonHocs",
                column: "KhoaDaoTao");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_QUyens_ID_NguoiDug",
                table: "NguoiDung_QUyens",
                column: "ID_NguoiDug");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_QUyens_ID_Quyen",
                table: "NguoiDung_QUyens",
                column: "ID_Quyen");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungs_role",
                table: "NguoiDungs",
                column: "role");

            migrationBuilder.CreateIndex(
                name: "IX_ThuHocPhiChiTiets_ID_MaGiangVien",
                table: "ThuHocPhiChiTiets",
                column: "ID_MaGiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_ThuHocPhiChiTiets_ID_MaHocVien",
                table: "ThuHocPhiChiTiets",
                column: "ID_MaHocVien");

            migrationBuilder.CreateIndex(
                name: "IX_ThuHocPhiChiTiets_ID_MaLop",
                table: "ThuHocPhiChiTiets",
                column: "ID_MaLop");

            migrationBuilder.CreateIndex(
                name: "IX_ThuHocPhis_MaLopHoc",
                table: "ThuHocPhis",
                column: "MaLopHoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HocVien_Diems");

            migrationBuilder.DropTable(
                name: "LichDays");

            migrationBuilder.DropTable(
                name: "LichHocs");

            migrationBuilder.DropTable(
                name: "LichNghis");

            migrationBuilder.DropTable(
                name: "LienHes");

            migrationBuilder.DropTable(
                name: "Lop_HocViens");

            migrationBuilder.DropTable(
                name: "Luongs");

            migrationBuilder.DropTable(
                name: "NguoiDung_QUyens");

            migrationBuilder.DropTable(
                name: "ThuHocPhiChiTiets");

            migrationBuilder.DropTable(
                name: "ThuHocPhis");

            migrationBuilder.DropTable(
                name: "ToBoMons");

            migrationBuilder.DropTable(
                name: "Diems");

            migrationBuilder.DropTable(
                name: "CaHocs");

            migrationBuilder.DropTable(
                name: "ThuNgays");

            migrationBuilder.DropTable(
                name: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "Quyens");

            migrationBuilder.DropTable(
                name: "GiangViens");

            migrationBuilder.DropTable(
                name: "HocViens");

            migrationBuilder.DropTable(
                name: "LopHocs");

            migrationBuilder.DropTable(
                name: "LoaiDiems");

            migrationBuilder.DropTable(
                name: "MonHocs");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "KhoaDaoTaos");
        }
    }
}
