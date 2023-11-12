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

CREATE TABLE [users] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Username] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [Token] nvarchar(max) NULL,
    [Role] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_users] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231001065632_v1', N'7.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Cities] (
    [CityId] int NOT NULL IDENTITY,
    [CityName] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY ([CityId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231009122158_City', N'7.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Movies] (
    [MovieId] int NOT NULL IDENTITY,
    [Title] nvarchar(100) NOT NULL,
    [Language] nvarchar(50) NOT NULL,
    [DurationMinutes] int NOT NULL,
    [ReleaseDate] datetime2 NOT NULL,
    [CityId] int NOT NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY ([MovieId]),
    CONSTRAINT [FK_Movies_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [Cities] ([CityId]) ON DELETE CASCADE
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231010131236_MoviesTable', N'7.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Theaters] (
    [TheaterId] int NOT NULL IDENTITY,
    [TheaterName] nvarchar(100) NOT NULL,
    [Location] nvarchar(100) NOT NULL,
    [NumberOfScreens] int NOT NULL,
    CONSTRAINT [PK_Theaters] PRIMARY KEY ([TheaterId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231010140913_MovieTheaters', N'7.0.11');
GO

COMMIT;
GO

