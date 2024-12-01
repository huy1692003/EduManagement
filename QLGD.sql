USE [master]
GO
/****** Object:  Database [QLGD_TT]    Script Date: 01/12/2024 10:26:01 CH ******/
CREATE DATABASE [QLGD_TT]
GO
USE [QLGD_TT]
GO
/****** Object:  Table [dbo].[BaiHoc]    Script Date: 01/12/2024 10:26:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiHoc](
	[BaiHocId] [int] IDENTITY(1,1) NOT NULL,
	[TenBaiHoc] [nvarchar](255) NOT NULL,
	[MoTa] [nvarchar](500) NULL,
	[ThoiGianHoanThanh] [int] NULL,
	[NgayTao] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
	[KhoaHocId] [int] NULL,
	[noidung] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[BaiHocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaiKiemTra]    Script Date: 01/12/2024 10:26:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiKiemTra](
	[BaiKiemTraId] [int] IDENTITY(1,1) NOT NULL,
	[TenBaiKiemTra] [nvarchar](100) NOT NULL,
	[KhoaHocId] [int] NOT NULL,
	[ThoiLuong] [int] NOT NULL,
	[NgayTao] [datetime] NULL,
	[MaBKT] [nvarchar](50) NULL,
	[GiangVienID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BaiKiemTraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CauHoi]    Script Date: 01/12/2024 10:26:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHoi](
	[CauHoiId] [int] IDENTITY(1,1) NOT NULL,
	[BaiKiemTraId] [int] NOT NULL,
	[NoiDung] [nvarchar](255) NOT NULL,
	[Diem] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CauHoiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiangVien]    Script Date: 01/12/2024 10:26:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiangVien](
	[GiangVienId] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoanId] [int] NOT NULL,
	[TenGiangVien] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[SoDienThoai] [nvarchar](15) NULL,
	[Image] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[GiangVienId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocVien]    Script Date: 01/12/2024 10:26:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocVien](
	[HocVienId] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoanId] [int] NOT NULL,
	[TenHocVien] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[SoDienThoai] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[HocVienId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocVien_KhoaHoc]    Script Date: 01/12/2024 10:26:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocVien_KhoaHoc](
	[HocVien_KhoaHocId] [int] IDENTITY(1,1) NOT NULL,
	[HocVienId] [int] NOT NULL,
	[KhoaHocId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HocVien_KhoaHocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KetQuaKiemTra]    Script Date: 01/12/2024 10:26:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KetQuaKiemTra](
	[KetQuaKiemTraId] [int] IDENTITY(1,1) NOT NULL,
	[HocVienId] [int] NOT NULL,
	[BaiKiemTraId] [int] NOT NULL,
	[Diem] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[KetQuaKiemTraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoaHoc]    Script Date: 01/12/2024 10:26:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoaHoc](
	[KhoaHocId] [int] IDENTITY(1,1) NOT NULL,
	[TenKhoaHoc] [nvarchar](100) NOT NULL,
	[MoTa] [nvarchar](255) NULL,
	[GiangVienId] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[noidung] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[KhoaHocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LuaChon]    Script Date: 01/12/2024 10:26:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LuaChon](
	[LuaChonId] [int] IDENTITY(1,1) NOT NULL,
	[CauHoiId] [int] NOT NULL,
	[NoiDung] [nvarchar](255) NOT NULL,
	[LaDapAnDung] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LuaChonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 01/12/2024 10:26:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 01/12/2024 10:26:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TaiKhoanId] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](100) NOT NULL,
	[LoaiTaiKhoan] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TaiKhoanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TienDoHocTap]    Script Date: 01/12/2024 10:26:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TienDoHocTap](
	[TienDoHocTapId] [int] IDENTITY(1,1) NOT NULL,
	[HocVienId] [int] NULL,
	[KhoaHocId] [int] NULL,
	[BaiHocId] [int] NULL,
	[TrangThai] [int] NULL,
	[NgayHoanThanh] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TienDoHocTapId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BaiHoc] ON 
GO
INSERT [dbo].[BaiHoc] ([BaiHocId], [TenBaiHoc], [MoTa], [ThoiGianHoanThanh], [NgayTao], [NgayCapNhat], [KhoaHocId], [noidung]) VALUES (1, N'string', N'string', 0, CAST(N'2024-11-23T10:27:37.353' AS DateTime), CAST(N'2024-11-23T10:27:37.353' AS DateTime), 0, NULL)
GO
INSERT [dbo].[BaiHoc] ([BaiHocId], [TenBaiHoc], [MoTa], [ThoiGianHoanThanh], [NgayTao], [NgayCapNhat], [KhoaHocId], [noidung]) VALUES (3, N'Bài 1 . Giới thiệu về JavaScript', N'Giúp học viên hiểu về JavaScript và cách ứng dụng vào phát triển web.', 1, CAST(N'2024-12-01T15:48:25.973' AS DateTime), CAST(N'2024-12-01T08:47:52.200' AS DateTime), 1, N'<p>JavaScript là một ngôn ngữ gia thêm khả năng tương tác cho website của bạn&nbsp;(ví dụ: trò chơi, các phản hồi khi các nút được nhấn hoặc nhập dữ liệu trên form, kiểu&nbsp;động, hoạt họa). Bài viết này sẽ giúp bạn khởi động với&nbsp;ngôn ngữ thú vị này và cho bạn&nbsp;ý tưởng về những gì có thể xảy ra.</p><h3><strong>JavaScript là gì ?</strong></h3><p>JavaScript&nbsp;(viết tắt là "js") là một ngôn ngữ lập trình mang đầy đủ tính năng&nbsp;của một&nbsp;ngôn ngữ lập trình động&nbsp;mà khi nó được áp dụng&nbsp;vào một tài liệu&nbsp;HTML, nó&nbsp;có thể đem lại khả năng tương tác động trên các trang web. Cha đẻ của ngôn ngữ này là&nbsp;Brendan Eich, đồng sáng lập dự án&nbsp;Mozilla,&nbsp;quỹ&nbsp;Mozilla, và tập đoàn&nbsp;Mozilla.</p><p>JavaScript thật sự rất linh hoạt. Bạn có thể bắt đầu với các bước nhỏ, với&nbsp;? viện&nbsp;ảnh, bố cục có tính&nbsp;thay đổi và phản hồi đến các&nbsp;nút nhấn. Khi có nhiều kinh nghiệm hơn, bạn có thể tạo ra các trò chơi, hoạt họa 2 chiều hoặc 3 chiều, ứng dụng&nbsp;cơ sở dữ liệu toàn diện&nbsp;và nhiều thứ khác!</p><p>Bản thân Javascript là một ngôn ngữ linh động. Các nhà phát triển đã viết ra một số lượng lớn các&nbsp;công cụ&nbsp;thuộc&nbsp;top của&nbsp;core Javascript, mở ra một lượng lớn tính năng bổ sung với ít nỗ lực nhất. Nó bao gồm:</p><ul><li>Giao diện lập trình ứng dụng trên trình duyệt&nbsp;(API) — Các&nbsp;API được xây dựng bên trong các trình duyệt web, cung cấp tính năng như tạo HTML động, cài đặt CSS, thu tập và điều khiển video trực tiếp từ webcam của người dùng hoặc sinh ra đồ dọa 3D và các mẫu&nbsp;audio.</li><li>Các API bên thứ ba cho phép nhà phát triển&nbsp;kết hợp&nbsp;tính năng trong website của họ từ người cung cấp nội dung khác chẳng hạn như Twitter hay Facebook.</li><li>Từ các framework&nbsp;và thư viện bên thứ ba bạn có thể áp dụng tới tài liệu HTML của bạn, cho phép bạn nhanh chóng xây dựng được các trang web và các ứng dụng.</li></ul><p>Vì khóa học này chỉ giới thiệu về JavaScript, chúng tôi sẽ không làm bạn bối rối khi nói rõ hơn về sự khác nhau giữa mã nguồn JavaScript căn bản và những công cụ được liệt kê ở trên. Bạn có thể tìm hiểu chi tiết trong Mục học JavaScript, và MDN.</p><p>Ở phần dưới chúng tôi sẽ giới thiệu cho bạn một số khía cạnh cơ bản về JavaScript và bạn cũng sẽ được làm việc với một vài API. Chúc bạn học tốt!</p><h3><strong>Ứng dụng của JavaScript.</strong></h3><p><img src="https://s3-sgn09.fptcloud.com/codelearnstorage/Media/Default/Users/TuanLQ7/HaiZuka/js_web2.png" alt="" width="696" height="348"></p><ul><li><strong>Ứng dụng trong lập trình website</strong>:<br>Khi nhắc đến lập trình web người ta không thể không nhắc đến bộ 03 HTML, CSS và&nbsp;JavaScript. Có thể nói không phải là tất cả, song hầu như các website đang chạy hiện nay đều sử dụng JavaScript và các Front-end framework của nó như:&nbsp;Bootstrap, jQuery &nbsp;Foundation, UIKit,… &nbsp;Ở đó&nbsp;JavaScript giúp tạo các hiệu ứng hiển thị trên website, các tương tác với người dùng.</li><li><strong>Xây dựng các ứng dụng web cho máy chủ:</strong><br>Đây là một xu hướng công nghệ có thể nói là rất hót hiện nay (từ 2016 đến giờ). Các anh em lập trình viên khá hào hứng với các Frame work từ JavaScript như:&nbsp;Node.js,&nbsp;AngularJS,… Cụ thể những cái này sẽ hỗ trợ tạo ra các ứng dụng web thiên về tương tác thời gian thực của người dùng.&nbsp; Nếu cùng cấu hình máy chủ tương tự thì điều đó là không thể đối với PHP, Java, Python, .Net khi số lượng user tương tác cùng lúc quá nhiều. Máy chủ sẽ không thể nào gánh nổi, nhưng với các Frame work của JavaScript thì mọi chuyện sẽ hoàn toàn khác.</li><li><strong>Xây dựng các ứng dụng di động, trò chơi và ứng dụng trên desktop.</strong></li></ul><h3><strong>Học viên nhận được những gì khi tham gia khóa học.</strong></h3><ul><li>Các lý thuyết cơ bản về chương trinh JavaScript.</li><li>Biết cách sử dụng các toán tử trong JavaScript.</li><li>Làm quen với các câu lệnh và các cấu trúc dữ liệu trong JavaScrip:<ul><li>Câu lệnh điều kiện.</li><li>Vòng lặp.</li><li>Phương thức mảng.</li><li>Phương thức chuỗi.</li><li>Phương thức dữ liệu.</li></ul></li><li>Biết các thư viện liên quan đến thuật toán.</li></ul>')
GO
INSERT [dbo].[BaiHoc] ([BaiHocId], [TenBaiHoc], [MoTa], [ThoiGianHoanThanh], [NgayTao], [NgayCapNhat], [KhoaHocId], [noidung]) VALUES (4, N'Bài 2 . Biến và cách thao tác với DOM', N'JavaScript là một ngôn ngữ gia thêm khả năng tương tác cho website của bạn (ví dụ: trò chơi, các phản hồi khi các nút được nhấn hoặc nhập dữ liệu trên form, kiểu động, hoạt họa). Bài viết này sẽ giúp bạn khởi động với ngôn ngữ thú vị này và cho bạn ý tưởng về những gì có thể xảy ra.', 1, CAST(N'2024-12-01T15:54:13.450' AS DateTime), CAST(N'2024-12-01T08:54:13.383' AS DateTime), 1, N'<p>JavaScript là một ngôn ngữ gia thêm khả năng tương tác cho website của bạn&nbsp;(ví dụ: trò chơi, các phản hồi khi các nút được nhấn hoặc nhập dữ liệu trên form, kiểu&nbsp;động, hoạt họa). Bài viết này sẽ giúp bạn khởi động với&nbsp;ngôn ngữ thú vị này và cho bạn&nbsp;ý tưởng về những gì có thể xảy ra.</p><h3><strong>JavaScript là gì ?</strong></h3><p>JavaScript&nbsp;(viết tắt là "js") là một ngôn ngữ lập trình mang đầy đủ tính năng&nbsp;của một&nbsp;ngôn ngữ lập trình động&nbsp;mà khi nó được áp dụng&nbsp;vào một tài liệu&nbsp;HTML, nó&nbsp;có thể đem lại khả năng tương tác động trên các trang web. Cha đẻ của ngôn ngữ này là&nbsp;Brendan Eich, đồng sáng lập dự án&nbsp;Mozilla,&nbsp;quỹ&nbsp;Mozilla, và tập đoàn&nbsp;Mozilla.</p><p>JavaScript thật sự rất linh hoạt. Bạn có thể bắt đầu với các bước nhỏ, với&nbsp;? viện&nbsp;ảnh, bố cục có tính&nbsp;thay đổi và phản hồi đến các&nbsp;nút nhấn. Khi có nhiều kinh nghiệm hơn, bạn có thể tạo ra các trò chơi, hoạt họa 2 chiều hoặc 3 chiều, ứng dụng&nbsp;cơ sở dữ liệu toàn diện&nbsp;và nhiều thứ khác!</p><p>Bản thân Javascript là một ngôn ngữ linh động. Các nhà phát triển đã viết ra một số lượng lớn các&nbsp;công cụ&nbsp;thuộc&nbsp;top của&nbsp;core Javascript, mở ra một lượng lớn tính năng bổ sung với ít nỗ lực nhất. Nó bao gồm:</p><ul><li>Giao diện lập trình ứng dụng trên trình duyệt&nbsp;(API) — Các&nbsp;API được xây dựng bên trong các trình duyệt web, cung cấp tính năng như tạo HTML động, cài đặt CSS, thu tập và điều khiển video trực tiếp từ webcam của người dùng hoặc sinh ra đồ dọa 3D và các mẫu&nbsp;audio.</li><li>Các API bên thứ ba cho phép nhà phát triển&nbsp;kết hợp&nbsp;tính năng trong website của họ từ người cung cấp nội dung khác chẳng hạn như Twitter hay Facebook.</li><li>Từ các framework&nbsp;và thư viện bên thứ ba bạn có thể áp dụng tới tài liệu HTML của bạn, cho phép bạn nhanh chóng xây dựng được các trang web và các ứng dụng.</li></ul><p>Vì khóa học này chỉ giới thiệu về JavaScript, chúng tôi sẽ không làm bạn bối rối khi nói rõ hơn về sự khác nhau giữa mã nguồn JavaScript căn bản và những công cụ được liệt kê ở trên. Bạn có thể tìm hiểu chi tiết trong Mục học JavaScript, và MDN.</p><p>Ở phần dưới chúng tôi sẽ giới thiệu cho bạn một số khía cạnh cơ bản về JavaScript và bạn cũng sẽ được làm việc với một vài API. Chúc bạn học tốt!</p><h3><strong>Ứng dụng của JavaScript.</strong></h3><p><img src="https://s3-sgn09.fptcloud.com/codelearnstorage/Media/Default/Users/TuanLQ7/HaiZuka/js_web2.png" alt="" width="696" height="348"></p><ul><li><strong>Ứng dụng trong lập trình website</strong>:<br>Khi nhắc đến lập trình web người ta không thể không nhắc đến bộ 03 HTML, CSS và&nbsp;JavaScript. Có thể nói không phải là tất cả, song hầu như các website đang chạy hiện nay đều sử dụng JavaScript và các Front-end framework của nó như:&nbsp;Bootstrap, jQuery &nbsp;Foundation, UIKit,… &nbsp;Ở đó&nbsp;JavaScript giúp tạo các hiệu ứng hiển thị trên website, các tương tác với người dùng.</li><li><strong>Xây dựng các ứng dụng web cho máy chủ:</strong><br>Đây là một xu hướng công nghệ có thể nói là rất hót hiện nay (từ 2016 đến giờ). Các anh em lập trình viên khá hào hứng với các Frame work từ JavaScript như:&nbsp;Node.js,&nbsp;AngularJS,… Cụ thể những cái này sẽ hỗ trợ tạo ra các ứng dụng web thiên về tương tác thời gian thực của người dùng.&nbsp; Nếu cùng cấu hình máy chủ tương tự thì điều đó là không thể đối với PHP, Java, Python, .Net khi số lượng user tương tác cùng lúc quá nhiều. Máy chủ sẽ không thể nào gánh nổi, nhưng với các Frame work của JavaScript thì mọi chuyện sẽ hoàn toàn khác.</li><li><strong>Xây dựng các ứng dụng di động, trò chơi và ứng dụng trên desktop.</strong></li></ul><h3><strong>Học viên nhận được những gì khi tham gia khóa học.</strong></h3><ul><li>Các lý thuyết cơ bản về chương trinh JavaScript.</li><li>Biết cách sử dụng các toán tử trong JavaScript.</li><li>Làm quen với các câu lệnh và các cấu trúc dữ liệu trong JavaScrip:<ul><li>Câu lệnh điều kiện.</li><li>Vòng lặp.</li><li>Phương thức mảng.</li><li>Phương thức chuỗi.</li><li>Phương thức dữ liệu.</li></ul></li><li>Biết các thư viện liên quan đến thuật toán.</li></ul>')
GO
INSERT [dbo].[BaiHoc] ([BaiHocId], [TenBaiHoc], [MoTa], [ThoiGianHoanThanh], [NgayTao], [NgayCapNhat], [KhoaHocId], [noidung]) VALUES (5, N'Bài 1. Làm quen với kỹ thuật máy tính', N'ok', 1, CAST(N'2024-12-01T10:21:40.610' AS DateTime), CAST(N'2024-12-01T10:21:40.610' AS DateTime), 2, N'<p>ddd</p>')
GO
SET IDENTITY_INSERT [dbo].[BaiHoc] OFF
GO
SET IDENTITY_INSERT [dbo].[BaiKiemTra] ON 
GO
INSERT [dbo].[BaiKiemTra] ([BaiKiemTraId], [TenBaiKiemTra], [KhoaHocId], [ThoiLuong], [NgayTao], [MaBKT], [GiangVienID]) VALUES (1, N'Kiểm tra giữa khóa học', 1, 10, CAST(N'2024-12-01T18:52:54.670' AS DateTime), N'BKT01', 9)
GO
SET IDENTITY_INSERT [dbo].[BaiKiemTra] OFF
GO
SET IDENTITY_INSERT [dbo].[CauHoi] ON 
GO
INSERT [dbo].[CauHoi] ([CauHoiId], [BaiKiemTraId], [NoiDung], [Diem]) VALUES (8, 1, N'Trong JavaScript, var, let, và const khác nhau như thế nào?', 1)
GO
SET IDENTITY_INSERT [dbo].[CauHoi] OFF
GO
SET IDENTITY_INSERT [dbo].[GiangVien] ON 
GO
INSERT [dbo].[GiangVien] ([GiangVienId], [TaiKhoanId], [TenGiangVien], [Email], [SoDienThoai], [Image]) VALUES (1, 1, N'Nguyễn Tấn Tài', N'huymuahanglzd06@gmail.com', N'0987654321', N'/images/20241201090050.jpg')
GO
INSERT [dbo].[GiangVien] ([GiangVienId], [TaiKhoanId], [TenGiangVien], [Email], [SoDienThoai], [Image]) VALUES (3, 9, N'Nguyễn Văn An', N'huysp01@awgarstone.com', N'0987654321', N'/images/20241201090009.jpg')
GO
INSERT [dbo].[GiangVien] ([GiangVienId], [TaiKhoanId], [TenGiangVien], [Email], [SoDienThoai], [Image]) VALUES (7, 15, N'Chu Bá Thành', N'm9sdtqf@taxibmt.net', N'23423423', N'/images/20241201002140.jpg')
GO
INSERT [dbo].[GiangVien] ([GiangVienId], [TaiKhoanId], [TenGiangVien], [Email], [SoDienThoai], [Image]) VALUES (8, 16, N'Hoàng Văn Hải', N'm9sdtqf@taxibmt.net', N'0987654321', N'/images/20241201090139.jpg')
GO
INSERT [dbo].[GiangVien] ([GiangVienId], [TaiKhoanId], [TenGiangVien], [Email], [SoDienThoai], [Image]) VALUES (9, 17, N'Đào Quang Huy', N'huysp01@awgarstone.com', N'0987654321', N'/images/20241201090211.jpg')
GO
SET IDENTITY_INSERT [dbo].[GiangVien] OFF
GO
SET IDENTITY_INSERT [dbo].[HocVien] ON 
GO
INSERT [dbo].[HocVien] ([HocVienId], [TaiKhoanId], [TenHocVien], [Email], [SoDienThoai]) VALUES (1, 10, N'Huyf', N'huysp01@awgarstone.comd', N'23423423')
GO
INSERT [dbo].[HocVien] ([HocVienId], [TaiKhoanId], [TenHocVien], [Email], [SoDienThoai]) VALUES (3, 18, N'huyhv', N'daohuy1692003@gmail.com', N'0987654321')
GO
SET IDENTITY_INSERT [dbo].[HocVien] OFF
GO
SET IDENTITY_INSERT [dbo].[HocVien_KhoaHoc] ON 
GO
INSERT [dbo].[HocVien_KhoaHoc] ([HocVien_KhoaHocId], [HocVienId], [KhoaHocId]) VALUES (1, 3, 1)
GO
INSERT [dbo].[HocVien_KhoaHoc] ([HocVien_KhoaHocId], [HocVienId], [KhoaHocId]) VALUES (2, 3, 2)
GO
SET IDENTITY_INSERT [dbo].[HocVien_KhoaHoc] OFF
GO
SET IDENTITY_INSERT [dbo].[KetQuaKiemTra] ON 
GO
INSERT [dbo].[KetQuaKiemTra] ([KetQuaKiemTraId], [HocVienId], [BaiKiemTraId], [Diem]) VALUES (1, 3, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[KetQuaKiemTra] OFF
GO
SET IDENTITY_INSERT [dbo].[KhoaHoc] ON 
GO
INSERT [dbo].[KhoaHoc] ([KhoaHocId], [TenKhoaHoc], [MoTa], [GiangVienId], [Image], [noidung]) VALUES (1, N'Lập Trình Javascript', N'Xây dựng API mạnh mẽ và linh hoạt với Node.js và Express.', 9, N'/images/20241201104509.jpg', N'<h2><strong>Lập Trình JavaScript Cơ Bản</strong></h2><p>Học Javascript cơ bản phù hợp cho người chưa từng học lập trình. Với hơn 100 bài học và có bài tập thực hành sau mỗi bài học.</p><h2><strong>Bạn sẽ học được gì?</strong></h2><ul><li>Hiểu chi tiết về các khái niệm cơ bản trong JS</li><li>Xây dựng được website đầu tiên kết hợp với JS</li><li>Tự tin khi phỏng vấn với kiến thức vững chắc</li><li>Có nền tảng để học các thư viện và framework JS</li><li>Nắm chắc các tính năng trong phiên bản ES6</li><li>Thành thạo DOM APIs để tương tác với trang web</li><li>Ghi nhớ các khái niệm nhờ bài tập trắc nghiệm</li><li>Nâng cao tư duy với các bài kiểm tra với testcases</li><li>Các bài thực hành như Tabs, Music Player</li><li>Nhận chứng chỉ khóa học do F8 cấp</li></ul><h2><strong>Nội dung khóa học</strong></h2><ul><li><strong>20 </strong>chương</li><li>•</li><li><strong>205 </strong>bài học</li><li>•</li><li>Thời lượng <strong>29 giờ 14 phút</strong></li></ul><p><strong>Mở rộng tất cả</strong></p><p><strong>1. Giới thiệu3 bài học</strong></p><p>1. Lời khuyên trước khóa học</p><p>04:20</p><p>2. Cài đặt môi trường</p><p>02:08</p><p>3. Tham gia cộng đồng F8 trên Discord</p><p>01:00</p><p><strong>2. Biến, comments, built-in10 bài học</strong></p><p><strong>3. Toán tử, kiểu dữ liệu26 bài học</strong></p><p><strong>4. Làm việc với hàm15 bài học</strong></p><p><strong>5. Làm việc với chuỗi6 bài học</strong></p><p><strong>6. Làm việc với số5 bài học</strong></p><p><strong>7. Làm việc với mảng7 bài học</strong></p><p><strong>8. Làm việc với object10 bài học</strong></p><p><strong>9. Lệnh rẽ nhánh, toán tử 3 ngôi7 bài học</strong></p><p><strong>10. Vòng lặp16 bài học</strong></p><p><strong>11. Làm việc với mảng II11 bài học</strong></p><p><strong>12. Callback12 bài học</strong></p><p><strong>13. HTML DOM30 bài học</strong></p><p><strong>14. JSON, Fetch, Postman19 bài học</strong></p><p><strong>15. ECMAScript 6+15 bài học</strong></p><p><strong>16. Các bài thực hành3 bài học</strong></p><p><strong>17. Form validation I5 bài học</strong></p><p><strong>18. Form validation II2 bài học</strong></p><p><strong>19. Tham khảo thêm1 bài học</strong></p><p><strong>20. Hoàn thành khóa học2 bài học</strong></p><h2><strong>Yêu cầu</strong></h2><ul><li>Máy vi tính kết nối internet (Windows, Ubuntu hoặc MacOS)</li><li>Ý thức tự học cao, trách nhiệm cao, kiên trì bền bỉ không ngại cái khó</li><li>Không được nóng vội, bình tĩnh học, làm bài tập sau mỗi bài học</li><li>Khi học nếu có khúc mắc hãy tham gia hỏi/đáp tại group FB: Học lập trình web (fullstack.edu.vn)</li><li>Bạn không cần biết gì hơn nữa, trong khóa học tôi sẽ chỉ cho bạn những gì bạn cần phải biết</li></ul>')
GO
INSERT [dbo].[KhoaHoc] ([KhoaHocId], [TenKhoaHoc], [MoTa], [GiangVienId], [Image], [noidung]) VALUES (2, N'Kỹ thuật học máy cơ bản', N'Giới thiệu về machine learning và cách triển khai các thuật toán cơ bản.', 9, N'/images/20241201085027.jpg', NULL)
GO
INSERT [dbo].[KhoaHoc] ([KhoaHocId], [TenKhoaHoc], [MoTa], [GiangVienId], [Image], [noidung]) VALUES (3, N'Bảo mật hệ thống thông tin', N'Tìm hiểu về các phương pháp bảo mật dữ liệu và hệ thống.', 9, N'/images/20241201085133.jpg', NULL)
GO
INSERT [dbo].[KhoaHoc] ([KhoaHocId], [TenKhoaHoc], [MoTa], [GiangVienId], [Image], [noidung]) VALUES (4, N'Lập trình Game cơ bản', N'Học cách phát triển game 2D đơn giản với Unity hoặc Phaser.', 1, N'/images/20241201085231.jpg', NULL)
GO
INSERT [dbo].[KhoaHoc] ([KhoaHocId], [TenKhoaHoc], [MoTa], [GiangVienId], [Image], [noidung]) VALUES (5, N'Thiết kế giao diện người dùng (UI/UX)', N'Học các nguyên tắc thiết kế và tạo giao diện người dùng chuyên nghiệp.', 1, N'/images/20241201085308.jpg', NULL)
GO
INSERT [dbo].[KhoaHoc] ([KhoaHocId], [TenKhoaHoc], [MoTa], [GiangVienId], [Image], [noidung]) VALUES (6, N'Tiếng Anh Giao Tiếp Cơ Bản', N'Rèn luyện kỹ năng nghe và nói tiếng Anh trong các tình huống hàng ngày.', 1, N'/images/20241201085508.jpg', NULL)
GO
INSERT [dbo].[KhoaHoc] ([KhoaHocId], [TenKhoaHoc], [MoTa], [GiangVienId], [Image], [noidung]) VALUES (7, N'Marketing Kỹ Thuật Số', N'Học cách quảng bá thương hiệu và sản phẩm trên các nền tảng số.', 1, N'/images/20241201090315.jpg', NULL)
GO
INSERT [dbo].[KhoaHoc] ([KhoaHocId], [TenKhoaHoc], [MoTa], [GiangVienId], [Image], [noidung]) VALUES (8, N'Kế Toán Tài Chính Cơ Bản', N'Giới thiệu các nguyên tắc kế toán và cách lập báo cáo tài chính.', 1, N'/images/20241201085625.jpg', NULL)
GO
SET IDENTITY_INSERT [dbo].[KhoaHoc] OFF
GO
SET IDENTITY_INSERT [dbo].[LuaChon] ON 
GO
INSERT [dbo].[LuaChon] ([LuaChonId], [CauHoiId], [NoiDung], [LaDapAnDung]) VALUES (12, 8, N'A. let và const có phạm vi khối, còn var có phạm vi toàn cục hoặc hàm', 0)
GO
INSERT [dbo].[LuaChon] ([LuaChonId], [CauHoiId], [NoiDung], [LaDapAnDung]) VALUES (13, 8, N'B. const không thể được gán lại giá trị, còn let và var thì có thể', 0)
GO
INSERT [dbo].[LuaChon] ([LuaChonId], [CauHoiId], [NoiDung], [LaDapAnDung]) VALUES (14, 8, N'C. var có thể gây ra hoisting, còn let và const thì không', 0)
GO
INSERT [dbo].[LuaChon] ([LuaChonId], [CauHoiId], [NoiDung], [LaDapAnDung]) VALUES (15, 8, N'D. Tất cả các đáp án trên đều đúng', 1)
GO
SET IDENTITY_INSERT [dbo].[LuaChon] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoanId], [TenDangNhap], [MatKhau], [LoaiTaiKhoan]) VALUES (1, N'string', N'string', 0)
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoanId], [TenDangNhap], [MatKhau], [LoaiTaiKhoan]) VALUES (2, N'huy', N'123', 1)
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoanId], [TenDangNhap], [MatKhau], [LoaiTaiKhoan]) VALUES (7, N'hoang', N'string', 0)
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoanId], [TenDangNhap], [MatKhau], [LoaiTaiKhoan]) VALUES (9, N'haohan', N'123', 2)
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoanId], [TenDangNhap], [MatKhau], [LoaiTaiKhoan]) VALUES (10, N'ahahahad', N'123', 3)
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoanId], [TenDangNhap], [MatKhau], [LoaiTaiKhoan]) VALUES (11, N'd', N'd', 3)
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoanId], [TenDangNhap], [MatKhau], [LoaiTaiKhoan]) VALUES (12, N'hhhh', N'hhhh', 2)
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoanId], [TenDangNhap], [MatKhau], [LoaiTaiKhoan]) VALUES (13, N'gggg', N'gggg', 2)
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoanId], [TenDangNhap], [MatKhau], [LoaiTaiKhoan]) VALUES (14, N'fdfd', N'string', 2)
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoanId], [TenDangNhap], [MatKhau], [LoaiTaiKhoan]) VALUES (15, N'ffwf', N'sff', 2)
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoanId], [TenDangNhap], [MatKhau], [LoaiTaiKhoan]) VALUES (16, N'hvh', N'123', 2)
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoanId], [TenDangNhap], [MatKhau], [LoaiTaiKhoan]) VALUES (17, N'huygv', N'123', 2)
GO
INSERT [dbo].[TaiKhoan] ([TaiKhoanId], [TenDangNhap], [MatKhau], [LoaiTaiKhoan]) VALUES (18, N'huyhv', N'123', 3)
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
SET IDENTITY_INSERT [dbo].[TienDoHocTap] ON 
GO
INSERT [dbo].[TienDoHocTap] ([TienDoHocTapId], [HocVienId], [KhoaHocId], [BaiHocId], [TrangThai], [NgayHoanThanh]) VALUES (4, 3, 1, 3, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[TienDoHocTap] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TaiKhoan__55F68FC04F8F99C0]    Script Date: 01/12/2024 10:26:01 CH ******/
ALTER TABLE [dbo].[TaiKhoan] ADD UNIQUE NONCLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BaiHoc] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[BaiHoc] ADD  DEFAULT (getdate()) FOR [NgayCapNhat]
GO
ALTER TABLE [dbo].[BaiKiemTra] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[BaiKiemTra]  WITH CHECK ADD FOREIGN KEY([KhoaHocId])
REFERENCES [dbo].[KhoaHoc] ([KhoaHocId])
GO
ALTER TABLE [dbo].[CauHoi]  WITH CHECK ADD FOREIGN KEY([BaiKiemTraId])
REFERENCES [dbo].[BaiKiemTra] ([BaiKiemTraId])
GO
ALTER TABLE [dbo].[GiangVien]  WITH CHECK ADD FOREIGN KEY([TaiKhoanId])
REFERENCES [dbo].[TaiKhoan] ([TaiKhoanId])
GO
ALTER TABLE [dbo].[HocVien]  WITH CHECK ADD FOREIGN KEY([TaiKhoanId])
REFERENCES [dbo].[TaiKhoan] ([TaiKhoanId])
GO
ALTER TABLE [dbo].[HocVien_KhoaHoc]  WITH CHECK ADD FOREIGN KEY([HocVienId])
REFERENCES [dbo].[HocVien] ([HocVienId])
GO
ALTER TABLE [dbo].[HocVien_KhoaHoc]  WITH CHECK ADD FOREIGN KEY([KhoaHocId])
REFERENCES [dbo].[KhoaHoc] ([KhoaHocId])
GO
ALTER TABLE [dbo].[KetQuaKiemTra]  WITH CHECK ADD FOREIGN KEY([BaiKiemTraId])
REFERENCES [dbo].[BaiKiemTra] ([BaiKiemTraId])
GO
ALTER TABLE [dbo].[KetQuaKiemTra]  WITH CHECK ADD FOREIGN KEY([HocVienId])
REFERENCES [dbo].[HocVien] ([HocVienId])
GO
ALTER TABLE [dbo].[KhoaHoc]  WITH CHECK ADD FOREIGN KEY([GiangVienId])
REFERENCES [dbo].[GiangVien] ([GiangVienId])
GO
ALTER TABLE [dbo].[LuaChon]  WITH CHECK ADD FOREIGN KEY([CauHoiId])
REFERENCES [dbo].[CauHoi] ([CauHoiId])
GO
ALTER TABLE [dbo].[TienDoHocTap]  WITH CHECK ADD FOREIGN KEY([BaiHocId])
REFERENCES [dbo].[BaiHoc] ([BaiHocId])
GO
ALTER TABLE [dbo].[TienDoHocTap]  WITH CHECK ADD FOREIGN KEY([HocVienId])
REFERENCES [dbo].[HocVien] ([HocVienId])
GO
ALTER TABLE [dbo].[TienDoHocTap]  WITH CHECK ADD FOREIGN KEY([KhoaHocId])
REFERENCES [dbo].[KhoaHoc] ([KhoaHocId])
GO
USE [master]
GO
ALTER DATABASE [QLGD_TT] SET  READ_WRITE 
GO
