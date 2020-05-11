IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200510102340_Initial')
BEGIN
    CREATE TABLE [Authors] (
        [id] nvarchar(450) NOT NULL,
        [Name] nvarchar(150) NULL,
        CONSTRAINT [PK_Authors] PRIMARY KEY ([id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200510102340_Initial')
BEGIN
    CREATE TABLE [Books] (
        [id] nvarchar(450) NOT NULL,
        [Title] nvarchar(150) NOT NULL,
        [Authorid] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_Books] PRIMARY KEY ([id]),
        CONSTRAINT [FK_Books_Authors_Authorid] FOREIGN KEY ([Authorid]) REFERENCES [Authors] ([id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200510102340_Initial')
BEGIN
    CREATE INDEX [IX_Books_Authorid] ON [Books] ([Authorid]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200510102340_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200510102340_Initial', N'3.1.3');
END;

GO

