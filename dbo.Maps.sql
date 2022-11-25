CREATE TABLE [dbo].[DBMaps] (
    [MapId]                     INT            IDENTITY (1, 1) NOT NULL,
    [Name]                   NVARCHAR (MAX) NOT NULL,
    [Lesser]                 INT            NOT NULL,
    [Greater]                INT            NOT NULL,
    [Direction]              NCHAR (10)     NOT NULL,
    [MaxCoordinateLongitude] FLOAT (53)     NOT NULL,
    [MaxCoordinateLatitude]  FLOAT (53)     NOT NULL,
    [MinCoordinateLongitude] FLOAT (53)     NOT NULL,
    [MinCoordinateLatitude]  FLOAT (53)     NOT NULL,
    [Image]                  IMAGE          NOT NULL,
    PRIMARY KEY CLUSTERED ([MapId] ASC)
);

