--------------------------------------------Drop if exists----------------------------------------
ALTER TABLE [dbo].[t_ProductCategory] DROP CONSTRAINT [FK_t_ProductCategory_ToProducts]
GO
ALTER TABLE [dbo].[t_ProductCategory] DROP CONSTRAINT [FK_t_ProductCategory_ToCategories]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_ProductCategory]') AND type in (N'U'))
DROP TABLE [dbo].[t_ProductCategory]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_Categories]') AND type in (N'U'))
DROP TABLE [dbo].[t_Categories]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_Products]') AND type in (N'U'))
DROP TABLE [dbo].[t_Products]
GO

------------------------------[t_Categories]---------------------------------------------
CREATE TABLE [dbo].[t_Categories](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](100) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

------------------------------[t_Products]---------------------------------------------
CREATE TABLE [dbo].[t_Products](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](100) NULL,
 CONSTRAINT [PK_t_Products] PRIMARY KEY CLUSTERED (	[Id] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----------------------------[t_ProductCategory]---------------------------------------
CREATE TABLE [dbo].[t_ProductCategory](
	[ProductId] [uniqueidentifier] NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_t_ProductCategory] PRIMARY KEY CLUSTERED (	[ProductId] ASC, [CategoryId] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[t_ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_t_ProductCategory_ToCategories] FOREIGN KEY([CategoryId]) REFERENCES [dbo].[t_Categories] ([Id]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[t_ProductCategory] CHECK CONSTRAINT [FK_t_ProductCategory_ToCategories]
GO
ALTER TABLE [dbo].[t_ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_t_ProductCategory_ToProducts] FOREIGN KEY([ProductId]) REFERENCES [dbo].[t_Products] ([Id]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[t_ProductCategory] CHECK CONSTRAINT [FK_t_ProductCategory_ToProducts]
GO

------------------------------------------Insert------------------------------------------------------------------------

INSERT INTO [dbo].[t_Categories] ([Id], [Name]) VALUES (N'75cb84a5-307e-4a69-9072-1a255ae92525', N'Еда')
INSERT INTO [dbo].[t_Categories] ([Id], [Name]) VALUES (N'99fa8549-27d8-4993-8a9c-276fbf167af7', N'Оргтехника')
INSERT INTO [dbo].[t_Categories] ([Id], [Name]) VALUES (N'765ac03a-de70-4e0c-90ab-43550a50084f', N'Крепеж')
INSERT INTO [dbo].[t_Categories] ([Id], [Name]) VALUES (N'f78c39f5-2f97-479e-bf32-489ac8b007b5', N'Средства гигиены')

INSERT INTO [dbo].[t_Products] ([Id], [Name]) VALUES (N'a0284016-8f90-4784-a890-16ce6c98e0ab', N'Гвоздь                                                                                              ')
INSERT INTO [dbo].[t_Products] ([Id], [Name]) VALUES (N'ae389d08-e5b9-442e-9657-6bca4fbe8f41', N'Чай                                                                                                 ')
INSERT INTO [dbo].[t_Products] ([Id], [Name]) VALUES (N'8d5cd33d-f488-4229-b63c-8f7caa3df6ff', N'Мыло                                                                                                ')
INSERT INTO [dbo].[t_Products] ([Id], [Name]) VALUES (N'17b536f2-88a0-48a1-a1f8-992eb66f6ebc', N'Полотенце                                                                                           ')
INSERT INTO [dbo].[t_Products] ([Id], [Name]) VALUES (N'a1c8d52d-dbcb-447b-a59a-afc4650372d6', N'Зубная паста                                                                                        ')
INSERT INTO [dbo].[t_Products] ([Id], [Name]) VALUES (N'32ac9681-85f6-4f98-bfff-c070a5c33440', N'Печеньки                                                                                            ')
INSERT INTO [dbo].[t_Products] ([Id], [Name]) VALUES (N'9ce4049b-2a0e-4c46-88af-d09577805dd9', N'Саморез                                                                                             ')
INSERT INTO [dbo].[t_Products] ([Id], [Name]) VALUES (N'56d8457c-5359-445e-a40c-ddc462e9782a', N'Шуруп                                                                                               ')

INSERT INTO [dbo].[t_ProductCategory] ([ProductId], [CategoryId]) VALUES (N'a0284016-8f90-4784-a890-16ce6c98e0ab', N'765ac03a-de70-4e0c-90ab-43550a50084f')
INSERT INTO [dbo].[t_ProductCategory] ([ProductId], [CategoryId]) VALUES (N'ae389d08-e5b9-442e-9657-6bca4fbe8f41', N'75cb84a5-307e-4a69-9072-1a255ae92525')
INSERT INTO [dbo].[t_ProductCategory] ([ProductId], [CategoryId]) VALUES (N'8d5cd33d-f488-4229-b63c-8f7caa3df6ff', N'f78c39f5-2f97-479e-bf32-489ac8b007b5')
INSERT INTO [dbo].[t_ProductCategory] ([ProductId], [CategoryId]) VALUES (N'a1c8d52d-dbcb-447b-a59a-afc4650372d6', N'f78c39f5-2f97-479e-bf32-489ac8b007b5')
INSERT INTO [dbo].[t_ProductCategory] ([ProductId], [CategoryId]) VALUES (N'32ac9681-85f6-4f98-bfff-c070a5c33440', N'75cb84a5-307e-4a69-9072-1a255ae92525')
INSERT INTO [dbo].[t_ProductCategory] ([ProductId], [CategoryId]) VALUES (N'9ce4049b-2a0e-4c46-88af-d09577805dd9', N'765ac03a-de70-4e0c-90ab-43550a50084f')
INSERT INTO [dbo].[t_ProductCategory] ([ProductId], [CategoryId]) VALUES (N'56d8457c-5359-445e-a40c-ddc462e9782a', N'765ac03a-de70-4e0c-90ab-43550a50084f')

