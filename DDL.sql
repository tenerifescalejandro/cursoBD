-- CREACION DE LA TABLA MARCAS

CREATE TABLE [dbo].[Marcas](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[denominacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
	)
) 

GO

-- CREAMOS LA TABLA TIPO DE COMBUSTIBLE
CREATE TABLE [dbo].[TiposCombustible](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[denominacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposCombustible] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)
)

GO

-- CREAMOS LA TABLA DE COCHES
CREATE TABLE [dbo].[coches](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[matricula] [nchar](10) NOT NULL,
	[idMarca] [bigint] NOT NULL,
	[idTipoCOmbustible] [bigint] NOT NULL,
	[color] [nchar](20) NULL,
	[cilindrada] [decimal](4, 2) NULL,
	[nPlazas] [smallint] NOT NULL DEFAULT 5,
	[fechaMatriculacion] [date] NULL,
 CONSTRAINT [PK_coches] PRIMARY KEY CLUSTERED 
	(
	[id] ASC
	)
)

GO

-- CREACIÓN DE LA RELACION ENTRE COCHE Y MARCAS
ALTER TABLE [dbo].[coches]  
WITH CHECK ADD  CONSTRAINT [FK_coches_Marcas] FOREIGN KEY([idMarca])
REFERENCES [dbo].[Marcas] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[coches] CHECK CONSTRAINT [FK_coches_Marcas]
GO

-- CREACION DE LA RELACION ENTRE TIPOS DE COMBUSTIBLE Y COCHES
ALTER TABLE [dbo].[coches]  
WITH CHECK ADD  CONSTRAINT [FK_coches_TiposCombustible] FOREIGN KEY([idTipoCombustible])
REFERENCES [dbo].[TiposCombustible] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[coches] CHECK CONSTRAINT [FK_coches_TiposCombustible]
GO







