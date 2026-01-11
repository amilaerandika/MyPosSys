
CREATE TABLE [dbo].[Bill](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[BillNo] [nvarchar](50) NOT NULL,
	[BillDate] [datetime2](7) NOT NULL,
	[Cashier] [nvarchar](100) NULL,
	[CustomerName] [nvarchar](150) NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[Tax] [decimal](18, 2) NOT NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[PaymentMethod] [nvarchar](20) NOT NULL,
	[PaidAmount] [decimal](18, 2) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillItem]    Script Date: 1/11/2026 1:33:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillItem](
	[BillItemId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductCode] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Total]  AS ([Price]*[Quantity]),
PRIMARY KEY CLUSTERED 
(
	[BillItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PosProduct]    Script Date: 1/11/2026 1:33:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosProduct](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [nvarchar](50) NOT NULL,
	[ProductName] [nvarchar](150) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[CostPrice] [decimal](18, 2) NULL,
	[StockQty] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ProductOrder] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PosUser]    Script Date: 1/11/2026 1:33:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosUser](
	[PosUserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Email] [nvarchar](150) NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PosUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PosProduct] ON 
GO
INSERT [dbo].[PosProduct] ([ProductID], [ProductCode], [ProductName], [UnitPrice], [CostPrice], [StockQty], [IsActive], [CreatedDate], [ProductOrder]) VALUES (11, N'D002', N'Wood Apple Drink', CAST(150.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 150, 1, CAST(N'2026-01-11T11:44:47.183' AS DateTime), 0)
GO
INSERT [dbo].[PosProduct] ([ProductID], [ProductCode], [ProductName], [UnitPrice], [CostPrice], [StockQty], [IsActive], [CreatedDate], [ProductOrder]) VALUES (13, N'C001', N'Highland 200ml', CAST(150.00 AS Decimal(18, 2)), CAST(120.00 AS Decimal(18, 2)), 250, 1, CAST(N'2026-01-11T12:40:49.607' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[PosProduct] OFF
GO
SET IDENTITY_INSERT [dbo].[PosUser] ON 
GO
INSERT [dbo].[PosUser] ([PosUserID], [UserName], [PasswordHash], [IsActive], [Email], [CreatedDate]) VALUES (1, N'amila', N'WZRHGrsBESr8wYFZ9sx0tPURuZgG2lmzyvWpwXPKz8U=', 1, N'amilaerandikasampath@gmail.com', CAST(N'2026-01-10T12:47:59.317' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[PosUser] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Bill__11F284189CC51190]    Script Date: 1/11/2026 1:33:35 PM ******/
ALTER TABLE [dbo].[Bill] ADD UNIQUE NONCLUSTERED 
(
	[BillNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [BillDate]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [SubTotal]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [Tax]
GO
ALTER TABLE [dbo].[PosProduct] ADD  DEFAULT ((0)) FOR [StockQty]
GO
ALTER TABLE [dbo].[PosProduct] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PosProduct] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[PosUser] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PosUser] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
