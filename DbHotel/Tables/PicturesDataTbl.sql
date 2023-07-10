CREATE TABLE [dbo].[PictureDataTbl]
(
    [hotelImageUrl] VARCHAR(200) NOT NULL, 
    [hotelName] VARCHAR(200) NOT NULL, 
    [hotelLocation] VARCHAR(200) NOT NULL, 
    [hotelPrice] NVARCHAR(50) NULL, 
    [hotelDescription] VARCHAR(300) NULL, 
    [hotelGroup] VARCHAR(200) NULL, 
    [hotelPopularity] VARCHAR(200) NULL, 
    [IsPopular] VARCHAR(20) NULL
)