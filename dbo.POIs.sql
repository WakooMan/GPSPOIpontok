CREATE TABLE [dbo].[DBPOIs] (
    [POIId]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Longitude]   FLOAT (53)     NOT NULL,
    [Latitude]    FLOAT (53)     NOT NULL,
    [Category]    NVARCHAR (MAX) NULL,
    [Image]       IMAGE          NULL,
	[MapId] INT NOT NULL
	FOREIGN KEY (MapId) REFERENCES DBMaps(MapId),
    PRIMARY KEY CLUSTERED ([POIId] ASC)
);

