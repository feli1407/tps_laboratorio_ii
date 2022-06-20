USE [master]
GO
/****** Object:  Database [TPFinalCascoFelipe]    Script Date: 20/6/2022 00:50:59 ******/
CREATE DATABASE [TPFinalCascoFelipe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TPFinalCascoFelipe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TPFinalCascoFelipe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TPFinalCascoFelipe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TPFinalCascoFelipe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TPFinalCascoFelipe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TPFinalCascoFelipe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TPFinalCascoFelipe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET ARITHABORT OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET RECOVERY FULL 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET  MULTI_USER 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TPFinalCascoFelipe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TPFinalCascoFelipe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TPFinalCascoFelipe', N'ON'
GO
ALTER DATABASE [TPFinalCascoFelipe] SET QUERY_STORE = OFF
GO
USE [TPFinalCascoFelipe]
GO
/****** Object:  Table [dbo].[ClientesTPFinal]    Script Date: 20/6/2022 00:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientesTPFinal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JuegosNintendo]    Script Date: 20/6/2022 00:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JuegosNintendo](
	[Nombre] [varchar](50) NOT NULL,
	[PrecioCompra] [int] NOT NULL,
	[PrecioVenta] [int] NOT NULL,
	[Genero] [varchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[ExclusivoNintendo] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JuegosPlay]    Script Date: 20/6/2022 00:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JuegosPlay](
	[Nombre] [varchar](50) NOT NULL,
	[PrecioCompra] [int] NOT NULL,
	[PrecioVenta] [int] NOT NULL,
	[Genero] [varchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[ExclusivoPlay] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JuegosXbox]    Script Date: 20/6/2022 00:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JuegosXbox](
	[Nombre] [varchar](50) NOT NULL,
	[PrecioCompra] [int] NOT NULL,
	[PrecioVenta] [int] NOT NULL,
	[Genero] [varchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[ExclusivoXbox] [bit] NOT NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [TPFinalCascoFelipe] SET  READ_WRITE 
GO
use TPFinalCascoFelipe
insert into ClientesTPFinal (Nombre, Apellido) values ('Anatole', 'Smethurst');
insert into ClientesTPFinal (Nombre, Apellido) values ('Nisse', 'Butters');
insert into ClientesTPFinal (Nombre, Apellido) values ('Sergent', 'Simionato');
insert into ClientesTPFinal (Nombre, Apellido) values ('Davey', 'Condliffe');
insert into ClientesTPFinal (Nombre, Apellido) values ('Kelwin', 'Kenner');
insert into ClientesTPFinal (Nombre, Apellido) values ('Lucas', 'Posthill');
insert into ClientesTPFinal (Nombre, Apellido) values ('Reider', 'Oswick');
insert into ClientesTPFinal (Nombre, Apellido) values ('Tracie', 'Sweeting');
insert into ClientesTPFinal (Nombre, Apellido) values ('Ximenes', 'Bracknall');
insert into ClientesTPFinal (Nombre, Apellido) values ('Ora', 'Beverage');
insert into ClientesTPFinal (Nombre, Apellido) values ('Gasper', 'Diggins');
insert into ClientesTPFinal (Nombre, Apellido) values ('Joshua', 'Rhubottom');
insert into ClientesTPFinal (Nombre, Apellido) values ('Gretta', 'Parzizek');
insert into ClientesTPFinal (Nombre, Apellido) values ('Papagena', 'Chesser');
insert into ClientesTPFinal (Nombre, Apellido) values ('Milzie', 'Knevett');
insert into ClientesTPFinal (Nombre, Apellido) values ('Lionel', 'Benck');
insert into ClientesTPFinal (Nombre, Apellido) values ('Laughton', 'O''Doohaine');
insert into ClientesTPFinal (Nombre, Apellido) values ('Goldina', 'Haselhurst');
insert into ClientesTPFinal (Nombre, Apellido) values ('Sargent', 'Sweatland');
insert into ClientesTPFinal (Nombre, Apellido) values ('Finn', 'Raraty');
insert into ClientesTPFinal (Nombre, Apellido) values ('Tremayne', 'Gahan');
insert into ClientesTPFinal (Nombre, Apellido) values ('Isahella', 'Tschersich');
insert into ClientesTPFinal (Nombre, Apellido) values ('Kip', 'Ziems');
insert into ClientesTPFinal (Nombre, Apellido) values ('Alexina', 'Buntin');
insert into ClientesTPFinal (Nombre, Apellido) values ('Ban', 'Mold');
insert into ClientesTPFinal (Nombre, Apellido) values ('Archibald', 'Kelleher');
insert into ClientesTPFinal (Nombre, Apellido) values ('Toddy', 'Piser');
insert into ClientesTPFinal (Nombre, Apellido) values ('Morley', 'Bickerdicke');
insert into ClientesTPFinal (Nombre, Apellido) values ('Kelby', 'Scough');
insert into ClientesTPFinal (Nombre, Apellido) values ('Conny', 'Twitchings');
insert into ClientesTPFinal (Nombre, Apellido) values ('Aksel', 'Poulsum');
insert into ClientesTPFinal (Nombre, Apellido) values ('Tull', 'Copplestone');
insert into ClientesTPFinal (Nombre, Apellido) values ('Mark', 'Cansdell');
insert into ClientesTPFinal (Nombre, Apellido) values ('Lynnell', 'Gong');
insert into ClientesTPFinal (Nombre, Apellido) values ('Bella', 'Taks');
insert into ClientesTPFinal (Nombre, Apellido) values ('Joana', 'Brimson');
insert into ClientesTPFinal (Nombre, Apellido) values ('Paola', 'Robker');
insert into ClientesTPFinal (Nombre, Apellido) values ('Shelbi', 'Wawer');
insert into ClientesTPFinal (Nombre, Apellido) values ('Tobin', 'Vye');
insert into ClientesTPFinal (Nombre, Apellido) values ('Antoinette', 'Smithson');
insert into ClientesTPFinal (Nombre, Apellido) values ('Lorenza', 'Slamaker');
insert into ClientesTPFinal (Nombre, Apellido) values ('Aubrette', 'Chipperfield');
insert into ClientesTPFinal (Nombre, Apellido) values ('Blanch', 'Robert');
insert into ClientesTPFinal (Nombre, Apellido) values ('Isabel', 'Gainsburgh');
insert into ClientesTPFinal (Nombre, Apellido) values ('Dyanna', 'Guitonneau');
insert into ClientesTPFinal (Nombre, Apellido) values ('Almeta', 'Guerre');
insert into ClientesTPFinal (Nombre, Apellido) values ('Vivian', 'Kneeland');
insert into ClientesTPFinal (Nombre, Apellido) values ('Darrell', 'MacNish');
insert into ClientesTPFinal (Nombre, Apellido) values ('Alanson', 'D''Oyly');
insert into ClientesTPFinal (Nombre, Apellido) values ('Caressa', 'Yetts');
insert into ClientesTPFinal (Nombre, Apellido) values ('Donica', 'Tindley');
insert into ClientesTPFinal (Nombre, Apellido) values ('Brennan', 'Thicking');
insert into ClientesTPFinal (Nombre, Apellido) values ('Georgianna', 'Beurich');
insert into ClientesTPFinal (Nombre, Apellido) values ('Layla', 'Mingotti');
insert into ClientesTPFinal (Nombre, Apellido) values ('Kessiah', 'Hawton');
insert into ClientesTPFinal (Nombre, Apellido) values ('Chickie', 'Castellan');
insert into ClientesTPFinal (Nombre, Apellido) values ('Addy', 'Rowesby');
insert into ClientesTPFinal (Nombre, Apellido) values ('Reilly', 'Knaggs');
insert into ClientesTPFinal (Nombre, Apellido) values ('Francisco', 'Lukash');
insert into ClientesTPFinal (Nombre, Apellido) values ('Zita', 'Gronav');
insert into ClientesTPFinal (Nombre, Apellido) values ('Teirtza', 'Drysdell');
insert into ClientesTPFinal (Nombre, Apellido) values ('Adelheid', 'Woodvine');
insert into ClientesTPFinal (Nombre, Apellido) values ('Horatius', 'Libby');
insert into ClientesTPFinal (Nombre, Apellido) values ('Spencer', 'Becke');
insert into ClientesTPFinal (Nombre, Apellido) values ('Heather', 'Lenard');
insert into ClientesTPFinal (Nombre, Apellido) values ('Charmain', 'Tenniswood');
insert into ClientesTPFinal (Nombre, Apellido) values ('Leonid', 'Enrique');
insert into ClientesTPFinal (Nombre, Apellido) values ('Lily', 'Lazenby');
insert into ClientesTPFinal (Nombre, Apellido) values ('Preston', 'Morde');
insert into ClientesTPFinal (Nombre, Apellido) values ('Hubie', 'McGrane');
insert into ClientesTPFinal (Nombre, Apellido) values ('Elita', 'Eddison');
insert into ClientesTPFinal (Nombre, Apellido) values ('Samuele', 'Winslett');
insert into ClientesTPFinal (Nombre, Apellido) values ('Phillip', 'Paulisch');
insert into ClientesTPFinal (Nombre, Apellido) values ('Ferris', 'MacIan');
insert into ClientesTPFinal (Nombre, Apellido) values ('Greta', 'Eteen');
insert into ClientesTPFinal (Nombre, Apellido) values ('Elna', 'Deener');
insert into ClientesTPFinal (Nombre, Apellido) values ('Daren', 'McCowan');
insert into ClientesTPFinal (Nombre, Apellido) values ('Thatch', 'Eaton');
insert into ClientesTPFinal (Nombre, Apellido) values ('Jackson', 'Pasek');
insert into ClientesTPFinal (Nombre, Apellido) values ('Marilin', 'Manns');
insert into ClientesTPFinal (Nombre, Apellido) values ('Jenn', 'Garner');
insert into ClientesTPFinal (Nombre, Apellido) values ('Hally', 'Cornwell');
insert into ClientesTPFinal (Nombre, Apellido) values ('Jaimie', 'Longhorn');
insert into ClientesTPFinal (Nombre, Apellido) values ('Zaccaria', 'Hoppner');
insert into ClientesTPFinal (Nombre, Apellido) values ('Winifred', 'Reddish');
insert into ClientesTPFinal (Nombre, Apellido) values ('Zabrina', 'Jury');
insert into ClientesTPFinal (Nombre, Apellido) values ('Clementina', 'Walshe');
insert into ClientesTPFinal (Nombre, Apellido) values ('Georgeanne', 'Fray');
insert into ClientesTPFinal (Nombre, Apellido) values ('Janina', 'Tooze');
insert into ClientesTPFinal (Nombre, Apellido) values ('Cristen', 'Edler');
insert into ClientesTPFinal (Nombre, Apellido) values ('Tom', 'Campkin');
insert into ClientesTPFinal (Nombre, Apellido) values ('Tammi', 'Fludgate');
insert into ClientesTPFinal (Nombre, Apellido) values ('Valentina', 'Faltskog');
insert into ClientesTPFinal (Nombre, Apellido) values ('Barde', 'Snowdon');
insert into ClientesTPFinal (Nombre, Apellido) values ('Florida', 'Wathey');
insert into ClientesTPFinal (Nombre, Apellido) values ('Eve', 'Haile');
insert into ClientesTPFinal (Nombre, Apellido) values ('Maye', 'Cutsforth');
insert into ClientesTPFinal (Nombre, Apellido) values ('Neal', 'Olenchenko');
insert into ClientesTPFinal (Nombre, Apellido) values ('Tobias', 'Matantsev');
insert into ClientesTPFinal (Nombre, Apellido) values ('Prince', 'Unger');
--Agrega juegos de play
insert into JuegosPlay(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoPlay) values 
('Call of duty Black ops', 1200, 2000, 'Accion', 20, 1);
insert into JuegosPlay(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoPlay) values 
('Fifa 22', 5200, 7000, 'Deporte', 15, 0);
insert into JuegosPlay(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoPlay) values 
('Crash Bandicoot', 4300, 7000, 'Aventura', 12, 1);
insert into JuegosPlay(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoPlay) values 
('God of war 4', 2500, 7000, 'Aventura', 15, 1);
insert into JuegosPlay(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoPlay) values 
('Destiny 2', 3750, 7000, 'Accion', 15, 0);
--Agrega juegos de xbox
insert into JuegosXbox(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoXbox) values 
('HALO 3', 1200, 2000, 'Accion', 20, 1);
insert into JuegosXbox(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoXbox) values 
('Fifa 22', 5200, 7000, 'Deporte', 15, 0);
insert into JuegosXbox(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoXbox) values 
('GTA V', 4300, 7000, 'Aventura', 12, 0);
insert into JuegosXbox(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoXbox) values 
('Mafia 3', 2500, 7000, 'Aventura', 15, 0);
insert into JuegosXbox(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoXbox) values 
('Destiny 2', 3750, 7000, 'Accion', 15, 0);
--Agregar juegos nintendo
insert into JuegosNintendo(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoNintendo) values 
('Legends of Zelda', 1200, 2000, 'Accion', 20, 1);
insert into JuegosNintendo(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoNintendo) values 
('Fifa 22', 5200, 7000, 'Deporte', 15, 0);
insert into JuegosNintendo(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoNintendo) values 
('Kirby', 4300, 7000, 'Aventura', 12, 1);
insert into JuegosNintendo(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoNintendo) values 
('Mario Bross', 2500, 7000, 'Aventura', 15, 1);
insert into JuegosNintendo(Nombre, PrecioCompra, PrecioVenta, Genero, Stock, ExclusivoNintendo) values 
('Destiny 2', 3750, 7000, 'Accion', 15, 0);
