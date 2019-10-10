USE [Phone]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/15/2019 11:40:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id_Category] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](500) NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id_Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 6/15/2019 11:40:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[id_News] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](500) NULL,
	[description] [ntext] NULL,
	[content] [ntext] NULL,
	[img] [nvarchar](500) NULL,
	[hotnews] [bit] NULL,
 CONSTRAINT [PK_tbl_news] PRIMARY KEY CLUSTERED 
(
	[id_News] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/15/2019 11:40:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id_Product] [int] IDENTITY(1,1) NOT NULL,
	[id_Category] [int] NULL,
	[name] [nvarchar](500) NULL,
	[description] [nvarchar](500) NULL,
	[content] [nvarchar](500) NULL,
	[img] [nvarchar](500) NULL,
	[hotproduct] [bit] NULL,
	[price] [int] NULL,
 CONSTRAINT [PK_tbl_product] PRIMARY KEY CLUSTERED 
(
	[id_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/15/2019 11:40:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](500) NULL,
	[password] [nvarchar](500) NULL,
	[fullname] [nvarchar](500) NULL,
	[phone] [nvarchar](500) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id_Category], [name]) VALUES (1, N'Tablet')
INSERT [dbo].[Category] ([id_Category], [name]) VALUES (7, N'SmartPhone')
INSERT [dbo].[Category] ([id_Category], [name]) VALUES (8, N'Camera')
INSERT [dbo].[Category] ([id_Category], [name]) VALUES (9, N'Computer')
INSERT [dbo].[Category] ([id_Category], [name]) VALUES (11, N'Electronic')
INSERT [dbo].[Category] ([id_Category], [name]) VALUES (12, N'Destop')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([id_News], [name], [description], [content], [img], [hotnews]) VALUES (1005, N' Tất tần tật những điều cần biết về cúp bóng đá Nam Mỹ (Copa America) sẽ bắt đầu vào sáng mai, giải đấu này từng khiến Messi hai lần phải khóc hận', N'<p>Tất tần tật những điều cần biết về c&uacute;p b&oacute;ng đ&aacute; Nam Mỹ (Copa America) sẽ bắt đầu v&agrave;o s&aacute;ng mai, giải đấu n&agrave;y từng khiến Messi hai lần phải kh&oacute;c hận</p>
', N'Tất tần tật những điều cần biết về cúp bóng đá Nam Mỹ (Copa America) sẽ bắt đầu vào sáng mai, giải đấu này từng khiến Messi hai lần phải khóc hận					    ', N'132050810382513783_5ea827ea78c29d4ba642975e0dbbab144d3de939-300x200.jpg', 1)
INSERT [dbo].[News] ([id_News], [name], [description], [content], [img], [hotnews]) VALUES (1006, N' Ngắm gu thời trang đơn giản, nữ tính của Nabi Nhã Phương  ', N'<p>Ch&uacute;ng ta vẫn biết rằng, l&agrave;m việc với một đoạn văn bản dễ đọc v&agrave; r&otilde; nghĩa dễ g&acirc;y rối tr&iacute; v&agrave; cản trở việc tập trung v&agrave;o yếu tố tr&igrave;nh b&agrave;y văn bản.&nbsp;</p>
', N'<p>Ch&uacute;ng ta vẫn biết rằng, l&agrave;m việc với một đoạn văn bản dễ đọc v&agrave; r&otilde; nghĩa dễ g&acirc;y rối tr&iacute; v&agrave; cản trở việc tập trung v&agrave;o yếu tố tr&igrave;nh b&agrave;y văn bản.</p>
', N'132050860228257993thang20160215-032929-9_600x600-150x150.jpg', 1)
INSERT [dbo].[News] ([id_News], [name], [description], [content], [img], [hotnews]) VALUES (1009, N'Ngắm gu thời trang đơn giản, nữ tính của Nabi Nhã Phương 1213131  ', N'<p>Ch&uacute;ng ta vẫn biết rằng, l&agrave;m việc với một đoạn văn bản dễ đọc v&agrave; r&otilde; nghĩa dễ g&acirc;y rối tr&iacute; v&agrave; cản trở việc tập trung v&agrave;o yếu tố tr&igrave;nh b&agrave;y văn bản.&nbsp;</p>
', N'<p>Ch&uacute;ng ta vẫn biết rằng, l&agrave;m việc với một đoạn văn bản dễ đọc v&agrave; r&otilde; nghĩa dễ g&acirc;y rối tr&iacute; v&agrave; cản trở việc tập trung v&agrave;o yếu tố tr&igrave;nh b&agrave;y văn bản.&nbsp;</p>
', N'132050855134713596thang1a.jpg', 1)
SET IDENTITY_INSERT [dbo].[News] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id_Product], [id_Category], [name], [description], [content], [img], [hotproduct], [price]) VALUES (19, 8, N'vivo', N'<p>123</p>
', N'<p>123</p>
', N'1.jpg', 1, 123)
INSERT [dbo].[Product] ([id_Product], [id_Category], [name], [description], [content], [img], [hotproduct], [price]) VALUES (20, 7, N'Iphone', N'<p>123</p>
', N'<p>123</p>
', N'3.jpg', 1, 123)
INSERT [dbo].[Product] ([id_Product], [id_Category], [name], [description], [content], [img], [hotproduct], [price]) VALUES (21, 1, N'Guitar', N'<p>123</p>
', N'<p>223232</p>
', N'11.jpg', 0, 12313)
INSERT [dbo].[Product] ([id_Product], [id_Category], [name], [description], [content], [img], [hotproduct], [price]) VALUES (22, 11, N'Headphone', N'<p>2323</p>
', N'<p>23</p>
', N'6.jpg', 1, 123)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [email], [password], [fullname], [phone]) VALUES (21, N'tham@gmail.com', N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', N'tham', N'123')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_tbl_news_hotnews]  DEFAULT ((0)) FOR [hotnews]
GO
