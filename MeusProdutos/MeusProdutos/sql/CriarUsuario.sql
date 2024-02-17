--Referência
--https://serverfault.com/questions/422269/where-can-i-find-the-user-in-this-iis-error-login-failed-for-user-iis-appool-w

USE [master]
GO
CREATE LOGIN [IIS APPPOOL\AppProdutos] FROM WINDOWS WITH DEFAULT_DATABASE=[MeusProdutos]
GO

USE [MeusProdutos]
GO
CREATE USER [IIS APPPOOL\AppProdutos] FOR LOGIN [IIS APPPOOL\AppProdutos]
GO
EXEC sp_addrolemember N'db_owner', N'IIS APPPOOL\AppProdutos'
GO