
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/08/2012 22:03:49
-- Generated from EDMX file: C:\Users\Jeremy\workspaces\545_2\WebDocumentSystem\WebDocumentSystem\Models\WebDocModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WebDoc];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DocumentData_Document]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentDatas] DROP CONSTRAINT [FK_DocumentData_Document];
GO
IF OBJECT_ID(N'[dbo].[FK_Audit_Log_Document]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentLogs] DROP CONSTRAINT [FK_Audit_Log_Document];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentNotes_Document]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentNotes] DROP CONSTRAINT [FK_DocumentNotes_Document];
GO
IF OBJECT_ID(N'[dbo].[FK_user_accounts2SecurityQuestions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_user_accounts2SecurityQuestions];
GO
IF OBJECT_ID(N'[dbo].[FK_user_requestsUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountRequests] DROP CONSTRAINT [FK_user_requestsUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserLogs] DROP CONSTRAINT [FK_UserUserLog];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentLogUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentLogs] DROP CONSTRAINT [FK_DocumentLogUser];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentNoteUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentNotes] DROP CONSTRAINT [FK_DocumentNoteUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserDocument]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_UserDocument];
GO
IF OBJECT_ID(N'[dbo].[FK_ShareDocument]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Shares] DROP CONSTRAINT [FK_ShareDocument];
GO
IF OBJECT_ID(N'[dbo].[FK_ShareWithUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Shares] DROP CONSTRAINT [FK_ShareWithUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DocumentDatas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentDatas];
GO
IF OBJECT_ID(N'[dbo].[DocumentLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentLogs];
GO
IF OBJECT_ID(N'[dbo].[DocumentNotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentNotes];
GO
IF OBJECT_ID(N'[dbo].[Documents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Documents];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[AccountRequests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountRequests];
GO
IF OBJECT_ID(N'[dbo].[UserLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserLogs];
GO
IF OBJECT_ID(N'[dbo].[SecurityQuestions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SecurityQuestions];
GO
IF OBJECT_ID(N'[dbo].[Shares]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Shares];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DocumentDatas'
CREATE TABLE [dbo].[DocumentDatas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DocContent] varbinary(max)  NULL,
    [CreatedDate] datetime  NOT NULL,
    [Document] int  NOT NULL,
    [Encrypted] bit  NOT NULL,
    [Salt] varbinary(max)  NULL
);
GO

-- Creating table 'DocumentLogs'
CREATE TABLE [dbo].[DocumentLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Document] int  NOT NULL,
    [Message] varchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'DocumentNotes'
CREATE TABLE [dbo].[DocumentNotes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DocumentId] int  NOT NULL,
    [Note] varchar(max)  NOT NULL,
    [CreatedDate] datetime  NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Documents'
CREATE TABLE [dbo].[Documents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(max)  NULL,
    [IsLocked] bit  NOT NULL,
    [LockHolder] int  NULL,
    [Revision] int  NULL,
    [LastModified] datetime  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NULL,
    [SecurityAnswer] nvarchar(max)  NOT NULL,
    [Salt] varbinary(max)  NULL,
    [Role] int  NOT NULL,
    [Group] int  NOT NULL,
    [SecurityQuestion_Id] int  NOT NULL
);
GO

-- Creating table 'AccountRequests'
CREATE TABLE [dbo].[AccountRequests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PasswordStrength] int  NOT NULL,
    [Timestamp] datetime  NULL,
    [State] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'UserLogs'
CREATE TABLE [dbo].[UserLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'SecurityQuestions'
CREATE TABLE [dbo].[SecurityQuestions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Question] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Shares'
CREATE TABLE [dbo].[Shares] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Created] datetime  NOT NULL,
    [Document_Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'DocumentDatas'
ALTER TABLE [dbo].[DocumentDatas]
ADD CONSTRAINT [PK_DocumentDatas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocumentLogs'
ALTER TABLE [dbo].[DocumentLogs]
ADD CONSTRAINT [PK_DocumentLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocumentNotes'
ALTER TABLE [dbo].[DocumentNotes]
ADD CONSTRAINT [PK_DocumentNotes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [PK_Documents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AccountRequests'
ALTER TABLE [dbo].[AccountRequests]
ADD CONSTRAINT [PK_AccountRequests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserLogs'
ALTER TABLE [dbo].[UserLogs]
ADD CONSTRAINT [PK_UserLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SecurityQuestions'
ALTER TABLE [dbo].[SecurityQuestions]
ADD CONSTRAINT [PK_SecurityQuestions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Shares'
ALTER TABLE [dbo].[Shares]
ADD CONSTRAINT [PK_Shares]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [SecurityQuestion_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_user_accounts2SecurityQuestions]
    FOREIGN KEY ([SecurityQuestion_Id])
    REFERENCES [dbo].[SecurityQuestions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_user_accounts2SecurityQuestions'
CREATE INDEX [IX_FK_user_accounts2SecurityQuestions]
ON [dbo].[Users]
    ([SecurityQuestion_Id]);
GO

-- Creating foreign key on [User_Id] in table 'AccountRequests'
ALTER TABLE [dbo].[AccountRequests]
ADD CONSTRAINT [FK_user_requestsUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_user_requestsUser'
CREATE INDEX [IX_FK_user_requestsUser]
ON [dbo].[AccountRequests]
    ([User_Id]);
GO

-- Creating foreign key on [UserId] in table 'UserLogs'
ALTER TABLE [dbo].[UserLogs]
ADD CONSTRAINT [FK_UserUserLog]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserLog'
CREATE INDEX [IX_FK_UserUserLog]
ON [dbo].[UserLogs]
    ([UserId]);
GO

-- Creating foreign key on [User_Id] in table 'DocumentLogs'
ALTER TABLE [dbo].[DocumentLogs]
ADD CONSTRAINT [FK_DocumentLogUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentLogUser'
CREATE INDEX [IX_FK_DocumentLogUser]
ON [dbo].[DocumentLogs]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'DocumentNotes'
ALTER TABLE [dbo].[DocumentNotes]
ADD CONSTRAINT [FK_DocumentNoteUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentNoteUser'
CREATE INDEX [IX_FK_DocumentNoteUser]
ON [dbo].[DocumentNotes]
    ([User_Id]);
GO

-- Creating foreign key on [UserId] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [FK_UserDocument]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserDocument'
CREATE INDEX [IX_FK_UserDocument]
ON [dbo].[Documents]
    ([UserId]);
GO

-- Creating foreign key on [Document_Id] in table 'Shares'
ALTER TABLE [dbo].[Shares]
ADD CONSTRAINT [FK_ShareDocument]
    FOREIGN KEY ([Document_Id])
    REFERENCES [dbo].[Documents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ShareDocument'
CREATE INDEX [IX_FK_ShareDocument]
ON [dbo].[Shares]
    ([Document_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Shares'
ALTER TABLE [dbo].[Shares]
ADD CONSTRAINT [FK_ShareWithUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ShareWithUser'
CREATE INDEX [IX_FK_ShareWithUser]
ON [dbo].[Shares]
    ([User_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------