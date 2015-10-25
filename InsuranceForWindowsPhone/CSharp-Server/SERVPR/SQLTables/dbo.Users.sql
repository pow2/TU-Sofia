CREATE TABLE [dbo].[Users] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [FName]    NCHAR (20) NULL,
    [LName]    NCHAR (20) NULL,
    [Username] NCHAR (50) NOT NULL,
    [Pass]     NCHAR (50) NOT NULL,
    [Email]    NCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
