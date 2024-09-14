USE [master]
GO
/****** Object:  Database [MercanciasJyCData]    Script Date: 13/09/2024 09:09:35 pm ******/
CREATE DATABASE [MercanciasJyCData]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MercanciasJyCData', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MercanciasJyCData.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MercanciasJyCData_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MercanciasJyCData_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MercanciasJyCData] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MercanciasJyCData].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MercanciasJyCData] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET ARITHABORT OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MercanciasJyCData] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MercanciasJyCData] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MercanciasJyCData] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MercanciasJyCData] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MercanciasJyCData] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET RECOVERY FULL 
GO
ALTER DATABASE [MercanciasJyCData] SET  MULTI_USER 
GO
ALTER DATABASE [MercanciasJyCData] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MercanciasJyCData] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MercanciasJyCData] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MercanciasJyCData] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MercanciasJyCData] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MercanciasJyCData] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MercanciasJyCData', N'ON'
GO
ALTER DATABASE [MercanciasJyCData] SET QUERY_STORE = OFF
GO
USE [MercanciasJyCData]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13/09/2024 09:09:35 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 13/09/2024 09:09:35 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Direccion] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entregas]    Script Date: 13/09/2024 09:09:35 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entregas](
	[EntregaId] [int] IDENTITY(1,1) NOT NULL,
	[PedidoId] [int] NOT NULL,
	[FechaEntrega] [datetime2](7) NOT NULL,
	[Estado] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Entregas] PRIMARY KEY CLUSTERED 
(
	[EntregaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoProductos]    Script Date: 13/09/2024 09:09:35 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoProductos](
	[PedidoId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_PedidoProductos] PRIMARY KEY CLUSTERED 
(
	[PedidoId] ASC,
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 13/09/2024 09:09:35 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[PedidoId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[FechaPedido] [datetime] NOT NULL,
	[FechaEntrega] [datetime] NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 13/09/2024 09:09:35 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[ProductoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240913024634_InicialMercanciasJYC', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240913025049_AjusteDecimalTotal', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240913030602_AddFechaPedidoAndFechaEntrega', N'8.0.8')
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Direccion]) VALUES (1, N'Juan Pérez', N'Calle 123, Bogotá')
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Direccion]) VALUES (2, N'Ana Gómez', N'Carrera 45, Medellín')
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Direccion]) VALUES (3, N'Carlos Ruiz', N'Avenida Central, Cali')
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Direccion]) VALUES (4, N'Hilder', N'lasdoiasuod ')
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Direccion]) VALUES (5, N'Valentina Jimenez', N'Trasversal 38 aa')
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Direccion]) VALUES (6, N'Hola', N'Hola')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Entregas] ON 

INSERT [dbo].[Entregas] ([EntregaId], [PedidoId], [FechaEntrega], [Estado]) VALUES (4, 3, CAST(N'2024-09-12T00:00:00.0000000' AS DateTime2), N'Pendiente')
INSERT [dbo].[Entregas] ([EntregaId], [PedidoId], [FechaEntrega], [Estado]) VALUES (5, 11, CAST(N'2024-09-16T18:36:00.0000000' AS DateTime2), N'Pendiente')
INSERT [dbo].[Entregas] ([EntregaId], [PedidoId], [FechaEntrega], [Estado]) VALUES (6, 12, CAST(N'2024-09-16T21:25:19.0000000' AS DateTime2), N'Pendiente')
SET IDENTITY_INSERT [dbo].[Entregas] OFF
GO
INSERT [dbo].[PedidoProductos] ([PedidoId], [ProductoId], [Cantidad]) VALUES (4, 3, 3)
INSERT [dbo].[PedidoProductos] ([PedidoId], [ProductoId], [Cantidad]) VALUES (10, 1, 10)
INSERT [dbo].[PedidoProductos] ([PedidoId], [ProductoId], [Cantidad]) VALUES (11, 1, 10)
INSERT [dbo].[PedidoProductos] ([PedidoId], [ProductoId], [Cantidad]) VALUES (12, 3, 7)
GO
SET IDENTITY_INSERT [dbo].[Pedidos] ON 

INSERT [dbo].[Pedidos] ([PedidoId], [ClienteId], [FechaPedido], [FechaEntrega], [Total]) VALUES (3, 2, CAST(N'2024-09-11T00:00:00.000' AS DateTime), CAST(N'2024-09-17T00:00:00.000' AS DateTime), CAST(800000.75 AS Decimal(18, 2)))
INSERT [dbo].[Pedidos] ([PedidoId], [ClienteId], [FechaPedido], [FechaEntrega], [Total]) VALUES (4, 3, CAST(N'2024-09-12T00:00:00.000' AS DateTime), CAST(N'2024-09-18T00:00:00.000' AS DateTime), CAST(350000.99 AS Decimal(18, 2)))
INSERT [dbo].[Pedidos] ([PedidoId], [ClienteId], [FechaPedido], [FechaEntrega], [Total]) VALUES (7, 1, CAST(N'2024-01-09T00:00:00.000' AS DateTime), CAST(N'2024-10-09T00:00:00.000' AS DateTime), CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[Pedidos] ([PedidoId], [ClienteId], [FechaPedido], [FechaEntrega], [Total]) VALUES (8, 2, CAST(N'2024-09-14T13:00:00.000' AS DateTime), CAST(N'2024-09-16T00:00:00.000' AS DateTime), CAST(250.00 AS Decimal(18, 2)))
INSERT [dbo].[Pedidos] ([PedidoId], [ClienteId], [FechaPedido], [FechaEntrega], [Total]) VALUES (9, 4, CAST(N'2024-09-14T10:23:48.000' AS DateTime), CAST(N'2024-09-16T18:23:48.000' AS DateTime), CAST(16000.00 AS Decimal(18, 2)))
INSERT [dbo].[Pedidos] ([PedidoId], [ClienteId], [FechaPedido], [FechaEntrega], [Total]) VALUES (10, 4, CAST(N'2024-09-14T10:36:00.000' AS DateTime), CAST(N'2024-09-16T18:36:00.000' AS DateTime), CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[Pedidos] ([PedidoId], [ClienteId], [FechaPedido], [FechaEntrega], [Total]) VALUES (11, 4, CAST(N'2024-09-14T10:36:00.000' AS DateTime), CAST(N'2024-09-16T18:36:00.000' AS DateTime), CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[Pedidos] ([PedidoId], [ClienteId], [FechaPedido], [FechaEntrega], [Total]) VALUES (12, 1, CAST(N'2024-09-13T11:30:28.000' AS DateTime), CAST(N'2024-09-16T21:25:19.000' AS DateTime), CAST(16000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Pedidos] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([ProductoId], [Nombre], [Descripcion]) VALUES (1, N'Laptop HP', N'Laptop de 14 pulgadas con procesador Intel i5')
INSERT [dbo].[Productos] ([ProductoId], [Nombre], [Descripcion]) VALUES (2, N'Teléfono Samsung', N'Teléfono móvil Samsung Galaxy S21')
INSERT [dbo].[Productos] ([ProductoId], [Nombre], [Descripcion]) VALUES (3, N'Teclado Mecánico', N'Teclado mecánico RGB con switches rojos')
INSERT [dbo].[Productos] ([ProductoId], [Nombre], [Descripcion]) VALUES (4, N'Manos semi', N'esmalte semipermanente')
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
/****** Object:  Index [IX_Entregas_PedidoId]    Script Date: 13/09/2024 09:09:35 pm ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Entregas_PedidoId] ON [dbo].[Entregas]
(
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PedidoProductos_ProductoId]    Script Date: 13/09/2024 09:09:35 pm ******/
CREATE NONCLUSTERED INDEX [IX_PedidoProductos_ProductoId] ON [dbo].[PedidoProductos]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pedidos_ClienteId]    Script Date: 13/09/2024 09:09:35 pm ******/
CREATE NONCLUSTERED INDEX [IX_Pedidos_ClienteId] ON [dbo].[Pedidos]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Entregas]  WITH CHECK ADD  CONSTRAINT [FK_Entregas_Pedidos_PedidoId] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedidos] ([PedidoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Entregas] CHECK CONSTRAINT [FK_Entregas_Pedidos_PedidoId]
GO
ALTER TABLE [dbo].[PedidoProductos]  WITH CHECK ADD  CONSTRAINT [FK_PedidoProductos_Pedidos_PedidoId] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedidos] ([PedidoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PedidoProductos] CHECK CONSTRAINT [FK_PedidoProductos_Pedidos_PedidoId]
GO
ALTER TABLE [dbo].[PedidoProductos]  WITH CHECK ADD  CONSTRAINT [FK_PedidoProductos_Productos_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([ProductoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PedidoProductos] CHECK CONSTRAINT [FK_PedidoProductos_Productos_ProductoId]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([ClienteId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Clientes_ClienteId]
GO
/****** Object:  StoredProcedure [dbo].[VerificarCreacionPedido]    Script Date: 13/09/2024 09:09:35 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VerificarCreacionPedido]
    @FechaPedido DATETIME,
    @EntregaDeseada DATETIME
AS
BEGIN
     DECLARE @DiaSemana INT = DATEPART(WEEKDAY, @FechaPedido);
     DECLARE @DiaSemanaEntregar INT = DATEPART(WEEKDAY, @EntregaDeseada);
    DECLARE @HoraPedido TIME = CAST(@FechaPedido AS TIME);
    DECLARE @FechaLimite DATETIME;
	DECLARE @MensajeError NVARCHAR(255);
	DECLARE @Cumple VARCHAR(100);

    -- Ajusta y establece el primer día de la semana
    SET DATEFIRST 1;

    -- Determina el rango de fechas validas para los pedidos
    IF @DiaSemanaEntregar = 5 -- Viernes
    BEGIN
        IF  (@DiaSemana = 2 AND @HoraPedido >= '12:00') OR (@DiaSemana = 3 AND @HoraPedido <= '12:00') 
            SET @Cumple = 'SI'
        ELSE
            SET @Cumple = 'NO'

    END
    ELSE IF @DiaSemanaEntregar = 6 -- Sábado
    BEGIN
        IF  (@DiaSemana = 3 AND @HoraPedido >= '12:00') OR (@DiaSemana = 4 AND @HoraPedido <= '12:00') 
            SET @Cumple = 'SI'
        ELSE
            SET @Cumple = 'NO'
    END
    ELSE IF @DiaSemana = 7 -- Domingo
    BEGIN
            SET @Cumple = 'DOMINGO'
    END
    ELSE IF @DiaSemanaEntregar = 1 -- Lunes
    BEGIN
        IF (@DiaSemana = 5 AND @HoraPedido <= '12:00') OR (@DiaSemana = 6 AND @HoraPedido <= '12:00') 
            --SET @FechaLimite = DATEADD(DAY, 5, @fechaPedido); -- Condicion para Entrega el jueves
			SET @Cumple = 'SI'
        ELSE
            SET @Cumple = 'NO'
    END
    ELSE IF @DiaSemanaEntregar = 2 -- Martes
    BEGIN
        IF (@DiaSemana = 6 AND @HoraPedido >= '12:00') OR (@DiaSemana = 7 AND @HoraPedido <= '12:00') 
            SET @Cumple = 'SI'
        ELSE
            SET @Cumple = 'NO'
    END
    ELSE IF @DiaSemanaEntregar = 3 -- Miércoles
    BEGIN
        IF  (@DiaSemana = 7 AND @HoraPedido >= '12:00') OR (@DiaSemana = 1 AND @HoraPedido <= '12:00') 
            SET @Cumple = 'SI'
        ELSE
            SET @Cumple = 'NO'
    END
	ELSE IF @DiaSemanaEntregar = 4 -- Jueves
    BEGIN
        IF  (@DiaSemana = 1 AND @HoraPedido >= '12:00') OR (@DiaSemana = 2 AND @HoraPedido <= '12:00') 
            SET @Cumple = 'SI'
        ELSE
            SET @Cumple = 'NO'
    END

   SELECT @Cumple
END
GO
USE [master]
GO
ALTER DATABASE [MercanciasJyCData] SET  READ_WRITE 
GO
