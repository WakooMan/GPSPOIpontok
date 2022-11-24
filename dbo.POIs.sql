CREATE TABLE [dbo].[DBPOIs] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Longitude]   FLOAT (53)     NOT NULL,
    [Latitude]    FLOAT (53)     NOT NULL,
    [Category]    NVARCHAR (MAX) NULL,
    [Image]       IMAGE          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

