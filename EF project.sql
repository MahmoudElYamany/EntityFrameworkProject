USE [master]
GO
/****** Object:  Database [Company_Project]    Script Date: 05/03/2021 23:23:15 ******/
CREATE DATABASE [Company_Project]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Company_Projecet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Company_Projecet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Company_Projecet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Company_Projecet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Company_Project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Company_Project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Company_Project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Company_Project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Company_Project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Company_Project] SET ARITHABORT OFF 
GO
ALTER DATABASE [Company_Project] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Company_Project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Company_Project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Company_Project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Company_Project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Company_Project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Company_Project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Company_Project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Company_Project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Company_Project] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Company_Project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Company_Project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Company_Project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Company_Project] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Company_Project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Company_Project] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Company_Project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Company_Project] SET RECOVERY FULL 
GO
ALTER DATABASE [Company_Project] SET  MULTI_USER 
GO
ALTER DATABASE [Company_Project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Company_Project] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Company_Project] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Company_Project] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Company_Project] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Company_Project', N'ON'
GO
USE [Company_Project]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 05/03/2021 23:23:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Recipt_ID] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[storage_id] [int] NOT NULL,
	[date] [varchar](50) NOT NULL,
	[custumer_id] [varchar](50) NOT NULL,
	[amount] [int] NOT NULL,
	[selling_Price] [float] NULL,
	[Tax] [float] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Recipt_ID] ASC,
	[item_id] ASC,
	[storage_id] ASC,
	[date] ASC,
	[custumer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers_Suppliers]    Script Date: 05/03/2021 23:23:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers_Suppliers](
	[ID] [varchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[BirthDate] [varchar](50) NULL,
	[phone] [int] NULL,
	[mobile] [int] NULL,
	[fax] [int] NULL,
	[Mail] [varchar](50) NULL,
	[website] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[Comments] [varchar](100) NULL,
 CONSTRAINT [PK_Customers_Suppliers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Emloyees]    Script Date: 05/03/2021 23:23:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emloyees](
	[ID_Emp] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[Password] [int] NOT NULL,
	[phone] [int] NULL,
	[mobile] [int] NULL,
	[Mail] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[Storage_ID_emp] [int] NULL,
 CONSTRAINT [PK_Enployees] PRIMARY KEY CLUSTERED 
(
	[ID_Emp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[items]    Script Date: 05/03/2021 23:23:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[items](
	[ID_item] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[size] [varchar](50) NULL,
	[expireDate] [varchar](50) NULL,
	[ManifuctureDate] [varchar](50) NULL,
 CONSTRAINT [PK_items] PRIMARY KEY CLUSTERED 
(
	[ID_item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 05/03/2021 23:23:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[permission_ID] [int] NOT NULL,
	[typePermission] [varchar](50) NOT NULL,
	[item_id] [int] NOT NULL,
	[Date_permission] [varchar](50) NOT NULL,
	[stroage_id] [int] NOT NULL,
	[amount_item] [int] NULL,
	[name_id] [varchar](50) NOT NULL,
	[expireDate] [varchar](50) NULL,
	[Comment] [varchar](150) NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[permission_ID] ASC,
	[typePermission] ASC,
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Storage]    Script Date: 05/03/2021 23:23:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storage](
	[ID_storage] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[location] [varchar](50) NOT NULL,
	[Manger_ID] [varchar](50) NOT NULL,
	[Comment] [varchar](50) NULL,
	[Phone] [int] NULL,
 CONSTRAINT [PK_Storage] PRIMARY KEY CLUSTERED 
(
	[ID_storage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Storage_cust_sup]    Script Date: 05/03/2021 23:23:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storage_cust_sup](
	[Storage_id] [int] NOT NULL,
	[cust_sup_id] [varchar](50) NOT NULL,
	[date] [varchar](50) NULL,
 CONSTRAINT [PK_Storage_cust_sup] PRIMARY KEY CLUSTERED 
(
	[Storage_id] ASC,
	[cust_sup_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Storage_item]    Script Date: 05/03/2021 23:23:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storage_item](
	[Storage_ID] [int] NOT NULL,
	[Item_ID] [int] NOT NULL,
	[amount] [int] NULL,
 CONSTRAINT [PK_Storage_item] PRIMARY KEY CLUSTERED 
(
	[Storage_ID] ASC,
	[Item_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transport_items]    Script Date: 05/03/2021 23:23:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transport_items](
	[Transaction_ID] [int] NOT NULL,
	[supplier_Name] [varchar](50) NOT NULL,
	[Product_Name] [varchar](50) NOT NULL,
	[From_Storage] [varchar](50) NOT NULL,
	[To_Storage] [varchar](50) NOT NULL,
	[amount] [varchar](50) NOT NULL,
	[TransactionDate] [varchar](50) NULL,
 CONSTRAINT [PK_Transport_items_1] PRIMARY KEY CLUSTERED 
(
	[Transaction_ID] ASC,
	[supplier_Name] ASC,
	[Product_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Client] ([Recipt_ID], [item_id], [storage_id], [date], [custumer_id], [amount], [selling_Price], [Tax]) VALUES (796084292, 1894005018, 238800172, N'01/03/2021', N'Cus-1503390658', 50, 60, 0.14000000059604645)
INSERT [dbo].[Client] ([Recipt_ID], [item_id], [storage_id], [date], [custumer_id], [amount], [selling_Price], [Tax]) VALUES (1324740307, 1894005018, 382154151, N'02/03/2021', N'Cus-1503390658', 10, 50, 0.14000000059604645)
INSERT [dbo].[Client] ([Recipt_ID], [item_id], [storage_id], [date], [custumer_id], [amount], [selling_Price], [Tax]) VALUES (2082748111, 182903490, 238800172, N'03/03/2021', N'Cus-1503390658', 5, 50, 0.14000000059604645)
INSERT [dbo].[Client] ([Recipt_ID], [item_id], [storage_id], [date], [custumer_id], [amount], [selling_Price], [Tax]) VALUES (2082748111, 690196647, 238800172, N'03/03/2021', N'Cus-1503390658', 5, 50, 0.14000000059604645)
INSERT [dbo].[Client] ([Recipt_ID], [item_id], [storage_id], [date], [custumer_id], [amount], [selling_Price], [Tax]) VALUES (2082748111, 1894005018, 238800172, N'03/03/2021', N'Cus-1503390658', 5, 50, 0.14000000059604645)
GO
INSERT [dbo].[Customers_Suppliers] ([ID], [type], [name], [BirthDate], [phone], [mobile], [fax], [Mail], [website], [Location], [Comments]) VALUES (N'Cus-1503390658', N'Cus', N'MAhmoud', N'03/03/2021', 356789, 64789, 65578, N'mahmoud@example.com', N'', N'ejngoenew', N'regoihgo3o8rghtjyruktiylyu;uilkjhg')
INSERT [dbo].[Customers_Suppliers] ([ID], [type], [name], [BirthDate], [phone], [mobile], [fax], [Mail], [website], [Location], [Comments]) VALUES (N'Sup-90874745', N'Sup', N'Ahmed', N'28/03/2021', 21345, 3256235, 12345323, N'ahmed@example.com', N'', N'wefw', N'ddddd')
INSERT [dbo].[Customers_Suppliers] ([ID], [type], [name], [BirthDate], [phone], [mobile], [fax], [Mail], [website], [Location], [Comments]) VALUES (N'Sup-90874746', N'Sup', N'Mahmoud', N'28/05/2021', 123456789, 123456789, 123456789, N'mahmouf@exaple.cm', NULL, N'shdghnhhsgh', N'dfdffdfdfdfd')
GO
INSERT [dbo].[Emloyees] ([ID_Emp], [name], [Password], [phone], [mobile], [Mail], [Location], [Storage_ID_emp]) VALUES (N'100', N'Mahmoud Moataz', 123456, 123456789, 123456789, N'MAhmoud@example.com', N'123exmple', NULL)
INSERT [dbo].[Emloyees] ([ID_Emp], [name], [Password], [phone], [mobile], [Mail], [Location], [Storage_ID_emp]) VALUES (N'101', N'Moataz Mossad', 123456, 123456789, 123456789, N'Moataz@examole.com', N'123example', NULL)
INSERT [dbo].[Emloyees] ([ID_Emp], [name], [Password], [phone], [mobile], [Mail], [Location], [Storage_ID_emp]) VALUES (N'102', N'Adham Mohamed', 123456, 123456789, 123456789, N'adham@example.com', N'233example', NULL)
GO
INSERT [dbo].[items] ([ID_item], [name], [size], [expireDate], [ManifuctureDate]) VALUES (182903490, N'books', N'20*15', N'31/03/2021', N'04/03/2021')
INSERT [dbo].[items] ([ID_item], [name], [size], [expireDate], [ManifuctureDate]) VALUES (690196647, N'doors', N'1000*70', N'31/03/2021', N'04/03/2021')
INSERT [dbo].[items] ([ID_item], [name], [size], [expireDate], [ManifuctureDate]) VALUES (1894005018, N'comics', N'60*70', N'03/06/2025', N'04/03/2021')
GO
INSERT [dbo].[Permission] ([permission_ID], [typePermission], [item_id], [Date_permission], [stroage_id], [amount_item], [name_id], [expireDate], [Comment]) VALUES (1130711685, N'rec', 182903490, N'05/03/2021', 238800172, 10, N'Sup-90874746', N'05/03/2021', N'')
INSERT [dbo].[Permission] ([permission_ID], [typePermission], [item_id], [Date_permission], [stroage_id], [amount_item], [name_id], [expireDate], [Comment]) VALUES (1919344032, N'rec', 182903490, N'05/03/2021', 238800172, 10, N'Sup-90874746', N'05/03/2021', N'')
INSERT [dbo].[Permission] ([permission_ID], [typePermission], [item_id], [Date_permission], [stroage_id], [amount_item], [name_id], [expireDate], [Comment]) VALUES (1919344032, N'rec', 690196647, N'05/03/2021', 238800172, 10, N'Sup-90874746', N'05/03/2021', N'')
INSERT [dbo].[Permission] ([permission_ID], [typePermission], [item_id], [Date_permission], [stroage_id], [amount_item], [name_id], [expireDate], [Comment]) VALUES (1919344032, N'rec', 1894005018, N'05/03/2021', 238800172, 10, N'Sup-90874746', N'05/03/2021', N'')
GO
INSERT [dbo].[Storage] ([ID_storage], [name], [location], [Manger_ID], [Comment], [Phone]) VALUES (238800172, N'mainstore', N'sdfghjkh', N'100', N'dsfgdhfjkl', NULL)
INSERT [dbo].[Storage] ([ID_storage], [name], [location], [Manger_ID], [Comment], [Phone]) VALUES (382154151, N'Maadi', N'asdfsghdf', N'101', N'', NULL)
GO
INSERT [dbo].[Storage_item] ([Storage_ID], [Item_ID], [amount]) VALUES (238800172, 182903490, 45)
INSERT [dbo].[Storage_item] ([Storage_ID], [Item_ID], [amount]) VALUES (238800172, 690196647, 5)
INSERT [dbo].[Storage_item] ([Storage_ID], [Item_ID], [amount]) VALUES (238800172, 1894005018, 945)
INSERT [dbo].[Storage_item] ([Storage_ID], [Item_ID], [amount]) VALUES (382154151, 182903490, 1020)
INSERT [dbo].[Storage_item] ([Storage_ID], [Item_ID], [amount]) VALUES (382154151, 1894005018, 20)
GO
INSERT [dbo].[Transport_items] ([Transaction_ID], [supplier_Name], [Product_Name], [From_Storage], [To_Storage], [amount], [TransactionDate]) VALUES (204840758, N'Ahmed', N'books', N'mainstore', N'Maadi', N'10', N'05/03/2021')
INSERT [dbo].[Transport_items] ([Transaction_ID], [supplier_Name], [Product_Name], [From_Storage], [To_Storage], [amount], [TransactionDate]) VALUES (1938675111, N'Ahmed', N'books', N'mainstore', N'Maadi', N'10', N'05/03/2021')
INSERT [dbo].[Transport_items] ([Transaction_ID], [supplier_Name], [Product_Name], [From_Storage], [To_Storage], [amount], [TransactionDate]) VALUES (1938675111, N'Ahmed', N'comics', N'mainstore', N'Maadi', N'10', N'05/03/2021')
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Customers_Suppliers] FOREIGN KEY([custumer_id])
REFERENCES [dbo].[Customers_Suppliers] ([ID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Customers_Suppliers]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_items] FOREIGN KEY([item_id])
REFERENCES [dbo].[items] ([ID_item])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_items]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Storage] FOREIGN KEY([storage_id])
REFERENCES [dbo].[Storage] ([ID_storage])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Storage]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Customers_Suppliers] FOREIGN KEY([name_id])
REFERENCES [dbo].[Customers_Suppliers] ([ID])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Customers_Suppliers]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_items] FOREIGN KEY([item_id])
REFERENCES [dbo].[items] ([ID_item])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_items]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Storage] FOREIGN KEY([stroage_id])
REFERENCES [dbo].[Storage] ([ID_storage])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Storage]
GO
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [FK_Storage_Enployees] FOREIGN KEY([Manger_ID])
REFERENCES [dbo].[Emloyees] ([ID_Emp])
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [FK_Storage_Enployees]
GO
ALTER TABLE [dbo].[Storage_cust_sup]  WITH CHECK ADD  CONSTRAINT [FK_Storage_cust_sup_Customers_Suppliers] FOREIGN KEY([cust_sup_id])
REFERENCES [dbo].[Customers_Suppliers] ([ID])
GO
ALTER TABLE [dbo].[Storage_cust_sup] CHECK CONSTRAINT [FK_Storage_cust_sup_Customers_Suppliers]
GO
ALTER TABLE [dbo].[Storage_cust_sup]  WITH CHECK ADD  CONSTRAINT [FK_Storage_cust_sup_Storage] FOREIGN KEY([Storage_id])
REFERENCES [dbo].[Storage] ([ID_storage])
GO
ALTER TABLE [dbo].[Storage_cust_sup] CHECK CONSTRAINT [FK_Storage_cust_sup_Storage]
GO
ALTER TABLE [dbo].[Storage_item]  WITH CHECK ADD  CONSTRAINT [FK_Storage_item_items] FOREIGN KEY([Item_ID])
REFERENCES [dbo].[items] ([ID_item])
GO
ALTER TABLE [dbo].[Storage_item] CHECK CONSTRAINT [FK_Storage_item_items]
GO
ALTER TABLE [dbo].[Storage_item]  WITH CHECK ADD  CONSTRAINT [FK_Storage_item_Storage] FOREIGN KEY([Storage_ID])
REFERENCES [dbo].[Storage] ([ID_storage])
GO
ALTER TABLE [dbo].[Storage_item] CHECK CONSTRAINT [FK_Storage_item_Storage]
GO
USE [master]
GO
ALTER DATABASE [Company_Project] SET  READ_WRITE 
GO
