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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426062939_1')
BEGIN
    CREATE TABLE [Catagories] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Icon] nvarchar(max) NULL,
        CONSTRAINT [PK_Catagories] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426062939_1')
BEGIN
    CREATE TABLE [Transactions] (
        [Id] int NOT NULL IDENTITY,
        [Amount] float NULL,
        [Description] nvarchar(max) NULL,
        [CatagoryId] int NULL,
        [Date] datetime2 NULL,
        CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Transactions_Catagories_CatagoryId] FOREIGN KEY ([CatagoryId]) REFERENCES [Catagories] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426062939_1')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Icon', N'Name') AND [object_id] = OBJECT_ID(N'[Catagories]'))
        SET IDENTITY_INSERT [Catagories] ON;
    EXEC(N'INSERT INTO [Catagories] ([Id], [Icon], [Name])
    VALUES (1, N''Home'', N''Home'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Icon', N'Name') AND [object_id] = OBJECT_ID(N'[Catagories]'))
        SET IDENTITY_INSERT [Catagories] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426062939_1')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Icon', N'Name') AND [object_id] = OBJECT_ID(N'[Catagories]'))
        SET IDENTITY_INSERT [Catagories] ON;
    EXEC(N'INSERT INTO [Catagories] ([Id], [Icon], [Name])
    VALUES (2, N''Dollar'', N''Salary'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Icon', N'Name') AND [object_id] = OBJECT_ID(N'[Catagories]'))
        SET IDENTITY_INSERT [Catagories] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426062939_1')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Icon', N'Name') AND [object_id] = OBJECT_ID(N'[Catagories]'))
        SET IDENTITY_INSERT [Catagories] ON;
    EXEC(N'INSERT INTO [Catagories] ([Id], [Icon], [Name])
    VALUES (3, N''QuestionMark'', N''Other'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Icon', N'Name') AND [object_id] = OBJECT_ID(N'[Catagories]'))
        SET IDENTITY_INSERT [Catagories] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426062939_1')
BEGIN
    CREATE INDEX [IX_Transactions_CatagoryId] ON [Transactions] ([CatagoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426062939_1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220426062939_1', N'6.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426075403_2')
BEGIN
    ALTER TABLE [Transactions] DROP CONSTRAINT [FK_Transactions_Catagories_CatagoryId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426075403_2')
BEGIN
    DROP INDEX [IX_Transactions_CatagoryId] ON [Transactions];
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'CatagoryId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Transactions] ALTER COLUMN [CatagoryId] int NOT NULL;
    ALTER TABLE [Transactions] ADD DEFAULT 0 FOR [CatagoryId];
    CREATE INDEX [IX_Transactions_CatagoryId] ON [Transactions] ([CatagoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426075403_2')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Amount', N'CatagoryId', N'Date', N'Description') AND [object_id] = OBJECT_ID(N'[Transactions]'))
        SET IDENTITY_INSERT [Transactions] ON;
    EXEC(N'INSERT INTO [Transactions] ([Id], [Amount], [CatagoryId], [Date], [Description])
    VALUES (1, 100.0E0, 1, ''2022-04-26T13:24:02.9807515+05:30'', N''a'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Amount', N'CatagoryId', N'Date', N'Description') AND [object_id] = OBJECT_ID(N'[Transactions]'))
        SET IDENTITY_INSERT [Transactions] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426075403_2')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Amount', N'CatagoryId', N'Date', N'Description') AND [object_id] = OBJECT_ID(N'[Transactions]'))
        SET IDENTITY_INSERT [Transactions] ON;
    EXEC(N'INSERT INTO [Transactions] ([Id], [Amount], [CatagoryId], [Date], [Description])
    VALUES (2, 100.0E0, 2, ''2022-04-26T13:24:02.9807531+05:30'', N''a'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Amount', N'CatagoryId', N'Date', N'Description') AND [object_id] = OBJECT_ID(N'[Transactions]'))
        SET IDENTITY_INSERT [Transactions] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426075403_2')
BEGIN
    ALTER TABLE [Transactions] ADD CONSTRAINT [FK_Transactions_Catagories_CatagoryId] FOREIGN KEY ([CatagoryId]) REFERENCES [Catagories] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426075403_2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220426075403_2', N'6.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426084026_3')
BEGIN
    EXEC(N'UPDATE [Transactions] SET [Date] = ''2022-04-26T14:10:26.0458821+05:30''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426084026_3')
BEGIN
    EXEC(N'UPDATE [Transactions] SET [Date] = ''2022-04-26T14:10:26.0458836+05:30''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426084026_3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220426084026_3', N'6.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426085346_4')
BEGIN
    ALTER TABLE [Transactions] DROP CONSTRAINT [FK_Transactions_Catagories_CatagoryId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426085346_4')
BEGIN
    DROP INDEX [IX_Transactions_CatagoryId] ON [Transactions];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426085346_4')
BEGIN
    EXEC(N'UPDATE [Transactions] SET [Date] = ''2022-04-26T14:23:46.1428248+05:30''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426085346_4')
BEGIN
    EXEC(N'UPDATE [Transactions] SET [Date] = ''2022-04-26T14:23:46.1428260+05:30''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426085346_4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220426085346_4', N'6.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426093838_5')
BEGIN
    EXEC(N'DELETE FROM [Catagories]
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426093838_5')
BEGIN
    EXEC(N'DELETE FROM [Catagories]
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426093838_5')
BEGIN
    EXEC(N'DELETE FROM [Catagories]
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426093838_5')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Catagories]') AND [c].[name] = N'Name');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Catagories] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Catagories] ALTER COLUMN [Name] nvarchar(450) NOT NULL;
    ALTER TABLE [Catagories] ADD DEFAULT N'' FOR [Name];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426093838_5')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Icon', N'Name') AND [object_id] = OBJECT_ID(N'[Catagories]'))
        SET IDENTITY_INSERT [Catagories] ON;
    EXEC(N'INSERT INTO [Catagories] ([Id], [Icon], [Name])
    VALUES (1, N''Home'', N''Home''),
    (2, N''Dollar'', N''Salary''),
    (3, N''QuestionMark'', N''Other'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Icon', N'Name') AND [object_id] = OBJECT_ID(N'[Catagories]'))
        SET IDENTITY_INSERT [Catagories] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426093838_5')
BEGIN
    EXEC(N'UPDATE [Transactions] SET [Date] = ''2022-04-26T15:08:38.4585701+05:30''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426093838_5')
BEGIN
    EXEC(N'UPDATE [Transactions] SET [Date] = ''2022-04-26T15:08:38.4585715+05:30''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426093838_5')
BEGIN
    CREATE UNIQUE INDEX [IX_Catagories_Name] ON [Catagories] ([Name]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426093838_5')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220426093838_5', N'6.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426100918_6')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Description');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Transactions] ALTER COLUMN [Description] nvarchar(200) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426100918_6')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Date');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Transactions] ALTER COLUMN [Date] datetime2 NOT NULL;
    ALTER TABLE [Transactions] ADD DEFAULT '0001-01-01T00:00:00.0000000' FOR [Date];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426100918_6')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Amount');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Transactions] ALTER COLUMN [Amount] float NOT NULL;
    ALTER TABLE [Transactions] ADD DEFAULT 0.0E0 FOR [Amount];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426100918_6')
BEGIN
    DROP INDEX [IX_Catagories_Name] ON [Catagories];
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Catagories]') AND [c].[name] = N'Name');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Catagories] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Catagories] ALTER COLUMN [Name] nvarchar(100) NOT NULL;
    CREATE UNIQUE INDEX [IX_Catagories_Name] ON [Catagories] ([Name]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426100918_6')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Catagories]') AND [c].[name] = N'Icon');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Catagories] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Catagories] ALTER COLUMN [Icon] nvarchar(max) NOT NULL;
    ALTER TABLE [Catagories] ADD DEFAULT N'' FOR [Icon];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426100918_6')
BEGIN
    EXEC(N'UPDATE [Transactions] SET [Date] = ''2022-04-26T15:39:17.7283709+05:30''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426100918_6')
BEGIN
    EXEC(N'UPDATE [Transactions] SET [Date] = ''2022-04-26T15:39:17.7283724+05:30''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426100918_6')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220426100918_6', N'6.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426130525_7')
BEGIN
    EXEC(N'UPDATE [Transactions] SET [Date] = ''2022-04-26T18:35:24.7821897+05:30''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426130525_7')
BEGIN
    EXEC(N'UPDATE [Transactions] SET [Date] = ''2022-04-26T18:35:24.7821913+05:30''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426130525_7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220426130525_7', N'6.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426131221_8')
BEGIN
    EXEC(N'UPDATE [Transactions] SET [Date] = ''2022-04-26T18:42:21.0893082+05:30''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426131221_8')
BEGIN
    EXEC(N'UPDATE [Transactions] SET [Date] = ''2022-04-26T18:42:21.0893093+05:30''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220426131221_8')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220426131221_8', N'6.0.4');
END;
GO

COMMIT;
GO

