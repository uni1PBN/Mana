
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/16/2016 16:07:42
-- Generated from EDMX file: C:\Users\uni1lab\Source\Repos\Mana\Data\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBMana];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TaskLogActivityLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MANA_ActivityLog] DROP CONSTRAINT [FK_TaskLogActivityLog];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskRunningTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MANA_WFInstancesLog] DROP CONSTRAINT [FK_TaskRunningTask];
GO
IF OBJECT_ID(N'[dbo].[FK_UserActivityLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MANA_ActivityLog] DROP CONSTRAINT [FK_UserActivityLog];
GO
IF OBJECT_ID(N'[dbo].[FK_UserActivityLog1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MANA_ActivityLog] DROP CONSTRAINT [FK_UserActivityLog1];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRunningTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MANA_WFInstancesLog] DROP CONSTRAINT [FK_UserRunningTask];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTaskLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MANA_WFInstancesLog] DROP CONSTRAINT [FK_UserTaskLog];
GO
IF OBJECT_ID(N'[dbo].[FK_WFInstancesLogDossier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MANA_Dossier] DROP CONSTRAINT [FK_WFInstancesLogDossier];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MANA_ActivityLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MANA_ActivityLog];
GO
IF OBJECT_ID(N'[dbo].[MANA_Dossier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MANA_Dossier];
GO
IF OBJECT_ID(N'[dbo].[MANA_User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MANA_User];
GO
IF OBJECT_ID(N'[dbo].[MANA_WFInstancesLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MANA_WFInstancesLog];
GO
IF OBJECT_ID(N'[dbo].[MANA_WorkflowRepository]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MANA_WorkflowRepository];
GO


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MANA_ActivityLog'
CREATE TABLE [dbo].[MANA_ActivityLog] (
    [PK] int IDENTITY(1,1) NOT NULL,
    [ActivityStatus] nvarchar(64)  NOT NULL,
    [ActivityName] nvarchar(128)  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [FK_ExecutedBy] int  NULL,
    [FK_ControledBy] int  NULL,
    [FK_TaskLog] int  NOT NULL,
    [FK_WFInstanceID] uniqueidentifier  NULL,
    [ActivityID] nvarchar(64)  NOT NULL
);
GO

-- Creating table 'MANA_User'
CREATE TABLE [dbo].[MANA_User] (
    [PK] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(128)  NOT NULL,
    [UserID] nvarchar(64)  NOT NULL
);
GO

-- Creating table 'MANA_WFInstancesLog'
CREATE TABLE [dbo].[MANA_WFInstancesLog] (
    [PK] int IDENTITY(1,1) NOT NULL,
    [FK_TaskRepo] int  NULL,
    [FK_UserExec] int  NULL,
    [Status] nvarchar(64)  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [FK_UserCtrl] int  NULL,
    [FK_WFInstanceID] uniqueidentifier  NULL,
    [Topic] nvarchar(100)  NULL
);
GO

-- Creating table 'MANA_WorkflowRepository'
CREATE TABLE [dbo].[MANA_WorkflowRepository] (
    [PK] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(128)  NOT NULL,
    [Description] nvarchar(1024)  NULL,
    [ValidityStartDate] datetime  NOT NULL,
    [ValidityEndDate] datetime  NOT NULL,
    [WorkFlow] nvarchar(max)  NOT NULL,
    [Area] nvarchar(128)  NULL,
    [Function] nvarchar(128)  NULL
);
GO

-- Creating table 'MANA_Dossier'
CREATE TABLE [dbo].[MANA_Dossier] (
    [PK] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NULL,
    [Status] nvarchar(64)  NULL,
    [OpenDate] datetime  NULL,
    [CloseDate] datetime  NULL,
    [FK_WFInstanceLog] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PK] in table 'MANA_ActivityLog'
ALTER TABLE [dbo].[MANA_ActivityLog]
ADD CONSTRAINT [PK_MANA_ActivityLog]
    PRIMARY KEY CLUSTERED ([PK] ASC);
GO

-- Creating primary key on [PK] in table 'MANA_User'
ALTER TABLE [dbo].[MANA_User]
ADD CONSTRAINT [PK_MANA_User]
    PRIMARY KEY CLUSTERED ([PK] ASC);
GO

-- Creating primary key on [PK] in table 'MANA_WFInstancesLog'
ALTER TABLE [dbo].[MANA_WFInstancesLog]
ADD CONSTRAINT [PK_MANA_WFInstancesLog]
    PRIMARY KEY CLUSTERED ([PK] ASC);
GO

-- Creating primary key on [PK] in table 'MANA_WorkflowRepository'
ALTER TABLE [dbo].[MANA_WorkflowRepository]
ADD CONSTRAINT [PK_MANA_WorkflowRepository]
    PRIMARY KEY CLUSTERED ([PK] ASC);
GO

-- Creating primary key on [PK] in table 'MANA_Dossier'
ALTER TABLE [dbo].[MANA_Dossier]
ADD CONSTRAINT [PK_MANA_Dossier]
    PRIMARY KEY CLUSTERED ([PK] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FK_ExecutedBy] in table 'MANA_ActivityLog'
ALTER TABLE [dbo].[MANA_ActivityLog]
ADD CONSTRAINT [FK_UserActivityLog]
    FOREIGN KEY ([FK_ExecutedBy])
    REFERENCES [dbo].[MANA_User]
        ([PK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserActivityLog'
CREATE INDEX [IX_FK_UserActivityLog]
ON [dbo].[MANA_ActivityLog]
    ([FK_ExecutedBy]);
GO

-- Creating foreign key on [FK_ControledBy] in table 'MANA_ActivityLog'
ALTER TABLE [dbo].[MANA_ActivityLog]
ADD CONSTRAINT [FK_UserActivityLog1]
    FOREIGN KEY ([FK_ControledBy])
    REFERENCES [dbo].[MANA_User]
        ([PK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserActivityLog1'
CREATE INDEX [IX_FK_UserActivityLog1]
ON [dbo].[MANA_ActivityLog]
    ([FK_ControledBy]);
GO

-- Creating foreign key on [FK_TaskLog] in table 'MANA_ActivityLog'
ALTER TABLE [dbo].[MANA_ActivityLog]
ADD CONSTRAINT [FK_TaskLogActivityLog1]
    FOREIGN KEY ([FK_TaskLog])
    REFERENCES [dbo].[MANA_WFInstancesLog]
        ([PK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskLogActivityLog1'
CREATE INDEX [IX_FK_TaskLogActivityLog1]
ON [dbo].[MANA_ActivityLog]
    ([FK_TaskLog]);
GO

-- Creating foreign key on [FK_UserExec] in table 'MANA_WFInstancesLog'
ALTER TABLE [dbo].[MANA_WFInstancesLog]
ADD CONSTRAINT [FK_UserRunningTask1]
    FOREIGN KEY ([FK_UserExec])
    REFERENCES [dbo].[MANA_User]
        ([PK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRunningTask1'
CREATE INDEX [IX_FK_UserRunningTask1]
ON [dbo].[MANA_WFInstancesLog]
    ([FK_UserExec]);
GO

-- Creating foreign key on [FK_UserCtrl] in table 'MANA_WFInstancesLog'
ALTER TABLE [dbo].[MANA_WFInstancesLog]
ADD CONSTRAINT [FK_UserTaskLog1]
    FOREIGN KEY ([FK_UserCtrl])
    REFERENCES [dbo].[MANA_User]
        ([PK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTaskLog1'
CREATE INDEX [IX_FK_UserTaskLog1]
ON [dbo].[MANA_WFInstancesLog]
    ([FK_UserCtrl]);
GO

-- Creating foreign key on [FK_TaskRepo] in table 'MANA_WFInstancesLog'
ALTER TABLE [dbo].[MANA_WFInstancesLog]
ADD CONSTRAINT [FK_TaskRunningTask1]
    FOREIGN KEY ([FK_TaskRepo])
    REFERENCES [dbo].[MANA_WorkflowRepository]
        ([PK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskRunningTask1'
CREATE INDEX [IX_FK_TaskRunningTask1]
ON [dbo].[MANA_WFInstancesLog]
    ([FK_TaskRepo]);
GO

-- Creating foreign key on [FK_WFInstanceLog] in table 'MANA_Dossier'
ALTER TABLE [dbo].[MANA_Dossier]
ADD CONSTRAINT [FK_WFInstancesLogDossier]
    FOREIGN KEY ([FK_WFInstanceLog])
    REFERENCES [dbo].[MANA_WFInstancesLog]
        ([PK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WFInstancesLogDossier'
CREATE INDEX [IX_FK_WFInstancesLogDossier]
ON [dbo].[MANA_Dossier]
    ([FK_WFInstanceLog]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------