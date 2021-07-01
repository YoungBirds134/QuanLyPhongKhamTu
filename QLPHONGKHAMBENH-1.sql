CREATE DATABASE QLPHONGKHAMBENH



USE QLPHONGKHAMBENH
Go

CREATE TABLE NHASANXUAT --NHÀ SẢN XUẤT THUỐC
(
	MANSX NCHAR(20) NOT NULL,
	TENNSX NVARCHAR(100),
	DIACHI NVARCHAR(100),
	SDT CHAR(10),
	GMAIL NVARCHAR(100),
	CONSTRAINT PK_NHASANXUAT PRIMARY KEY(MANSX)
)

CREATE TABLE LOAITHUOC --LOẠI THUỐC
(
	MALOAI NCHAR(20) NOT NULL,
	TENLOAI NVARCHAR(100),	
	CONSTRAINT PK_LOAITHUOC PRIMARY KEY(MALOAI)
)

CREATE TABLE BENH --BỆNH LÝ
(
	MABENH NCHAR(20) NOT NULL,
	TENBENH NVARCHAR(100),	
	GHICHU NVARCHAR(1500),	
	CONSTRAINT PK_BENH PRIMARY KEY(MABENH)
)

CREATE TABLE VITRI --VỊ TRÍ ĐỂ THUỐC TRONG CỬA HÀNG
(
	MAVITRI NCHAR(20) NOT NULL,
	TENVITRI NVARCHAR(100),	
	CONSTRAINT PK_VITRI PRIMARY KEY(MAVITRI)
)

CREATE TABLE NHACUNGCAP --NHÀ CUNG CẤP
(
	MANCC NCHAR(20) NOT NULL,
	TENNCC NVARCHAR(100),	
	DIACHI NVARCHAR(100),
	GMAIL NVARCHAR(100),
	SDT CHAR(11),
	CONSTRAINT PK_NHACUNGCAO PRIMARY KEY(MANCC)
)

CREATE TABLE KHOA --KHOA
(
	MAKHOA NCHAR(20) NOT NULL,
	TENKHOA NVARCHAR(100),		
	CHUCNANG NVARCHAR(100), --CHỨC NĂNG CỦA KHOA	
	CONSTRAINT PK_KHOA PRIMARY KEY(MAKHOA)
)

CREATE TABLE NHANVIEN --NHÂN VIÊN CỬA HÀNG
(
	MANV NCHAR(20) NOT NULL,
	TENNV NVARCHAR(100),	
	TENDANGNHAP NVARCHAR(100), --TÊN ĐĂNG NHẬP CHO TÀI KHOẢNG CỦA NHÂN VIÊN
	MATKHAU NVARCHAR(16), --MẬT KHẨU ĐĂNG NHẬP CHO TÀI KHOẢNG CỦA NHÂN VIÊN
	NGAYSINH DATE,
	GIOITINH NVARCHAR(5),	
	DIACHI NVARCHAR(100),
	GMAIL NVARCHAR(100),
	SDT CHAR(10),
	CHUCVU NVARCHAR(100), --CHỨC VỤ CỦA NHÂN VIÊN
	LUONGCB INT, --LƯƠNG CƠ BẢN
	HSL FLOAT,--HỆ SỐ LƯƠNG
	LUONG FLOAT, --LƯƠNG NHÂN VIÊN = LUONGCB*HSL
	MAKHOA NCHAR(20) NOT NULL,
	CONSTRAINT PK_NHANVIEN PRIMARY KEY(MANV),
	CONSTRAINT FK_NHANVIEN_KHOA FOREIGN KEY(MAKHOA) REFERENCES KHOA(MAKHOA)
)

CREATE TABLE BENHNHAN --THÔNG TIN BỆNH NHÂN 
(
	MABN INT IDENTITY(1,1) NOT NULL,
	TENBN NVARCHAR(100),	
	NGAYSINH DATE,
	GIOITINH NVARCHAR(5),	
	DIACHI NVARCHAR(100),	
	SDT CHAR(10),	
	CONSTRAINT PK_BENHNHAN PRIMARY KEY(MABN)
)

CREATE TABLE THANNHAN --THÔNG TIN THÂN NHÂN
(
	MATN INT IDENTITY(1,1) NOT NULL,
	TENTN NVARCHAR(100),	
	NGAYSINH DATE,
	GIOITINH NVARCHAR(5),	
	DIACHI NVARCHAR(100),	
	SDT CHAR(10),	
	MABN INT NOT NULL,
	CONSTRAINT PK_THANNHAN PRIMARY KEY(MATN),
	CONSTRAINT FK_THANNHAN_BENHNHAN FOREIGN KEY(MABN) REFERENCES BENHNHAN(MABN)
)

CREATE TABLE BANGGIAKHAMBENH --BẢNG GIÁ KHÁM BỆNH
(
	MAGIAKHAM NCHAR(20) NOT NULL,
	HINHTHUCKHAM NVARCHAR(100), --HÌNH THỨC KHÁM ( KHÁM BỆNH TỔNG QUÁT, KHÁM TAI MŨI HỌNG, KHÁM MẮT, KHÁM TÙM LUM,...)	
	TIENKHAM FLOAT,	
	CONSTRAINT PK_BANGGIAKHAMBENH PRIMARY KEY(MAGIAKHAM)	
)

CREATE TABLE PHONG --PHÒNG KHÁM
(
	MAPHONG NCHAR(20) NOT NULL,
	TENPHONG NVARCHAR(100), --HÌNH THỨC KHÁM ( KHÁM BỆNH TỔNG QUÁT, KHÁM TAI MŨI HỌNG, KHÁM MẮT, KHÁM TÙM LUM,...)	
	MAKHOA NCHAR(20) NOT NULL,
	CONSTRAINT PK_PHONG PRIMARY KEY(MAPHONG),	
	CONSTRAINT FK_PHONG_KHOA FOREIGN KEY(MAKHOA) REFERENCES KHOA(MAKHOA)
)

CREATE TABLE PHIEUKHAMBENH
(
	SOPHIEUKHAM INT IDENTITY(1,1) NOT NULL,
	MABN INT NOT NULL,
	MANV NCHAR(20) NOT NULL,--NHÂN VIÊN TIẾP NHẬN LẬP
	NGAYLAPPHIEU DATE,
	MAPHONG NCHAR(20) NOT NULL, --PHÒNG KHÁM	
	TINHTRANGSUCKHOE NVARCHAR(100), -- TÌNH TRẠNG SỨC KHỎE
	DENGHIKHAM NVARCHAR(100), --ĐỀ NGHỊ KHÁM BỆNH (KHÁM MẮT, KHÁM RĂNG, KHÁM TỔNG QUÁT,...)
	MAGIAKHAM NCHAR(20) NOT NULL,
	TRANGTHAIPHIEU NVARCHAR(100),--TRẠNG THÁI CỦA PHIẾU ( CHỜ KHÁM, CHỜ XÉT NGHIỆM, ĐÃ KHÁM)	
	CONSTRAINT PK_PHIEUKHAMBENH PRIMARY KEY(SOPHIEUKHAM),
	CONSTRAINT FK_PHIEUKHAM_BENHNHAN FOREIGN KEY(MABN) REFERENCES BENHNHAN(MABN),
	CONSTRAINT FK_PHIEUKHAM_NV FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV),
	CONSTRAINT FK_PHIEUKHAM_PHONG FOREIGN KEY(MAPHONG) REFERENCES PHONG(MAPHONG),
	CONSTRAINT FK_PHIEUKHAM_BANGGIA FOREIGN KEY(MAGIAKHAM) REFERENCES BANGGIAKHAMBENH(MAGIAKHAM)
)

CREATE TABLE HOADONKHAMBENH --HÓA ĐƠN KHÁM BỆNH
(
	SOHDKHAM INT IDENTITY(1,1) NOT NULL,
	SOPHIEUKHAM INT NOT NULL,	
	NGAYLAPHDKHAM DATE, --NGÀY LẬP
	THANHTIEN FLOAT, --TÍNH TIỀN LẤY TỪ MÃ GIÁ KHÁM BÊN PHIẾU KHÁM BỆNH
	CONSTRAINT PK_HDKHAM PRIMARY KEY(SOHDKHAM),
	CONSTRAINT FK_HDKHAM_PHIEUKHAMBENH FOREIGN KEY(SOPHIEUKHAM) REFERENCES PHIEUKHAMBENH(SOPHIEUKHAM)
	
)

CREATE TABLE DICHVU --DỊCH VỤ
(
	MADV NCHAR(20) NOT NULL,
	TENDV NVARCHAR(100), 
	GIASUDUNG FLOAT,	--GIÁ SỬ DỤNG 1 LẦN
	CONSTRAINT PK_DICHVU PRIMARY KEY(MADV)	
)

CREATE TABLE PHIEUDKDICHVU --PHIẾU ĐĂNG KÝ SỬ DỤNG DỊCH VỤ
(
	MADKDV INT IDENTITY(1,1) NOT NULL,--MÃ ĐK DỊCH VỤ	
	MABS NCHAR(20) NOT NULL,--BÁC SĨ LẬP
	NGAYLAPPHIEUDK DATE, --NGÀY LẬP PHIẾU
	MAPHONG NCHAR(20) NOT NULL, --PHÒNG SỬ DỤNG DỊCH VỤ	
	TONGTIEN FLOAT, --TỔNG TIỀN 
	TRANGTHAI NVARCHAR(100),--TRANG THAI PHIẾU ( CHỜ THỰC HIỆN, ĐÃ THỰC HIỆN)
	CONSTRAINT PK_DKDICHVU PRIMARY KEY(MADKDV),	
	CONSTRAINT FK_DKDICHVU_NV FOREIGN KEY(MABS) REFERENCES NHANVIEN(MANV),
	CONSTRAINT FK_DKDICHVU_PHONG FOREIGN KEY(MAPHONG) REFERENCES PHONG(MAPHONG),
)

CREATE TABLE HOADONDICHVU --HÓA ĐƠN SỬ DỤNG DICH VỤ
(
	SOHDDV INT IDENTITY(1,1) NOT NULL,
	MADKDV INT NOT NULL,
	MANV NCHAR(20) NOT NULL,--NHÂN VIÊN THỰC HIỆN DỊCH VỤ LẬP	
	NGAYLAPHDDV DATE, --NGÀY LẬP
	TONGTIEN FLOAT, --TỔNG TIỀN LẤY TỪ TỔNG TIỀN BÊN PHIẾU ĐK DỊCH VỤ
	CONSTRAINT PK_HDDV PRIMARY KEY(SOHDDV),
	CONSTRAINT FK_HDDV_PHIEUDKDV1 FOREIGN KEY(MADKDV) REFERENCES PHIEUDKDICHVU(MADKDV),
	CONSTRAINT FK_DV_NV FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
)

CREATE TABLE CT_PHIEUDKDICHVU --CHI TIẾT PHIẾU ĐĂNG KÝ SỬ DỤNG DỊCH VỤ
(
	MACTDICHVU INT IDENTITY(1,1) NOT NULL,--MÃ CHI TIẾT DK DV
	MADKDV INT NOT NULL,
	MADV NCHAR(20) NOT NULL,		
	THANHTIEN FLOAT --THÀNH TIỀN LẤY TỪ GIÁ DỊCH VỤ
	CONSTRAINT PK_CT_DKDV PRIMARY KEY(MACTDICHVU),
	CONSTRAINT FK_CTDKDV_DKDV FOREIGN KEY(MADKDV) REFERENCES PHIEUDKDICHVU(MADKDV),
	CONSTRAINT FK_CTDKDV_DV FOREIGN KEY(MADV) REFERENCES DICHVU(MADV)
)

CREATE TABLE KETQUADICHVU -- KẾT QUẢ SỬ DỤNG DỊCH VỤ
(
	MAKQDV INT IDENTITY(1,1) NOT NULL,--MÃ KẾT QUẢ DICH VỤ
	MADKDV INT NOT NULL,
	MANV NCHAR(20) NOT NULL,--NHÂN VIÊN THỰC HIỆN DV
	NGAYLAPKQ DATE, --NGÀY LẬP KQ	
	GHICHU 	NVARCHAR(100),--GHI CHÚ NHƯNG CÁI CẦN THIẾT
	CONSTRAINT PK_KQDV PRIMARY KEY(MAKQDV),
	CONSTRAINT FK_KQDV_DKDV FOREIGN KEY(MADKDV) REFERENCES PHIEUDKDICHVU(MADKDV),
	CONSTRAINT FK_KQDV_NV FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
)

CREATE TABLE CT_KQDV --CHI TIẾT KẾT QUẢ DV
(	
	MAKQDV INT NOT NULL,
	MACTDICHVU INT NOT NULL,
	KETQUA NVARCHAR(100), --KẾT QUẢ XÉT NGHIỆM
	HOICHUAN NVARCHAR(100), --HỘI CHUẨN KẾT QUẢ
	GHICHU NVARCHAR(100),--GHI CHÚ THÊM NHẬN XÉT
	CONSTRAINT PK_CT_KQDV PRIMARY KEY(MAKQDV,MACTDICHVU),
	CONSTRAINT FK_CTKQDV_KQDV FOREIGN KEY(MAKQDV) REFERENCES KETQUADICHVU(MAKQDV),
	CONSTRAINT FK_CTKQDV_CTDV FOREIGN KEY(MACTDICHVU) REFERENCES CT_PHIEUDKDICHVU(MACTDICHVU)
)


CREATE TABLE THUOC --THUỐC
(
	MATHUOC NCHAR(20) NOT NULL,	
	TENTHUOC NVARCHAR(100),	
	MALOAI NCHAR(20) NOT NULL,
	MANSX NCHAR(20) NOT NULL,	
	CONGDUNG NVARCHAR(1000), --CÔNG DỤNG
	HAMLUONG NVARCHAR(100), --HÀM LƯỢNG THUỐC 
	HSD DATE, --HẠN SỬ DỤNG
	DONVICB NVARCHAR(100), --ĐƠN VỊ CƠ BẢN (VIÊN)
	GIACB FLOAT, --GIÁ BÁN THEO ĐƠN VỊ CƠ BẢN
	SOLUONGCB INT, --SỐ LƯỢNG TỒN THEO ĐƠN VỊ CƠ BẢN
	DONVIBAN NVARCHAR(100), --ĐƠN VỊ BÁN (HỘP)
	GIABAN FLOAT, --GIÁ BÁN THEO ĐƠN VỊ BÁN
	SOLUONGBAN INT, --SỐ LƯỢNG TỒN THEO ĐƠN VỊ BÁN
	GIATRIQUYDOI INT, --GIÁ TRỊ QUY ĐỔI (1 HỘP 100 VIÊN --> 100)
	QUICACHDONGGOI NVARCHAR(100), --QUY CÁCH ĐÓNG GÓI (1 HỘP 100 VIÊN)
	MAVITRI NCHAR(20) NOT NULL,
	MOTA NVARCHAR(1000), --MÔ TẢ THÀNH PHẦN THUỐC
	CONSTRAINT PK_THUOC PRIMARY KEY(MATHUOC),
	CONSTRAINT FK_THUOC_LOAI FOREIGN KEY(MALOAI) REFERENCES LOAITHUOC(MALOAI),
	CONSTRAINT FK_THUOC_NSX FOREIGN KEY(MANSX) REFERENCES NHASANXUAT(MANSX),
	CONSTRAINT FK_THUOC_VITRI FOREIGN KEY(MAVITRI) REFERENCES VITRI(MAVITRI),
)

CREATE TABLE TOATHUOC --TOA THUỐC 
(
	MATOA INT IDENTITY(1,1) NOT NULL,
	SOPHIEUKHAM INT NOT NULL,
	MABS NCHAR(20) NOT NULL, --BÁC SĨ LẬP
	NGAYLAPTOA DATE,
	TINHTRANG NVARCHAR(100), --TÌNH TRẠNG BỆNH KHI BS KHÁM
	CHUANDOAN NVARCHAR(100),--CHUẨN ĐOÁN
	HUONGDIEUTRI NVARCHAR(100), --HƯỚNG ĐIỀU TRỊ
	TONGTIEN FLOAT,	
	CONSTRAINT PK_TOA PRIMARY KEY(MATOA),
	CONSTRAINT FK_TOA_PHIEUKHAMBENH FOREIGN KEY(SOPHIEUKHAM) REFERENCES PHIEUKHAMBENH(SOPHIEUKHAM),
	CONSTRAINT FK_TOA_NV FOREIGN KEY(MABS) REFERENCES NHANVIEN(MANV)
)

CREATE TABLE CT_TOATHUOC -- CHI TIẾT TOA THUỐC
(
	MATOA INT NOT NULL,
	MATHUOC NCHAR(20) NOT NULL,	
	SOLUONG INT, --SỐ LƯỢNG BÁN
	GIABAN FLOAT,--GIÁ BÁN
	DVT NVARCHAR(100), --ĐƠN VỊ BÁN (VIÊN HOẶC HỘP)	
	CACHDUNG NVARCHAR(100),--CÁCH DÙNG
	THANHTIEN FLOAT,
	CONSTRAINT PK_CT_TOA PRIMARY KEY(MATOA,MATHUOC),
	CONSTRAINT FK_CTTOA_TOA FOREIGN KEY(MATOA) REFERENCES TOATHUOC(MATOA),
	CONSTRAINT FK_CTTOA_THUOC FOREIGN KEY(MATHUOC) REFERENCES THUOC(MATHUOC)
)

CREATE TABLE HOADONTHUOC --HÓA ĐƠN THUỐC
(
	SOHDTHUOC INT IDENTITY(1,1) NOT NULL,
	MATOA INT NOT NULL,		
	NGAYLAPHDKHAM DATE, --NGÀY LẬP
	TONGTIENTIEN FLOAT, --TÍNH TIỀN LẤY TỪ TONG TIEN TOA THUOC
	CONSTRAINT PK_HDTHUOC PRIMARY KEY(SOHDTHUOC),
	CONSTRAINT FK_HDTHUOC_TOA FOREIGN KEY(MATOA) REFERENCES TOATHUOC(MATOA)
)

CREATE TABLE DIEUTRI --THUỐC ĐIỀU TRỊ BỆNH
(
	MATHUOC NCHAR(20) NOT NULL,
	MABENH NCHAR(20) NOT NULL,	
	CACHDIEUTRI NVARCHAR(100),-- CÁCH ĐIỀU TRỊ
	CONSTRAINT PK_DIEUTRI PRIMARY KEY(MATHUOC,MABENH),
	CONSTRAINT FK_DIEUTRI_THUOC FOREIGN KEY(MATHUOC) REFERENCES THUOC(MATHUOC),
	CONSTRAINT FK_DIEUTRI_BENH FOREIGN KEY(MABENH) REFERENCES BENH(MABENH)
)

CREATE TABLE DATHANG --ĐẶT HÀNG NCC
(
	MADATHANG NCHAR(20) NOT NULL,--MÃ ĐẶT HÀNG
	MANCC NCHAR(20) NOT NULL,
	MANV NCHAR(20) NOT NULL,--NHÂN VIÊN QUẢN LÝ
	NGAYDATHANG DATE, --NGÀY ĐẶT HÀNG
	TONGTIENDAT FLOAT, --TỔNG TIỀN ĐẶT HÀNG
	TRANGTHAI NVARCHAR(100),--TRANG THAI ĐÃ GIAO HAY CHƯA GIAO	
	CONSTRAINT PK_DATHANG PRIMARY KEY(MADATHANG),
	CONSTRAINT FK_DATHANG_NCC FOREIGN KEY(MANCC) REFERENCES NHACUNGCAP(MANCC),
	CONSTRAINT FK_DATHANG_NV FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
)

CREATE TABLE CT_DATHANG --CHI TIẾT ĐẶT HÀNG NCC
(
	MACTDATHANG NCHAR(20) NOT NULL,--MÃ CHI TIẾT ĐẶT HÀNG
	MADATHANG NCHAR(20) NOT NULL,
	MATHUOC NCHAR(20) NOT NULL,
	SOLUONGDAT INT, --SỐ LƯỢNG THUỐC ĐẶT
	SOLUONGDAGIAO INT, --SỐ LƯỢNG ĐÃ GIAO ( KHỞI TẠO 0)
	GIANHAP FLOAT, --GIÁ ĐỂ ĐẶT HÀNG ( NHỎ HƠN GIÁ BÁN THUỐC)
	THANHTIENDAT FLOAT --THÀNH TIỀN ĐẶT HÀNG CỦA THUỐC ĐẶT
	CONSTRAINT PK_CT_DATHANG PRIMARY KEY(MACTDATHANG),
	CONSTRAINT FK_CTDATHANG_DATHANG FOREIGN KEY(MADATHANG) REFERENCES DATHANG(MADATHANG),
	CONSTRAINT FK_CTDATHANG_THUOC FOREIGN KEY(MATHUOC) REFERENCES THUOC(MATHUOC)
)

CREATE TABLE NHAPHANG -- NHẬP HÀNG (GIAO HÀNG)
(
	MANHAPHANG NCHAR(20) NOT NULL,--MÃ NHẬP HÀNG
	MADATHANG NCHAR(20) NOT NULL,
	MANV NCHAR(20) NOT NULL,
	NGAYNHAP DATE, --NGÀY NHẬP HÀNG
	TONGTIENNHAP FLOAT, --TỔNG TIỀN ĐƠN NHẬP HÀNG
	HSD DATE, --HẠN SỬ DỤNG
	CONSTRAINT PK_NHAPHANG PRIMARY KEY(MANHAPHANG),
	CONSTRAINT FK_NHAPHANG_DATHANG FOREIGN KEY(MADATHANG) REFERENCES DATHANG(MADATHANG),
	CONSTRAINT FK_NHAPHANG_NV FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
)

CREATE TABLE CT_NHAPHANG --CHI TIẾT NHẬP HÀNG 
(
	MANHAPHANG NCHAR(20)  NOT NULL,
	MACTDATHANG NCHAR(20) NOT NULL,
	SOLUONGNHAP INT, --SỐ LƯỢNG THUỐC NHẬP
	GIANHAP FLOAT, --GIÁ ĐỂ ĐẶT HÀNG ( LẤY TỪ CT_DATHANG)
	THANHTIENNHAP FLOAT --THÀNH TIỀN NHẬP HÀNG
	CONSTRAINT PK_CT_NHAPHANG PRIMARY KEY(MANHAPHANG,MACTDATHANG),
	CONSTRAINT FK_CTNHAPHANG_NHAPHANG FOREIGN KEY(MANHAPHANG) REFERENCES NHAPHANG(MANHAPHANG),
	CONSTRAINT FK_CTNHAPHANG_CTDATHANG FOREIGN KEY(MACTDATHANG) REFERENCES CT_DATHANG(MACTDATHANG)
)







INSERT INTO BENH VALUES('MB0001',N'Đau dạ dày',N'Triệu chứng đau dạ dày
Đau dạ dày thường có một số biểu hiện rõ rệt, tuy nhiên, cũng có một số trường hợp bệnh không có dấu hiệu đặc trưng mà chỉ xuất hiện những cơn đau bụng âm ỉ.
Dưới đây là một số triệu chứng của đau dạ dày:
- Đau thượng vị
- Đau dạ dày gây ra ăn uống kém
- Đau dạ dày thường có triệu chứng ợ hơi, ợ chua, ợ nóng
- Cảm giác buồn nôn, nôn
- Đau dạ dày có thể khiến chảy máu tiêu hóa
Khi gặp một trong những triệu chứng kể trên, đặc biệt là chảy máu tiêu hóa, bạn cần đến ngay các cơ sở y tế để được thăm khám và điều trị càng sớm càng tốt.')

INSERT INTO BENH VALUES('MB0002',N'Sốt',N'Những triệu chứng thường gặp của sốt là:

Cảm thấy lạnh khi mọi người xung quanh không cảm thấy thế
Run
Da sờ thấy nóng
Đau đầu
Chán ăn
Mất nước
Trầm cảm
Khó tập trung
Buồn ngủ
Đổ mồ hôi.')
INSERT INTO BENH VALUES('MB0003',N'Đau mắt',N'Những triệu chứng báo động
Sau đây là những triệu chứng cần được quan tâm:

Nôn mửa, nhìn thấy quầng màu, hoặc phù giác giác mạc
Các dấu hiệu nhiễm trùng toàn thân (ví dụ, sốt, rét run)
Giảm thị lực
Lồi mắt
Hạn chế vận nhãn')
INSERT INTO BENH VALUES('MB0004',N'Thiếu vitamin C',N'Dấu hiệu thiếu vitamin C bao gồm:
Tăng cân không rõ nguyên nhân bởi vì vitamin C giúp đốt cháy chất béo. 

Xuất huyết dưới da, xuất huyết khớp do tổn thương collagen dẫn đến suy yếu các mao mạch, có thể bị chảy máu kết mạc mắt, cơ thể dễ bị bầm tím. 

Bị viêm lợi, chảy máu chân răng dẫn đến viêm chân răng. 

Phụ nữ hành kinh ra nhiều máu hơn bình thường, có thể bị rong kinh. 

Dễ bị cảm lạnh, viêm họng, sốt,... do khả năng chống oxy hóa và bảo vệ các tế bào miễn dịch bị giảm sút do thiếu vitamin C.

Tác dụng chống oxy hóa bị giảm sút khiến da bị khô, dễ cháy nắng, xỉn màu và hình thành nếp nhăn.

Thường xuyên gặp phải tình trạng chảy máu cam do mạch máu nhỏ nằm bên trong mũi bị vỡ. ')
INSERT INTO BENH VALUES('MB0005',N'Đau, căng cơ',N'Triệu chứng đặc trưng của đau căng cơ bắp mà bệnh nhân cần biết:

- Đau nhức tại một vị trí hoặc nhiều vị trí trên cơ thể.

- Căng cứng cơ gây khó vận động hoặc mất vận động tạm thời.

- Tê bì, châm chích tay chân, thậm chí bị chuột rút (vọp bẻ).

- Cơn đau chỉ tập trung một chỗ hoặc lan tỏa sang nhiều chỗ.

- Sưng, phù nề xung quanh khớp, thậm chí nóng đỏ vùng da quanh khớp.')

INSERT INTO BENH VALUES('MB0006',N'Tiêu chảy cấp do virus Rota',N'Virus Rota là loại virus gây ra viêm dạ dày ruột cấp nặng ở trẻ sơ sinh và trẻ nhỏ. Virus Rota lây qua đường phân – miệng, tay – miệng và khả năng lây nhiễm rất cao. Loại virus này được thải ra theo đường tiêu hoá ở trẻ nhiễm bệnh, tồn tại bền vững trong môi trường. Trẻ dưới 1 tuổi có nguy cơ lây bệnh rất cao do thói quen tiếp xúc các đồ vật bằng tay và cho tay vào miệng.
Bệnh có thể khởi phát đột ngột với triệu chứng nôn mửa từ 1 – 3 ngày, sau đó là tiêu chảy cộng với nôn mửa, sốt và sốc gây co giật. Nhiễm Rotavirus khiến trẻ dễ bị mất nước, ảnh hưởng đến thể trạng toàn thân như suy dinh dưỡng và một số biểu hiện khác. Nếu không được cấp cứu kịp thời, trẻ có thể tử vong.')


INSERT INTO BENH VALUES('MB0007',N'Bệnh Tay –  Chân – Miệng',N'Tay chân miệng là bệnh thường bùng phát vào dịp hè, bệnh rất dễ lây lan từ người này sang người khác và có thể phát triển thành dịch.
Các triệu chứng bệnh tay chân miệng thường bắt đầu bằng sốt, giảm cảm giác ngon miệng, đau họng, và mệt mỏi. Một hoặc hai ngày sau khi bắt đầu sốt, những vết lở loét có thể xuất hiện trong miệng. Những vết đốm đỏ mọng nước bắt đầu nổi dạng ban trên da ở tay và chân, có thể cả trên đầu gối, khuỷu tay và mông trẻ. Bệnh nếu không can thiệp kịp thời có thể sẽ diễn tiến rất nhanh và gây tử vong chỉ trong 24h.')


INSERT INTO BENH VALUES('MB0008',N'Sốt xuất huyết',N'Sốt xuất huyết là bệnh truyền nhiễm do muỗi vằn Aedes Aegypti mang vi-rút Dengue gây ra. Các con muỗi cái mang mầm bệnh, sau khi đốt người sẽ khiến người nhiễm virus bắt đầu phát bệnh với biểu hiện sốt cao liên tục, dưới da xuất hiện các đốm xuất huyết màu đỏ sau 4 – 6 ngày
Đối với các bệnh nhân sốt xuất huyết thể nhẹ, người bệnh có thể được điều trị tại nhà theo chỉ định của bác sĩ. Tuy nhiên, từ ngày thứ 3 đến ngày thứ 7, người bệnh, đặc biệt là trẻ em, cần được theo dõi sát để phát hiện các triệu chứng tiền sốc do mất máu. Ở thể nặng, bệnh gây xuất huyết ồ ạt, biến chứng gan, thận, xuất huyết não và tử vong
Phụ nữ mang thai ở giai đoạn đầu bị sốt xuất huyết rất nguy hiểm. Bệnh có thể gây suy thai, đẻ non, thai chết lưu do sốt và mất nước dài ngày hoặc tổn thương chức năng gan, thận.')

INSERT INTO BENH VALUES('MB0009',N'Táo bón',N'Triệu chứng này gây ra cho người mắc táo bón sự mệt mỏi, bực tức, đau đớn vùng hậu môn mỗi khi đi đại tiện. Táo bón xảy ra ở tất cả các độ tuổi. Đối với người bình thường, trong một tuần tần suất đi đại tiện sẽ là hơn 3 lần. Người bị táo bón thường đi tiêu dưới 3 lần/tuần với các biểu hiện đau đớn, khó khăn, phân cứng và đau vùng bụng dưới.')

INSERT INTO BENH VALUES('MB00010',N'Viêm gan',N'Được gây ra bởi một số virus. Các loại chính là A, B và C. Các triệu chứng loại A thường xuất hiện như do siêu vi khuẩn dạ dày. Viêm gan B và C có thể gây ra bệnh đột ngột. Tuy nhiên, bệnh có thể diễn tiến tới tổn thương tế bào gan gây xơ gan,nhiễm trùng  gan và ung thư gan.')

INSERT INTO BENH VALUES('MB00011',N'Đau dạ dày',N'Triệu chứng của bệnh đau dạ dày ở mỗi người là khác nhau, nhưng nhìn chung người mắc đau dạ dày thường xuất hiện các biểu hiện:

– Đau vùng thượng vị, cảm giác nóng rát hoặc râm ran

– Buồn nôn hoặc nôn

– Ợ hơi hoặc ợ chua

– Đầy bụng, khó tiêu

– Chán ăn, mệt mỏi

– Xuất huyết dạ dày')

INSERT INTO BENH VALUES('MB00012',N'Viêm họng',N'Người bệnh sẽ cảm thấy đau rát cổ họng, đặc biệt là khi nuốt, kèm với một số triệu chứng khác như ho, sốt, hắt hơi, ngạt mũi, chảy nước mũi, …')

INSERT INTO BENH VALUES('MB00013',N'Bệnh mề đay',N'Triệu chứng đặc trưng của bệnh là tình trạng nổi các mảng sẩn phù màu hồng hoặc đỏ trên da. Ban đầu mảng sẩn chỉ xuất hiện rải rác ở một số vị trí nhất định trên cơ thể nhưng nếu bệnh tiến triển nặng hơn thì có thể gây nổi mề đay toàn thân. Khu vực da bị bệnh vô cùng ngứa ngáy. Cơn ngứa trở nên dữ dội hơn vào chiều tốt và càng gãi bệnh nhân càng cảm thấy ngứa. Các mảng mề đay thường lặn đi sau vài giờ nhưng chúng có thể xuất hiện trở lại sau đó hoặc mọc ở vị trí khác.')

INSERT INTO BENH VALUES('MB00014',N'Cao huyết áp',N'Một số trường hợp có thể có các triệu chứng cao huyết áp thoáng qua như nhức đầu, hoa mắt, chóng mặt, ù tai, mất ngủ nhẹ,... Một số bệnh nhân khác có biểu hiện tăng huyết áp dữ dội hơn, chẳng hạn như đau nhói vùng tim, suy giảm thị lực, thở gấp, mặt đỏ bừng, da tái xanh, nôn ói, hồi hộp, đánh trống ngực, hốt hoảng.')

INSERT INTO BENH VALUES('MB00015',N'Tụt huyết áp',N'Dấu hiệu của Tụt huyết áp là người bệnh sẽ có cảm giác choáng váng, hoa mắt, chóng mặt, hồi hộp, tim đập nhanh; nặng hơn có thể là lơ mơ, lú lẫn, ngất xỉu và mất ý thức. Huyết áp giảm đột ngột làm cho não và các cơ quan khác trong cơ thể không nhận được lượng máu cung cấp đủ oxy và các chất dinh dưỡng, có thể gây thiếu máu não và chết não, nguy hiểm đến tính mạng.')



INSERT INTO VITRI VALUES('VTK0001',N'Kệ 1, Cột 1 , Hàng 1, Ô 1')
INSERT INTO VITRI VALUES('VTK0002',N'Kệ 1, Cột 2 , Hàng 1, Ô 3')
INSERT INTO VITRI VALUES('VTK0003',N'Kệ 1, Cột 5 , Hàng 4, Ô 2')
INSERT INTO VITRI VALUES('VTK0004',N'Kệ 2, Cột 4 , Hàng 1, Ô 1')
INSERT INTO VITRI VALUES('VTK0005',N'Kệ 2, Cột 2 , Hàng 1, Ô 5')
INSERT INTO VITRI VALUES('VTK0006',N'Kệ 2, Cột 2 , Hàng 3, Ô 1')
INSERT INTO VITRI VALUES('VTK0007',N'Kệ 3, Cột 3 , Hàng 5, Ô 1')
INSERT INTO VITRI VALUES('VTK0008',N'Kệ 3, Cột 3 , Hàng 1, Ô 3')
INSERT INTO VITRI VALUES('VTK0009',N'Kệ 4, Cột 5 , Hàng 2, Ô 2')
INSERT INTO VITRI VALUES('VTK00010',N'Kệ 4, Cột 5 , Hàng 3, Ô 4')




INSERT INTO NHACUNGCAP VALUES('NCC0001',N'Công ty Cổ phần Dược liệu Trung ương 2',N'24 Nguyễn Thị Nghĩa - P. Bến Thành - Quận 1 - Tp Hồ Chí Minh','info@phytopharma.vn','02838539126')
INSERT INTO NHACUNGCAP VALUES('NCC0002',N'Công ty Cổ phần Dược Hậu Giang',N'288 Bis Nguyễn Văn Cừ, P. An Hòa, Q. Ninh Kiều, TP. Cần Thơ','dhgpharma@dhgpharma.com.vn','02923891433')
INSERT INTO NHACUNGCAP VALUES('NCC0003',N'CÔNG TY CP DƯỢC PHẨM ECO',N'148 Hoàng Hoa Thám, P.12, Q.Tân Bình, TP.HCM','','02862936630')
INSERT INTO NHACUNGCAP VALUES('NCC0004',N'CÔNG TY CỔ PHẦN DƯỢC PHẨM BẾN TRE',N'6A3, Quốc lộ 60, Phường Phú Tân, Thành phố Bến Tre, Tỉnh Bến Tre','bepharco.vietnam@bepharco.com','02753900059')
INSERT INTO NHACUNGCAP VALUES('NCC0005',N'CÔNG TY CỔ PHẦN DƯỢC PHẨM VIMEDIMEX',N'Tầng 8 tòa nhà Vimedimex Group, số 46-48 Bà Triệu, phường Hàng Bài, quận Hoàng Kiếm, thành phố Hà Nội, Việt Nam','','0822476688')


INSERT INTO KHOA VALUES('MK0001',N'Phòng Điều Dưỡng',N'Nơi điều trị, phòng hồi sức.')
INSERT INTO KHOA VALUES('MK0002',N'Khoa Khám Bệnh',N'Nơi khám bệnh chính')
INSERT INTO KHOA VALUES('MK0003',N'Khoa Cấp cứu',N'Tiếp nhận, cấp cứu bệnh nhân')
INSERT INTO KHOA VALUES('MK0004',N'Khoa Ngoại tổng hợp', N'Chuẩn đoán, chửa các bệnh bên ngoài cơ thể')
INSERT INTO KHOA VALUES('MK0005',N'Khoa Tai Mũi Họng',N'Chuẩn đoán, khám, chữa các bệnh liên quan đến Tai Mũi Họng.')
INSERT INTO KHOA VALUES('MK0006',N'Khoa Mắt',N'Chuẩn đoán, khám, chữa các bệnh liên quan đến mắt.')
INSERT INTO KHOA VALUES('MK0007',N'Khoa Chuẩn đoán hình ảnh',N'Triển khai các kỹ thuật điện quang can thiệp. Chụp cộng hưởng từ.')
INSERT INTO KHOA VALUES('MK0008',N'Khoa Da liễu',N'Chuẩn đoán, khám, chữa các bệnh ngoài da.')


SET DATEFORMAT DMY 
INSERT INTO NHANVIEN VALUES('NV0001',N'Đàm Tấn Sang','sang123','sang123','12/04/2000','nam',N'Long An','sang@gmail.com','0123456789',N'Nhân viên điều dưỡng','5000000','3.99','18000000','MK0001')
INSERT INTO NHANVIEN VALUES('NV0002',N'Đàm Tấn Sang','sang1234','sang1234','12/04/1999','nu',N'HCM','sang1@gmail.com','0123456789',N'Bác sĩ','6400000','4.32','25000000','MK0002')
INSERT INTO NHANVIEN VALUES('NV0003',N'Đàm Tấn Sang','sang12345','sang12345','12/04/1998','nam',N'Hà Nội','sang2@gmail.com','0123456789',N'Bác sĩ','6400000','4.32','25000000','MK0003')
INSERT INTO NHANVIEN VALUES('NV0004',N'Đàm Tấn Sang','sang12346','sang12346','12/04/1997','nu',N'Bến Tre','sang3@gmail.com','0123456789',N'Bác sĩ','6400000','4.32','25000000','MK0004')
INSERT INTO NHANVIEN VALUES('NV0005',N'Đàm Tấn Sang','sang12347','sang12347','12/04/1996','nam',N'Trà Vinh','sang4@gmail.com','0123456789',N'Bác sĩ','6400000','4.32','25000000','MK0005')
INSERT INTO NHANVIEN VALUES('NV0006',N'Đàm Tấn Sang','sang12348','sang12348','12/04/1995','nu',N'Quãng Ngãi','sang5@gmail.com','0123456789',N'Bác sĩ','6400000','4.32','25000000','MK0006')
INSERT INTO NHANVIEN VALUES('NV0007',N'Đàm Tấn Sang','sang12349','sang12349','12/04/1994','nam',N'Bình Thuận','sang6@gmail.com','0123456789',N'Bác sĩ','6400000','4.32','25000000','MK0007')
INSERT INTO NHANVIEN VALUES('NV0008',N'Đàm Tấn Sang','sang1','sang1','12/04/1993','nu',N'Hải Phòng','sang7@gmail.com','0123456789',N'Nhân viên thu ngân','6400000','4.32','25000000','MK0008')
INSERT INTO NHANVIEN VALUES('NV0009',N'Đàm Tấn Sang','sangnhap','sangnhap','12/04/1993','nam',N'Hải Phòng','sang8@gmail.com','0123456789',N'Nhân viên quản lý thuốc','6400000','4.32','25000000','MK0008')

SET DATEFORMAT DMY 
INSERT INTO BENHNHAN VALUES(N'Đàm Tấn Sang','12/04/2000',N'NAM',N'Long An','0123456789')
INSERT INTO BENHNHAN VALUES(N'NGUYỄN DUY MINH','12/05/1999',N'Nữ',N'Cần Thơ','0123456789')
INSERT INTO BENHNHAN VALUES(N'NGUYỄN DUY MINH','12/06/1998',N'NAM',N'Trà Vinh','0123456789')
INSERT INTO BENHNHAN VALUES(N'NGUYỄN DUY MINH','12/07/1997',N'Nữ',N'Bạc Liêu','0123456789')
INSERT INTO BENHNHAN VALUES(N'NGUYỄN DUY MINH','12/08/1996',N'NAM',N'Đồng Tháp','0123456789')

SET DATEFORMAT DMY 
INSERT INTO THANNHAN VALUES(N'Đàm Tấn Sang','06/04/2000',N'NAM',N'Long An','0123456789','1')
INSERT INTO THANNHAN VALUES(N'NGUYỄN DUY MINH','07/05/2000',N'Nữ',N'Cần Thơ','0123456789','2')
INSERT INTO THANNHAN VALUES(N'NGUYỄN DUY MINH','01/06/2000',N'NAM',N'Trà Vinh','0123456789','3')
INSERT INTO THANNHAN VALUES(N'NGUYỄN DUY MINH','03/07/2000',N'Nữ',N'Bạc Liêu','0123456789','4')
INSERT INTO THANNHAN VALUES(N'NGUYỄN DUY MINH','08/08/2000',N'Nữ',N'Đồng Tháp','0123456789','5')


INSERT INTO BANGGIAKHAMBENH VALUES('GK0001',N'Khám thông thường','50000')
INSERT INTO BANGGIAKHAMBENH VALUES('GK0002',N'Siêu âm','200000')
INSERT INTO BANGGIAKHAMBENH VALUES('GK0003',N'Chụp X quang','300000')
INSERT INTO BANGGIAKHAMBENH VALUES('GK0004',N'Xét nghiệm máu','500000')
INSERT INTO BANGGIAKHAMBENH VALUES('GK0005',N'Cấp cứu','1000000')



INSERT INTO PHONG VALUES('MP0001',N'Phòng điều trị','MK0001')
INSERT INTO PHONG VALUES('MP0002',N'Phòng khám bệnh','MK0002')
INSERT INTO PHONG VALUES('MP0003',N'Phòng cấp cứu','MK0003')
INSERT INTO PHONG VALUES('MP0004',N'Phòng khám ngoại khoa','MK0004')
INSERT INTO PHONG VALUES('MP0005',N'Phòng khám ngoại khoa(tai, mũi, họng)','MK0005')
INSERT INTO PHONG VALUES('MP0006',N'Phòng khám ngoại khoa(mắt)','MK0006')
INSERT INTO PHONG VALUES('MP0007',N'Phòng khám dịch vụ tổng quát','MK0007')
INSERT INTO PHONG VALUES('MP0008',N'Phòng khám ngoại khoa(da liễu)','MK0008')
INSERT INTO PHONG VALUES('MP0009',N'Phòng khám dịch vụ(Siêu âm)','MK0007')
INSERT INTO PHONG VALUES('MP00010',N'Phòng khám dịch vụ(Chụp X quang)','MK0007')
INSERT INTO PHONG VALUES('MP00011',N'Phòng khám dịch vụ(Xét nghiệm máu)','MK0007')
INSERT INTO PHONG VALUES('MP00012',N'Phòng khám dịch vụ(Mổ)','MK0007')


SET DATEFORMAT DMY 
INSERT INTO PHIEUKHAMBENH VALUES('1','NV0006','03/04/2021','MP0002',N'Chóng mặt, mặt hơi xanh',N'Xét nghiệm máu','GK0004','')
INSERT INTO PHIEUKHAMBENH VALUES('2','NV0002','04/04/2021','MP0002',N'Ho khán, hơi nóng',N'Mua thuốc về nhà uống đúng giờ','GK0001','')
INSERT INTO PHIEUKHAMBENH VALUES('3','NV0003','05/04/2021','MP0002',N'Nghi gãy tay',N'Chụp X quang','GK0003','')
INSERT INTO PHIEUKHAMBENH VALUES('4','NV0004','06/04/2021','MP0002',N'Ghi thiếu máu, mặt hơi xanh',N'Xét nghiệm máu','GK0004','')


SET DATEFORMAT DMY 
INSERT INTO HOADONKHAMBENH VALUES('5','03/04/2021','500000')
INSERT INTO HOADONKHAMBENH VALUES('6','04/04/2021','50000')
INSERT INTO HOADONKHAMBENH VALUES('7','05/04/2021','300000')
INSERT INTO HOADONKHAMBENH VALUES('8','06/04/2021','500000')


INSERT INTO DICHVU VALUES('DV0001',N'Khám thông thường','50000')
INSERT INTO DICHVU VALUES('DV0002',N'Siêu âm','200000')
INSERT INTO DICHVU VALUES('DV0003',N'Chụp X quang','300000')
INSERT INTO DICHVU VALUES('DV0004',N'Xét nghiệm máu','500000')
INSERT INTO DICHVU VALUES('DV0005',N'Bó bột','350000')
INSERT INTO DICHVU VALUES('DV0006',N'Vô nước biển','150000')
INSERT INTO DICHVU VALUES('DV0007',N'Mổ thường','1000000')
INSERT INTO DICHVU VALUES('DV0008',N'Mổ nội soi','3000000')

SET DATEFORMAT DMY 
INSERT INTO PHIEUDKDICHVU VALUES('NV0002','25/05/2021','MP0007','300000',N'Đã thực hiện')
INSERT INTO PHIEUDKDICHVU VALUES('NV0003','24/05/2021','MP0007','200000',N'Đã thực hiện')
INSERT INTO PHIEUDKDICHVU VALUES('NV0004','23/04/2021','MP0007','150000',N'Đã thực hiện')
INSERT INTO PHIEUDKDICHVU VALUES('NV0005','22/05/2021','MP0007','150000',N'Đã thực hiện')
INSERT INTO PHIEUDKDICHVU VALUES('NV0006','21/04/2021','MP0007','50000',N'Đã thực hiện')


SET DATEFORMAT DMY 
INSERT INTO HOADONDICHVU VALUES('1','NV0001','25/05/2021','300000')
INSERT INTO HOADONDICHVU VALUES('2','NV0008','24/05/2021','200000')
INSERT INTO HOADONDICHVU VALUES('3','NV0008','23/04/2021','150000')
INSERT INTO HOADONDICHVU VALUES('4','NV0008','22/05/2021','150000')
INSERT INTO HOADONDICHVU VALUES('5','NV0008','21/04/2021','50000')



INSERT INTO CT_PHIEUDKDICHVU VALUES('1','DV0003','300000')
INSERT INTO CT_PHIEUDKDICHVU VALUES('1','DV0001','50000')
INSERT INTO CT_PHIEUDKDICHVU VALUES('2','DV0002','200000')
INSERT INTO CT_PHIEUDKDICHVU VALUES('3','DV0006','150000')


SET DATEFORMAT DMY 
INSERT INTO KETQUADICHVU VALUES('1','NV0002','25/05/2021','tốt')
INSERT INTO KETQUADICHVU VALUES('2','NV0003','24/05/2021','tốt')
INSERT INTO KETQUADICHVU VALUES('3','NV0004','23/04/2021','tốt')
INSERT INTO KETQUADICHVU VALUES('4','NV0005','22/05/2021','tốt')
INSERT INTO KETQUADICHVU VALUES('5','NV0006','21/04/2021','tốt')



INSERT INTO CT_KQDV VALUES('1','1',N'tốt',N'nghi nhiễm sốt',N'yêu cầu theo dõi thêm')
INSERT INTO CT_KQDV VALUES('2','2',N'tốt','...','...')
INSERT INTO CT_KQDV VALUES('3','5',N'không tốt',N'nghi đau ruột thừa',N'yêu cầu sang phòng mỗ')
INSERT INTO CT_KQDV VALUES('4','6',N'tốt',N'đã ổn','xong')


INSERT INTO NHASANXUAT VALUES('NSX0001',N'Novartis (Thụy Sĩ)',N'Thổ Nhĩ Kỳ','','')
INSERT INTO NHASANXUAT VALUES('NSX0002',N'Imexpharm (Việt Nam)',N'Việt Nam','','')
INSERT INTO NHASANXUAT VALUES('NSX0003',N'Sanofi (Pháp)','Pháp',N'','')
INSERT INTO NHASANXUAT VALUES('NSX0004',N'Merap (Việt Nam)',N'Việt Nam','','')
INSERT INTO NHASANXUAT VALUES('NSX0005',N'Bayer (Đức)',N'Indonesia','','')
INSERT INTO NHASANXUAT VALUES('NSX0006',N'Traphaco (Việt Nam)',N'Việt Nam','','')
INSERT INTO NHASANXUAT VALUES('NSX0007',N'Stellapharm',N'Việt Nam','','')
INSERT INTO NHASANXUAT VALUES('NSX0008',N'Olic (Nhật Bản)',N'Sản xuất tại: Thái Lan','','')
INSERT INTO NHASANXUAT VALUES('NSX0009',N'Thái Nakorn Patana (Thái Lan)',N'Sản xuất tại: Thái Lan','','')
INSERT INTO NHASANXUAT VALUES('NSX00010',N'TW1 (Việt Nam)',N'Việt Nam','','')
INSERT INTO NHASANXUAT VALUES('NSX00011',N'2/9 (Việt Nam)',N'Việt Nam','','')
INSERT INTO NHASANXUAT VALUES('NSX00012',N'AstraZeneca (Anh)',N'Sản xuất tại Thụy Điển','','')
INSERT INTO NHASANXUAT VALUES('NSX00013',N'Sandoz (Đức)','Sản xuất tại Áo',N'','')
INSERT INTO NHASANXUAT VALUES('NSX00014',N'Pharmedic (Việt Nam)',N'Việt Nam','','')
INSERT INTO NHASANXUAT VALUES('NSX00015',N'Pharmascience (Canada)','Canada',N'','')



INSERT INTO LOAITHUOC VALUES('LT0001',N'Thuốc tuần hoàn máu não')
INSERT INTO LOAITHUOC VALUES('LT0002',N'Thuốc kháng sinh, kháng virut')
INSERT INTO LOAITHUOC VALUES('LT0003',N'Thuốc giảm đau, kháng viêm')
INSERT INTO LOAITHUOC VALUES('LT0004',N'Thuốc đường tiêu hóa')
INSERT INTO LOAITHUOC VALUES('LT0005',N'Thuốc cầm máu')
INSERT INTO LOAITHUOC VALUES('LT0006',N'Dầu nóng, thuốc bôi - xịt ngoài da')
INSERT INTO LOAITHUOC VALUES('LT0007',N'Thuốc ho, long đờm')
INSERT INTO LOAITHUOC VALUES('LT0008',N'Thuốc bổ, vitamin và khoáng chất')
INSERT INTO LOAITHUOC VALUES('LT0009',N'Dung Dịch Sát Trùng')
INSERT INTO LOAITHUOC VALUES('LT00010',N'Thuốc trị gút - xương khớp')
INSERT INTO LOAITHUOC VALUES('LT00011',N'Thuốc tim mạch')
INSERT INTO LOAITHUOC VALUES('LT00012',N'Thuốc giãn cơ')
INSERT INTO LOAITHUOC VALUES('LT00013',N'Thuốc gan mật')
INSERT INTO LOAITHUOC VALUES('LT00014',N'Thuốc da liễu')
INSERT INTO LOAITHUOC VALUES('LT00015',N'Thuốc chống dị ứng (Kháng Histamin)')
INSERT INTO LOAITHUOC VALUES('LT00016',N'Thuốc nhỏ mắt, tra mắt')
INSERT INTO LOAITHUOC VALUES('LT00017',N'Thuốc tai mũi họng')



SET DATEFORMAT DMY 
INSERT INTO THUOC VALUES('SPKUT0001',N'Thuốc trung hòa acid dạ dày Anticid 500mg 500 viên','LT0004','NSX0002',N'Tăng tiết acid dạ dày, ợ nóng, khó tiêu, ợ chua.','Calci carbonat 500mg','12/06/2024',N'Viên','900','500',N'Lọ','450000','1','500','1 Lọ 500 viên','VTK0003',N'')
INSERT INTO THUOC VALUES('SPKUT0002',N'Thuốc giảm đau, kháng viêm Cataflam 25mg hộp 10 viên','LT0003',N'NSX0001',N'Điều trị ngắn hạn các tình trạng cấp tính: đau sau chấn thương, viêm và sưng do bong gân, đau sau phẫu thuật, đau và/hoặc viêm trong phụ khoa như đau bụng kinh tiên phát hoặc viêm phần phụ, đau nửa đầu, đau cột sống, bệnh thấp không phải ở khớp.Điều trị hỗ trợ trong các nhiễm khuẩn viêm đau nặng ở tai, mũi hoặc họng, như viêm họng amiđan, viêm tai.','Diclofenac 25mg','01/04/2024',N'Viên','4000','10',N'Hộp','38000','3','10',N'Hộp 10 viên','VTK0002',N'')
INSERT INTO THUOC VALUES('SPKUT0003',N'Thuốc giảm đau, hạ sốt Panadol Extra hộp 180 viên','LT0003',N'NSX0003',N'Điều trị đau nhẹ đến vừa và hạ sốt: Đau đầu, đau cơ, đau bụng kinh, đau họng, đau cơ xương, sốt và đau sau khi tiêm vacxin, đau sau khi nhổ răng hoặc sau các thủ thuật nha khoa, đau răng, đau do viêm xương khớp.','Cafein 65mg, Paracetamol 500mg',N'10/12/2023',N'Viên','1300','180',N'Hộp','225000','5','15',N'Hộp 15 vỉ, mỗi vỉ 12 viên','VTK0001',N'Người lớn (kể cả người cao tuổi) và trẻ em từ 12 tuổi: 500mg/65mg - 1000mg/30mg[paracetamol/ caffeine] (1 hoặc 2 viên) mỗi 4 - 6 giờ nếu cần.Tối đa hàng ngày: 4000mg/520mg (paracetamol/ caffeine).Thời gian tối thiểu dùng liều lặp lại: 4 giờ. Không dùng các thuốc khác có chưa paracetamol, không dùng quá liều chỉ định. Trẻ em dưới 12 tuổi: không khuyến nghị.')
INSERT INTO THUOC VALUES('SPKUT0004',N'Thuốc nhỏ mắt Osla chai 15ml','LT00016',N'NSX0004',N'Mỏi mắt, ngứa mắt, khô rát mắt, cay mắt, xốn (cộm) mắt, đỏ mắt, mờ mắt, chảy nước mắt, mắt khó chịu. Rửa mắt để loại các vật lạ, làm sạch ghèn rỉ mắt. Phòng ngừa các bệnh đau mắt. ',N'Natri clorid 0.033g','12/8/2021',N'Chai','19000','1',N'Hộp','19000','20','1',N'1 Hộp 1 chai','VTK0004',N'')
INSERT INTO THUOC VALUES('SPKUT0005',N'Viên sủi bổ sung vitamin C, kẽm Redoxon Double Action 10 viên','LT0008',N'NSX0005',N'Dự phòng và điều trị thiếu hụt vitamin C và kẽm.',N'Kẽm 10mg, Vitamin C 1000mg',N'05/03/2022',N'Viên','4400','10',N'Lọ','44000','10','10',N'1 lọ 10 viên','VTK0003',N'')
INSERT INTO THUOC VALUES('SPKUT0006',N'Hoạt huyết dưỡng não Traphaco 20 viên bao đường','LT0001',N'NSX0006',N'Phòng và điều trị các bệnh sau: suy giảm trí nhớ, căng thẳng thần kính, kém tập trung. Thiểu năng tuần hoàn não, hội chứng tiền đình với các biểu hiện: đau đầu, hoa mắt chóng mặt, mất ngủ, mất thăng bằng. Giảm chức năng não bộ: giảm trí nhớ, suy nhược thần kinh, di chứng não. Chứng run giật của bệnh nhân Parkinson.',N'Cao khô lá Bạch quả 5mg, Cao đặc rễ Đinh lăng 5:1 150mg',N'12/02/2022',N'Vỉ','23000','1',N'Hộp','23000','30','1',N'1 hộp 1 vỉ','VTK0004',N'')
INSERT INTO THUOC VALUES('SPKUT0007',N'Thuốc chống co thắt cơ trơn No-Spa Forte 80mg 30 viên','LT0004',N'NSX0003',N'Co thắt cơ trơn trong những bệnh lý đường mật. Co thắt cơ trơn trong những bệnh lý đường niệu. Co thắt cơ trơn hệ tiêu hoá. Đau bụng kinh',N'Drotaverin hydrochlorid 80mg','04/05/2023',N'Viên','1500',N'30',N'Hộp','30000','10','30',N'Hộp 2 vỉ, mỗi vỉ 10 viên.','VTK0005',N'')
INSERT INTO THUOC VALUES('SPKUT0008',N'Kem bôi trị viêm da, nấm Stadgentri tuýp 10g','LT00014',N'NSX0007',N'Điều trị các bệnh về da có đáp ứng với corticosteroid khi có biến chứng nhiễm trùng do vi khuẩn (nhạy cảm với gentamicin) và nấm (nhạy cảm với clotrimazole) hoặc khi có nghi ngờ các nhiễm trùng này. Thuốc cũng được chỉ định cho bệnh chàm có rỉ dịch.',N' Gentamicin 10mg, Betamethason dipropionat 6.4mg, Clotrimazol 100mg','05/07/2022',N'Tuýp','9000','1',N'Hộp','9000','12','1',N'1 hộp 1 tuýp','VTK0009',N'')
INSERT INTO THUOC VALUES('SPKUT0009',N'Thuốc cầm máu Transamin 500mg 100 viên','LT0005',N'NSX0008',N'Điều trị Xu hướng chảy máu được coi như liên quan tới tăng tiêu fibrin (bệnh bạch huyết, thiếu máu không tái tạo, ban xuất huyết, v.v, và chảy máu bất thường trong và sau khi phẫu thuật). Chảy máu bất thường được coi như liên quan tới tăng tiêu fibrin tại chỗ (chảy máu ở phổi, mũi, bộ phận sinh dục, hoặc thận hoặc chảy máu bất thường trong khi hoặc sau phẫu thuật tuyến tiền liệt). Rong kinh.','Tranexamic acid 500mg','01/04/2024',N'Viên','4300','100',N'Hộp','425000','9','100',N'Hộp 10 vỉ, mỗi vỉ 10 viên.','VTK0007',N'')
INSERT INTO THUOC VALUES('SPKUT00010',N'Thuốc cầm máu Transamin 250mg 100 viên','LT0005',N'NSX0008',N'Điều trị Xu hướng chảy máu do tăng tiêu fibrin toàn thân trong những trường hợp sau: bệnh bạch cầu, thiếu máu bất sản, ban xuất huyết, chảy máu bất thường trong hoặc sau phẫu thuật. Chảy máu bất thường do tăng tiêu fibrin tại chỗ trong những trường hợp sau: chảy máu phổi, chảy máu cam, chảy máu âm đạo, chảy máu thận, chảy máu bất thường trong hoặc sau phẫu thuật tuyến tiền liệt.','Tranexamic acid 250mg',N'10/12/2023',N'Viên','2700','100',N'Hộp','267000','12','100',N' Hộp 10 vỉ, mỗi vỉ 10 viên.','VTK0001',N'')
INSERT INTO THUOC VALUES('SPKUT00011',N'Kem bôi giảm đau Neoticabalm 15g','LT0006',N'NSX0009',N'Giảm đau, giảm sưng, kháng viêm trong chấn thương. Đau cơ, đau khớp, bong gân, tan máu bầm, vết chích do côn trùng gây ra, đau & mỏi cơ do hoạt động thể dục thể thao.',N'Methyl Salicylate, Eucalyptol, Menthol, DL-Camphor, Eugenol','12/8/2021',N'Tuýp','18000','1',N'Hộp','18000','20','1',N'1 Hộp 1 Tuýp','VTK0008',N'')
INSERT INTO THUOC VALUES('SPKUT00012',N'Thuốc xịt mũi trị viêm mũi, viêm xoang Otilin 0.1% chai 15ml','LT00017',N'NSX00010',N'Viêm mũi cấp hoặc mạn tính, viêm xoang, cảm lạnh, cảm mạo hoặc dị ứng đường hô hấp trên, đau đầu hoặc viêm tai giữa cấp liên quan tới sung huyết mũi.',N'Xylometazolin 15mg',N'05/03/2022',N'Chai','19000','1',N'Hộp','19000','10','1',N'Hộp 1 lọ 15ml.','VTK0008',N'')
INSERT INTO THUOC VALUES('SPKUT00013',N'Thuốc giảm đau, hạ sốt Acemol 325mg chai 40 viên','LT0003',N'NSX00011',N'Hạ sốt và giảm đau trong các trường hợp: Cảm cúm, sốt, đau nhức.',N'Paracetamol 325mg','12/02/2022',N'Viên','300','40',N'Chai','12000','30','40',N'Chai 40 viên','VTK0007',N'')
INSERT INTO THUOC VALUES('SPKUT00014',N'Thuốc bổ sung canxi cho bé Calcium Corbiere 5ml 30 ống','LT0008',N'NSX0003',N'Thiếu canxi, có nhu cầu canxi cao, bổ sung canxi trong hỗ trợ điều trị loãng xương, mất canxi xương ở người lớn tuổi, phòng ngừa tình trạng giảm sự khoáng hóa xương ở giai đoạn tiền và hậu mãn kinh, dùng corticosteroid.',N'Calci glucoheptonat 0.550g, Vitamin C 0.050g, Vitamin PP 0.025g','04/05/2023',N'Ống','4100',N'30',N'Hộp','120','10','30',N'Hộp 3 vỉ, mỗi vỉ 10 ống, mỗi ống 5ml.','VTK0005',N'')
INSERT INTO THUOC VALUES('SPKUT00015',N'Thuốc trị cao huyết áp, đau thắt ngực Betaloc Zok 25mg hộp 14 viên','LT00011',N'NSX00012',N'Điều trị tăng huyết áp, đau thắt ngực, loạn nhịp tim, suy tim cơ bản, rối loạn chức năng tim, phòng ngừa tử vong do tim và tái nhồi máu sau cơn nhồi máu cơ tim cấp, đau nửa đầu dạng migraine.',N'Metoprolol 25mg','05/07/2022',N'Viên','4900','14',N'Hộp','68000','12','14',N'Hộp 1 vỉ, mỗi vỉ 14 viên','VTK0009',N'')
INSERT INTO THUOC VALUES('SPKUT00016',N'Dung dịch sát khuẩn Povidine 10% 8ml','LT0009',N'NSX00014',N'Sát khuẩn để giúp ngăn ngừa nhiễm khuẩn ở vết cắt, vết trầy và vết bỏng nhỏ. Sát khuẩn da trước khi phẫu thuật.Giúp giảm các vi khuẩn có khả năng gây nhiễm trùng da.',N'Povidon iodin 10g','22/04/2025',N'Chai','6000','1',N'Hộp','6000','30','1',N'Hộp 1 Chai 8ml.','VTK0009',N'')
INSERT INTO THUOC VALUES('SPKUT00017',N'Thuốc giãn cơ Pharmaclofen 10mg chai 100 viên','LT00012',N'NSX00015',N'Giảm dấu hiệu và triệu chứng của tình trạng co cứng do đa xơ cứng, tổn thương tủy sống và các bệnh khác liên quan tủy sống.',N'Baclofen 10mg','12/04/2023',N'Viên','2800','100',N'Chai','277000','100','14',N'Chai 100 viên','VTK0002',N'')
INSERT INTO THUOC VALUES('SPKUT00018',N'Thuốc chống dị ứng Telfast HD 180mg 10 viên','LT00015',N'NSX0003',N'Điều trị Viêm mũi dị ứng ở người lớn và trẻ em từ 12 tuổi trở lên. Mày đay vô căn mạn tính: Thuốc làm giảm ngứa và số lượng dát mày đay một cách đáng kể.',N'Fexofenadin 180mg','05/07/2022',N'Viên','7900','10',N'Hộp','75000','19','10',N'Hộp 1 vỉ, mỗi vỉ 10 viên.','VTK0005',N'')
INSERT INTO THUOC VALUES('SPKUT00019',N'Thuốc kháng sinh Curam 1000mg hộp 10 viên','LT0002',N'NSX00013',N'Nhiễm khuẩn xoang và tai giữa; nhiễm khuẩn đường hô hấp; nhiễm khuẩn đường tiết niệu; nhiễm khuẩn da và mô mềm; nhiễm khuẩn xương và khớp.',N'Amoxicilin 875mg, Acid clavulanic 125mg','05/04/2022',N'Viên','9000','10',N'Hộp','90000','15','10',N'Hộp 5 vỉ, mỗi vỉ 2 viên.','VTK0006',N'')






SET DATEFORMAT DMY
INSERT INTO TOATHUOC VALUES('1','NV0006','03/04/2021',N'Bệnh mới phát',N'Cảm nhẹ',N'Về nhà uống thuốc','100000')
INSERT INTO TOATHUOC VALUES('2','NV0002','04/04/2021',N'Bệnh mới phát',N'Thiếu máu',N'Về nhà uống thuốc','100000')
INSERT INTO TOATHUOC VALUES('3','NV0003','05/04/2021',N'Nguy hiểm nếu không điều trị đúng cách',N'Gãy tay',N'Về nhà uống thuốc','400000')
INSERT INTO TOATHUOC VALUES('4','NV0004','06/04/2021',N'Bệnh mới phát',N'Đau mắt',N'Về nhà uống thuốc','200000')


SET DATEFORMAT DMY
INSERT INTO CT_TOATHUOC VALUES('1','SPKUT0003','20','1300',N'Viên',N'Ngày 3 cử mỗi cử 2 viên','26000')
INSERT INTO CT_TOATHUOC VALUES('2','SPKUT0006','1','23000',N'Vỉ',N'Ngày 3 cử mỗi cử 2 viên','23000')
INSERT INTO CT_TOATHUOC VALUES('4','SPKUT0004','1','19000',N'Chai',N'Ngày 3 cử mỗi cử 2 viên','19000')
INSERT INTO CT_TOATHUOC VALUES('3','SPKUT0003','30','1300',N'Viên',N'Ngày 3 cử mỗi cử 2 viên','39000')


SET DATEFORMAT DMY
INSERT INTO HOADONTHUOC VALUES('1','03/04/2021','26000')
INSERT INTO HOADONTHUOC VALUES('2','04/04/2021','23000')
INSERT INTO HOADONTHUOC VALUES('3','05/04/2021','19000')
INSERT INTO HOADONTHUOC VALUES('4','06/04/2021','39000')

SET DATEFORMAT DMY
INSERT INTO DATHANG VALUES('MPDH0001','NCC0001','NV0009','29/5/2021','5000000',N'đã giao')
INSERT INTO DATHANG VALUES('MPDH0002','NCC0002','NV0009','28/5/2021','200000',N'Chờ giao')
INSERT INTO DATHANG VALUES('MPDH0003','NCC0003','NV0009','27/5/2021','300000',N'Chờ giao')
INSERT INTO DATHANG VALUES('MPDH0004','NCC0004','NV0009','26/5/2021','100000',N'Chờ giao')

INSERT INTO CT_DATHANG VALUES('MPCTNH0001','MPDH0001','SPKUT0002','20','20','35000','700000')
INSERT INTO CT_DATHANG VALUES('MPCTDH0002','MPDH0002','SPKUT0003','10','0','220000','2200000')
INSERT INTO CT_DATHANG VALUES('MPCTDH0003','MPDH0003','SPKUT0006','20','0','20000','400000')
INSERT INTO CT_DATHANG VALUES('MPCTDH0004','MPDH0004','SPKUT0005','30','0','16000','480000')

SET DATEFORMAT DMY
INSERT INTO NHAPHANG VALUES('MPNH0001','MPDH0001','NV0009','31/05/2021','5000000','03/06/2025')

INSERT INTO CT_NHAPHANG VALUES('MPNH0001','MPCTNH0001','20','35000','700000')