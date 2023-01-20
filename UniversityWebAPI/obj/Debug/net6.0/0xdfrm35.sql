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

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230109212723_Create table users', N'6.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(55) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [CreateBy] nvarchar(max) NOT NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NOT NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NOT NULL,
    [DeleteAt] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230109213524_Agregando tabla usuarios', N'6.0.12');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Cursos] (
    [Nombre] nvarchar(max) NOT NULL,
    [DescripcionCorta] nvarchar(280) NOT NULL,
    [DescripcionLarga] nvarchar(max) NOT NULL,
    [PublicoObjetivo] nvarchar(max) NOT NULL,
    [Objectivos] nvarchar(max) NOT NULL,
    [Requisitos] nvarchar(max) NOT NULL,
    [Nivel] nvarchar(max) NOT NULL
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230109222437_Create table Cursos', N'6.0.12');
GO

COMMIT;
GO

