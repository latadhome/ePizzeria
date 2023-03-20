GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] ON
GO
INSERT INTO [dbo].[AspNetRoles](Id, Name,NormalizedName, ConcurrencyStamp)
values(1, 'Admin', 'ADMIN','9999') 
GO
INSERT INTO [dbo].[AspNetRoles](Id, Name,NormalizedName, ConcurrencyStamp)
values(2, 'User', 'USER','99999') 
Go
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF
GO


SET IDENTITY_INSERT [dbo].[Categories] ON
GO
insert into [dbo].[Categories](Id,Name,Description) values(1, 'Pizza','PIZZA')
GO
insert into [dbo].[Categories](Id,Name,Description) values(2, 'Beverages','TEST') -- NA for this assignment added as an extra sample value
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO

SET IDENTITY_INSERT [dbo].[ItemTypes] ON
GO
INSERT [dbo].[ItemTypes] ([Id], [Name]) VALUES (1, N'Veg')
GO
INSERT [dbo].[ItemTypes] ([Id], [Name]) VALUES (2, N'NonVeg')
GO
SET IDENTITY_INSERT [dbo].[ItemTypes] OFF
GO

INSERT INTO [dbo].[Toppings](Name,UnitPrice)VALUES('Cheese',1)
GO
INSERT INTO [dbo].[Toppings](Name,UnitPrice)VALUES('Capsicum',1)
GO
INSERT INTO [dbo].[Toppings](Name,UnitPrice)VALUES('Salami',1)
GO
INSERT INTO [dbo].[Toppings](Name,UnitPrice)VALUES('Olives',1)
GO
INSERT INTO [dbo].[Toppings](Name,UnitPrice)VALUES('Onions',1)
GO

