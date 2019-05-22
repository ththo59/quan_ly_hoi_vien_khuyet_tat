
CREATE TABLE [dbo].[DM_NHA_TAI_TRO](
	[NTT_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[NTT_TEN] [nvarchar](250) NULL,
	[NTT_DIACHI] [nvarchar](250) NULL,
	[NTT_CANHAN_TOCHUC] [nvarchar](50) NULL,
	[NTT_LOAI] [nvarchar](50) NULL,
 CONSTRAINT [PK_DM_NHA_TAI_TRO] PRIMARY KEY CLUSTERED 
(
	[NTT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


