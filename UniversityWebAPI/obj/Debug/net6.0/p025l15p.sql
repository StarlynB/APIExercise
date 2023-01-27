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

CREATE TABLE [baseEntities] (
    [Id] int NOT NULL IDENTITY,
    [CreateBy] nvarchar(max) NOT NULL,
    [CreateAt] datetime2 NULL,
    [UpdateBy] nvarchar(max) NOT NULL,
    [UpdateAt] datetime2 NULL,
    [DeleteBy] nvarchar(max) NOT NULL,
    [DeleteAt] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [Name] nvarchar(max) NULL,
    [CourseId] int NULL,
    [Student_Name] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Dob] datetime2 NULL,
    [User_Name] nvarchar(55) NULL,
    [User_LastName] nvarchar(100) NULL,
    [Email] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    CONSTRAINT [PK_baseEntities] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230118180247_add all tables', N'6.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [LoginUsers] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_LoginUsers] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230123234719_Update dbcontext', N'6.0.13');
GO

COMMIT;
GO

