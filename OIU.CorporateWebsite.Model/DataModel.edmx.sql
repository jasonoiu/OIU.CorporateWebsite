
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/23/2013 13:41:05
-- Generated from EDMX file: E:\项目\OIU.CorporateWebsite\OIU.CorporateWebsite.Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CorporateWebsite];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[BaseUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaseUsers];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[PCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PCategories];
GO
IF OBJECT_ID(N'[dbo].[SystemMenus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SystemMenus];
GO
IF OBJECT_ID(N'[dbo].[Abouts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Abouts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(32)  NULL
);
GO

-- Creating table 'BaseUsers'
CREATE TABLE [dbo].[BaseUsers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(32)  NOT NULL,
    [PassWord] nvarchar(16)  NOT NULL,
    [AddTime] datetime  NULL,
    [Code] nvarchar(32)  NULL,
    [RealName] nvarchar(50)  NULL,
    [QuickQuery] nvarchar(100)  NULL,
    [SecurityLevel] int  NULL,
    [UserFrom] nvarchar(50)  NULL,
    [CompanyID] int  NULL,
    [CompanyName] nvarchar(50)  NULL,
    [SubCompanyID] int  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PName] nvarchar(50)  NOT NULL,
    [BriefIntroduction] nvarchar(1000)  NULL,
    [PCid] int  NULL,
    [PImg] nvarchar(1000)  NULL,
    [AddTime] datetime  NULL
);
GO

-- Creating table 'PCategories'
CREATE TABLE [dbo].[PCategories] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CName] nvarchar(50)  NOT NULL,
    [Pid] int  NULL,
    [Description] nvarchar(1000)  NULL,
    [CImg] nvarchar(500)  NULL
);
GO

-- Creating table 'SystemMenus'
CREATE TABLE [dbo].[SystemMenus] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [MenuName] nvarchar(50)  NOT NULL,
    [MenuUrl] nvarchar(500)  NULL,
    [Pid] int  NULL,
    [SortId] int  NULL,
    [IsDisable] bit  NULL
);
GO

-- Creating table 'Abouts'
CREATE TABLE [dbo].[Abouts] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NULL,
    [Contents] nvarchar(max)  NULL,
    [AddTime] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'BaseUsers'
ALTER TABLE [dbo].[BaseUsers]
ADD CONSTRAINT [PK_BaseUsers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PCategories'
ALTER TABLE [dbo].[PCategories]
ADD CONSTRAINT [PK_PCategories]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [MenuName] in table 'SystemMenus'
ALTER TABLE [dbo].[SystemMenus]
ADD CONSTRAINT [PK_SystemMenus]
    PRIMARY KEY CLUSTERED ([ID], [MenuName] ASC);
GO

-- Creating primary key on [ID] in table 'Abouts'
ALTER TABLE [dbo].[Abouts]
ADD CONSTRAINT [PK_Abouts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------