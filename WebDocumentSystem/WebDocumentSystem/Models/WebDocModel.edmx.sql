
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/04/2012 17:17:15
-- Generated from EDMX file: C:\Users\Jeremy\workspaces\545_proj\WebDocumentSystem\WebDocumentSystem\Models\WebDocModel.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DocumentDatas'
CREATE TABLE [dbo].[DocumentDatas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DocContent] varbinary(max)  NULL,
    [CreatedDate] datetime  NOT NULL,
    [Document] int  NOT NULL,
    [Encrypted] bit  NOT NULL
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
    [LastModified] datetime  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NULL,
    [SecurityAnswer] nvarchar(max)  NOT NULL,
    [SecurityQuestion_Id] int  NOT NULL,
    [UserType_Id] int  NOT NULL
);
GO

-- Creating table 'AccountRequests'
CREATE TABLE [dbo].[AccountRequests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PasswordStrength] int  NOT NULL,
    [Timestamp] datetime  NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'UserTypes'
CREATE TABLE [dbo].[UserTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(50)  NOT NULL
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

-- Creating primary key on [Id] in table 'UserTypes'
ALTER TABLE [dbo].[UserTypes]
ADD CONSTRAINT [PK_UserTypes]
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

-- Creating foreign key on [UserType_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_UserUserType]
    FOREIGN KEY ([UserType_Id])
    REFERENCES [dbo].[UserTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserType'
CREATE INDEX [IX_FK_UserUserType]
ON [dbo].[Users]
    ([UserType_Id]);
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------