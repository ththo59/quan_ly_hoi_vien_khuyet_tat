

CREATE TABLE [dbo].[QL_HOATDONG_TAPHUAN](
	[TH_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TH_LOAI_ID] [bigint] NULL,
	[TH_THOIGIAN_BATDAU] [datetime] NULL,
	[TH_THOIGIAN_KETTHUC] [datetime] NULL,
	[TH_TONGSO_NGAY] [int] NULL,
	[TH_TEN] [nvarchar](250) NULL,
	[TH_LA_HOATDONG] [nvarchar](50) NULL,
	[NTT_ID] [bigint] NULL,
	[TH_DONVI_PHUTRACH] [nvarchar](50) NULL,
	[TH_TINH_THUCHIEN] [nvarchar](50) NULL,
	[TH_HOATDONG_MA] [nvarchar](50) NULL,
	[TH_HOATDONG_LOAI] [nvarchar](50) NULL,
	[TH_LINK_THV_HOPDONG] [nvarchar](250) NULL,
	[TH_LINK_THV_BANCAMKET] [nvarchar](250) NULL,
	[TH_LINK_TAILIEU] [nvarchar](250) NULL,
	[TH_LINK_BAOCAO_SAU_TAPHUAN] [nvarchar](250) NULL,
	[TH_DOITUONG_HV_ID] [nvarchar](250) NULL,
	[TH_DOITUONG_HV_TEN] [nvarchar](max) NULL,
	[TH_DOITUONG_LINK_EXCEL] [nvarchar](250) NULL,
	[TH_DOITUONG_LINK_SCAN] [nvarchar](250) NULL,
	[TH_DOITUONG_TONGSO] [int] NULL,
	[TH_DOITUONG_SL_NAM] [int] NULL,
	[TH_DOITUONG_SL_NU] [int] NULL,
	[TH_TIEN_DILAI] [int] NULL,
	[TH_TIEN_ANTRUA] [int] NULL,
	[TH_TIEN_ANNHE] [int] NULL,
	[TH_KT_SL_VANDONG] [int] NULL,
	[TH_KT_SL_NHIN] [int] NULL,
	[TH_KT_SL_NGHENOI] [int] NULL,
	[TH_KT_SL_TRITUE] [int] NULL,
	[TH_KT_SL_KHAC] [int] NULL,
	[TH_DIADIEM_LINK_HOPDONG] [nvarchar](250) NULL,
	[TH_DIADIEM_LINK_BB_THANHLY] [nvarchar](250) NULL,
	[TH_TONGTIEN_DUYET] [int] NULL,
	[TH_TONGTIEN_THUCHIEN] [int] NULL,
	[TH_TONGTIEN_BAN_KEHOACH] [int] NULL,
	[TH_LINK_DUYETCHI] [nvarchar](250) NULL,
	[TH_LINK_KEHOACH_HOATDONG] [nvarchar](250) NULL,
	[TH_LINK_CHUNGTU] [nvarchar](250) NULL,
	[TH_CONGVAN_SO] [nvarchar](50) NULL,
	[TH_CONGVAN_DONVI_GUI] [nvarchar](50) NULL,
	[TH_CONGVAN_GUI_DONVI] [nvarchar](50) NULL,
	[TH_CONGVAN_LINK] [nvarchar](250) NULL,
	[TH_DONVI_THUCHIEN] [nvarchar](250) NULL,
	[TH_NOIDUNG] [nvarchar](max) NULL,
	[TH_SOLUONG] [int] NULL,
	[TH_SOTIEN_1NGUOI] [int] NULL,
	[TH_TONGTIEN] [bigint] NULL,
	[TH_GIANGVIEN] [nvarchar](250) NULL,
	[TH_GIANGVIEN_THULAO] [int] NULL,
	[TH_NGUOI_HOTRO] [nvarchar](250) NULL,
	[TH_NGUOI_HOTRO_THULAO] [int] NULL,
 CONSTRAINT [PK_QL_HOATDONG_TAPHUAN] PRIMARY KEY CLUSTERED 
(
	[TH_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[QL_HOATDONG_TAPHUAN]  WITH CHECK ADD  CONSTRAINT [FK_QL_HOATDONG_TAPHUAN_DM_NHA_TAI_TRO] FOREIGN KEY([NTT_ID])
REFERENCES [dbo].[DM_NHA_TAI_TRO] ([NTT_ID])
GO

ALTER TABLE [dbo].[QL_HOATDONG_TAPHUAN] CHECK CONSTRAINT [FK_QL_HOATDONG_TAPHUAN_DM_NHA_TAI_TRO]
GO


