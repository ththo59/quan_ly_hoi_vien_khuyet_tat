

CREATE TABLE [dbo].[QL_HOATDONG_TAPHUAN_CHITIET](
	[TH_CT_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TH_ID] [bigint] NULL,
	[TH_CT_LOAI] [int] NULL,
	[TH_CT_HOTEN] [nvarchar](50) NULL,
	[TH_CT_CHUCVU] [nvarchar](50) NULL,
	[TH_CT_EMAIL] [nvarchar](50) NULL,
	[TH_CT_FACEBOOK] [nvarchar](250) NULL,
	[TH_CT_CMND_SO] [nvarchar](50) NULL,
	[TH_CT_CMND_NGAYCAP] [datetime] NULL,
	[TH_CT_CMND_NOICAP] [nvarchar](50) NULL,
	[TH_CT_DIACHI] [nvarchar](250) NULL,
	[TH_CT_DONVI_TEN] [nvarchar](250) NULL,
	[TH_CT_DONVI_DIACHI] [nvarchar](250) NULL,
	[TH_CT_DONVI_SDT] [nvarchar](50) NULL,
	[TH_CT_SDT] [nvarchar](50) NULL,
	[TH_CT_MASOTHUE] [nvarchar](50) NULL,
	[TH_CT_TK_SO] [nvarchar](50) NULL,
	[TH_CT_TK_NGANHANG] [nvarchar](50) NULL,
	[TH_CT_TK_DIACHI] [nvarchar](50) NULL,
	[TH_CT_LINK_TOR] [nvarchar](250) NULL,
	[TH_CT_LINK_CV] [nvarchar](250) NULL,
	[TH_CT_LINK_HOPDONG] [nvarchar](250) NULL,
	[TH_CT_LINK_BANCAMKET] [nvarchar](250) NULL,
	[TH_CT_THULAO] [int] NULL,
	[TH_CT_CHIPHIKHAC] [int] NULL,
	[TH_CT_DIENGIAI] [nvarchar](250) NULL,
 CONSTRAINT [PK_QL_HOATDONG_TAPHUAN_CHITIET] PRIMARY KEY CLUSTERED 
(
	[TH_CT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[QL_HOATDONG_TAPHUAN_CHITIET]  WITH CHECK ADD  CONSTRAINT [FK_QL_HOATDONG_TAPHUAN_CHITIET_QL_HOATDONG_TAPHUAN] FOREIGN KEY([TH_ID])
REFERENCES [dbo].[QL_HOATDONG_TAPHUAN] ([TH_ID])
GO

ALTER TABLE [dbo].[QL_HOATDONG_TAPHUAN_CHITIET] CHECK CONSTRAINT [FK_QL_HOATDONG_TAPHUAN_CHITIET_QL_HOATDONG_TAPHUAN]
GO


