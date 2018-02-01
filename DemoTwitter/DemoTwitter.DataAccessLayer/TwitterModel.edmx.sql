
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/01/2018 15:43:47
-- Generated from EDMX file: D:\Projects\Personal\DemoTwitter\DemoTwitter\DemoTwitter.DataAccessLayer\TwitterModel.edmx
-- --------------------------------------------------
CREATE DATABASE [Twitter_db]
SET QUOTED_IDENTIFIER OFF;
GO
USE [Twitter_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_follower_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Followers] DROP CONSTRAINT [FK_follower_ID];
GO
IF OBJECT_ID(N'[dbo].[FK_Follower_user_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Followers] DROP CONSTRAINT [FK_Follower_user_ID];
GO
IF OBJECT_ID(N'[dbo].[FK_user_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tweet] DROP CONSTRAINT [FK_user_ID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Followers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Followers];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Tweet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tweet];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Followers'
CREATE TABLE [dbo].[Followers] (
    [id] int IDENTITY(1,1) NOT NULL,
    [user_id] int  NOT NULL,
    [follower_id] int  NOT NULL
);
GO

-- Creating table 'Tweets'
CREATE TABLE [dbo].[Tweets] (
    [id] int IDENTITY(1,1) NOT NULL,
    [user_id] int  NOT NULL,
    [text] varchar(140)  NOT NULL,
    [post_date] datetime  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [id] int IDENTITY(1,1) NOT NULL,
    [username] varchar(50)  NOT NULL,
    [email] varchar(50)  NOT NULL,
    [password] varchar(50)  NOT NULL,
    [firstname] varchar(50)  NOT NULL,
    [lastname] varchar(50)  NOT NULL,
    [avatar] varchar(200)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Followers'
ALTER TABLE [dbo].[Followers]
ADD CONSTRAINT [PK_Followers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Tweets'
ALTER TABLE [dbo].[Tweets]
ADD CONSTRAINT [PK_Tweets]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [follower_id] in table 'Followers'
ALTER TABLE [dbo].[Followers]
ADD CONSTRAINT [FK_follower_ID]
    FOREIGN KEY ([follower_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_follower_ID'
CREATE INDEX [IX_FK_follower_ID]
ON [dbo].[Followers]
    ([follower_id]);
GO

-- Creating foreign key on [user_id] in table 'Followers'
ALTER TABLE [dbo].[Followers]
ADD CONSTRAINT [FK_Follower_user_ID]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Follower_user_ID'
CREATE INDEX [IX_FK_Follower_user_ID]
ON [dbo].[Followers]
    ([user_id]);
GO

-- Creating foreign key on [user_id] in table 'Tweets'
ALTER TABLE [dbo].[Tweets]
ADD CONSTRAINT [FK_user_ID]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_user_ID'
CREATE INDEX [IX_FK_user_ID]
ON [dbo].[Tweets]
    ([user_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------