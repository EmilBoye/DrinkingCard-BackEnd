IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Alcohols] (
    [AlcoId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Strength] nvarchar(max) NOT NULL,
    [Ingredients] nvarchar(max) NOT NULL,
    [AlcoholType] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Alcohols] PRIMARY KEY ([AlcoId])
);
GO

CREATE TABLE [NonAlcohols] (
    [NonAlcoId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Strength] nvarchar(max) NOT NULL,
    [Ingredients] nvarchar(max) NOT NULL,
    [NonAlcoholType] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_NonAlcohols] PRIMARY KEY ([NonAlcoId])
);
GO

CREATE TABLE [Users] (
    [UserId] uniqueidentifier NOT NULL,
    [userEmail] nvarchar(64) NOT NULL,
    [userName] nvarchar(35) NOT NULL,
    [passwordHash] nvarchar(20) NOT NULL,
    [Visible] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221012085137_test', N'6.0.9');
GO

COMMIT;
GO

