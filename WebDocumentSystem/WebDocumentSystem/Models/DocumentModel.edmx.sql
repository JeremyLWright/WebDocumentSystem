
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/04/2012 08:27:41
-- Generated from EDMX file: C:\Users\Jeremy\workspaces\545_proj\WebDocumentSystem\WebDocumentSystem\Models\DocumentModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WebDocDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[WebDocModelStoreContainer].[FK_Audit_Log_Document]', 'F') IS NOT NULL
    ALTER TABLE [WebDocModelStoreContainer].[Audit_Log] DROP CONSTRAINT [FK_Audit_Log_Document];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentData_Document]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentData] DROP CONSTRAINT [FK_DocumentData_Document];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentNotes_Document]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentNotes] DROP CONSTRAINT [FK_DocumentNotes_Document];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[access_table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[access_table];
GO
IF OBJECT_ID(N'[WebDocModelStoreContainer].[Audit_Log]', 'U') IS NOT NULL
    DROP TABLE [WebDocModelStoreContainer].[Audit_Log];
GO
IF OBJECT_ID(N'[dbo].[Document]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Document];
GO
IF OBJECT_ID(N'[dbo].[DocumentData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentData];
GO
IF OBJECT_ID(N'[dbo].[DocumentNotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentNotes];
GO
IF OBJECT_ID(N'[dbo].[override_access]', 'U') IS NOT NULL
    DROP TABLE [dbo].[override_access];
GO
IF OBJECT_ID(N'[WebDocModelStoreContainer].[user_accounts2]', 'U') IS NOT NULL
    DROP TABLE [WebDocModelStoreContainer].[user_accounts2];
GO
IF OBJECT_ID(N'[dbo].[user_reporting]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user_reporting];
GO
IF OBJECT_ID(N'[dbo].[user_requests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user_requests];
GO
IF OBJECT_ID(N'[dbo].[user_types]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user_types];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DocumentLogs'
CREATE TABLE [dbo].[DocumentLogs] (
    [Id] int  NOT NULL,
    [Document] int  NOT NULL,
    [Message] varchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [user_accounts2_user_id] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Documents'
CREATE TABLE [dbo].[Documents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(max)  NULL,
    [IsLocked] bit  NOT NULL,
    [LockHolder] int  NULL,
    [Revision] int  NULL,
    [LastModified] datetime  NOT NULL
);
GO

-- Creating table 'DocumentDatas'
CREATE TABLE [dbo].[DocumentDatas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DocContent] varbinary(max)  NULL,
    [CreatedDate] datetime  NOT NULL,
    [Document] int  NOT NULL,
    [Encrypted] bit  NOT NULL
);
GO

-- Creating table 'DocumentNotes'
CREATE TABLE [dbo].[DocumentNotes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DocumentId] int  NOT NULL,
    [Note] varchar(max)  NOT NULL,
    [CreatedDate] datetime  NULL
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

-- Creating table 'access_table'
CREATE TABLE [dbo].[access_table] (
    [access_id] int  NOT NULL,
    [access_type] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'override_access'
CREATE TABLE [dbo].[override_access] (
    [document_id] nvarchar(50)  NOT NULL,
    [user_id] nvarchar(50)  NOT NULL,
    [authorized_by] nvarchar(50)  NOT NULL,
    [access_privikege] int  NOT NULL
);
GO

-- Creating table 'user_accounts2'
CREATE TABLE [dbo].[user_accounts2] (
    [user_id] nvarchar(50)  NOT NULL,
    [password] nvarchar(50)  NOT NULL,
    [user_type] int  NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [email_id] nvarchar(50)  NULL
);
GO

-- Creating table 'user_reporting'
CREATE TABLE [dbo].[user_reporting] (
    [user_id] nvarchar(50)  NOT NULL,
    [super_user] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'user_requests'
CREATE TABLE [dbo].[user_requests] (
    [request_id] int  NOT NULL,
    [user_id] nvarchar(50)  NOT NULL,
    [password] nvarchar(50)  NOT NULL,
    [user_type] int  NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [email] nvarchar(50)  NOT NULL,
    [password_streangth] int  NOT NULL,
    [request_type_id] int  NOT NULL,
    [timestamp] datetime  NULL
);
GO

-- Creating table 'user_types'
CREATE TABLE [dbo].[user_types] (
    [user_type] int  NOT NULL,
    [type_name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'UserLogs'
CREATE TABLE [dbo].[UserLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [user_accounts2_user_id] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'DocumentLogs'
ALTER TABLE [dbo].[DocumentLogs]
ADD CONSTRAINT [PK_DocumentLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [PK_Documents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocumentDatas'
ALTER TABLE [dbo].[DocumentDatas]
ADD CONSTRAINT [PK_DocumentDatas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocumentNotes'
ALTER TABLE [dbo].[DocumentNotes]
ADD CONSTRAINT [PK_DocumentNotes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [access_id] in table 'access_table'
ALTER TABLE [dbo].[access_table]
ADD CONSTRAINT [PK_access_table]
    PRIMARY KEY CLUSTERED ([access_id] ASC);
GO

-- Creating primary key on [document_id], [user_id] in table 'override_access'
ALTER TABLE [dbo].[override_access]
ADD CONSTRAINT [PK_override_access]
    PRIMARY KEY CLUSTERED ([document_id], [user_id] ASC);
GO

-- Creating primary key on [user_id] in table 'user_accounts2'
ALTER TABLE [dbo].[user_accounts2]
ADD CONSTRAINT [PK_user_accounts2]
    PRIMARY KEY CLUSTERED ([user_id] ASC);
GO

-- Creating primary key on [user_id] in table 'user_reporting'
ALTER TABLE [dbo].[user_reporting]
ADD CONSTRAINT [PK_user_reporting]
    PRIMARY KEY CLUSTERED ([user_id] ASC);
GO

-- Creating primary key on [request_id] in table 'user_requests'
ALTER TABLE [dbo].[user_requests]
ADD CONSTRAINT [PK_user_requests]
    PRIMARY KEY CLUSTERED ([request_id] ASC);
GO

-- Creating primary key on [user_type] in table 'user_types'
ALTER TABLE [dbo].[user_types]
ADD CONSTRAINT [PK_user_types]
    PRIMARY KEY CLUSTERED ([user_type] ASC);
GO

-- Creating primary key on [Id] in table 'UserLogs'
ALTER TABLE [dbo].[UserLogs]
ADD CONSTRAINT [PK_UserLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Document] in table 'DocumentLogs'
ALTER TABLE [dbo].[DocumentLogs]
ADD CONSTRAINT [FK_Audit_Log_Document]
    FOREIGN KEY ([Document])
    REFERENCES [dbo].[Documents]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Audit_Log_Document'
CREATE INDEX [IX_FK_Audit_Log_Document]
ON [dbo].[DocumentLogs]
    ([Document]);
GO

-- Creating foreign key on [Document] in table 'DocumentDatas'
ALTER TABLE [dbo].[DocumentDatas]
ADD CONSTRAINT [FK_DocumentData_Document]
    FOREIGN KEY ([Document])
    REFERENCES [dbo].[Documents]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentData_Document'
CREATE INDEX [IX_FK_DocumentData_Document]
ON [dbo].[DocumentDatas]
    ([Document]);
GO

-- Creating foreign key on [DocumentId] in table 'DocumentNotes'
ALTER TABLE [dbo].[DocumentNotes]
ADD CONSTRAINT [FK_DocumentNotes_Document]
    FOREIGN KEY ([DocumentId])
    REFERENCES [dbo].[Documents]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentNotes_Document'
CREATE INDEX [IX_FK_DocumentNotes_Document]
ON [dbo].[DocumentNotes]
    ([DocumentId]);
GO

-- Creating foreign key on [user_accounts2_user_id] in table 'UserLogs'
ALTER TABLE [dbo].[UserLogs]
ADD CONSTRAINT [FK_UserLoguser_accounts2]
    FOREIGN KEY ([user_accounts2_user_id])
    REFERENCES [dbo].[user_accounts2]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserLoguser_accounts2'
CREATE INDEX [IX_FK_UserLoguser_accounts2]
ON [dbo].[UserLogs]
    ([user_accounts2_user_id]);
GO

-- Creating foreign key on [user_accounts2_user_id] in table 'DocumentLogs'
ALTER TABLE [dbo].[DocumentLogs]
ADD CONSTRAINT [FK_DocumentLoguser_accounts2]
    FOREIGN KEY ([user_accounts2_user_id])
    REFERENCES [dbo].[user_accounts2]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentLoguser_accounts2'
CREATE INDEX [IX_FK_DocumentLoguser_accounts2]
ON [dbo].[DocumentLogs]
    ([user_accounts2_user_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------