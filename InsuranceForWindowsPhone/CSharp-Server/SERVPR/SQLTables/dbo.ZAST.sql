CREATE TABLE [dbo].[ZAST] (
    [Id]              INT        IDENTITY (1, 1) NOT NULL,
    [FName]           NCHAR (20) NOT NULL,
    [LName]           NCHAR (20) NOT NULL,
    [CarNum]          NCHAR (20) NOT NULL,
    [CarBrand]        NCHAR (20) NOT NULL,
    [CarModel]        NCHAR (20) NOT NULL,
    [CarType]         SMALLINT   NOT NULL,
    [CarAddinfo]      NCHAR (10) NULL,
    [ExpireDateDay]   SMALLINT   NOT NULL,
    [ExpireDateMonth] SMALLINT   NOT NULL,
    [ExpireDateYear]  INT        NOT NULL,
    [employee]        INT        NOT NULL,
    [Price]           NCHAR (20) NOT NULL,
    [City]            SMALLINT   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([employee]) REFERENCES [dbo].[Users] ([Id])
);
