USE [RRSDashboard]
GO

INSERT INTO [dbo].[YardiClients]
           ([RrsId]
           ,[Enabled]
           ,[Automate]
           ,[Url]
           ,[UserId]
           ,[Password]
           ,[Server]
           ,[DatabaseId]
           ,[Platform]
           ,[YardiPropId]
           ,[PmcName])
     VALUES
           ('11111', 1, 0, 'www.h.com', 'testUser', 'beep', 'sqlsvr', 'dbID', 'Windows', 'propID1', '')
GO


