-- =====================================================================
-- ConsorAdmin - Script de instalacion COMPLETO de la base ConsorAdminDB
-- Une 01_CrearBaseDeDatos.sql (estructura) y 02_DatosIniciales.sql (datos) del proyecto,
-- sin las opciones propias de una version puntual de SQL Server (compatibilidad 160, Query Store, etc.).
-- Pensado para una instalacion NUEVA: el instalador no lo ejecuta si ConsorAdminDB ya tiene tablas.
-- =====================================================================

USE [master]
GO
IF DB_ID(N'ConsorAdminDB') IS NULL
    CREATE DATABASE [ConsorAdminDB]
GO
BEGIN TRY
    ALTER DATABASE [ConsorAdminDB] SET RECOVERY SIMPLE
END TRY
BEGIN CATCH
    PRINT N'No se pudo fijar el modo de recuperacion (se mantiene el de la instancia).'
END CATCH
GO
USE [ConsorAdminDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Bitacora_ID] [uniqueidentifier] NOT NULL,
	[Bitacora_FechaHora] [datetime] NOT NULL,
	[Bitacora_UsuarioID] [uniqueidentifier] NULL,
	[Bitacora_Actividad] [nvarchar](200) NOT NULL,
	[Bitacora_EntidadId] [nvarchar](100) NULL,
	[Bitacora_Detalle] [nvarchar](max) NULL,
	[DVH] [int] NOT NULL,
	CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED ([Bitacora_ID] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[CONSORCIO](
	[IdConsorcio] [int] IDENTITY(1,1) NOT NULL,
	[IdGestor] [nvarchar](50) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Direccion] [varchar](150) NOT NULL,
	[CantidadUnidades] [int] NOT NULL,
	[DVH] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	PRIMARY KEY CLUSTERED ([IdConsorcio] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[CONSORCISTA](
	[IdConsorcista] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[DNI] [varchar](15) NOT NULL,
	[Activo] [bit] NOT NULL,
	[DVH] [int] NOT NULL,
	PRIMARY KEY CLUSTERED ([IdConsorcista] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[DigitoVerificadorVertical](
	[DVV_ID] [uniqueidentifier] NOT NULL,
	[DVV_Tabla] [nvarchar](100) NOT NULL,
	[DVV_Atributo] [nvarchar](100) NOT NULL,
	[DVV_Valor] [int] NOT NULL,
	[DVV_FechaCalculo] [datetime] NOT NULL,
	CONSTRAINT [PK_DigitoVerificadorVertical] PRIMARY KEY CLUSTERED ([DVV_ID] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[EGRESO](
	[IdEgreso] [int] IDENTITY(1,1) NOT NULL,
	[IdConsorcio] [int] NOT NULL,
	[IdServicio] [int] NULL,
	[IdProveedor] [int] NULL,
	[Concepto] [varchar](200) NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[Fecha] [date] NOT NULL,
	[DVH] [int] NOT NULL,
	PRIMARY KEY CLUSTERED ([IdEgreso] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Etiqueta](
	[Etiqueta_ID] [nvarchar](50) NOT NULL,
	[Etiqueta_Descripcion] [nvarchar](50) NULL,
	[DVH] [int] NOT NULL,
	CONSTRAINT [PK_Etiqueta] PRIMARY KEY CLUSTERED ([Etiqueta_ID] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[EXPENSA](
	[IdExpensa] [int] IDENTITY(1,1) NOT NULL,
	[IdUnidadFuncional] [int] NOT NULL,
	[Periodo] [date] NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[FechaVencimiento] [date] NOT NULL,
	[HonorarioAplicado] [decimal](18, 2) NOT NULL,
	[CoeficienteAplicado] [decimal](18, 2) NOT NULL,
	[RecargoPorMora] [decimal](18, 2) NOT NULL,
	[Estado] [varchar](20) NOT NULL,
	[MotivoAnulacion] [varchar](200) NULL,
	[DVH] [int] NOT NULL,
	PRIMARY KEY CLUSTERED ([IdExpensa] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Familia_Patente](
	[Padre_ID] [nvarchar](50) NOT NULL,
	[Hijo_ID] [nvarchar](50) NOT NULL,
	[DVH] [int] NOT NULL
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[GASTO](
	[IdGasto] [int] IDENTITY(1,1) NOT NULL,
	[IdConsorcio] [int] NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[Periodo] [date] NOT NULL,
	[Rubro] [varchar](50) NOT NULL,
	[DVH] [int] NOT NULL,
	PRIMARY KEY CLUSTERED ([IdGasto] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Idioma](
	[Idioma_ID] [nvarchar](50) NOT NULL,
	[Idioma_Descripcion] [nvarchar](50) NULL,
	[Idioma_Default] [bit] NULL,
	[DVH] [int] NOT NULL,
	CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED ([Idioma_ID] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[ORDEN_PAGO](
	[IdOrdenPago] [int] IDENTITY(1,1) NOT NULL,
	[IdExpensa] [int] NOT NULL,
	[NumeroOrden] [int] NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[FechaVencimiento] [date] NOT NULL,
	[Estado] [varchar](20) NOT NULL,
	[PropietarioSnapshot] [varchar](200) NOT NULL,
	[DVH] [int] NOT NULL,
	PRIMARY KEY CLUSTERED ([IdOrdenPago] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[PAGO](
	[IdPago] [int] IDENTITY(1,1) NOT NULL,
	[IdExpensa] [int] NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[FechaPago] [date] NOT NULL,
	[MedioPago] [varchar](30) NOT NULL,
	[NumeroComprobante] [varchar](30) NOT NULL,
	[DVH] [int] NOT NULL,
	PRIMARY KEY CLUSTERED ([IdPago] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Permiso](
	[Permiso_ID] [nvarchar](50) NOT NULL,
	[Permiso_Descripcion] [nvarchar](50) NULL,
	[Permiso_Tipo] [int] NULL,
	[DVH] [int] NOT NULL,
	CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED ([Permiso_ID] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[PROVEEDOR](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Habilitado] [bit] NOT NULL,
	[DVH] [int] NOT NULL,
	PRIMARY KEY CLUSTERED ([IdProveedor] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[SERVICIO](
	[IdServicio] [int] IDENTITY(1,1) NOT NULL,
	[IdConsorcio] [int] NOT NULL,
	[IdProveedor] [int] NULL,
	[Categoria] [varchar](50) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[Costo] [decimal](18, 2) NOT NULL,
	[Estado] [varchar](30) NOT NULL,
	[IdUnidadFuncional] [int] NULL,
	[PlazoEstimado] [int] NULL,
	[FechaAsignacion] [date] NULL,
	[FechaPrestacion] [date] NULL,
	[DescripcionTrabajo] [varchar](500) NULL,
	[NumeroFactura] [varchar](30) NULL,
	[ArchivoAdjunto] [varchar](260) NULL,
	[MotivoRechazo] [varchar](200) NULL,
	[DVH] [int] NOT NULL,
	PRIMARY KEY CLUSTERED ([IdServicio] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
	PRIMARY KEY CLUSTERED ([diagram_id] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Traduccion](
	[Etiqueta_ID] [nvarchar](50) NOT NULL,
	[Idioma_ID] [nvarchar](50) NULL,
	[Traduccion_Traduccion] [nvarchar](300) NULL,
	[DVH] [int] NOT NULL
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[UNIDAD_CONSORCISTA](
	[IdUnidadFuncional] [int] NOT NULL,
	[IdConsorcista] [int] NOT NULL,
	[EsPropietario] [bit] NOT NULL,
	[DVH] [int] NOT NULL,
	CONSTRAINT [PK_UNIDAD_CONSORCISTA] PRIMARY KEY CLUSTERED ([IdUnidadFuncional] ASC, [IdConsorcista] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[UNIDAD_FUNCIONAL](
	[IdUnidadFuncional] [int] IDENTITY(1,1) NOT NULL,
	[IdConsorcio] [int] NOT NULL,
	[Numero] [varchar](20) NOT NULL,
	[Tipo] [varchar](30) NOT NULL,
	[Coeficiente] [decimal](18, 2) NOT NULL,
	[Activa] [bit] NOT NULL,
	[DVH] [int] NOT NULL,
	PRIMARY KEY CLUSTERED ([IdUnidadFuncional] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[UNIDAD_FUNCIONAL_C](
	[IdHistorico] [int] IDENTITY(1,1) NOT NULL,
	[IdUnidadFuncional] [int] NOT NULL,
	[IdConsorcio] [int] NOT NULL,
	[Numero] [varchar](20) NOT NULL,
	[Tipo] [varchar](30) NOT NULL,
	[Coeficiente] [decimal](18, 2) NOT NULL,
	[Activa] [bit] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Hora] [time](0) NOT NULL,
	[Act] [bit] NOT NULL,
	[Operacion] [varchar](20) NOT NULL,
	PRIMARY KEY CLUSTERED ([IdHistorico] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Usuario](
	[Usuario_ID] [nvarchar](50) NOT NULL,
	[Usuario_User] [nvarchar](50) NULL,
	[Usuario_Pass] [nvarchar](max) NULL,
	[Usuario_Bloq] [bit] NULL,
	[Usuario_Baja] [bit] NULL,
	[Usuario_DVH] [int] NULL,
	CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([Usuario_ID] ASC)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Usuario_Permiso](
	[Permiso_ID] [nvarchar](50) NOT NULL,
	[Usuario_ID] [nvarchar](50) NOT NULL,
	[DVH] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[sysdiagrams] ADD CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED ([principal_id] ASC, [name] ASC)
GO
CREATE NONCLUSTERED INDEX [IX_UNIDAD_FUNCIONAL_C_UF_Act] ON [dbo].[UNIDAD_FUNCIONAL_C] ([IdUnidadFuncional] ASC, [Act] ASC)
GO
ALTER TABLE [dbo].[Bitacora] ADD CONSTRAINT [DF_Bitacora_DVH] DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[CONSORCIO] ADD DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[CONSORCIO] ADD DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[CONSORCISTA] ADD DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[CONSORCISTA] ADD CONSTRAINT [DF_CONSORCISTA_DVH] DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[EGRESO] ADD DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Etiqueta] ADD CONSTRAINT [DF_Etiqueta_DVH] DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[EXPENSA] ADD DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Familia_Patente] ADD CONSTRAINT [DF_Familia_Patente_DVH] DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[GASTO] ADD CONSTRAINT [DF_GASTO_DVH] DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Idioma] ADD CONSTRAINT [DF_Idioma_DVH] DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[ORDEN_PAGO] ADD DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[PAGO] ADD DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Permiso] ADD CONSTRAINT [DF_Permiso_DVH] DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[PROVEEDOR] ADD CONSTRAINT [DF_PROVEEDOR_DVH] DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[PROVEEDOR] ADD DEFAULT ((1)) FOR [Habilitado]
GO
ALTER TABLE [dbo].[SERVICIO] ADD CONSTRAINT [DF_SERVICIO_DVH] DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Traduccion] ADD CONSTRAINT [DF_Traduccion_DVH] DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[UNIDAD_CONSORCISTA] ADD CONSTRAINT [DF_UNIDAD_CONSORCISTA_DVH] DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[UNIDAD_FUNCIONAL] ADD DEFAULT ((1)) FOR [Activa]
GO
ALTER TABLE [dbo].[UNIDAD_FUNCIONAL] ADD CONSTRAINT [DF_UNIDAD_FUNCIONAL_DVH] DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[Usuario_Permiso] ADD CONSTRAINT [DF_Usuario_Permiso_DVH] DEFAULT ((0)) FOR [DVH]
GO
ALTER TABLE [dbo].[CONSORCIO] WITH CHECK ADD CONSTRAINT [FK_CONSORCIO_Usuario] FOREIGN KEY([IdGestor])
REFERENCES [dbo].[Usuario] ([Usuario_ID])
GO
ALTER TABLE [dbo].[CONSORCIO] CHECK CONSTRAINT [FK_CONSORCIO_Usuario]
GO
ALTER TABLE [dbo].[EGRESO] WITH CHECK ADD CONSTRAINT [FK_EGRESO_CONSORCIO] FOREIGN KEY([IdConsorcio])
REFERENCES [dbo].[CONSORCIO] ([IdConsorcio])
GO
ALTER TABLE [dbo].[EGRESO] CHECK CONSTRAINT [FK_EGRESO_CONSORCIO]
GO
ALTER TABLE [dbo].[EGRESO] WITH CHECK ADD CONSTRAINT [FK_EGRESO_PROVEEDOR] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[PROVEEDOR] ([IdProveedor])
GO
ALTER TABLE [dbo].[EGRESO] CHECK CONSTRAINT [FK_EGRESO_PROVEEDOR]
GO
ALTER TABLE [dbo].[EGRESO] WITH CHECK ADD CONSTRAINT [FK_EGRESO_SERVICIO] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[SERVICIO] ([IdServicio])
GO
ALTER TABLE [dbo].[EGRESO] CHECK CONSTRAINT [FK_EGRESO_SERVICIO]
GO
ALTER TABLE [dbo].[EXPENSA] WITH CHECK ADD CONSTRAINT [FK_EXPENSA_UF] FOREIGN KEY([IdUnidadFuncional])
REFERENCES [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional])
GO
ALTER TABLE [dbo].[EXPENSA] CHECK CONSTRAINT [FK_EXPENSA_UF]
GO
ALTER TABLE [dbo].[GASTO] WITH CHECK ADD CONSTRAINT [FK_GASTO_CONSORCIO] FOREIGN KEY([IdConsorcio])
REFERENCES [dbo].[CONSORCIO] ([IdConsorcio])
GO
ALTER TABLE [dbo].[GASTO] CHECK CONSTRAINT [FK_GASTO_CONSORCIO]
GO
ALTER TABLE [dbo].[ORDEN_PAGO] WITH CHECK ADD CONSTRAINT [FK_ORDEN_PAGO_EXPENSA] FOREIGN KEY([IdExpensa])
REFERENCES [dbo].[EXPENSA] ([IdExpensa])
GO
ALTER TABLE [dbo].[ORDEN_PAGO] CHECK CONSTRAINT [FK_ORDEN_PAGO_EXPENSA]
GO
ALTER TABLE [dbo].[PAGO] WITH CHECK ADD CONSTRAINT [FK_PAGO_EXPENSA] FOREIGN KEY([IdExpensa])
REFERENCES [dbo].[EXPENSA] ([IdExpensa])
GO
ALTER TABLE [dbo].[PAGO] CHECK CONSTRAINT [FK_PAGO_EXPENSA]
GO
ALTER TABLE [dbo].[SERVICIO] WITH CHECK ADD CONSTRAINT [FK_SERVICIO_CONSORCIO] FOREIGN KEY([IdConsorcio])
REFERENCES [dbo].[CONSORCIO] ([IdConsorcio])
GO
ALTER TABLE [dbo].[SERVICIO] CHECK CONSTRAINT [FK_SERVICIO_CONSORCIO]
GO
ALTER TABLE [dbo].[SERVICIO] WITH CHECK ADD CONSTRAINT [FK_SERVICIO_PROVEEDOR] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[PROVEEDOR] ([IdProveedor])
GO
ALTER TABLE [dbo].[SERVICIO] CHECK CONSTRAINT [FK_SERVICIO_PROVEEDOR]
GO
ALTER TABLE [dbo].[SERVICIO] WITH CHECK ADD CONSTRAINT [FK_SERVICIO_UF] FOREIGN KEY([IdUnidadFuncional])
REFERENCES [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional])
GO
ALTER TABLE [dbo].[SERVICIO] CHECK CONSTRAINT [FK_SERVICIO_UF]
GO
ALTER TABLE [dbo].[UNIDAD_CONSORCISTA] WITH CHECK ADD CONSTRAINT [FK_UNIDAD_CONSORCISTA_Consorcista] FOREIGN KEY([IdConsorcista])
REFERENCES [dbo].[CONSORCISTA] ([IdConsorcista])
GO
ALTER TABLE [dbo].[UNIDAD_CONSORCISTA] CHECK CONSTRAINT [FK_UNIDAD_CONSORCISTA_Consorcista]
GO
ALTER TABLE [dbo].[UNIDAD_CONSORCISTA] WITH CHECK ADD CONSTRAINT [FK_UNIDAD_CONSORCISTA_UF] FOREIGN KEY([IdUnidadFuncional])
REFERENCES [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional])
GO
ALTER TABLE [dbo].[UNIDAD_CONSORCISTA] CHECK CONSTRAINT [FK_UNIDAD_CONSORCISTA_UF]
GO
ALTER TABLE [dbo].[UNIDAD_FUNCIONAL] WITH CHECK ADD CONSTRAINT [FK_UNIDAD_FUNCIONAL_CONSORCIO] FOREIGN KEY([IdConsorcio])
REFERENCES [dbo].[CONSORCIO] ([IdConsorcio])
GO
ALTER TABLE [dbo].[UNIDAD_FUNCIONAL] CHECK CONSTRAINT [FK_UNIDAD_FUNCIONAL_CONSORCIO]
GO
ALTER TABLE [dbo].[UNIDAD_FUNCIONAL_C] WITH CHECK ADD CONSTRAINT [FK_UNIDAD_FUNCIONAL_C_UF] FOREIGN KEY([IdUnidadFuncional])
REFERENCES [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional])
GO
ALTER TABLE [dbo].[UNIDAD_FUNCIONAL_C] CHECK CONSTRAINT [FK_UNIDAD_FUNCIONAL_C_UF]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE FUNCTION dbo.fn_diagramobjects() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
	
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE dbo.sp_alterdiagram
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE dbo.sp_creatediagram
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE dbo.sp_dropdiagram
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE dbo.sp_helpdiagramdefinition
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE dbo.sp_helpdiagrams
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE dbo.sp_renamediagram
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE dbo.sp_upgraddiagrams
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE TRIGGER dbo.TR_UNIDAD_FUNCIONAL_Insert
ON [dbo].[UNIDAD_FUNCIONAL]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO [dbo].[UNIDAD_FUNCIONAL_C]
        (IdUnidadFuncional, IdConsorcio, Numero, Tipo, Coeficiente, Activa, Fecha, Hora, Act, Operacion)
    SELECT
        i.IdUnidadFuncional, i.IdConsorcio, i.Numero, i.Tipo, i.Coeficiente, i.Activa,
        CAST(GETDATE() AS date), CAST(GETDATE() AS time(0)), 1, 'Alta'
    FROM inserted i;
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE TRIGGER dbo.TR_UNIDAD_FUNCIONAL_Update
ON [dbo].[UNIDAD_FUNCIONAL]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- solo las filas que cambiaron de verdad: recalcular los DV hace UPDATE del DVH en todas
    DECLARE @cambiadas TABLE (IdUnidadFuncional int, IdConsorcio int, Numero varchar(20), Tipo varchar(30), Coeficiente decimal(18, 2), Activa bit);
    INSERT INTO @cambiadas
    SELECT IdUnidadFuncional, IdConsorcio, Numero, Tipo, Coeficiente, Activa FROM inserted
    EXCEPT
    SELECT IdUnidadFuncional, IdConsorcio, Numero, Tipo, Coeficiente, Activa FROM deleted;

    UPDATE hc
    SET hc.Act = 0
    FROM [dbo].[UNIDAD_FUNCIONAL_C] hc
    INNER JOIN @cambiadas c ON c.IdUnidadFuncional = hc.IdUnidadFuncional
    WHERE hc.Act = 1;

    -- la restauracion la avisa la aplicacion en la misma sesion del UPDATE
    INSERT INTO [dbo].[UNIDAD_FUNCIONAL_C]
        (IdUnidadFuncional, IdConsorcio, Numero, Tipo, Coeficiente, Activa, Fecha, Hora, Act, Operacion)
    SELECT
        c.IdUnidadFuncional, c.IdConsorcio, c.Numero, c.Tipo, c.Coeficiente, c.Activa,
        CAST(GETDATE() AS date), CAST(GETDATE() AS time(0)), 1,
        CASE
            WHEN CAST(SESSION_CONTEXT(N'Operacion') AS varchar(20)) = 'Restauracion' THEN 'Restauracion'
            WHEN c.Activa = 0 AND d.Activa = 1 THEN 'Baja'
            WHEN c.Activa = 1 AND d.Activa = 0 THEN 'Reactivacion'
            ELSE 'Modificacion'
        END
    FROM @cambiadas c
    INNER JOIN deleted d ON d.IdUnidadFuncional = c.IdUnidadFuncional;
END

GO
USE [ConsorAdminDB]
GO
-- el historial se carga tal cual esta: los triggers no tienen que sumar filas nuevas
ALTER TABLE [dbo].[UNIDAD_FUNCIONAL] DISABLE TRIGGER ALL
GO
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'ddc08c19-bbcf-4c91-b2f0-00571925da51', CAST(N'2026-11-06T00:31:27.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 44)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'262d0d83-c0a6-4d66-87d4-00be931142fd', CAST(N'2026-11-06T20:50:31.000' AS DateTime), N'42d88568-a6ab-4d41-a377-a242d7b3fef7', N'Cierre de sesion', N'42d88568-a6ab-4d41-a377-a242d7b3fef7', N'', 86)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'fbfa8417-adf3-4c54-a13b-0a3a001ee795', CAST(N'2026-11-06T11:47:14.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 3)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'e459ab1b-2e46-4a62-be7f-0e9e47e70f5f', CAST(N'2026-11-06T11:56:02.000' AS DateTime), N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'Inicio de sesion', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'', 83)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'61551c68-8c20-4dcf-a7bd-190b52042528', CAST(N'2026-11-06T12:00:50.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Cierre de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 95)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'93422cb3-2c88-4c6d-b296-19244b06c34c', CAST(N'2026-11-06T00:42:20.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 44)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'f9aa5087-6717-4fbc-812a-1c5fcaeb51c3', CAST(N'2026-11-06T00:57:10.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 19)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'aa33de80-e317-4baf-8525-1e6d27d3ff3d', CAST(N'2026-11-06T11:42:54.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 93)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'f8f1b764-8365-40f3-8cf6-23450ac50039', CAST(N'2026-11-06T11:42:24.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Cierre de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 93)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'09cb5756-6b41-4393-b419-26ebda68eaf6', CAST(N'2026-11-06T12:01:15.000' AS DateTime), N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'Inicio de sesion', N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'', 0)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'e7e32272-7ec4-45ec-ac36-35594886f9fe', CAST(N'2026-11-06T12:00:47.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 56)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'aabf1310-5ec8-478f-a443-3a37f2850981', CAST(N'2026-11-06T20:43:03.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 4)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'8ed8bbe9-df12-44cb-b797-3a86714ba641', CAST(N'2026-11-06T11:52:01.000' AS DateTime), N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'Inicio de sesion', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'', 5)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'070fc783-6518-4b62-bd45-3d248458132a', CAST(N'2026-11-06T11:41:18.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 82)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'a8aee48f-0c0f-48a4-a435-3fe5e6c0adeb', CAST(N'2026-11-06T11:47:35.000' AS DateTime), N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'Inicio de sesion', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'', 92)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'acbe9c69-01b1-47df-a2c3-458d30c73781', CAST(N'2026-11-06T11:56:20.000' AS DateTime), N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'Cierre de sesion', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'', 35)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'6d3d512b-40c6-4784-9c9c-4960db6699f4', CAST(N'2026-11-06T00:32:09.000' AS DateTime), N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'Cierre de sesion', N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'', 31)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'c2fc712d-2353-46ec-bd58-4a50576f3dfb', CAST(N'2026-11-06T11:28:30.000' AS DateTime), N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'Inicio de sesion', N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'', 65)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'671d2318-dbc9-4274-9e60-4b5ddaeb8444', CAST(N'2026-11-06T11:45:58.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Modificacion Usuario', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'asd', 81)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'1ca4214e-b530-4c4c-8a81-54ef41bcef70', CAST(N'2026-11-06T11:41:12.000' AS DateTime), N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'Cierre de sesion', N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'', 41)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'56340124-2c10-4f4a-aa08-5afd935a89eb', CAST(N'2026-11-06T11:47:23.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Modificacion Usuario', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'asd', 67)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'83559b46-4b90-48a8-8eab-604e695f1621', CAST(N'2026-11-06T20:44:38.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 63)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'45bf7089-7ac8-4b0e-b3eb-681a14a1bb4f', CAST(N'2026-11-06T11:41:55.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Baja Usuario', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'asd', 69)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'261a6e2a-ba06-4dd8-8cc4-73225c6571ac', CAST(N'2026-11-06T11:28:21.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 50)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'9738b5bf-7791-4ea7-b0e7-7488ea53f56c', CAST(N'2026-11-06T20:43:16.000' AS DateTime), N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'Inicio de sesion', N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'', 91)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'e77c155e-386e-4f6b-87df-74c025772727', CAST(N'2026-11-06T20:50:19.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Cierre de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 52)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'e8c79859-825c-44cd-8cb2-76021c502b5e', CAST(N'2026-11-06T20:50:24.000' AS DateTime), N'42d88568-a6ab-4d41-a377-a242d7b3fef7', N'Inicio de sesion', N'42d88568-a6ab-4d41-a377-a242d7b3fef7', N'', 72)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'0155697b-102d-43c2-a738-7e3bcecdb1ce', CAST(N'2026-11-06T18:30:48.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Restauracion de unidad funcional', N'2', N'1B', 1)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'3e86ce87-e418-4255-9bd9-802b40d5dc50', CAST(N'2026-11-06T11:28:24.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Cierre de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 58)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'a55ec85c-f4e0-4d4f-87ab-81ccd8cff459', CAST(N'2026-11-06T11:47:46.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 90)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'528ee8db-947d-4955-b5ea-831112631f4b', CAST(N'2026-11-06T18:19:42.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 90)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'47df0333-1d04-43db-a171-836301d47eea', CAST(N'2026-11-06T11:47:57.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Modificacion Usuario', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'asd', 93)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'3562f6b6-ec5e-45d4-85d3-8f2bf1e2d640', CAST(N'2026-11-06T00:31:52.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Cierre de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 56)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'01bb4d2b-abbd-4226-a026-9874c8a2eb30', CAST(N'2026-11-06T11:47:27.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Cierre de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 28)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'87ae79a5-a6e0-4a43-92e1-98b4d60d5624', CAST(N'2026-11-06T00:38:46.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 68)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'f461be3b-35b2-44bc-828d-a47519d0d0c7', CAST(N'2026-11-06T00:31:59.000' AS DateTime), N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'Inicio de sesion', N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'', 50)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'1e97cf58-1d29-4a03-9748-a5499c8e8e83', CAST(N'2026-11-06T12:00:56.000' AS DateTime), N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'Inicio de sesion', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'', 92)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'39fee57d-04fb-4c91-a0b9-ac7771a2f631', CAST(N'2026-11-06T11:41:40.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Baja Usuario', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'asd', 59)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'03159a16-870e-4714-81f5-b6ddd0cb3025', CAST(N'2026-11-06T20:43:09.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Cierre de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 66)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'4250ba1c-493e-4e97-ad95-bf2d0dbb093a', CAST(N'2026-11-06T11:45:44.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Baja Usuario', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'asd', 94)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'a15cdb0b-8520-4733-ae2b-c236fe6f7b89', CAST(N'2026-11-06T11:42:10.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 50)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'aaaf9252-1b39-4557-a167-c4b8d6bc4a70', CAST(N'2026-11-06T18:30:13.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 47)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'cb5b518e-d4c1-4083-aba1-c7e727e6a764', CAST(N'2026-11-06T20:50:16.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Modificacion Usuario', N'42d88568-a6ab-4d41-a377-a242d7b3fef7', N'adminbasic', 82)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'3803409c-74ad-4bf5-9fe3-c9179a5fc4b2', CAST(N'2026-11-06T13:45:28.000' AS DateTime), N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'Inicio de sesion', N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'', 5)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'597042d4-26b2-444d-bf85-d272975a4661', CAST(N'2026-11-06T11:40:45.000' AS DateTime), N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'Inicio de sesion', N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'', 80)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'a1214f84-3c61-40fc-bdbb-d7e8d379870d', CAST(N'2026-11-06T11:48:02.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Cierre de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 16)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'67ec04d5-9155-4ea5-8c09-e257e7a804d1', CAST(N'2026-11-06T00:52:21.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 76)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'b25c27d6-7b86-406c-8d2b-e2d3ec944775', CAST(N'2026-11-06T00:33:09.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 76)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'272e0331-8bee-498f-8073-e656f7e77263', CAST(N'2026-11-06T11:45:59.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Baja Usuario', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'asd', 7)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'f6c54ec1-48ef-43fe-9bba-e66738731cde', CAST(N'2026-11-06T00:38:58.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Modificacion de unidad funcional', N'2', N'1B', 32)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'b9da91bc-7864-4b3f-9594-ea72d968b9da', CAST(N'2026-11-06T20:44:55.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Modificacion Usuario', N'42d88568-a6ab-4d41-a377-a242d7b3fef7', N'adminbasic', 81)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'2e712f26-af9c-41fa-8000-eb6719c170e8', CAST(N'2026-11-06T11:48:10.000' AS DateTime), N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'Inicio de sesion', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'', 80)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'f0ff2061-6d39-40bf-b135-eb9877711217', CAST(N'2026-11-06T11:47:40.000' AS DateTime), N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'Cierre de sesion', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'', 70)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'8bfba087-eebd-44cc-9f26-efdddc50452d', CAST(N'2026-11-06T12:24:27.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 13)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'5dcc3b61-82e1-40c1-8181-f17c3055cb97', CAST(N'2026-11-06T20:49:30.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Inicio de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 91)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'e827c903-7825-425c-88dc-f26670851c99', CAST(N'2026-11-06T11:45:42.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Baja Usuario', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'asd', 58)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'9bcc34c0-d178-4442-975f-f63bc401fad9', CAST(N'2026-11-06T11:41:59.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Cierre de sesion', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'', 25)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'18055c59-a183-4783-9d94-f7cce2fc4141', CAST(N'2026-11-06T11:45:58.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Baja Usuario', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'asd', 86)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'aa28d922-43da-4c37-8fb8-fbd7087ca2f1', CAST(N'2026-11-06T11:45:44.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Modificacion Usuario', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'asd', 89)
INSERT [dbo].[Bitacora] ([Bitacora_ID], [Bitacora_FechaHora], [Bitacora_UsuarioID], [Bitacora_Actividad], [Bitacora_EntidadId], [Bitacora_Detalle], [DVH]) VALUES (N'50bb7ca8-adc4-48b9-a5d5-fc3913d345c1', CAST(N'2026-11-06T11:45:19.000' AS DateTime), N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'Modificacion Usuario', N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'asd', 31)
GO
SET IDENTITY_INSERT [dbo].[CONSORCISTA] ON
GO
INSERT [dbo].[CONSORCISTA] ([IdConsorcista], [Nombre], [Apellido], [DNI], [Activo], [DVH]) VALUES (1, N'Juan', N'Perez', N'28111222', 1, 15)
INSERT [dbo].[CONSORCISTA] ([IdConsorcista], [Nombre], [Apellido], [DNI], [Activo], [DVH]) VALUES (2, N'Maria', N'Gomez', N'30222333', 1, 55)
INSERT [dbo].[CONSORCISTA] ([IdConsorcista], [Nombre], [Apellido], [DNI], [Activo], [DVH]) VALUES (3, N'Carlos', N'Lopez', N'25333444', 1, 1)
INSERT [dbo].[CONSORCISTA] ([IdConsorcista], [Nombre], [Apellido], [DNI], [Activo], [DVH]) VALUES (4, N'Ana', N'Diaz', N'33444555', 1, 18)
INSERT [dbo].[CONSORCISTA] ([IdConsorcista], [Nombre], [Apellido], [DNI], [Activo], [DVH]) VALUES (5, N'Laura', N'Fernandez', N'27555666', 1, 84)
INSERT [dbo].[CONSORCISTA] ([IdConsorcista], [Nombre], [Apellido], [DNI], [Activo], [DVH]) VALUES (6, N'Pedro', N'Romero', N'31666777', 1, 60)
INSERT [dbo].[CONSORCISTA] ([IdConsorcista], [Nombre], [Apellido], [DNI], [Activo], [DVH]) VALUES (7, N'Sofia', N'Ruiz', N'35777888', 1, 33)
INSERT [dbo].[CONSORCISTA] ([IdConsorcista], [Nombre], [Apellido], [DNI], [Activo], [DVH]) VALUES (8, N'Diego', N'Torres', N'29888999', 1, 23)
INSERT [dbo].[CONSORCISTA] ([IdConsorcista], [Nombre], [Apellido], [DNI], [Activo], [DVH]) VALUES (9, N'Lucia', N'Castro', N'34999000', 1, 25)
INSERT [dbo].[CONSORCISTA] ([IdConsorcista], [Nombre], [Apellido], [DNI], [Activo], [DVH]) VALUES (10, N'Martin', N'Silva', N'26000111', 1, 29)
INSERT [dbo].[CONSORCISTA] ([IdConsorcista], [Nombre], [Apellido], [DNI], [Activo], [DVH]) VALUES (11, N'Elena', N'Mora', N'24111333', 1, 86)
INSERT [dbo].[CONSORCISTA] ([IdConsorcista], [Nombre], [Apellido], [DNI], [Activo], [DVH]) VALUES (12, N'Hector', N'Vega', N'22333555', 0, 76)
GO
SET IDENTITY_INSERT [dbo].[CONSORCISTA] OFF
GO
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'68d4f18e-bdaf-4edb-a4de-069c2b45f6b0', N'PROVEEDOR', N'*', 55, CAST(N'2026-11-06T11:57:54.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'2c053e92-1d15-40ec-81c5-25951e0b4115', N'CONSORCIO', N'*', 83, CAST(N'2026-11-06T11:57:54.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'8e9f0b0a-1eda-4339-b91d-265446170572', N'Bitacora', N'*', 42, CAST(N'2026-11-06T20:50:31.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'd3b214de-d82c-4433-a296-3024db596139', N'GASTO', N'*', 91, CAST(N'2026-11-06T11:57:54.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'f87de8ca-5a41-43e1-ab84-512f2ce10aa0', N'Traduccion', N'*', 46, CAST(N'2026-11-18T13:54:01.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'4d400ac1-a98b-4b14-9318-520d714babf8', N'UNIDAD_CONSORCISTA', N'*', 64, CAST(N'2026-11-06T11:57:54.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'72e0ad5a-b907-42b1-ac0a-6b8010f87264', N'PAGO', N'*', 91, CAST(N'2026-11-06T11:57:54.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'9dc224ba-8fd3-4c6c-aa8d-774a6d817cb7', N'ORDEN_PAGO', N'*', 92, CAST(N'2026-11-06T11:57:54.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'3eb5e2b0-fc83-403a-b236-af9655300399', N'Familia_Patente', N'*', 11, CAST(N'2026-11-18T12:53:14.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'34e1c098-1d7d-4cca-8104-bbc4aec866c4', N'EXPENSA', N'*', 25, CAST(N'2026-11-06T11:57:54.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'5b1f2033-c919-4cbb-9342-bfa11a7d43bf', N'Idioma', N'*', 23, CAST(N'2026-11-06T11:57:54.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'a930954c-230d-48c2-8d25-c0703cd7d347', N'Permiso', N'*', 60, CAST(N'2026-11-18T13:57:50.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'e757ab15-a778-4bf4-b579-c3e2553b7e7a', N'EGRESO', N'*', 6, CAST(N'2026-11-06T11:57:54.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'db1ab7d7-2082-45ae-b98b-c6b4e929b95e', N'CONSORCISTA', N'*', 82, CAST(N'2026-11-06T11:57:54.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'4cbe9df0-187d-4a14-8051-ce75e9b5693b', N'SERVICIO', N'*', 34, CAST(N'2026-11-06T11:57:54.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'5515c69c-8055-4b6c-ad54-d12157a06edf', N'Usuario', N'*', 29, CAST(N'2026-11-06T20:50:16.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'6e10bfce-0edb-46b8-920b-db43a7de1a2f', N'UNIDAD_FUNCIONAL', N'*', 21, CAST(N'2026-11-06T18:30:48.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'7cd65f5a-cdd4-435c-9d93-e225b3aaedab', N'Usuario_Permiso', N'*', 21, CAST(N'2026-11-06T20:50:16.000' AS DateTime))
INSERT [dbo].[DigitoVerificadorVertical] ([DVV_ID], [DVV_Tabla], [DVV_Atributo], [DVV_Valor], [DVV_FechaCalculo]) VALUES (N'cbfe1d05-2200-407e-8cb5-e8bf5f9a2704', N'Etiqueta', N'*', 30, CAST(N'2026-11-18T13:57:50.000' AS DateTime))
GO
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'0029FAE8-E7B0-4D87-A90E-8E3EF5A65A6E', N'lb_ser_titulo', 68)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'015C0CE6-A40E-42FB-95C4-82E9E86381D3', N'lb_adjuntar', 96)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'0281DEBB-BF27-453D-A7BA-072785A680EC', N'lb_reporte_servicios', 33)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'028939DD-5401-4165-AB35-1DB787457233', N'lb_ubicacion', 77)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'03869D17-2055-415C-BF57-C298DC5C461B', N'lb_repserv_por_proveedor', 96)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'044a9a0d-08c2-4bab-9eb3-9a9e7f1b4486', N'btn_nuevo', 92)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'044dfdb4-a803-4624-b938-c95472d8f276', N'lb_familias', 28)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'05FAD6BD-87FC-4BE2-896B-10F01D3777E2', N'lb_repserv_elegir_consorcio', 69)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'068e9177-a7f1-4e97-8f57-c5c9627676e6', N'lb_backupRestore', 96)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'06AA4364-4352-43D7-8173-3BF64875217E', N'lb_integridadRecalcularConfirm', 9)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'083B5D46-ABAC-4704-9122-B65D1A84F219', N'lb_repglobal_col_expensado', 59)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'0893014D-D171-406A-9D8E-0B5E97DB62E6', N'lb_asignado_el', 75)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'08FA8DD4-AD81-4610-B85E-32B4B5C8BD15', N'lb_ser_ok_serializar', 13)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'0A91BE84-0148-4049-BAE8-B003C63B1865', N'lb_repserv_pdf_error', 74)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'0ab7c06f-34af-40ac-85ce-28e6dc39ca75', N'lb_col_pagado', 50)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'0B3CF967-73F9-439F-83AC-D3BC4AA99F38', N'lb_integridadRecalcularError', 72)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'0c92ba8f-480b-493b-ad66-f87d4e33f922', N'btn_inactivar', 34)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'0d17a004-7d47-43b8-baf9-5bcdf36d3807', N'lb_numero_orden', 82)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'0ec5791f-63e9-418d-bb70-3df3536a409d', N'lb_saldo_disponible', 47)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'10D71AA6-D825-40EE-B73C-257BA29B53CB', N'lb_desde', 6)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'1146F046-85D8-4443-9842-5483A6F2EFCC', N'lb_integridadPersiste', 9)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'115c9fd3-47d0-4715-9699-f28b5bffd357', N'btn_salir', 66)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'11d1cd30-b8fb-4ffe-8b1f-9e5d65a6d6b0', N'lb_menu_morosidad', 61)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'11F7FC2C-E2D6-4D7A-A51E-D9241B0CA8CD', N'lb_archivo_opcional', 40)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'127cee6a-681d-43e0-9031-da374ad68d12', N'lb_concepto', 9)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'12b2a186-e319-4703-ae4c-f5bc8ceb62ec', N'lb_tab_consorcistas', 95)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'14008F42-AF4B-4796-8CF3-611D0DD59D68', N'lb_sin_consorcios', 71)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'17B42034-10A6-4BC5-B764-69A28EA23983', N'lb_repglobal_desde', 3)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'17EC9087-21F5-4E3E-9E15-3B7762204355', N'lb_menu_servicios', 51)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'18fc3515-cc0b-4e06-9cc8-a3647212ffd2', N'lb_estado_cuenta', 71)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'1aaa3f4d-009e-4d18-b76e-60b132be738b', N'lb_usuario_log', 51)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'1afe9243-597c-4ae4-b085-83cbfbcad5a8', N'lb_col_costo', 60)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'1b87d0a1-53f7-4832-aa93-f348ab5f6afd', N'lb_vencimiento', 31)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'1c9f7db5-4149-4a9f-a1ef-24a95376d664', N'lb_col_activa', 6)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'1F3A5BB9-8E50-44F2-8AD2-2A566AD44FFA', N'lb_motivo_rechazo', 14)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'1fcd96f3-29f2-4ae8-ac11-1929a3094464', N'lb_col_incluye_recargo', 53)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'209CFCCD-809D-4E6E-8C24-643D09976D89', N'lb_export_error', 78)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'20b35fff-aa35-4417-8def-69f25376c2e6', N'lb_col_periodo', 81)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'20f739fa-e437-4dab-9257-cdbb1ae9bb78', N'btn_desbloquear', 41)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'21b377d2-6823-4ceb-8eb4-dc5344087b33', N'lb_estado_fondo', 31)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'21ea18ad-064f-4703-853e-5d63b06f2ca7', N'lb_tab_composicion', 94)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'220bbad3-a4c4-46b1-bb2c-11465af94583', N'lb_detalle_periodo_unidad', 5)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'226CA783-BE13-45B2-B58A-7570BFA74599', N'lb_repglobal_total_expensado', 31)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'23107bd3-f511-4c84-9528-a11346bfc11a', N'lb_Idioma', 71)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'2320CE48-AA6F-43EF-B318-440D0A168C13', N'lb_grp_asignacion', 85)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'240c12f3-b541-49f8-91fa-f6293db4d678', N'lb_col_monto_adeudado', 48)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'24f3d6ab-d835-4285-a744-826eafe88c17', N'lb_CerrarSesion', 23)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'2820e73c-a8ee-4501-80a9-afc59df9a834', N'btn_bloquear', 15)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'2b94590e-8a9c-4182-8ae1-7371185d361d', N'lb_permisos_fam', 88)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'2BBB3F89-5FDA-41F7-AF54-0C8B43D10C08', N'lb_ayuda_seguridad', 5)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'2C0315A3-3621-4543-AA61-446AE74E8630', N'lb_todos', 25)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'2EA7F11E-43C3-4644-B012-126B8A551455', N'lb_ayuda_temas', 7)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'2f05d59e-dc83-43c9-91a3-cb69639e915b', N'lb_traduccion', 36)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'2fe3b25e-b141-42b2-a828-25cd7b3bff62', N'lb_bienvenido', 30)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'314b660b-605d-4300-b98f-005184f8be11', N'lb_col_descripcion', 92)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'317E213B-D157-401C-9765-1CEE2AA20C72', N'lb_integridadDescripcion', 51)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'337811ab-6849-4a6a-a619-28c58034e5c6', N'lb_pct_honorario', 71)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'34CA2F3F-95DF-40E0-BA65-E1810511D0E5', N'lb_fecha', 11)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'34f4a63e-234b-4777-98ed-645754aecd6f', N'lb_gestor', 72)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'3509f38e-8ca7-4e76-9965-98d08a712980', N'lb_sesion', 7)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'3674A0EE-CCDF-410C-9CA7-DF77C3B921A2', N'btn_habilitar', 9)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'372f7212-73ab-4231-abfe-e67b15f0c5f0', N'lb_menu_revisar_composicion', 25)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'38738E04-7253-4722-8A18-88043FC2A043', N'btn_integridadRestaurar', 50)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'391ABDBF-F122-4B11-9B4D-5A920988D5AB', N'lb_confirmar_carga', 48)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'3acfb399-c330-4d14-a729-198fe6bea356', N'lb_fecha_vencimiento', 46)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'3afb5ef7-c5bd-45c2-a2b3-3f129eb51afc', N'lb_grp_unidad_propietario', 58)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'3aff9740-25fc-412a-8bd6-74a6e71c7e07', N'lb_registrar_egreso', 83)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'3c173344-e1a0-46f7-ab8c-745902173a8b', N'lb_estado', 86)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'3c986b89-004d-45c2-8a0b-ce3c35b21c0b', N'btn_backup', 14)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'3CB5240A-D4C8-4248-855C-08E3A9EE74A6', N'lb_numero_factura', 62)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'3cd4d8e2-ea17-4352-91f8-ef681c8116cf', N'lb_patentes', 43)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'3D5FD455-5841-47A9-B2F3-0CE98039924E', N'lb_repserv_col_descripcion', 55)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'3D78727E-91D7-46F0-95AE-ED4635061641', N'lb_ser_aviso', 46)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'3e92927e-2f11-4103-9dba-2572e14b8b28', N'lb_col_rubro', 42)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'3ea4d2f0-9de7-4a71-ae80-968bfac82b24', N'lb_col_nombre', 75)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'3f47cb56-8d09-47c2-8b91-79f07a8eaf79', N'lb_tab_unidades', 54)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'40dadff1-b6f3-466c-b456-b2c6613484bc', N'btn_cancelar', 52)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'41952A9A-C1DE-473F-88FE-BCF475691B30', N'btn_buscar', 22)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'4372bca4-aade-4ee5-97ea-d3e3e322d6c8', N'lb_baseDeDatos', 32)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'4545490C-E67D-4BC3-8419-F0E35071539A', N'lb_repserv_col_costo', 18)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'4710fea8-8117-4774-97d3-719af36ab1b6', N'lb_apellido', 42)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'4860B2D2-3E5A-424F-B009-F9CD24322BCD', N'lb_ayuda', 74)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'487fbd54-993c-4d73-9b93-8736a83fe834', N'lb_tipo', 20)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'48EBE6C4-5DCC-4911-96BB-D985287FC2AF', N'lb_confirmar_asignacion', 31)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'4AE03DC9-C8A0-40C4-9FC0-EF966B33A1DF', N'lb_detalle', 89)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'4C3462FF-BFAE-4136-9F58-889EA86BA43C', N'lb_col_detalle', 39)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'4c545932-afc9-4ea9-ba6b-d0580924c806', N'lb_NombreFamilia', 19)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'501fde6e-472d-4bc6-af5a-8c95ae52b1f9', N'lb_pagado', 59)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'5281ceb1-96f4-4e8c-b6ee-49932a7ff696', N'lb_col_vencimiento', 51)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'53033514-acb4-40f5-9f74-5b39267c5b6b', N'lb_nombre_usuario', 28)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'531c74e5-eac9-4288-b5e3-980881e4b943', N'lb_restoreError', 45)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'54801AFF-55CE-4D5C-9096-C5FE52D6DEDC', N'lb_col_habilitado', 12)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'54E145E0-9947-4F5D-96BC-E22035C3B0CE', N'lb_asignar_proveedor', 9)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'56127605-0D20-46D0-A11D-271B90C9D760', N'lb_ser_consorcio', 60)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'563DDB45-FB8F-4B0A-AEE9-6866598E362C', N'lb_ser_err_formato', 9)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'565E23F4-CF82-4CB8-AD2C-F3D1BA56EA1D', N'chk_filtrar_fecha', 46)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'569d6ab8-3ade-468b-9f97-000a913e9f61', N'lb_col_monto_expensa', 88)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'577512a2-8e28-4e1b-98b1-eaa1f198b16c', N'lb_medio_pago', 65)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'57a6b460-03ec-4441-a49c-6da9363cc556', N'lb_expensa_titulo', 66)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'57fa4025-1b0a-4979-bcf3-36073c79530c', N'lb_total_gastos', 65)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'58965D25-ADE7-496B-9604-4AC0443FDE72', N'lb_costo', 50)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'58a8ff7c-6ae4-4aa1-8f6d-d694cbf26855', N'lb_NuevoIdioma', 55)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'5C57E01D-D6D4-4B77-99E9-BB69A822A638', N'lb_repglobal_total_saldo', 79)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'5E5F5093-2D4C-4BDE-836D-ACBEF33750FF', N'lb_hasta', 82)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'611237b1-0d3d-483c-8991-5ea9ea8bc398', N'lb_col_dni', 67)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'6163F04B-EE6E-41B6-9A26-631ED7CA465D', N'lb_repglobal_col_egresos', 78)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'61d61ffe-7bb2-4065-9f44-b00c51c2104d', N'lb_monto', 60)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'62BCF934-59E1-4286-B325-22488502A2B5', N'lb_integridadRestoreConfirm', 62)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'654632ee-3103-40c6-8af2-95a12dbf764c', N'lb_consorcio', 54)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'6605dc45-7368-47cf-8e0a-3929bd541fbf', N'btn_crear', 72)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'66613f7c-8f3d-4620-b3f2-5602667c2da0', N'lb_numero', 36)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'668DD673-4E8E-4C25-929C-DFB238686C7D', N'lb_ser_col_estado', 87)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'67638ADF-8472-4BAF-AE87-A7B848BE71F0', N'lb_repglobal_hasta', 5)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'67A6E0B9-2D08-498D-A292-3EDB4EA40E03', N'lb_confirmar_solicitud', 19)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'67F0813C-4617-4B9D-BCB7-C22271E33361', N'lb_debe_indicar_motivo', 35)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'68273691-fb28-48ce-8b71-5008a07ff305', N'lb_col_recargo', 31)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'692B2CD9-29C5-4F1C-8E67-8DACBF76728E', N'lb_repserv_costo_acumulado', 44)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'693EE6DC-EDD4-41B2-9036-8AE6260AE2E8', N'lb_tab_proveedores', 86)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'6a1b1a7c-3c86-4403-ad94-06cfa0c32153', N'lb_col_activo', 91)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'6a20b07a-5231-43b9-9c81-84785c69ecf7', N'lb_grp_expensa_sel', 84)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'6a5355ef-46a1-4b47-ade6-896293c58f0c', N'lb_col_estado', 60)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'6b54a899-ce68-46a2-bf66-786beb51e39f', N'lb_col_tipo', 83)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'6C24BBF5-E056-4AB0-B60F-70486FBA768C', N'lb_ser_err_no_existe', 25)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'6C3A7ED0-92BE-4063-AF35-D5E58FCD9AD4', N'lb_sistema_no_disponible', 80)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'6C59506F-FED8-46D2-8D8B-78829E1054F8', N'lb_repserv_col_consorcio', 54)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'6d0d3e9e-ad73-4b10-bbca-486326191afd', N'lb_coeficiente', 33)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'6D139769-6072-49C3-8FF2-C540F058CB47', N'lb_integridadSesionInvalida', 49)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'70F2BACB-75FC-4FE0-A4F9-E5B9D8D32303', N'lb_repglobal_col_costo_servicios', 95)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'70f8ab73-9abe-4cf1-919f-28902733484f', N'lb_menu_liquidacion', 36)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'7158a7d7-b9ef-46f0-9b73-28ea04cd142f', N'btn_restaurar', 95)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'73576b05-d0a3-40f2-9771-abfc83d69e6b', N'lb_dni', 35)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'73b9cfef-0cdd-4ea2-8ec7-a7b77d6517a6', N'lb_col_honorario', 31)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'73E1E71C-7CAB-45CF-8EA9-0568AE83BCE1', N'lb_export_ok', 14)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'75a09cab-44e7-4bc4-bd7b-a9d16a947989', N'lb_pass', 10)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'75f3ce77-b54a-4254-9d28-332683b46bf4', N'lb_Usuarios', 36)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'7651A2F6-BBB0-491E-B46B-A717953D3753', N'lb_integridadColFila', 71)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'793b0d56-4d6d-4c4c-a4c7-6359f44e523e', N'btn_guardar', 85)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'7A97F2AB-85CF-43E1-8108-CCCB3AC3A904', N'lb_ser_err_serializar', 78)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'7ce4fbf7-8410-4ff8-9171-52b1f15c72cd', N'lb_grp_consorcista', 64)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'7EB0E730-17FE-44BC-96A7-8CC279212F7C', N'lb_plazo_invalido', 68)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8157DD81-2EB8-445A-AB72-7B8204316F7D', N'lb_exportar_pdf', 41)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'815C9FA1-ACD6-41C8-9A6B-77E2A0BB84D5', N'lb_plazo_dias', 64)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'816a1dbf-ff75-48f7-9805-e2a66b189980', N'lb_propietario', 68)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8379C8D9-FB2D-49F7-B828-A2D23A9374F4', N'lb_ser_menu', 87)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'84362c84-7d8f-43c4-99c1-21736e439846', N'btn_nuevo_user', 22)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'84f45660-4a23-456e-826b-76b2be87161e', N'lb_recargo_mora', 9)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'85A02EE5-8726-4596-90F9-7BBDE9237913', N'lb_actividad', 8)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'860AC279-4AE0-42D9-AD50-360CFF766114', N'lb_recargo_por_mora', 72)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'882FAEA7-1F48-4272-BAD6-2456D2BECFE4', N'lb_repglobal_col_servicios', 52)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8902F2DA-27E2-4ACF-9641-1231B6EC0F8A', N'lb_grp_solicitud_servicio', 15)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'89c4777b-288c-4084-a170-2c1044ec94a6', N'lb_permisos_user', 8)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8a7e1826-55b4-4171-8f21-8afa5a5efc14', N'lb_Usuario', 32)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8A8EC489-5672-461C-A9F3-AA822686A375', N'lb_repglobal_sin_datos', 93)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8B07B29D-5F53-401B-9DE9-4433D1947631', N'btn_inhabilitar', 75)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8B3100D4-CD43-48F8-ABE4-5B9436975589', N'btn_integridadRecalcular', 92)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8c56658c-cff1-4108-a5b8-06081b29c44d', N'lb_tab_consorcios', 60)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8c789e28-6359-44e8-8403-e56238625c1c', N'btn_generar_liq', 88)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8d34b8ae-ac8b-492a-8f7e-164cc7029b43', N'lb_descripcion', 31)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8D3E8231-925C-4CCD-AB3F-836EB111246D', N'lb_aprobar_prestacion', 76)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8D87A2FE-BD24-4C42-B03B-2742B613FC68', N'lb_grp_prestacion', 69)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8e10e0f8-22ef-4590-9c5e-8008aba95379', N'lb_col_cant_unidades', 16)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8E89F7A9-84F6-4576-9F66-A671EF464F76', N'lb_repserv_generar', 76)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8E94852E-67E9-47DB-93D1-D212D139F877', N'lb_ser_col_monto', 76)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8eb66d3f-1ce5-40b8-a9b4-0a493c655cc6', N'lb_generar_orden_pago', 44)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8F15AC4F-2295-4CE9-A566-71DAF3B65677', N'lb_integridadTablaCompleta', 87)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8fb8afd1-ce9a-4cbd-bd54-3dc11fa94b29', N'lb_saldo_insuficiente', 63)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'8fdd0317-4173-4d82-91f7-8c7336618f84', N'lb_direccion', 31)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'900bf7bf-0c0e-4d6b-be6a-16172b1f8f32', N'btn_ingresar', 10)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'909e1b38-c80e-4e03-a567-971987c70b24', N'btn_emitir_pdf', 6)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'91831522-515b-4c85-96bb-e0347abd344c', N'lb_morosidad_titulo', 38)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'929ed924-daaa-446c-9038-5eed718100fd', N'lb_honorario_aplicado', 95)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'9476A9A8-88F2-4DEB-BB9E-D8A17F3F7400', N'lb_rechazar_prestacion', 1)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'968b1aa2-6943-411e-a269-8562812dff65', N'lb_total_egresado', 73)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'98E51D0C-863D-4337-BE1D-2CDA8F610B34', N'lb_ayuda_cerrar', 24)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'9915392d-8b8c-4303-8c56-e8ee5a2da444', N'btn_anular', 61)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'9A60DC43-C0C5-410D-8BB9-DFDCD59F05CB', N'lb_proveedor', 63)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'9bd06464-45fa-45eb-8944-b7efa6faf355', N'btn_quitar_propietario', 86)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'9bf705d7-364c-4fc2-a0c3-7d853a1e143c', N'btn_nueva_fam', 60)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'9EBDC75E-B711-45F1-8545-C64D9288A3A1', N'lb_plazo_estimado', 57)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'9EC7607B-5B7E-4758-B95E-DF3F722B1770', N'lb_repglobal_total_cobrado', 64)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'9eff5e12-219a-4240-9136-8bb91bf9f0a3', N'lb_motivo', 7)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'a0385bc1-b7bc-4a88-91d3-8d3c6d49e9f2', N'lb_col_apellido', 48)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'A190D95E-0690-4256-AADC-5DF111822AB9', N'lb_repserv_col_estado', 43)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'A35BAC05-2AE3-4DAF-9DDA-B60CDA61B352', N'lb_col_fecha', 19)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'A58A4EC6-33D4-4333-A4A5-5257E99E23C1', N'lb_ser_col_vencimiento', 27)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'a59a69c2-387a-4c7c-a456-f937612d2922', N'lb_cant_unidades', 64)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'a76564e8-e6fe-4c07-86bb-8f0a89895310', N'lb_completar', 4)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'a76b3665-eda1-4c12-a386-e31872814beb', N'lb_col_cuotas_pend', 94)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'a78f60f7-db85-4476-b642-ef46739e0013', N'lb_periodo', 39)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'a7e8ff9c-e96a-4201-89ad-1c689121238d', N'lb_grp_insumo', 32)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'a948ecff-cdcd-4f02-8c33-7db69e9b553e', N'lb_email', 33)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'AA73C037-DA18-4430-AEFC-79428FC990A3', N'lb_repserv_por_consorcio', 3)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'aa95a8f3-4378-4717-935e-1d976013433c', N'lb_grp_talon', 85)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'AC35DA3F-D420-45BE-B6DF-A479C63AD02C', N'lb_integridadTitulo', 93)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'ac5f497a-8b59-48fc-977a-994b354a4b99', N'lb_col_categoria', 29)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'AEB26C5C-FDE5-4124-BA38-C1638DC5E2D5', N'lb_cargar_prestacion', 14)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'AF1F9627-6E0A-4272-9138-7AB0CA18F6FC', N'btn_exportar_csv', 48)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'AF36861F-1529-40F2-9941-21537B3FF110', N'lb_reporte_global', 57)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'affccf9d-8805-4200-88c9-9bacddf6e907', N'lb_gastos', 61)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'b109db41-318f-40ca-8084-09bc1f196f2d', N'lb_principal', 79)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'B1F02BED-0A93-4B30-84C6-A5C85D78DF03', N'lb_col_proveedor', 47)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'B6DD63F5-03AA-42F5-AC22-AE19D47FDE2C', N'lb_comprobante', 23)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'b7075cf2-256c-441e-8565-57ec187ba476', N'lb_col_unidad_propia', 46)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'b8a16bc3-821e-43b2-a128-4bccf3756b80', N'lb_grp_consorcio', 65)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'B8BB1004-8AF1-404E-A12F-44F5A68ED6DD', N'lb_integridadColTabla', 1)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'b9b94610-760c-4318-8a72-50ef041c4844', N'lb_col_gestor', 29)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'BA6717F9-4796-476D-B041-9A9CCBE20EB4', N'lb_repglobal_col_cobrado', 81)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'bb2e2560-08c8-478f-b17b-a00257789260', N'lb_anular_expensa', 1)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'bc494311-5884-4ff7-a230-ac602a95ed32', N'lb_backupError', 46)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'bc741753-3845-45c4-982d-10bcef1baf00', N'lb_generar_liquidacion', 24)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'BC9E5938-EF43-4799-A7F7-81DFCFE71789', N'lb_repglobal_col_saldo', 9)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'c3b226a0-0d17-49db-91fb-1198ed130bc6', N'lb_unidad', 54)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'c4d4afe1-caea-4462-8f27-4f108c96f1c9', N'lb_mant_consorcios', 64)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'C5C356B8-3EB4-4DE8-8464-EFE074D64C7F', N'lb_reporte_gestion', 26)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'c90d11bc-8291-46f3-b1e5-311233bcb26a', N'lb_col_monto', 90)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'c9795dad-544d-463e-8b86-4915ddb18721', N'lb_col_numero', 1)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'c9aa39f7-bd3f-4414-9e27-672e87243d67', N'btn_asignar_propietario', 56)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'cb3b20a4-a331-4e13-a471-1e80ff8a1fc3', N'lb_grp_composicion', 17)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'CB91F00F-61D3-4653-87ED-443F4EED87FB', N'lb_repglobal_col_deuda', 75)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'cc81b6ed-1384-4183-8fda-7d19a60951bb', N'lb_usuario_incorrecto', 46)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'CD76E8DF-7509-4024-A0B2-1D97E5FD8768', N'lb_id', 54)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'ce18847f-5352-4693-a9d3-b469382c4199', N'lb_col_direccion', 57)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'cf2b5ee7-50cb-4d2b-9549-375be52ccc22', N'lb_IniciarSesion', 57)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'CFCFCD38-A935-47D1-9342-90690835715C', N'btn_integridadCancelar', 56)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'd0bfb81e-69ca-49b0-95d3-168de11ac219', N'lb_grp_motivo_anulacion', 40)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'D0D482EB-265C-40D2-A3A4-C8B585C8F5A6', N'lb_repserv_elegir_proveedor', 86)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'd145117b-4a75-4d3a-966a-c0e936dc21cf', N'btn_reactivar', 25)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'd1f1c435-f2b2-4cfd-b093-40e232c41e8b', N'lb_nombre', 89)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'D216E868-4EFA-4EDF-BA4B-126DD4CC7E1D', N'lb_emitir_estado_cuenta', 62)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'D3113814-AA3C-4C9A-8EF7-242B18DE7D58', N'lb_repglobal_col_cobranza', 90)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'd40e4b79-90cf-481f-a310-72a06a08b5d4', N'btn_aceptar', 6)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'd5bd301a-da9c-4e40-89e1-44817f341b6a', N'lb_TraduccionPara', 39)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'd5d12fb0-128d-48b4-8b1b-4c768aa2f8ea', N'lb_permisos', 61)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'd6a04a0d-f84d-4b58-97ea-4968a3909ad1', N'btn_agregar', 13)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'd742b29e-d823-4920-a78b-30860302750b', N'lb_unidad_o_consorcio', 62)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'd898aa4d-4c26-4fa5-862a-ba3320fb7988', N'lb_unidad_funcional', 39)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'da5b66ac-2cdb-41d5-8b71-2cdca5c30b4e', N'btn_quitar', 66)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'DA7FEDD0-CF63-46D8-8969-0045915890E3', N'lb_coeficiente_aplicado', 66)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'DABAA01A-1B3E-4012-BC80-A800F2826553', N'lb_repserv_pdf_ok', 76)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'DB3C7036-D46D-4A87-9231-A9201019C93C', N'lb_grp_proveedor', 5)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'DB55D3FA-298F-4F81-A93D-28AD71756C6D', N'lb_repglobal_col_gastos', 4)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'DC249D14-60F0-4306-B308-0F488063A7FC', N'lb_solicitud_registrada', 72)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'dc58600a-8a57-495a-9b65-6baf164212e1', N'lb_pass_incorrecta', 96)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'DC6EE97D-B309-4852-A3A3-4B20A02CEF70', N'lb_repglobal_pdf_archivo', 35)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'dc85a7fa-f09b-4076-beaa-08b48ed9c79b', N'lb_total_recaudado', 39)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'dcce9329-609f-41d2-a879-424b8e6a48c8', N'lb_col_periodos_adeudados', 21)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'DD25673D-9C9A-403A-8430-8B24310A5B78', N'lb_ser_err_leer', 45)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'DE66B0B8-5332-4911-AD82-1EFE773609F3', N'lb_repglobal_col_puesto', 69)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'deb99801-ef38-4c73-87ad-b6ced32f2e6c', N'lb_grp_liquidacion', 42)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'df1322c5-eb73-4b17-9132-0a85049c0591', N'lb_backupOk', 27)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'df550ea4-4f4d-405f-bf5a-4d17b450683e', N'lb_original', 55)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'E03CC91B-B0E9-4122-81E2-5E6FBCB14E90', N'lb_bitacora', 89)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'e2c9531c-fe3c-4ca9-88fe-e20df69827f6', N'lb_col_dias_atraso', 31)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'E357A085-6D87-42A4-85D0-6BD603809164', N'lb_ser_serializar', 89)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'e443ecf8-4dc2-4685-b753-5d05811d9a31', N'lb_cobrar_expensa', 39)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'e4e2ace2-193a-4f78-9397-77811e7e0ecd', N'btn_confirmar_egreso', 61)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'E5F99194-923F-49E5-8DE6-710A91AAB47E', N'lb_usuario_baja', 82)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'E634B6ED-1020-4D33-9FE5-96CF644F8136', N'lb_integridadColCampos', 12)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'e6f0a916-06d3-425f-8692-b936ce37fadc', N'lb_restoreOk', 78)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'e7b080a3-22ca-4017-813b-b66cbf37c7a8', N'lb_usuario_bloqueado', 96)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'E7F3D988-2A7E-4D8A-BE3B-582770975CEC', N'lb_trabajo_realizado', 36)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'e8613d24-c4e5-45ca-b7bc-e38880d9721c', N'lb_menu_emitir_estado_cuenta', 68)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'e939cc14-7b57-466f-92e1-6a4e98fbadb1', N'lb_deslog_1', 36)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'E967497F-C530-4A26-8D54-A31093662155', N'lb_area_comun', 23)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'e9ada15a-841a-4935-82f9-26a26c9b4acf', N'lb_col_coeficiente', 10)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'e9d5634d-f72a-4864-b775-c73185f03293', N'lb_restoreConfirm', 53)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'eb5167b0-8005-467e-ad1f-b96f7cc5061e', N'lb_coeficiente_utilizado', 52)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'EF1E38CA-BD57-4B4D-86D1-442B8F260B60', N'lb_col_baja', 41)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'EFE522DC-8775-4981-8C18-FC5DDB08C7ED', N'lb_ser_col_periodo', 79)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'F0CDA8B6-34A2-4481-B4B3-80C55BB2DDE7', N'lb_repglobal_totales', 31)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'F1B6462D-9DBC-4420-BDB5-50C5F6481C2D', N'lb_formalizar_solicitud', 48)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'F28053DE-EFF9-4241-A694-AD9C23072840', N'lb_grp_detalle_prestacion', 45)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'F32CA16D-FAA9-4926-A06C-32965C65D035', N'lb_ser_deserializar', 74)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'f49742e2-de65-48ea-b8e2-77e249626f97', N'btn_editar_datos', 3)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'f5950eb9-e473-4dd9-99c2-aa576c43e149', N'lb_col_saldo_adeudado', 65)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'f6bd2051-e8c6-42e7-a1fb-bda5759292ff', N'btn_nueva', 63)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'F8AC711F-4E74-407A-A1D8-15DCB519B2E7', N'lb_repglobal_total_deuda', 16)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'f95619b2-e0ba-445d-a16c-e499610c6d69', N'lb_saldo', 84)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'f9648ae2-914f-46f2-824b-d59ea29399aa', N'lb_grp_nuevo_gasto', 90)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'fb038457-183a-41df-b87c-05a877cbb455', N'lb_obtener_estado_fondo', 4)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'fba792bb-3144-4857-99f2-a47b8353a10b', N'lb_rubro', 24)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'FDCBDE2A-8830-47D8-9A08-AEC0D14B788C', N'lb_repglobal_col_unidades', 54)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'fe276011-5849-44b7-bd8e-c0f951a5a051', N'lb_col_periodo_acento', 11)
INSERT [dbo].[Etiqueta] ([Etiqueta_ID], [Etiqueta_Descripcion], [DVH]) VALUES (N'FE3BB30B-E480-418B-9814-BE7CD5BD0A0B', N'lb_categoria', 7)
GO
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'28a2317f-4de7-4976-8810-bf9fc517c6ea', N'7acb2457-162c-480e-85bb-c444d223d1ab', 29)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'28a2317f-4de7-4976-8810-bf9fc517c6ea', N'b226e845-3ae7-42fd-809a-77a5f1f0ebf1', 83)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'28a2317f-4de7-4976-8810-bf9fc517c6ea', N'ce0d646b-f902-472d-8c00-b94f4a026ae9', 78)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'28a2317f-4de7-4976-8810-bf9fc517c6ea', N'27b3f0bd-6c96-4e03-b0ab-a2ca218200a0', 69)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'36ba3111-3d42-4766-9c54-542f17a247b2', N'27b3f0bd-6c96-4e03-b0ab-a2ca218200a0', 12)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'36ba3111-3d42-4766-9c54-542f17a247b2', N'ce0d646b-f902-472d-8c00-b94f4a026ae9', 21)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'28a2317f-4de7-4976-8810-bf9fc517c6ea', N'5bbb22c9-99fc-4a3f-ac0a-ca25af2157ae', 84)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'54eb6ad4-9ede-4764-a1f1-253b1f475e7a', 94)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'a2ae1c92-a11e-43e6-b87c-1a665d7ce200', 47)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'8662b692-cead-4abe-a741-941266db46bf', 65)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'4896f0a7-1f7b-4dd4-aa3b-a9389e4b2fbb', 29)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'28a2317f-4de7-4976-8810-bf9fc517c6ea', N'0288fddb-0aaa-4a0b-9f53-423a4d719ee8', 37)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'28a2317f-4de7-4976-8810-bf9fc517c6ea', N'573a9f39-e19d-4d5f-92cb-24079eeca4f3', 34)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'5fe7efe7-7cbd-409a-9bfd-8ea2b95987e4', 4)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'404c5f26-5ed3-4237-980e-421f45891af0', 34)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'573a9f39-e19d-4d5f-92cb-24079eeca4f3', 66)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'9b3e1f52-6c4a-4d7e-8a21-5f0c7e2d1a93', 60)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'99d3af7d-b13a-4222-b2f8-63d5b0aa1fa2', 67)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'0aa74983-dab0-4017-89ae-5d196d7c15fa', 70)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'1d8b0752-1f0e-472d-bac4-ade2457d4e7d', 70)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'79ef7615-6b9c-47aa-9bc7-057466da1e3f', 7)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'93b99fff-2b70-4383-9db3-be4e02228c14', 49)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'28a2317f-4de7-4976-8810-bf9fc517c6ea', N'4b98017f-acf5-4d30-90ab-1a24882564a4', 61)
INSERT [dbo].[Familia_Patente] ([Padre_ID], [Hijo_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'4b98017f-acf5-4d30-90ab-1a24882564a4', 93)
GO
INSERT [dbo].[Idioma] ([Idioma_ID], [Idioma_Descripcion], [Idioma_Default], [DVH]) VALUES (N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Español', 1, 61)
INSERT [dbo].[Idioma] ([Idioma_ID], [Idioma_Descripcion], [Idioma_Default], [DVH]) VALUES (N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Inglés', 0, 78)
GO
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'0288fddb-0aaa-4a0b-9f53-423a4d719ee8', N'mnuMantenimientoConsorcios_755ME', 16, 67)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'0AA74983-DAB0-4017-89AE-5D196D7C15FA', N'mnuCargarPrestacion_755ME', 19, 3)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'1D8B0752-1F0E-472D-BAC4-ADE2457D4E7D', N'mnuAsignarProveedor_755ME', 18, 78)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'27b3f0bd-6c96-4e03-b0ab-a2ca218200a0', N'baseDeDatosToolStripMenuItem', 4, 40)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'28a2317f-4de7-4976-8810-bf9fc517c6ea', N'Admin', NULL, 41)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'36ba3111-3d42-4766-9c54-542f17a247b2', N'BasicoAdmin', NULL, 20)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'404c5f26-5ed3-4237-980e-421f45891af0', N'mnuRegistrarEgreso_755ME', 12, 34)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'4896f0a7-1f7b-4dd4-aa3b-a9389e4b2fbb', N'mnuGenerarLiquidacion_755ME', 9, 73)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'4b98017f-acf5-4d30-90ab-1a24882564a4', N'mnuReporteGlobal_755ME', 23, 37)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'54eb6ad4-9ede-4764-a1f1-253b1f475e7a', N'mnuAnularExpensa_755ME', 6, 21)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'573a9f39-e19d-4d5f-92cb-24079eeca4f3', N'mnuSerializarExpensas_755ME', 21, 38)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'5BBB22C9-99FC-4A3F-AC0A-CA25AF2157AE', N'bitacoraToolStripMenuItem', 5, 75)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'5fe7efe7-7cbd-409a-9bfd-8ea2b95987e4', N'mnuGenerarOrdenPago_755ME', 11, 19)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'79EF7615-6B9C-47AA-9BC7-057466DA1E3F', N'mnuFormalizarSolicitud_755ME', 17, 17)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'7acb2457-162c-480e-85bb-c444d223d1ab', N'familiasToolStripMenuItem', 1, 45)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'8662b692-cead-4abe-a741-941266db46bf', N'mnuReporteGestion_755ME', 8, 23)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'93B99FFF-2B70-4383-9DB3-BE4E02228C14', N'mnuAprobarPrestacion_755ME', 20, 9)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'99d3af7d-b13a-4222-b2f8-63d5b0aa1fa2', N'mnuGestGastos_755ME', 15, 58)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'9b3e1f52-6c4a-4d7e-8a21-5f0c7e2d1a93', N'mnuReporteServicios_755ME', 22, 70)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'a2ae1c92-a11e-43e6-b87c-1a665d7ce200', N'mnuCobrarExpensa_755ME', 7, 1)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'b226e845-3ae7-42fd-809a-77a5f1f0ebf1', N'usuariosToolStripMenuItem', 2, 52)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'ce0d646b-f902-472d-8c00-b94f4a026ae9', N'nuevoIdiomaToolStripMenuItem', 3, 8)
INSERT [dbo].[Permiso] ([Permiso_ID], [Permiso_Descripcion], [Permiso_Tipo], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'Gestor de consorcios', NULL, 3)
GO
SET IDENTITY_INSERT [dbo].[PROVEEDOR] ON
GO
INSERT [dbo].[PROVEEDOR] ([IdProveedor], [Nombre], [Habilitado], [DVH]) VALUES (1, N'Plomeria Rapida SRL', 1, 51)
INSERT [dbo].[PROVEEDOR] ([IdProveedor], [Nombre], [Habilitado], [DVH]) VALUES (2, N'Electricidad del Sur', 1, 90)
INSERT [dbo].[PROVEEDOR] ([IdProveedor], [Nombre], [Habilitado], [DVH]) VALUES (3, N'Gas Seguro SA', 1, 82)
INSERT [dbo].[PROVEEDOR] ([IdProveedor], [Nombre], [Habilitado], [DVH]) VALUES (4, N'Pintura Express', 0, 40)
GO
SET IDENTITY_INSERT [dbo].[PROVEEDOR] OFF
GO
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'a948ecff-cdcd-4f02-8c33-7db69e9b553e', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Email', 85)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'a948ecff-cdcd-4f02-8c33-7db69e9b553e', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'E-mail', 33)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'900bf7bf-0c0e-4d6b-be6a-16172b1f8f32', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Ingresar', 77)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'900bf7bf-0c0e-4d6b-be6a-16172b1f8f32', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Enter', 44)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'115c9fd3-47d0-4715-9699-f28b5bffd357', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Salir', 87)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'115c9fd3-47d0-4715-9699-f28b5bffd357', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Exit', 6)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'75a09cab-44e7-4bc4-bd7b-a9d16a947989', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Contraseña', 15)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'75a09cab-44e7-4bc4-bd7b-a9d16a947989', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Password', 56)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2fe3b25e-b141-42b2-a828-25cd7b3bff62', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Bienvenido', 68)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2fe3b25e-b141-42b2-a828-25cd7b3bff62', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Welcome', 41)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'cc81b6ed-1384-4183-8fda-7d19a60951bb', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Usuario Incorrecto', 29)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'cc81b6ed-1384-4183-8fda-7d19a60951bb', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Incorrect User', 19)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'dc58600a-8a57-495a-9b65-6baf164212e1', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Contraseña Incorrecta', 9)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'dc58600a-8a57-495a-9b65-6baf164212e1', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Incorrect Password', 92)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e7b080a3-22ca-4017-813b-b66cbf37c7a8', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Usuario Bloqueado', 69)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e7b080a3-22ca-4017-813b-b66cbf37c7a8', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Blocked User', 68)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3509f38e-8ca7-4e76-9965-98d08a712980', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Sesión', 76)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3509f38e-8ca7-4e76-9965-98d08a712980', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Session', 39)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'cf2b5ee7-50cb-4d2b-9549-375be52ccc22', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Iniciar Sesión', 16)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'cf2b5ee7-50cb-4d2b-9549-375be52ccc22', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Log In', 65)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'24f3d6ab-d835-4285-a744-826eafe88c17', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Cerrar Sesión', 60)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'24f3d6ab-d835-4285-a744-826eafe88c17', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Log Out', 66)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'75f3ce77-b54a-4254-9d28-332683b46bf4', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Usuarios', 44)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'75f3ce77-b54a-4254-9d28-332683b46bf4', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Users', 95)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'044dfdb4-a803-4624-b938-c95472d8f276', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Familias', 44)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'044dfdb4-a803-4624-b938-c95472d8f276', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Families', 4)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'23107bd3-f511-4c84-9528-a11346bfc11a', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Idioma', 77)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'23107bd3-f511-4c84-9528-a11346bfc11a', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Language', 41)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'58a8ff7c-6ae4-4aa1-8f6d-d694cbf26855', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Nuevo Idioma', 82)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'58a8ff7c-6ae4-4aa1-8f6d-d694cbf26855', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'New Language', 45)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e939cc14-7b57-466f-92e1-6a4e98fbadb1', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'¿Quiere salir?', 48)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e939cc14-7b57-466f-92e1-6a4e98fbadb1', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Do you want to exit?', 76)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'20f739fa-e437-4dab-9257-cdbb1ae9bb78', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Desbloquear', 4)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'20f739fa-e437-4dab-9257-cdbb1ae9bb78', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Unlock', 35)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'f49742e2-de65-48ea-b8e2-77e249626f97', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Editar Datos', 63)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'f49742e2-de65-48ea-b8e2-77e249626f97', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Edit', 14)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2820e73c-a8ee-4501-80a9-afc59df9a834', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Bloquear', 26)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2820e73c-a8ee-4501-80a9-afc59df9a834', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Block', 74)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'84362c84-7d8f-43c4-99c1-21736e439846', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Nuevo Usuario', 48)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'84362c84-7d8f-43c4-99c1-21736e439846', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'New User', 88)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'89c4777b-288c-4084-a170-2c1044ec94a6', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Permisos Usuario', 12)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'89c4777b-288c-4084-a170-2c1044ec94a6', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'User Permissions', 17)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2b94590e-8a9c-4182-8ae1-7371185d361d', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Permisos de la Familia', 88)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2b94590e-8a9c-4182-8ae1-7371185d361d', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Family Permissions', 50)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3cd4d8e2-ea17-4352-91f8-ef681c8116cf', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Patentes', 67)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3cd4d8e2-ea17-4352-91f8-ef681c8116cf', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Patents', 96)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'da5b66ac-2cdb-41d5-8b71-2cdca5c30b4e', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Quitar-->', 51)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'da5b66ac-2cdb-41d5-8b71-2cdca5c30b4e', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Remove-->', 85)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd6a04a0d-f84d-4b58-97ea-4968a3909ad1', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'<--Agregar', 13)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd6a04a0d-f84d-4b58-97ea-4968a3909ad1', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'<--Add', 18)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd5d12fb0-128d-48b4-8b1b-4c768aa2f8ea', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Permisos', 65)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd5d12fb0-128d-48b4-8b1b-4c768aa2f8ea', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Permissions', 80)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd40e4b79-90cf-481f-a310-72a06a08b5d4', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Aceptar', 93)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd40e4b79-90cf-481f-a310-72a06a08b5d4', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Ok', 74)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'793b0d56-4d6d-4c4c-a4c7-6359f44e523e', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Guardar', 66)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'793b0d56-4d6d-4c4c-a4c7-6359f44e523e', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Save', 71)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'40dadff1-b6f3-466c-b456-b2c6613484bc', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Cancelar', 12)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'40dadff1-b6f3-466c-b456-b2c6613484bc', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Cancel', 62)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8a7e1826-55b4-4171-8f21-8afa5a5efc14', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Usuario', 11)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8a7e1826-55b4-4171-8f21-8afa5a5efc14', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'User', 30)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'1aaa3f4d-009e-4d18-b76e-60b132be738b', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Usuario Logueado', 6)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'1aaa3f4d-009e-4d18-b76e-60b132be738b', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Logged User', 90)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9bf705d7-364c-4fc2-a0c3-7d853a1e143c', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Nueva Familia', 95)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9bf705d7-364c-4fc2-a0c3-7d853a1e143c', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'New Family', 1)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6605dc45-7368-47cf-8e0a-3929bd541fbf', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Crear', 49)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6605dc45-7368-47cf-8e0a-3929bd541fbf', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Create', 27)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'4c545932-afc9-4ea9-ba6b-d0580924c806', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Nombre de la Familia', 19)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'4c545932-afc9-4ea9-ba6b-d0580924c806', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Family Name', 18)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'df550ea4-4f4d-405f-bf5a-4d17b450683e', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Original', 86)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'df550ea4-4f4d-405f-bf5a-4d17b450683e', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Original', 59)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2f05d59e-dc83-43c9-91a3-cb69639e915b', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Traduccion', 44)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2f05d59e-dc83-43c9-91a3-cb69639e915b', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Translation', 12)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'a76564e8-e6fe-4c07-86bb-8f0a89895310', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Completar idioma', 21)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'a76564e8-e6fe-4c07-86bb-8f0a89895310', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Complete Language', 0)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd5bd301a-da9c-4e40-89e1-44817f341b6a', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Traduccion para', 37)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd5bd301a-da9c-4e40-89e1-44817f341b6a', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Translation for', 7)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'b109db41-318f-40ca-8084-09bc1f196f2d', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Principal', 52)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'b109db41-318f-40ca-8084-09bc1f196f2d', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Main', 1)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'4372bca4-aade-4ee5-97ea-d3e3e322d6c8', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Base de Datos', 56)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'4372bca4-aade-4ee5-97ea-d3e3e322d6c8', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Database', 86)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'068e9177-a7f1-4e97-8f57-c5c9627676e6', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Backup / Restaurar', 39)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'068e9177-a7f1-4e97-8f57-c5c9627676e6', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Backup / Restore', 87)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3c986b89-004d-45c2-8a0b-ce3c35b21c0b', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Hacer Backup', 73)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3c986b89-004d-45c2-8a0b-ce3c35b21c0b', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Make Backup', 25)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'7158a7d7-b9ef-46f0-9b73-28ea04cd142f', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Restaurar', 3)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'7158a7d7-b9ef-46f0-9b73-28ea04cd142f', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Restore', 79)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'df1322c5-eb73-4b17-9132-0a85049c0591', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Backup realizado con exito', 29)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'df1322c5-eb73-4b17-9132-0a85049c0591', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Backup completed successfully', 32)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'bc494311-5884-4ff7-a230-ac602a95ed32', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Error al realizar el backup', 82)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'bc494311-5884-4ff7-a230-ac602a95ed32', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Error performing backup', 88)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e6f0a916-06d3-425f-8692-b936ce37fadc', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Base de datos restaurada con exito', 60)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e6f0a916-06d3-425f-8692-b936ce37fadc', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Database restored successfully', 19)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'531c74e5-eac9-4288-b5e3-980881e4b943', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Error al restaurar la base de datos', 57)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'531c74e5-eac9-4288-b5e3-980881e4b943', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Error restoring database', 53)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e9d5634d-f72a-4864-b775-c73185f03293', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Esta accion reemplaza los datos actuales. Desea continuar?', 23)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e9d5634d-f72a-4864-b775-c73185f03293', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'This action replaces the current data. Do you want to continue?', 30)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'AC35DA3F-D420-45BE-B6DF-A479C63AD02C', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Resolución de integridad', 80)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'AC35DA3F-D420-45BE-B6DF-A479C63AD02C', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Integrity resolution', 23)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'317E213B-D157-401C-9765-1CEE2AA20C72', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Se detectó una inconsistencia en los datos (posible manipulación fuera del sistema). Elija cómo resolverla:', 44)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'317E213B-D157-401C-9765-1CEE2AA20C72', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'An inconsistency was detected in the data (possible manipulation outside the system). Choose how to resolve it:', 19)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'38738E04-7253-4722-8A18-88043FC2A043', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Restaurar desde backup', 63)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'38738E04-7253-4722-8A18-88043FC2A043', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Restore from backup', 0)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8B3100D4-CD43-48F8-ABE4-5B9436975589', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Recalcular dígitos verificadores', 6)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8B3100D4-CD43-48F8-ABE4-5B9436975589', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Recalculate check digits', 20)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'CFCFCD38-A935-47D1-9342-90690835715C', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Cancelar', 22)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'CFCFCD38-A935-47D1-9342-90690835715C', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Cancel', 72)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'62BCF934-59E1-4286-B325-22488502A2B5', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Esta acción reemplaza los datos actuales por los del backup. ¿Desea continuar?', 1)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'62BCF934-59E1-4286-B325-22488502A2B5', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'This action replaces the current data with the backup data. Do you want to continue?', 30)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'06AA4364-4352-43D7-8173-3BF64875217E', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Se tomarán como válidos los datos actuales y se recalcularán los dígitos verificadores. ¿Desea continuar?', 41)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'06AA4364-4352-43D7-8173-3BF64875217E', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'The current data will be taken as valid and the check digits will be recalculated. Do you want to continue?', 25)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0B3CF967-73F9-439F-83AC-D3BC4AA99F38', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Error al recalcular los dígitos verificadores', 85)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0B3CF967-73F9-439F-83AC-D3BC4AA99F38', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Error recalculating the check digits', 8)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'1146F046-85D8-4443-9842-5483A6F2EFCC', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'La integridad de los datos sigue fallando. Revise el detalle y elija otra acción.', 16)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'1146F046-85D8-4443-9842-5483A6F2EFCC', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'The data integrity check is still failing. Review the details and choose another action.', 77)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6D139769-6072-49C3-8FF2-C540F058CB47', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'El backup restaurado no contiene al administrador actual. Debe iniciar sesión nuevamente.', 82)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6D139769-6072-49C3-8FF2-C540F058CB47', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'The restored backup does not contain the current administrator. You must log in again.', 49)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8F15AC4F-2295-4CE9-A566-71DAF3B65677', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'(tabla completa)', 70)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8F15AC4F-2295-4CE9-A566-71DAF3B65677', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'(entire table)', 15)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6C3A7ED0-92BE-4063-AF35-D5E58FCD9AD4', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'El sistema no está disponible en este momento
Contacte con un Administrador.', 46)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6C3A7ED0-92BE-4063-AF35-D5E58FCD9AD4', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'The system is not available right now.
Contact an Administrator.', 0)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'E5F99194-923F-49E5-8DE6-710A91AAB47E', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Usuario Dado de Baja', 38)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'E5F99194-923F-49E5-8DE6-710A91AAB47E', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'User Deactivated', 61)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'E03CC91B-B0E9-4122-81E2-5E6FBCB14E90', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Bitácora', 6)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'E03CC91B-B0E9-4122-81E2-5E6FBCB14E90', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Audit Log', 4)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'565E23F4-CF82-4CB8-AD2C-F3D1BA56EA1D', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Filtrar por fecha', 88)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'565E23F4-CF82-4CB8-AD2C-F3D1BA56EA1D', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Filter by date', 2)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'10D71AA6-D825-40EE-B73C-257BA29B53CB', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Desde', 59)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'10D71AA6-D825-40EE-B73C-257BA29B53CB', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'From', 31)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'5E5F5093-2D4C-4BDE-836D-ACBEF33750FF', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Hasta', 69)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'5E5F5093-2D4C-4BDE-836D-ACBEF33750FF', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'To', 63)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'85A02EE5-8726-4596-90F9-7BBDE9237913', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Actividad', 32)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'85A02EE5-8726-4596-90F9-7BBDE9237913', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Activity', 60)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'41952A9A-C1DE-473F-88FE-BCF475691B30', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Buscar', 80)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'41952A9A-C1DE-473F-88FE-BCF475691B30', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Search', 70)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'AF1F9627-6E0A-4272-9138-7AB0CA18F6FC', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Exportar CSV', 21)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'AF1F9627-6E0A-4272-9138-7AB0CA18F6FC', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Export CSV', 15)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'34CA2F3F-95DF-40E0-BA65-E1810511D0E5', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Fecha', 58)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'34CA2F3F-95DF-40E0-BA65-E1810511D0E5', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Date', 21)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'4AE03DC9-C8A0-40C4-9FC0-EF966B33A1DF', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Detalle', 69)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'4AE03DC9-C8A0-40C4-9FC0-EF966B33A1DF', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Detail', 10)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2C0315A3-3621-4543-AA61-446AE74E8630', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'(Todos)', 26)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2C0315A3-3621-4543-AA61-446AE74E8630', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'(All)', 47)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'73E1E71C-7CAB-45CF-8EA9-0568AE83BCE1', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Exportación realizada con éxito', 13)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'73E1E71C-7CAB-45CF-8EA9-0568AE83BCE1', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Export completed successfully', 20)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'209CFCCD-809D-4E6E-8C24-643D09976D89', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Error al exportar', 1)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'209CFCCD-809D-4E6E-8C24-643D09976D89', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Error exporting', 25)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'CD76E8DF-7509-4024-A0B2-1D97E5FD8768', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Id', 35)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'CD76E8DF-7509-4024-A0B2-1D97E5FD8768', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Id', 8)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'B8BB1004-8AF1-404E-A12F-44F5A68ED6DD', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Tabla', 9)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'B8BB1004-8AF1-404E-A12F-44F5A68ED6DD', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Table', 42)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'7651A2F6-BBB0-491E-B46B-A717953D3753', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Fila (clave primaria)', 71)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'7651A2F6-BBB0-491E-B46B-A717953D3753', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Row (primary key)', 22)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'E634B6ED-1020-4D33-9FE5-96CF644F8136', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Campos con falla', 53)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'E634B6ED-1020-4D33-9FE5-96CF644F8136', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Failing fields', 21)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9915392d-8b8c-4303-8c56-e8ee5a2da444', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Anular', 82)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'c9aa39f7-bd3f-4414-9e27-672e87243d67', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Asignar como propietario', 63)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e4e2ace2-193a-4f78-9397-77811e7e0ecd', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Confirmar egreso', 67)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'909e1b38-c80e-4e03-a567-971987c70b24', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Emitir (PDF)', 89)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8c789e28-6359-44e8-8403-e56238625c1c', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Generar liquidación', 21)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0c92ba8f-480b-493b-ad66-f87d4e33f922', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Inactivar', 14)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'f6bd2051-e8c6-42e7-a1fb-bda5759292ff', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Nueva', 79)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'044a9a0d-08c2-4bab-9eb3-9a9e7f1b4486', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Nuevo', 58)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9bd06464-45fa-45eb-8944-b7efa6faf355', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Quitar propietario', 32)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd145117b-4a75-4d3a-966a-c0e936dc21cf', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Reactivar', 43)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'bb2e2560-08c8-478f-b17b-a00257789260', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Anular expensa', 77)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'4710fea8-8117-4774-97d3-719af36ab1b6', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Apellido:', 17)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'a59a69c2-387a-4c7c-a456-f937612d2922', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Cant. de unidades:', 48)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6d0d3e9e-ad73-4b10-bbca-486326191afd', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Coeficiente:', 16)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'eb5167b0-8005-467e-ad1f-b96f7cc5061e', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Coeficiente utilizado:', 58)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'1c9f7db5-4149-4a9f-a1ef-24a95376d664', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Activa', 33)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6a1b1a7c-3c86-4403-ad94-06cfa0c32153', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Activo', 49)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'a0385bc1-b7bc-4a88-91d3-8d3c6d49e9f2', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Apellido', 68)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8e10e0f8-22ef-4590-9c5e-8008aba95379', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Cant. unidades', 42)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'ac5f497a-8b59-48fc-977a-994b354a4b99', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Categoría', 28)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e9ada15a-841a-4935-82f9-26a26c9b4acf', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Coeficiente', 20)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'1afe9243-597c-4ae4-b085-83cbfbcad5a8', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Costo', 51)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'a76b3665-eda1-4c12-a386-e31872814beb', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Cuotas pendientes', 61)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'314b660b-605d-4300-b98f-005184f8be11', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Descripción', 15)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e2c9531c-fe3c-4ca9-88fe-e20df69827f6', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Días de atraso', 77)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'ce18847f-5352-4693-a9d3-b469382c4199', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Direccion', 61)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'611237b1-0d3d-483c-8991-5ea9ea8bc398', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'DNI', 8)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6a5355ef-46a1-4b47-ade6-896293c58f0c', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Estado', 54)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'b9b94610-760c-4318-8a72-50ef041c4844', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Gestor', 92)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'73b9cfef-0cdd-4ea2-8ec7-a7b77d6517a6', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Honorario aplicado', 36)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'1fcd96f3-29f2-4ae8-ac11-1929a3094464', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Incluye recargo por mora', 54)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'c90d11bc-8291-46f3-b1e5-311233bcb26a', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Monto', 45)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'240c12f3-b541-49f8-91fa-f6293db4d678', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Monto adeudado', 79)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'569d6ab8-3ade-468b-9f97-000a913e9f61', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Monto expensa', 68)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3ea4d2f0-9de7-4a71-ae80-968bfac82b24', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Nombre', 89)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'c9795dad-544d-463e-8b86-4915ddb18721', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Numero', 3)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0ab7c06f-34af-40ac-85ce-28e6dc39ca75', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Pagado', 79)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'20b35fff-aa35-4417-8def-69f25376c2e6', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Periodo', 86)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'fe276011-5849-44b7-bd8e-c0f951a5a051', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Período', 43)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'dcce9329-609f-41d2-a879-424b8e6a48c8', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Períodos adeudados', 10)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'68273691-fb28-48ce-8b71-5008a07ff305', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Recargo por mora', 4)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3e92927e-2f11-4103-9dba-2572e14b8b28', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Rubro', 77)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'f5950eb9-e473-4dd9-99c2-aa576c43e149', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Saldo adeudado', 79)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6b54a899-ce68-46a2-bf66-786beb51e39f', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Tipo', 58)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'b7075cf2-256c-441e-8565-57ec187ba476', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Unidad funcional propia', 96)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'5281ceb1-96f4-4e8c-b6ee-49932a7ff696', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Vencimiento', 6)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'127cee6a-681d-43e0-9031-da374ad68d12', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Concepto:', 2)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'654632ee-3103-40c6-8af2-95a12dbf764c', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Consorcio:', 78)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8d34b8ae-ac8b-492a-8f7e-164cc7029b43', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Descripción:', 77)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'220bbad3-a4c4-46b1-bb2c-11465af94583', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Detalle por período de la unidad seleccionada:', 76)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8fdd0317-4173-4d82-91f7-8c7336618f84', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Direccion:', 64)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'73576b05-d0a3-40f2-9771-abfc83d69e6b', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'DNI:', 26)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3c173344-e1a0-46f7-ab8c-745902173a8b', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Estado:', 5)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'18fc3515-cc0b-4e06-9cc8-a3647212ffd2', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Estado de cuenta', 58)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'21b377d2-6823-4ceb-8eb4-dc5344087b33', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Estado del fondo', 15)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'57a6b460-03ec-4441-a49c-6da9363cc556', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Anular / revisar composición de expensa', 28)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3acfb399-c330-4d14-a729-198fe6bea356', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Fecha de vencimiento:', 40)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'affccf9d-8805-4200-88c9-9bacddf6e907', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Gastos', 63)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'bc741753-3845-45c4-982d-10bcef1baf00', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Generar liquidación de expensas', 66)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8eb66d3f-1ce5-40b8-a9b4-0a493c655cc6', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Generar orden de pago', 68)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'34f4a63e-234b-4777-98ed-645754aecd6f', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Gestor:', 88)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'cb3b20a4-a331-4e13-a471-1e80ff8a1fc3', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Composición de la expensa', 95)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'b8a16bc3-821e-43b2-a128-4bccf3756b80', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Consorcio', 96)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'7ce4fbf7-8410-4ff8-9171-52b1f15c72cd', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Consorcista', 19)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6a20b07a-5231-43b9-9c81-84785c69ecf7', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Expensa seleccionada', 9)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'a7e8ff9c-e96a-4201-89ad-1c689121238d', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Compra de insumo (si no se selecciona un servicio aprobado)', 66)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'deb99801-ef38-4c73-87ad-b6ced32f2e6c', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Liquidación', 65)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd0bfb81e-69ca-49b0-95d3-168de11ac219', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Motivo de anulación', 85)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'f9648ae2-914f-46f2-824b-d59ea29399aa', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Nuevo gasto', 47)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'aa95a8f3-4378-4717-935e-1d976013433c', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Talón de la orden de pago', 96)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3afb5ef7-c5bd-45c2-a2b3-3f129eb51afc', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Unidad funcional (propietario)', 30)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'929ed924-daaa-446c-9038-5eed718100fd', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Honorario aplicado:', 80)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'c4d4afe1-caea-4462-8f27-4f108c96f1c9', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Mantenimiento de consorcios', 89)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'577512a2-8e28-4e1b-98b1-eaa1f198b16c', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Medio de pago:', 38)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e8613d24-c4e5-45ca-b7bc-e38880d9721c', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Emitir estado de cuenta', 91)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'70f8ab73-9abe-4cf1-919f-28902733484f', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Liquidación de Expensas', 81)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'11d1cd30-b8fb-4ffe-8b1f-9e5d65a6d6b0', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Obtener morosidad', 15)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'372f7212-73ab-4231-abfe-e67b15f0c5f0', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Revisar composición de expensa', 86)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'61d61ffe-7bb2-4065-9f44-b00c51c2104d', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Monto:', 9)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'91831522-515b-4c85-96bb-e0347abd344c', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Estadísticas de morosidad', 85)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9eff5e12-219a-4240-9136-8bb91bf9f0a3', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Motivo:', 66)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd1f1c435-f2b2-4cfd-b093-40e232c41e8b', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Nombre:', 96)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'66613f7c-8f3d-4620-b3f2-5602667c2da0', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Numero:', 80)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0d17a004-7d47-43b8-baf9-5bcdf36d3807', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'N.º de orden:', 12)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'fb038457-183a-41df-b87c-05a877cbb455', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Obtener estado del fondo', 21)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'501fde6e-472d-4bc6-af5a-8c95ae52b1f9', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Pagado:', 23)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'337811ab-6849-4a6a-a619-28c58034e5c6', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'% de honorario:', 13)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'a78f60f7-db85-4476-b642-ef46739e0013', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Periodo:', 87)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'816a1dbf-ff75-48f7-9805-e2a66b189980', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Propietario:', 93)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'84f45660-4a23-456e-826b-76b2be87161e', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Recargo por mora:', 44)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3aff9740-25fc-412a-8bd6-74a6e71c7e07', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Registrar egreso a proveedor', 42)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e443ecf8-4dc2-4685-b753-5d05811d9a31', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Cobrar expensa', 47)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'fba792bb-3144-4857-99f2-a47b8353a10b', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Rubro:', 71)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'f95619b2-e0ba-445d-a16c-e499610c6d69', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Saldo:', 20)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0ec5791f-63e9-418d-bb70-3df3536a409d', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Saldo disponible:', 23)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8fb8afd1-ce9a-4cbd-bd54-3dc11fa94b29', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'saldo insuficiente para este egreso', 14)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'21ea18ad-064f-4703-853e-5d63b06f2ca7', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Revisar composición', 41)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8c56658c-cff1-4108-a5b8-06081b29c44d', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Consorcios', 62)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'12b2a186-e319-4703-ae4c-f5bc8ceb62ec', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Consorcistas', 78)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3f47cb56-8d09-47c2-8b91-79f07a8eaf79', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Unidades Funcionales', 75)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'487fbd54-993c-4d73-9b93-8736a83fe834', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Tipo:', 15)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'968b1aa2-6943-411e-a269-8562812dff65', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Total egresado:', 8)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'57fa4025-1b0a-4979-bcf3-36073c79530c', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Total de gastos:', 41)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'dc85a7fa-f09b-4076-beaa-08b48ed9c79b', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Total recaudado:', 93)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'c3b226a0-0d17-49db-91fb-1198ed130bc6', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Unidad funcional:', 73)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd898aa4d-4c26-4fa5-862a-ba3320fb7988', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Unidad funcional', 86)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd742b29e-d823-4920-a78b-30860302750b', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Unidad funcional / consorcio:', 67)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'1b87d0a1-53f7-4832-aa93-f348ab5f6afd', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Vencimiento:', 11)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'044a9a0d-08c2-4bab-9eb3-9a9e7f1b4486', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'New', 23)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0ab7c06f-34af-40ac-85ce-28e6dc39ca75', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Paid', 3)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0c92ba8f-480b-493b-ad66-f87d4e33f922', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Deactivate', 92)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0d17a004-7d47-43b8-baf9-5bcdf36d3807', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Order no.:', 45)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0ec5791f-63e9-418d-bb70-3df3536a409d', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Available balance:', 90)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'11d1cd30-b8fb-4ffe-8b1f-9e5d65a6d6b0', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Get delinquency', 25)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'127cee6a-681d-43e0-9031-da374ad68d12', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Concept:', 47)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'12b2a186-e319-4703-ae4c-f5bc8ceb62ec', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Owners', 32)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'18fc3515-cc0b-4e06-9cc8-a3647212ffd2', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Account statement', 2)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'1afe9243-597c-4ae4-b085-83cbfbcad5a8', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Cost', 8)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'1b87d0a1-53f7-4832-aa93-f348ab5f6afd', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Due date:', 86)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'1c9f7db5-4149-4a9f-a1ef-24a95376d664', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Active', 78)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'1fcd96f3-29f2-4ae8-ac11-1929a3094464', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Includes late surcharge', 81)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'20b35fff-aa35-4417-8def-69f25376c2e6', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Period', 56)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'21b377d2-6823-4ceb-8eb4-dc5344087b33', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Fund status', 27)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'21ea18ad-064f-4703-853e-5d63b06f2ca7', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Review breakdown', 43)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'220bbad3-a4c4-46b1-bb2c-11465af94583', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Breakdown by period for the selected unit:', 3)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'240c12f3-b541-49f8-91fa-f6293db4d678', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Amount owed', 13)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'314b660b-605d-4300-b98f-005184f8be11', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Description', 25)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'337811ab-6849-4a6a-a619-28c58034e5c6', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Management fee %:', 86)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'34f4a63e-234b-4777-98ed-645754aecd6f', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Manager:', 56)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'372f7212-73ab-4231-abfe-e67b15f0c5f0', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Review maintenance fee breakdown', 52)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3acfb399-c330-4d14-a729-198fe6bea356', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Due date:', 25)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3afb5ef7-c5bd-45c2-a2b3-3f129eb51afc', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Unit (owner)', 25)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3aff9740-25fc-412a-8bd6-74a6e71c7e07', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Register supplier payment', 2)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3c173344-e1a0-46f7-ab8c-745902173a8b', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Status:', 22)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3e92927e-2f11-4103-9dba-2572e14b8b28', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Category', 83)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3ea4d2f0-9de7-4a71-ae80-968bfac82b24', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Name', 75)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3f47cb56-8d09-47c2-8b91-79f07a8eaf79', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Units', 38)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'4710fea8-8117-4774-97d3-719af36ab1b6', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Last name:', 52)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'487fbd54-993c-4d73-9b93-8736a83fe834', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Type:', 61)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'501fde6e-472d-4bc6-af5a-8c95ae52b1f9', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Paid:', 84)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'5281ceb1-96f4-4e8c-b6ee-49932a7ff696', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Due date', 21)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'569d6ab8-3ade-468b-9f97-000a913e9f61', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Maintenance fee amount', 22)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'577512a2-8e28-4e1b-98b1-eaa1f198b16c', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Payment method:', 66)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'57a6b460-03ec-4441-a49c-6da9363cc556', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Cancel / review maintenance fee breakdown', 39)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'57fa4025-1b0a-4979-bcf3-36073c79530c', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Total costs:', 72)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'611237b1-0d3d-483c-8991-5ea9ea8bc398', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'National ID', 18)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'61d61ffe-7bb2-4065-9f44-b00c51c2104d', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Amount:', 68)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'654632ee-3103-40c6-8af2-95a12dbf764c', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Condominium:', 45)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'66613f7c-8f3d-4620-b3f2-5602667c2da0', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Number:', 70)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'68273691-fb28-48ce-8b71-5008a07ff305', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Late payment surcharge', 90)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6a1b1a7c-3c86-4403-ad94-06cfa0c32153', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Active', 36)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6a20b07a-5231-43b9-9c81-84785c69ecf7', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Selected maintenance fee', 69)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6a5355ef-46a1-4b47-ade6-896293c58f0c', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Status', 71)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6b54a899-ce68-46a2-bf66-786beb51e39f', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Type', 7)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6d0d3e9e-ad73-4b10-bbca-486326191afd', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Coefficient:', 94)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'70f8ab73-9abe-4cf1-919f-28902733484f', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Fee Settlement', 95)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'73576b05-d0a3-40f2-9771-abfc83d69e6b', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'National ID:', 70)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'73b9cfef-0cdd-4ea2-8ec7-a7b77d6517a6', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Management fee applied', 76)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'7ce4fbf7-8410-4ff8-9171-52b1f15c72cd', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Owner', 6)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'816a1dbf-ff75-48f7-9805-e2a66b189980', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Owner:', 30)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'84f45660-4a23-456e-826b-76b2be87161e', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Late payment surcharge:', 10)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8c56658c-cff1-4108-a5b8-06081b29c44d', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Condominiums', 80)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8c789e28-6359-44e8-8403-e56238625c1c', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Generate settlement', 0)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8d34b8ae-ac8b-492a-8f7e-164cc7029b43', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Description:', 87)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8e10e0f8-22ef-4590-9c5e-8008aba95379', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'No. of units', 94)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8eb66d3f-1ce5-40b8-a9b4-0a493c655cc6', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Generate payment order', 88)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8fb8afd1-ce9a-4cbd-bd54-3dc11fa94b29', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'insufficient balance for this payment', 87)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8fdd0317-4173-4d82-91f7-8c7336618f84', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Address:', 6)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'909e1b38-c80e-4e03-a567-971987c70b24', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Issue (PDF)', 17)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'91831522-515b-4c85-96bb-e0347abd344c', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Delinquency statistics', 50)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'929ed924-daaa-446c-9038-5eed718100fd', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Management fee applied:', 40)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'968b1aa2-6943-411e-a269-8562812dff65', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Total paid out:', 82)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9915392d-8b8c-4303-8c56-e8ee5a2da444', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Void', 2)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9bd06464-45fa-45eb-8944-b7efa6faf355', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Remove owner', 84)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9eff5e12-219a-4240-9136-8bb91bf9f0a3', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Reason:', 14)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'a0385bc1-b7bc-4a88-91d3-8d3c6d49e9f2', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Last name', 26)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'a59a69c2-387a-4c7c-a456-f937612d2922', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Number of units:', 53)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'a76b3665-eda1-4c12-a386-e31872814beb', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Pending installments', 80)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'a78f60f7-db85-4476-b642-ef46739e0013', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Period:', 77)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'a7e8ff9c-e96a-4201-89ad-1c689121238d', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Supply purchase (if no approved service is selected)', 49)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'aa95a8f3-4378-4717-935e-1d976013433c', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Payment order stub', 16)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'ac5f497a-8b59-48fc-977a-994b354a4b99', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Category', 30)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'affccf9d-8805-4200-88c9-9bacddf6e907', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Costs', 38)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'b7075cf2-256c-441e-8565-57ec187ba476', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Owned unit', 5)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'b8a16bc3-821e-43b2-a128-4bccf3756b80', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Condominium', 6)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'b9b94610-760c-4318-8a72-50ef041c4844', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Manager', 80)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'bb2e2560-08c8-478f-b17b-a00257789260', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Cancel maintenance fee', 14)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'bc741753-3845-45c4-982d-10bcef1baf00', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Generate maintenance fee settlement', 33)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'c3b226a0-0d17-49db-91fb-1198ed130bc6', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Unit:', 26)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'c4d4afe1-caea-4462-8f27-4f108c96f1c9', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Condominium maintenance', 39)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'c90d11bc-8291-46f3-b1e5-311233bcb26a', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Amount', 27)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'c9795dad-544d-463e-8b86-4915ddb18721', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Number', 90)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'c9aa39f7-bd3f-4414-9e27-672e87243d67', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Assign as owner', 44)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'cb3b20a4-a331-4e13-a471-1e80ff8a1fc3', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Maintenance fee breakdown', 4)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'ce18847f-5352-4693-a9d3-b469382c4199', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Address', 60)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd0bfb81e-69ca-49b0-95d3-168de11ac219', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Cancellation reason', 22)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd145117b-4a75-4d3a-966a-c0e936dc21cf', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Reactivate', 93)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd1f1c435-f2b2-4cfd-b093-40e232c41e8b', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Name:', 25)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd742b29e-d823-4920-a78b-30860302750b', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Unit / condominium:', 75)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'd898aa4d-4c26-4fa5-862a-ba3320fb7988', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Unit', 90)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'dc85a7fa-f09b-4076-beaa-08b48ed9c79b', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Total collected:', 94)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'dcce9329-609f-41d2-a879-424b8e6a48c8', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Periods owed', 37)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'deb99801-ef38-4c73-87ad-b6ced32f2e6c', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Settlement', 92)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e2c9531c-fe3c-4ca9-88fe-e20df69827f6', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Days overdue', 84)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e443ecf8-4dc2-4685-b753-5d05811d9a31', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Collect maintenance fee', 7)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e4e2ace2-193a-4f78-9397-77811e7e0ecd', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Confirm payment', 11)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e8613d24-c4e5-45ca-b7bc-e38880d9721c', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Issue account statement', 61)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'e9ada15a-841a-4935-82f9-26a26c9b4acf', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Coefficient', 1)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'eb5167b0-8005-467e-ad1f-b96f7cc5061e', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Coefficient used:', 11)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'f5950eb9-e473-4dd9-99c2-aa576c43e149', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Balance owed', 53)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'f6bd2051-e8c6-42e7-a1fb-bda5759292ff', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'New', 60)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'f95619b2-e0ba-445d-a16c-e499610c6d69', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Balance:', 68)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'f9648ae2-914f-46f2-824b-d59ea29399aa', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'New cost', 68)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'fb038457-183a-41df-b87c-05a877cbb455', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Get fund status', 28)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'fba792bb-3144-4857-99f2-a47b8353a10b', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Category:', 17)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'fe276011-5849-44b7-bd8e-c0f951a5a051', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Period', 78)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'53033514-acb4-40f5-9f74-5b39267c5b6b', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Nombre de usuario', 10)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'53033514-acb4-40f5-9f74-5b39267c5b6b', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Username', 33)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'015C0CE6-A40E-42FB-95C4-82E9E86381D3', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Adjuntar...', 2)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'015C0CE6-A40E-42FB-95C4-82E9E86381D3', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Attach...', 50)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'028939DD-5401-4165-AB35-1DB787457233', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Ubicación', 93)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'028939DD-5401-4165-AB35-1DB787457233', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Location', 22)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0893014D-D171-406A-9D8E-0B5E97DB62E6', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Asignado el', 17)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0893014D-D171-406A-9D8E-0B5E97DB62E6', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Assigned on', 65)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'11F7FC2C-E2D6-4D7A-A51E-D9241B0CA8CD', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Archivo (opcional):', 93)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'11F7FC2C-E2D6-4D7A-A51E-D9241B0CA8CD', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'File (optional):', 29)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'17EC9087-21F5-4E3E-9E15-3B7762204355', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Gestión de Servicios', 20)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'17EC9087-21F5-4E3E-9E15-3B7762204355', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Service Management', 43)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'1F3A5BB9-8E50-44F2-8AD2-2A566AD44FFA', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Motivo del rechazo:', 8)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'1F3A5BB9-8E50-44F2-8AD2-2A566AD44FFA', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Rejection reason:', 95)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2320CE48-AA6F-43EF-B318-440D0A168C13', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Asignación', 86)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2320CE48-AA6F-43EF-B318-440D0A168C13', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Assignment', 12)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'391ABDBF-F122-4B11-9B4D-5A920988D5AB', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Confirmar carga', 57)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'391ABDBF-F122-4B11-9B4D-5A920988D5AB', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Confirm entry', 4)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3CB5240A-D4C8-4248-855C-08E3A9EE74A6', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'N.º factura:', 2)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3CB5240A-D4C8-4248-855C-08E3A9EE74A6', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Invoice No.:', 35)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'48EBE6C4-5DCC-4911-96BB-D985287FC2AF', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Confirmar asignación', 47)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'48EBE6C4-5DCC-4911-96BB-D985287FC2AF', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Confirm assignment', 28)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'4C3462FF-BFAE-4136-9F58-889EA86BA43C', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Detalle', 38)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'4C3462FF-BFAE-4136-9F58-889EA86BA43C', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Detail', 76)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'54E145E0-9947-4F5D-96BC-E22035C3B0CE', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Asignar proveedor al servicio', 92)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'54E145E0-9947-4F5D-96BC-E22035C3B0CE', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Assign supplier to service', 2)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'58965D25-ADE7-496B-9604-4AC0443FDE72', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Costo:', 20)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'58965D25-ADE7-496B-9604-4AC0443FDE72', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Cost:', 94)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'67A6E0B9-2D08-498D-A292-3EDB4EA40E03', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Confirmar solicitud', 39)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'67A6E0B9-2D08-498D-A292-3EDB4EA40E03', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Confirm request', 47)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'67F0813C-4617-4B9D-BCB7-C22271E33361', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Debe indicar un motivo para rechazar', 72)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'67F0813C-4617-4B9D-BCB7-C22271E33361', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'You must enter a reason to reject', 71)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'7EB0E730-17FE-44BC-96A7-8CC279212F7C', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Debe indicar un plazo estimado válido', 60)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'7EB0E730-17FE-44BC-96A7-8CC279212F7C', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'You must enter a valid estimated term', 44)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8157DD81-2EB8-445A-AB72-7B8204316F7D', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Exportar PDF', 40)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8157DD81-2EB8-445A-AB72-7B8204316F7D', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Export PDF', 45)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'815C9FA1-ACD6-41C8-9A6B-77E2A0BB84D5', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Plazo (días)', 14)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'815C9FA1-ACD6-41C8-9A6B-77E2A0BB84D5', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Term (days)', 90)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'860AC279-4AE0-42D9-AD50-360CFF766114', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Recargo por mora:', 91)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'860AC279-4AE0-42D9-AD50-360CFF766114', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Late payment surcharge:', 57)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8902F2DA-27E2-4ACF-9641-1231B6EC0F8A', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Solicitud de servicio', 93)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8902F2DA-27E2-4ACF-9641-1231B6EC0F8A', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Service request', 91)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8D3E8231-925C-4CCD-AB3F-836EB111246D', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Aprobar prestación', 64)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8D3E8231-925C-4CCD-AB3F-836EB111246D', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Approve service', 41)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8D87A2FE-BD24-4C42-B03B-2742B613FC68', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Prestación realizada', 33)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8D87A2FE-BD24-4C42-B03B-2742B613FC68', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Service performed', 68)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9476A9A8-88F2-4DEB-BB9E-D8A17F3F7400', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Rechazar prestación', 45)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9476A9A8-88F2-4DEB-BB9E-D8A17F3F7400', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Reject service', 45)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9A60DC43-C0C5-410D-8BB9-DFDCD59F05CB', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Proveedor:', 85)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9A60DC43-C0C5-410D-8BB9-DFDCD59F05CB', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Supplier:', 47)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9EBDC75E-B711-45F1-8545-C64D9288A3A1', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Plazo estimado (días):', 56)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9EBDC75E-B711-45F1-8545-C64D9288A3A1', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Estimated term (days):', 34)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'A35BAC05-2AE3-4DAF-9DDA-B60CDA61B352', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Fecha', 61)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'A35BAC05-2AE3-4DAF-9DDA-B60CDA61B352', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Date', 24)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'AEB26C5C-FDE5-4124-BA38-C1638DC5E2D5', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Cargar prestación del proveedor', 24)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'AEB26C5C-FDE5-4124-BA38-C1638DC5E2D5', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Record supplier service', 61)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'B1F02BED-0A93-4B30-84C6-A5C85D78DF03', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Proveedor', 23)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'B1F02BED-0A93-4B30-84C6-A5C85D78DF03', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Supplier', 62)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'B6DD63F5-03AA-42F5-AC22-AE19D47FDE2C', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Comprobante:', 23)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'B6DD63F5-03AA-42F5-AC22-AE19D47FDE2C', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Receipt:', 17)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'C5C356B8-3EB4-4DE8-8464-EFE074D64C7F', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Reporte de gestión', 34)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'C5C356B8-3EB4-4DE8-8464-EFE074D64C7F', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Management report', 39)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'D216E868-4EFA-4EDF-BA4B-126DD4CC7E1D', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Estado de cuenta', 38)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'D216E868-4EFA-4EDF-BA4B-126DD4CC7E1D', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Account statement', 79)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DA7FEDD0-CF63-46D8-8969-0045915890E3', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Coeficiente aplicado:', 74)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DA7FEDD0-CF63-46D8-8969-0045915890E3', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Applied coefficient:', 85)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DC249D14-60F0-4306-B308-0F488063A7FC', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Solicitud registrada:', 75)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DC249D14-60F0-4306-B308-0F488063A7FC', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Request registered:', 48)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'E7F3D988-2A7E-4D8A-BE3B-582770975CEC', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Trabajo realizado:', 68)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'E7F3D988-2A7E-4D8A-BE3B-582770975CEC', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Work performed:', 73)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'E967497F-C530-4A26-8D54-A31093662155', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Área común', 95)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'E967497F-C530-4A26-8D54-A31093662155', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Common area', 38)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'F1B6462D-9DBC-4420-BDB5-50C5F6481C2D', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Formalizar solicitud de servicio', 34)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'F1B6462D-9DBC-4420-BDB5-50C5F6481C2D', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Submit service request', 85)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'F28053DE-EFF9-4241-A694-AD9C23072840', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Detalle de la prestación', 56)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'F28053DE-EFF9-4241-A694-AD9C23072840', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Service details', 10)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'FE3BB30B-E480-418B-9814-BE7CD5BD0A0B', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Categoría', 18)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'FE3BB30B-E480-418B-9814-BE7CD5BD0A0B', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Category', 20)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3674A0EE-CCDF-410C-9CA7-DF77C3B921A2', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Habilitar', 11)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3674A0EE-CCDF-410C-9CA7-DF77C3B921A2', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Enable', 0)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'54801AFF-55CE-4D5C-9096-C5FE52D6DEDC', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Habilitado', 86)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'54801AFF-55CE-4D5C-9096-C5FE52D6DEDC', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Enabled', 96)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'693EE6DC-EDD4-41B2-9036-8AE6260AE2E8', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Proveedores', 36)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'693EE6DC-EDD4-41B2-9036-8AE6260AE2E8', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Suppliers', 41)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8B07B29D-5F53-401B-9DE9-4433D1947631', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Inhabilitar', 8)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8B07B29D-5F53-401B-9DE9-4433D1947631', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Disable', 34)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DB3C7036-D46D-4A87-9231-A9201019C93C', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Proveedor', 74)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DB3C7036-D46D-4A87-9231-A9201019C93C', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Supplier', 16)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0029FAE8-E7B0-4D87-A90E-8E3EF5A65A6E', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Serializar/Deserializar expensas', 53)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0029FAE8-E7B0-4D87-A90E-8E3EF5A65A6E', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Serialize/Deserialize expenses', 84)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'08FA8DD4-AD81-4610-B85E-32B4B5C8BD15', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Expensas serializadas correctamente', 70)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'08FA8DD4-AD81-4610-B85E-32B4B5C8BD15', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Expenses serialized successfully', 64)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3D78727E-91D7-46F0-95AE-ED4635061641', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Los datos deserializados no se guardan en la base de datos, solo se muestran en pantalla.', 89)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3D78727E-91D7-46F0-95AE-ED4635061641', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Deserialized data is not saved to the database, it is only shown on screen.', 70)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'56127605-0D20-46D0-A11D-271B90C9D760', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Consorcio:', 92)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'56127605-0D20-46D0-A11D-271B90C9D760', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Consortium:', 51)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'563DDB45-FB8F-4B0A-AEE9-6866598E362C', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'El archivo no tiene un formato de expensas valido', 5)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'563DDB45-FB8F-4B0A-AEE9-6866598E362C', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'The file does not have a valid expenses format', 46)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'668DD673-4E8E-4C25-929C-DFB238686C7D', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Estado', 20)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'668DD673-4E8E-4C25-929C-DFB238686C7D', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Status', 37)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6C24BBF5-E056-4AB0-B60F-70486FBA768C', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'El archivo no existe', 45)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6C24BBF5-E056-4AB0-B60F-70486FBA768C', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'The file does not exist', 87)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'7A97F2AB-85CF-43E1-8108-CCCB3AC3A904', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'No se pudo serializar:', 13)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'7A97F2AB-85CF-43E1-8108-CCCB3AC3A904', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Could not serialize:', 49)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8379C8D9-FB2D-49F7-B828-A2D23A9374F4', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Serializar/Deserializar expensas', 35)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8379C8D9-FB2D-49F7-B828-A2D23A9374F4', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Serialize/Deserialize expenses', 66)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8E94852E-67E9-47DB-93D1-D212D139F877', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Monto', 4)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8E94852E-67E9-47DB-93D1-D212D139F877', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Amount', 83)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'A58A4EC6-33D4-4333-A4A5-5257E99E23C1', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Fecha de vencimiento', 39)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'A58A4EC6-33D4-4333-A4A5-5257E99E23C1', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Due date', 75)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DD25673D-9C9A-403A-8430-8B24310A5B78', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'No se pudo leer el archivo:', 37)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DD25673D-9C9A-403A-8430-8B24310A5B78', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Could not read the file:', 60)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'E357A085-6D87-42A4-85D0-6BD603809164', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Serializar', 56)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'E357A085-6D87-42A4-85D0-6BD603809164', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Serialize', 15)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'EFE522DC-8775-4981-8C18-FC5DDB08C7ED', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Período', 5)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'EFE522DC-8775-4981-8C18-FC5DDB08C7ED', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Period', 40)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'F32CA16D-FAA9-4926-A06C-32965C65D035', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Deserializar', 68)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'F32CA16D-FAA9-4926-A06C-32965C65D035', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Deserialize', 46)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0281DEBB-BF27-453D-A7BA-072785A680EC', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Reporte de servicios', 94)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0281DEBB-BF27-453D-A7BA-072785A680EC', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Services report', 47)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'03869D17-2055-415C-BF57-C298DC5C461B', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Por proveedor', 35)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'03869D17-2055-415C-BF57-C298DC5C461B', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'By supplier', 89)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'05FAD6BD-87FC-4BE2-896B-10F01D3777E2', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Seleccione un consorcio', 90)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'05FAD6BD-87FC-4BE2-896B-10F01D3777E2', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Select a consortium', 22)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3D5FD455-5841-47A9-B2F3-0CE98039924E', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Descripción', 56)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'3D5FD455-5841-47A9-B2F3-0CE98039924E', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Description', 66)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'4545490C-E67D-4BC3-8419-F0E35071539A', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Costo', 3)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'4545490C-E67D-4BC3-8419-F0E35071539A', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Cost', 57)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'692B2CD9-29C5-4F1C-8E67-8DACBF76728E', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Costo acumulado:', 18)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'692B2CD9-29C5-4F1C-8E67-8DACBF76728E', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Accumulated cost:', 94)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6C59506F-FED8-46D2-8D8B-78829E1054F8', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Consorcio', 69)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6C59506F-FED8-46D2-8D8B-78829E1054F8', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Consortium', 48)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8E89F7A9-84F6-4576-9F66-A671EF464F76', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Generar', 39)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8E89F7A9-84F6-4576-9F66-A671EF464F76', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Generate', 53)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'A190D95E-0690-4256-AADC-5DF111822AB9', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Estado', 24)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'A190D95E-0690-4256-AADC-5DF111822AB9', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Status', 41)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'AA73C037-DA18-4430-AEFC-79428FC990A3', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Por consorcio', 18)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'AA73C037-DA18-4430-AEFC-79428FC990A3', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'By consortium', 66)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'D0D482EB-265C-40D2-A3A4-C8B585C8F5A6', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Seleccione un proveedor', 33)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'D0D482EB-265C-40D2-A3A4-C8B585C8F5A6', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Select a supplier', 15)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0A91BE84-0148-4049-BAE8-B003C63B1865', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'No se pudo generar el PDF, intente nuevamente', 47)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'0A91BE84-0148-4049-BAE8-B003C63B1865', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'The PDF could not be generated, please try again', 31)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DABAA01A-1B3E-4012-BC80-A800F2826553', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Reporte exportado', 52)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DABAA01A-1B3E-4012-BC80-A800F2826553', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Report exported', 81)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'EF1E38CA-BD57-4B4D-86D1-442B8F260B60', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'Baja', 86)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'EF1E38CA-BD57-4B4D-86D1-442B8F260B60', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'Deactivated', 82)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'14008F42-AF4B-4796-8CF3-611D0DD59D68', N'66cbf8f7-3eaa-4aea-bd95-2ba8dc234db7', N'No tiene consorcios asignados', 37)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'14008F42-AF4B-4796-8CF3-611D0DD59D68', N'6ff0850f-7318-4270-aaf4-3b24c9223b37', N'You have no assigned consortiums', 77)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'AF36861F-1529-40F2-9941-21537B3FF110', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Reporte global', 51)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'AF36861F-1529-40F2-9941-21537B3FF110', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Global report', 36)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'17B42034-10A6-4BC5-B764-69A28EA23983', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Desde:', 4)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'17B42034-10A6-4BC5-B764-69A28EA23983', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'From:', 93)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'67638ADF-8472-4BAF-AE87-A7B848BE71F0', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Hasta:', 64)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'67638ADF-8472-4BAF-AE87-A7B848BE71F0', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'To:', 21)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DE66B0B8-5332-4911-AD82-1EFE773609F3', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Puesto', 55)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DE66B0B8-5332-4911-AD82-1EFE773609F3', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Rank', 41)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'FDCBDE2A-8830-47D8-9A08-AEC0D14B788C', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Unidades activas', 63)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'FDCBDE2A-8830-47D8-9A08-AEC0D14B788C', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Active units', 8)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'083B5D46-ABAC-4704-9122-B65D1A84F219', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Expensado', 59)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'083B5D46-ABAC-4704-9122-B65D1A84F219', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Billed', 96)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'BA6717F9-4796-476D-B041-9A9CCBE20EB4', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Cobrado', 44)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'BA6717F9-4796-476D-B041-9A9CCBE20EB4', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Collected', 68)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'CB91F00F-61D3-4653-87ED-443F4EED87FB', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Deuda vencida', 24)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'CB91F00F-61D3-4653-87ED-443F4EED87FB', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Overdue debt', 47)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'D3113814-AA3C-4C9A-8EF7-242B18DE7D58', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Cobranza %', 85)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'D3113814-AA3C-4C9A-8EF7-242B18DE7D58', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Collection %', 22)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DB55D3FA-298F-4F81-A93D-28AD71756C6D', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Gastos', 51)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DB55D3FA-298F-4F81-A93D-28AD71756C6D', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Expenses', 62)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'882FAEA7-1F48-4272-BAD6-2456D2BECFE4', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Servicios aprobados pendientes', 90)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'882FAEA7-1F48-4272-BAD6-2456D2BECFE4', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Approved pending services', 92)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'70F2BACB-75FC-4FE0-A4F9-E5B9D8D32303', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Costo de esos servicios', 33)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'70F2BACB-75FC-4FE0-A4F9-E5B9D8D32303', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Cost of those services', 96)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6163F04B-EE6E-41B6-9A26-631ED7CA465D', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Egresos', 87)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'6163F04B-EE6E-41B6-9A26-631ED7CA465D', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Outflows', 33)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'BC9E5938-EF43-4799-A7F7-81DFCFE71789', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Saldo del fondo', 39)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'BC9E5938-EF43-4799-A7F7-81DFCFE71789', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Fund balance', 55)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'226CA783-BE13-45B2-B58A-7570BFA74599', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Total expensado:', 52)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'226CA783-BE13-45B2-B58A-7570BFA74599', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Total billed:', 14)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9EC7607B-5B7E-4758-B95E-DF3F722B1770', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Total cobrado:', 31)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'9EC7607B-5B7E-4758-B95E-DF3F722B1770', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Total collected:', 66)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'F8AC711F-4E74-407A-A1D8-15DCB519B2E7', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Total deuda vencida:', 35)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'F8AC711F-4E74-407A-A1D8-15DCB519B2E7', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Total overdue debt:', 18)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'5C57E01D-D6D4-4B77-99E9-BB69A822A638', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Total saldo:', 30)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'5C57E01D-D6D4-4B77-99E9-BB69A822A638', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Total balance:', 2)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8A8EC489-5672-461C-A9F3-AA822686A375', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'No hay consorcios activos para el período elegido', 83)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'8A8EC489-5672-461C-A9F3-AA822686A375', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'There are no active consortiums for the selected period', 35)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'F0CDA8B6-34A2-4481-B4B3-80C55BB2DDE7', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Totales', 54)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'F0CDA8B6-34A2-4481-B4B3-80C55BB2DDE7', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Totals', 95)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DC6EE97D-B309-4852-A3A3-4B20A02CEF70', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'No se pudo guardar el archivo. Verifique que no esté abierto en otro programa', 35)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'DC6EE97D-B309-4852-A3A3-4B20A02CEF70', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'The file could not be saved. Check that it is not open in another program', 72)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'4860B2D2-3E5A-424F-B009-F9CD24322BCD', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Ayuda', 69)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'4860B2D2-3E5A-424F-B009-F9CD24322BCD', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Help', 6)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2EA7F11E-43C3-4644-B012-126B8A551455', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Temas', 3)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2EA7F11E-43C3-4644-B012-126B8A551455', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Topics', 49)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'98E51D0C-863D-4337-BE1D-2CDA8F610B34', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Cerrar', 54)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'98E51D0C-863D-4337-BE1D-2CDA8F610B34', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Close', 2)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2BBB3F89-5FDA-41F7-AF54-0C8B43D10C08', N'66CBF8F7-3EAA-4AEA-BD95-2BA8DC234DB7', N'Seguridad', 67)
INSERT [dbo].[Traduccion] ([Etiqueta_ID], [Idioma_ID], [Traduccion_Traduccion], [DVH]) VALUES (N'2BBB3F89-5FDA-41F7-AF54-0C8B43D10C08', N'6FF0850F-7318-4270-AAF4-3B24C9223B37', N'Security', 59)
GO
INSERT [dbo].[Usuario] ([Usuario_ID], [Usuario_User], [Usuario_Pass], [Usuario_Bloq], [Usuario_Baja], [Usuario_DVH]) VALUES (N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'gestor', N'18f2b94d784d03c222cb7c47148cdb8457f1ef3eaf3e317711f25d55747f6a35', 0, NULL, 12)
INSERT [dbo].[Usuario] ([Usuario_ID], [Usuario_User], [Usuario_Pass], [Usuario_Bloq], [Usuario_Baja], [Usuario_DVH]) VALUES (N'42d88568-a6ab-4d41-a377-a242d7b3fef7', N'adminbasic', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 0, 0, 4)
INSERT [dbo].[Usuario] ([Usuario_ID], [Usuario_User], [Usuario_Pass], [Usuario_Bloq], [Usuario_Baja], [Usuario_DVH]) VALUES (N'b9c09721-83e1-4874-9bb2-58d8f4520248', N'asd', N'54d5cb2d332dbdb4850293caae4559ce88b65163f1ea5d4e4b3ac49d772ded14', 0, 0, 57)
INSERT [dbo].[Usuario] ([Usuario_ID], [Usuario_User], [Usuario_Pass], [Usuario_Bloq], [Usuario_Baja], [Usuario_DVH]) VALUES (N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', N'admin', N'240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 0, 0, 8)
GO
SET IDENTITY_INSERT [dbo].[CONSORCIO] ON
GO
INSERT [dbo].[CONSORCIO] ([IdConsorcio], [IdGestor], [Nombre], [Direccion], [CantidadUnidades], [DVH], [Activo]) VALUES (1, N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'Edificio Belgrano', N'Av. Cabildo 1500', 6, 52, 1)
INSERT [dbo].[CONSORCIO] ([IdConsorcio], [IdGestor], [Nombre], [Direccion], [CantidadUnidades], [DVH], [Activo]) VALUES (2, N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'Edificio San Martin', N'San Martin 820', 3, 96, 1)
INSERT [dbo].[CONSORCIO] ([IdConsorcio], [IdGestor], [Nombre], [Direccion], [CantidadUnidades], [DVH], [Activo]) VALUES (3, N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'Torre Palermo', N'Santa Fe 3200', 6, 7, 1)
INSERT [dbo].[CONSORCIO] ([IdConsorcio], [IdGestor], [Nombre], [Direccion], [CantidadUnidades], [DVH], [Activo]) VALUES (4, N'0e4f5d83-b886-45a9-8429-74b0654cd493', N'Edificio Caballito', N'Rivadavia 5100', 1, 3, 0)
GO
SET IDENTITY_INSERT [dbo].[CONSORCIO] OFF
GO
SET IDENTITY_INSERT [dbo].[GASTO] ON
GO
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (1, 1, N'Sueldo encargado agosto', 180000.00, CAST(N'2026-08-01' AS Date), N'Sueldos', 17)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (2, 1, N'Limpieza agosto', 70000.00, CAST(N'2026-08-01' AS Date), N'Limpieza', 42)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (3, 1, N'Luz y agua agosto', 50000.00, CAST(N'2026-08-01' AS Date), N'Servicios publicos', 62)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (4, 1, N'Sueldo encargado septiembre', 180000.00, CAST(N'2026-09-01' AS Date), N'Sueldos', 10)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (5, 1, N'Limpieza septiembre', 70000.00, CAST(N'2026-09-01' AS Date), N'Limpieza', 24)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (6, 1, N'Luz y agua septiembre', 70000.00, CAST(N'2026-09-01' AS Date), N'Servicios publicos', 77)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (7, 1, N'Sueldo encargado octubre', 190000.00, CAST(N'2026-10-01' AS Date), N'Sueldos', 32)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (8, 1, N'Limpieza octubre', 75000.00, CAST(N'2026-10-01' AS Date), N'Limpieza', 82)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (9, 1, N'Luz y agua octubre', 75000.00, CAST(N'2026-10-01' AS Date), N'Servicios publicos', 35)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (10, 2, N'Limpieza septiembre', 60000.00, CAST(N'2026-09-01' AS Date), N'Limpieza', 22)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (11, 2, N'Luz septiembre', 40000.00, CAST(N'2026-09-01' AS Date), N'Servicios publicos', 58)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (12, 2, N'Limpieza octubre', 65000.00, CAST(N'2026-10-01' AS Date), N'Limpieza', 80)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (13, 2, N'Luz octubre', 45000.00, CAST(N'2026-10-01' AS Date), N'Servicios publicos', 75)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (14, 3, N'Sueldo encargado octubre', 150000.00, CAST(N'2026-10-01' AS Date), N'Sueldos', 10)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (15, 3, N'Ascensor octubre', 50000.00, CAST(N'2026-10-01' AS Date), N'Mantenimiento', 65)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (16, 1, N'Sueldo encargado noviembre', 190000.00, CAST(N'2026-11-01' AS Date), N'Sueldos', 84)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (17, 1, N'Limpieza noviembre', 75000.00, CAST(N'2026-11-01' AS Date), N'Limpieza', 56)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (18, 2, N'Limpieza noviembre', 65000.00, CAST(N'2026-11-01' AS Date), N'Limpieza', 54)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (19, 3, N'Ascensor noviembre', 50000.00, CAST(N'2026-11-01' AS Date), N'Mantenimiento', 39)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (20, 1, N'Cambio de bomba de agua', 30000.00, CAST(N'2026-11-01' AS Date), N'Plomeria', 33)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (21, 1, N'Lamparas LED para pasillos', 12000.00, CAST(N'2026-11-01' AS Date), N'Insumos', 45)
INSERT [dbo].[GASTO] ([IdGasto], [IdConsorcio], [Descripcion], [Monto], [Periodo], [Rubro], [DVH]) VALUES (22, 2, N'Productos de limpieza', 20000.00, CAST(N'2026-11-01' AS Date), N'Insumos', 18)
GO
SET IDENTITY_INSERT [dbo].[GASTO] OFF
GO
SET IDENTITY_INSERT [dbo].[UNIDAD_FUNCIONAL] ON
GO
INSERT [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [DVH]) VALUES (1, 1, N'1A', N'Departamento', 0.30, 1, 67)
INSERT [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [DVH]) VALUES (2, 1, N'1B', N'Departamento', 0.30, 1, 71)
INSERT [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [DVH]) VALUES (3, 1, N'2A', N'Departamento', 0.25, 1, 40)
INSERT [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [DVH]) VALUES (4, 1, N'2B', N'Cochera', 0.15, 1, 42)
INSERT [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [DVH]) VALUES (5, 2, N'PB', N'Local', 0.50, 1, 7)
INSERT [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [DVH]) VALUES (6, 2, N'1A', N'Departamento', 0.30, 1, 68)
INSERT [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [DVH]) VALUES (7, 2, N'1B', N'Departamento', 0.20, 1, 60)
INSERT [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [DVH]) VALUES (8, 3, N'A', N'Departamento', 0.50, 1, 59)
INSERT [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [DVH]) VALUES (9, 3, N'B', N'Departamento', 0.30, 1, 37)
INSERT [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [DVH]) VALUES (10, 3, N'C', N'Departamento', 0.20, 1, 27)
INSERT [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [DVH]) VALUES (11, 3, N'D', N'Baulera', 0.10, 0, 58)
INSERT [dbo].[UNIDAD_FUNCIONAL] ([IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [DVH]) VALUES (12, 4, N'1', N'Departamento', 1.00, 1, 69)
GO
SET IDENTITY_INSERT [dbo].[UNIDAD_FUNCIONAL] OFF
GO
SET IDENTITY_INSERT [dbo].[EXPENSA] ON
GO
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (1, 1, CAST(N'2026-08-01' AS Date), 99000.00, CAST(N'2026-09-10' AS Date), 9000.00, 0.30, 0.00, N'Pagada', NULL, 19)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (2, 2, CAST(N'2026-08-01' AS Date), 99000.00, CAST(N'2026-09-10' AS Date), 9000.00, 0.30, 0.00, N'Pagada', NULL, 20)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (3, 3, CAST(N'2026-08-01' AS Date), 82500.00, CAST(N'2026-09-10' AS Date), 7500.00, 0.25, 0.00, N'Pagada', NULL, 66)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (4, 4, CAST(N'2026-08-01' AS Date), 49500.00, CAST(N'2026-09-10' AS Date), 4500.00, 0.15, 0.00, N'Pagada', NULL, 64)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (5, 1, CAST(N'2026-09-01' AS Date), 105600.00, CAST(N'2026-10-10' AS Date), 9600.00, 0.30, 0.00, N'Pagada', NULL, 33)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (6, 2, CAST(N'2026-09-01' AS Date), 105600.00, CAST(N'2026-10-10' AS Date), 9600.00, 0.30, 0.00, N'Pagada', NULL, 34)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (7, 3, CAST(N'2026-09-01' AS Date), 88000.00, CAST(N'2026-10-10' AS Date), 8000.00, 0.25, 0.00, N'Vencida', NULL, 10)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (8, 4, CAST(N'2026-09-01' AS Date), 52800.00, CAST(N'2026-10-10' AS Date), 4800.00, 0.15, 0.00, N'Vencida', NULL, 80)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (9, 1, CAST(N'2026-10-01' AS Date), 112200.00, CAST(N'2026-11-20' AS Date), 10200.00, 0.30, 0.00, N'Pendiente', NULL, 74)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (10, 2, CAST(N'2026-10-01' AS Date), 112200.00, CAST(N'2026-11-20' AS Date), 10200.00, 0.30, 0.00, N'Pendiente', NULL, 75)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (11, 3, CAST(N'2026-10-01' AS Date), 102300.00, CAST(N'2026-11-20' AS Date), 8500.00, 0.25, 8800.00, N'PagadaParcial', NULL, 16)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (12, 4, CAST(N'2026-10-01' AS Date), 59380.00, CAST(N'2026-11-20' AS Date), 5100.00, 0.15, 3280.00, N'Anulada', N'Error en el coeficiente aplicado', 61)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (13, 5, CAST(N'2026-09-01' AS Date), 55000.00, CAST(N'2026-10-10' AS Date), 5000.00, 0.50, 0.00, N'Pagada', NULL, 89)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (14, 6, CAST(N'2026-09-01' AS Date), 33000.00, CAST(N'2026-10-10' AS Date), 3000.00, 0.30, 0.00, N'Vencida', NULL, 35)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (15, 7, CAST(N'2026-09-01' AS Date), 22000.00, CAST(N'2026-10-10' AS Date), 2000.00, 0.20, 0.00, N'Vencida', NULL, 4)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (16, 5, CAST(N'2026-10-01' AS Date), 60500.00, CAST(N'2026-11-20' AS Date), 5500.00, 0.50, 0.00, N'Pendiente', NULL, 86)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (17, 6, CAST(N'2026-10-01' AS Date), 39600.00, CAST(N'2026-11-20' AS Date), 3300.00, 0.30, 3300.00, N'Pendiente', NULL, 88)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (18, 7, CAST(N'2026-10-01' AS Date), 26400.00, CAST(N'2026-11-20' AS Date), 2200.00, 0.20, 2200.00, N'Pendiente', NULL, 93)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (19, 8, CAST(N'2026-10-01' AS Date), 110000.00, CAST(N'2026-11-25' AS Date), 10000.00, 0.50, 0.00, N'Pagada', NULL, 43)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (20, 9, CAST(N'2026-10-01' AS Date), 66000.00, CAST(N'2026-11-25' AS Date), 6000.00, 0.30, 0.00, N'Pendiente', NULL, 40)
INSERT [dbo].[EXPENSA] ([IdExpensa], [IdUnidadFuncional], [Periodo], [Monto], [FechaVencimiento], [HonorarioAplicado], [CoeficienteAplicado], [RecargoPorMora], [Estado], [MotivoAnulacion], [DVH]) VALUES (21, 10, CAST(N'2026-10-01' AS Date), 44000.00, CAST(N'2026-11-25' AS Date), 4000.00, 0.20, 0.00, N'Pendiente', NULL, 82)
GO
SET IDENTITY_INSERT [dbo].[EXPENSA] OFF
GO
SET IDENTITY_INSERT [dbo].[ORDEN_PAGO] ON
GO
INSERT [dbo].[ORDEN_PAGO] ([IdOrdenPago], [IdExpensa], [NumeroOrden], [Monto], [FechaVencimiento], [Estado], [PropietarioSnapshot], [DVH]) VALUES (1, 9, 1, 112200.00, CAST(N'2026-11-20' AS Date), N'Vigente', N'Juan Perez', 89)
INSERT [dbo].[ORDEN_PAGO] ([IdOrdenPago], [IdExpensa], [NumeroOrden], [Monto], [FechaVencimiento], [Estado], [PropietarioSnapshot], [DVH]) VALUES (2, 20, 2, 66000.00, CAST(N'2026-11-25' AS Date), N'Vigente', N'Lucia Castro', 50)
GO
SET IDENTITY_INSERT [dbo].[ORDEN_PAGO] OFF
GO
SET IDENTITY_INSERT [dbo].[PAGO] ON
GO
INSERT [dbo].[PAGO] ([IdPago], [IdExpensa], [Monto], [FechaPago], [MedioPago], [NumeroComprobante], [DVH]) VALUES (1, 1, 99000.00, CAST(N'2026-09-02' AS Date), N'Transferencia', N'P-PRUEBA-001', 63)
INSERT [dbo].[PAGO] ([IdPago], [IdExpensa], [Monto], [FechaPago], [MedioPago], [NumeroComprobante], [DVH]) VALUES (2, 2, 99000.00, CAST(N'2026-09-03' AS Date), N'Efectivo', N'P-PRUEBA-002', 52)
INSERT [dbo].[PAGO] ([IdPago], [IdExpensa], [Monto], [FechaPago], [MedioPago], [NumeroComprobante], [DVH]) VALUES (3, 3, 82500.00, CAST(N'2026-09-04' AS Date), N'Debito', N'P-PRUEBA-003', 48)
INSERT [dbo].[PAGO] ([IdPago], [IdExpensa], [Monto], [FechaPago], [MedioPago], [NumeroComprobante], [DVH]) VALUES (4, 4, 49500.00, CAST(N'2026-09-05' AS Date), N'Cheque', N'P-PRUEBA-004', 96)
INSERT [dbo].[PAGO] ([IdPago], [IdExpensa], [Monto], [FechaPago], [MedioPago], [NumeroComprobante], [DVH]) VALUES (5, 5, 105600.00, CAST(N'2026-10-05' AS Date), N'Transferencia', N'P-PRUEBA-005', 71)
INSERT [dbo].[PAGO] ([IdPago], [IdExpensa], [Monto], [FechaPago], [MedioPago], [NumeroComprobante], [DVH]) VALUES (6, 6, 105600.00, CAST(N'2026-10-08' AS Date), N'Efectivo', N'P-PRUEBA-006', 66)
INSERT [dbo].[PAGO] ([IdPago], [IdExpensa], [Monto], [FechaPago], [MedioPago], [NumeroComprobante], [DVH]) VALUES (7, 8, 20000.00, CAST(N'2026-10-07' AS Date), N'Efectivo', N'P-PRUEBA-007', 66)
INSERT [dbo].[PAGO] ([IdPago], [IdExpensa], [Monto], [FechaPago], [MedioPago], [NumeroComprobante], [DVH]) VALUES (8, 11, 30000.00, CAST(N'2026-11-02' AS Date), N'Transferencia', N'P-PRUEBA-008', 0)
INSERT [dbo].[PAGO] ([IdPago], [IdExpensa], [Monto], [FechaPago], [MedioPago], [NumeroComprobante], [DVH]) VALUES (9, 13, 55000.00, CAST(N'2026-10-03' AS Date), N'Transferencia', N'P-PRUEBA-009', 79)
INSERT [dbo].[PAGO] ([IdPago], [IdExpensa], [Monto], [FechaPago], [MedioPago], [NumeroComprobante], [DVH]) VALUES (10, 19, 110000.00, CAST(N'2026-11-03' AS Date), N'Cheque', N'P-PRUEBA-010', 77)
GO
SET IDENTITY_INSERT [dbo].[PAGO] OFF
GO
SET IDENTITY_INSERT [dbo].[SERVICIO] ON
GO
INSERT [dbo].[SERVICIO] ([IdServicio], [IdConsorcio], [IdProveedor], [Categoria], [Descripcion], [Costo], [Estado], [IdUnidadFuncional], [PlazoEstimado], [FechaAsignacion], [FechaPrestacion], [DescripcionTrabajo], [NumeroFactura], [ArchivoAdjunto], [MotivoRechazo], [DVH]) VALUES (1, 1, NULL, N'Plomeria', N'Perdida de agua en el hall', 0.00, N'Pendiente de asignacion', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 30)
INSERT [dbo].[SERVICIO] ([IdServicio], [IdConsorcio], [IdProveedor], [Categoria], [Descripcion], [Costo], [Estado], [IdUnidadFuncional], [PlazoEstimado], [FechaAsignacion], [FechaPrestacion], [DescripcionTrabajo], [NumeroFactura], [ArchivoAdjunto], [MotivoRechazo], [DVH]) VALUES (2, 1, NULL, N'Electricidad', N'Enchufe quemado en la unidad', 0.00, N'Pendiente de asignacion', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 83)
INSERT [dbo].[SERVICIO] ([IdServicio], [IdConsorcio], [IdProveedor], [Categoria], [Descripcion], [Costo], [Estado], [IdUnidadFuncional], [PlazoEstimado], [FechaAsignacion], [FechaPrestacion], [DescripcionTrabajo], [NumeroFactura], [ArchivoAdjunto], [MotivoRechazo], [DVH]) VALUES (3, 2, NULL, N'Pintura', N'Pintar el palier', 0.00, N'Pendiente de asignacion', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 90)
INSERT [dbo].[SERVICIO] ([IdServicio], [IdConsorcio], [IdProveedor], [Categoria], [Descripcion], [Costo], [Estado], [IdUnidadFuncional], [PlazoEstimado], [FechaAsignacion], [FechaPrestacion], [DescripcionTrabajo], [NumeroFactura], [ArchivoAdjunto], [MotivoRechazo], [DVH]) VALUES (4, 3, NULL, N'Plomeria', N'Revisar tanque de agua', 0.00, N'Pendiente de asignacion', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 58)
INSERT [dbo].[SERVICIO] ([IdServicio], [IdConsorcio], [IdProveedor], [Categoria], [Descripcion], [Costo], [Estado], [IdUnidadFuncional], [PlazoEstimado], [FechaAsignacion], [FechaPrestacion], [DescripcionTrabajo], [NumeroFactura], [ArchivoAdjunto], [MotivoRechazo], [DVH]) VALUES (5, 1, 3, N'Gas', N'Revision de la caldera', 0.00, N'Asignado', NULL, 7, CAST(N'2026-11-02' AS Date), NULL, NULL, NULL, NULL, NULL, 21)
INSERT [dbo].[SERVICIO] ([IdServicio], [IdConsorcio], [IdProveedor], [Categoria], [Descripcion], [Costo], [Estado], [IdUnidadFuncional], [PlazoEstimado], [FechaAsignacion], [FechaPrestacion], [DescripcionTrabajo], [NumeroFactura], [ArchivoAdjunto], [MotivoRechazo], [DVH]) VALUES (6, 2, 2, N'Electricidad', N'Cambiar tablero del pasillo', 0.00, N'Asignado', NULL, 10, CAST(N'2026-11-03' AS Date), NULL, NULL, NULL, NULL, NULL, 27)
INSERT [dbo].[SERVICIO] ([IdServicio], [IdConsorcio], [IdProveedor], [Categoria], [Descripcion], [Costo], [Estado], [IdUnidadFuncional], [PlazoEstimado], [FechaAsignacion], [FechaPrestacion], [DescripcionTrabajo], [NumeroFactura], [ArchivoAdjunto], [MotivoRechazo], [DVH]) VALUES (7, 1, 1, N'Plomeria', N'Destapar caneria de la cochera', 38000.00, N'Prestado', 4, 5, CAST(N'2026-10-26' AS Date), CAST(N'2026-11-01' AS Date), N'Se destapo la caneria y se cambio un codo', N'A-0001-00001234', NULL, NULL, 44)
INSERT [dbo].[SERVICIO] ([IdServicio], [IdConsorcio], [IdProveedor], [Categoria], [Descripcion], [Costo], [Estado], [IdUnidadFuncional], [PlazoEstimado], [FechaAsignacion], [FechaPrestacion], [DescripcionTrabajo], [NumeroFactura], [ArchivoAdjunto], [MotivoRechazo], [DVH]) VALUES (8, 3, 2, N'Electricidad', N'Luces de emergencia', 52000.00, N'Prestado', NULL, 7, CAST(N'2026-10-25' AS Date), CAST(N'2026-11-02' AS Date), N'Se cambiaron 6 luces de emergencia', N'B-0002-00004567', NULL, NULL, 46)
INSERT [dbo].[SERVICIO] ([IdServicio], [IdConsorcio], [IdProveedor], [Categoria], [Descripcion], [Costo], [Estado], [IdUnidadFuncional], [PlazoEstimado], [FechaAsignacion], [FechaPrestacion], [DescripcionTrabajo], [NumeroFactura], [ArchivoAdjunto], [MotivoRechazo], [DVH]) VALUES (9, 1, 2, N'Electricidad', N'Portero electrico', 45000.00, N'Aprobado', NULL, 5, CAST(N'2026-10-15' AS Date), CAST(N'2026-10-22' AS Date), N'Se cambio la central del portero', N'A-0003-00000321', NULL, NULL, 4)
INSERT [dbo].[SERVICIO] ([IdServicio], [IdConsorcio], [IdProveedor], [Categoria], [Descripcion], [Costo], [Estado], [IdUnidadFuncional], [PlazoEstimado], [FechaAsignacion], [FechaPrestacion], [DescripcionTrabajo], [NumeroFactura], [ArchivoAdjunto], [MotivoRechazo], [DVH]) VALUES (10, 2, 3, N'Gas', N'Cambio de canerias de gas', 90000.00, N'Aprobado', NULL, 15, CAST(N'2026-10-01' AS Date), CAST(N'2026-10-20' AS Date), N'Se reemplazo el tramo principal', N'A-0004-00000777', NULL, NULL, 90)
INSERT [dbo].[SERVICIO] ([IdServicio], [IdConsorcio], [IdProveedor], [Categoria], [Descripcion], [Costo], [Estado], [IdUnidadFuncional], [PlazoEstimado], [FechaAsignacion], [FechaPrestacion], [DescripcionTrabajo], [NumeroFactura], [ArchivoAdjunto], [MotivoRechazo], [DVH]) VALUES (11, 1, 3, N'Gas', N'Revision de medidores', 80000.00, N'Rechazado', NULL, 3, CAST(N'2026-10-10' AS Date), CAST(N'2026-10-14' AS Date), N'Revision de 4 medidores', N'C-0005-00000088', NULL, N'El presupuesto supera lo acordado', 0)
INSERT [dbo].[SERVICIO] ([IdServicio], [IdConsorcio], [IdProveedor], [Categoria], [Descripcion], [Costo], [Estado], [IdUnidadFuncional], [PlazoEstimado], [FechaAsignacion], [FechaPrestacion], [DescripcionTrabajo], [NumeroFactura], [ArchivoAdjunto], [MotivoRechazo], [DVH]) VALUES (12, 1, 1, N'Plomeria', N'Cambio de bomba de agua', 30000.00, N'Pagado', NULL, 4, CAST(N'2026-10-05' AS Date), CAST(N'2026-10-12' AS Date), N'Se instalo una bomba nueva', N'A-0001-00001100', NULL, NULL, 71)
GO
SET IDENTITY_INSERT [dbo].[SERVICIO] OFF
GO
SET IDENTITY_INSERT [dbo].[EGRESO] ON
GO
INSERT [dbo].[EGRESO] ([IdEgreso], [IdConsorcio], [IdServicio], [IdProveedor], [Concepto], [Monto], [Fecha], [DVH]) VALUES (1, 1, 12, 1, N'Cambio de bomba de agua', 30000.00, CAST(N'2026-11-02' AS Date), 44)
INSERT [dbo].[EGRESO] ([IdEgreso], [IdConsorcio], [IdServicio], [IdProveedor], [Concepto], [Monto], [Fecha], [DVH]) VALUES (2, 1, NULL, NULL, N'Lamparas LED para pasillos', 12000.00, CAST(N'2026-11-03' AS Date), 43)
INSERT [dbo].[EGRESO] ([IdEgreso], [IdConsorcio], [IdServicio], [IdProveedor], [Concepto], [Monto], [Fecha], [DVH]) VALUES (3, 2, NULL, NULL, N'Productos de limpieza', 20000.00, CAST(N'2026-11-03' AS Date), 88)
GO
SET IDENTITY_INSERT [dbo].[EGRESO] OFF
GO
INSERT [dbo].[UNIDAD_CONSORCISTA] ([IdUnidadFuncional], [IdConsorcista], [EsPropietario], [DVH]) VALUES (1, 1, 1, 50)
INSERT [dbo].[UNIDAD_CONSORCISTA] ([IdUnidadFuncional], [IdConsorcista], [EsPropietario], [DVH]) VALUES (2, 2, 1, 53)
INSERT [dbo].[UNIDAD_CONSORCISTA] ([IdUnidadFuncional], [IdConsorcista], [EsPropietario], [DVH]) VALUES (2, 4, 0, 60)
INSERT [dbo].[UNIDAD_CONSORCISTA] ([IdUnidadFuncional], [IdConsorcista], [EsPropietario], [DVH]) VALUES (3, 1, 1, 52)
INSERT [dbo].[UNIDAD_CONSORCISTA] ([IdUnidadFuncional], [IdConsorcista], [EsPropietario], [DVH]) VALUES (4, 3, 1, 57)
INSERT [dbo].[UNIDAD_CONSORCISTA] ([IdUnidadFuncional], [IdConsorcista], [EsPropietario], [DVH]) VALUES (5, 5, 1, 62)
INSERT [dbo].[UNIDAD_CONSORCISTA] ([IdUnidadFuncional], [IdConsorcista], [EsPropietario], [DVH]) VALUES (6, 6, 1, 65)
INSERT [dbo].[UNIDAD_CONSORCISTA] ([IdUnidadFuncional], [IdConsorcista], [EsPropietario], [DVH]) VALUES (7, 7, 1, 68)
INSERT [dbo].[UNIDAD_CONSORCISTA] ([IdUnidadFuncional], [IdConsorcista], [EsPropietario], [DVH]) VALUES (8, 8, 1, 71)
INSERT [dbo].[UNIDAD_CONSORCISTA] ([IdUnidadFuncional], [IdConsorcista], [EsPropietario], [DVH]) VALUES (9, 9, 1, 74)
INSERT [dbo].[UNIDAD_CONSORCISTA] ([IdUnidadFuncional], [IdConsorcista], [EsPropietario], [DVH]) VALUES (10, 10, 1, 47)
INSERT [dbo].[UNIDAD_CONSORCISTA] ([IdUnidadFuncional], [IdConsorcista], [EsPropietario], [DVH]) VALUES (11, 10, 1, 49)
INSERT [dbo].[UNIDAD_CONSORCISTA] ([IdUnidadFuncional], [IdConsorcista], [EsPropietario], [DVH]) VALUES (12, 11, 1, 55)
GO
SET IDENTITY_INSERT [dbo].[UNIDAD_FUNCIONAL_C] ON
GO
INSERT [dbo].[UNIDAD_FUNCIONAL_C] ([IdHistorico], [IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [Fecha], [Hora], [Act], [Operacion]) VALUES (1, 12, 4, N'1', N'Departamento', 1.00, 1, CAST(N'2026-11-06' AS Date), CAST(N'00:30:29.0000000' AS Time), 1, N'Alta')
INSERT [dbo].[UNIDAD_FUNCIONAL_C] ([IdHistorico], [IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [Fecha], [Hora], [Act], [Operacion]) VALUES (2, 11, 3, N'D', N'Baulera', 0.10, 0, CAST(N'2026-11-06' AS Date), CAST(N'00:30:29.0000000' AS Time), 1, N'Alta')
INSERT [dbo].[UNIDAD_FUNCIONAL_C] ([IdHistorico], [IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [Fecha], [Hora], [Act], [Operacion]) VALUES (3, 10, 3, N'C', N'Departamento', 0.20, 1, CAST(N'2026-11-06' AS Date), CAST(N'00:30:29.0000000' AS Time), 1, N'Alta')
INSERT [dbo].[UNIDAD_FUNCIONAL_C] ([IdHistorico], [IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [Fecha], [Hora], [Act], [Operacion]) VALUES (4, 9, 3, N'B', N'Departamento', 0.30, 1, CAST(N'2026-11-06' AS Date), CAST(N'00:30:29.0000000' AS Time), 1, N'Alta')
INSERT [dbo].[UNIDAD_FUNCIONAL_C] ([IdHistorico], [IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [Fecha], [Hora], [Act], [Operacion]) VALUES (5, 8, 3, N'A', N'Departamento', 0.50, 1, CAST(N'2026-11-06' AS Date), CAST(N'00:30:29.0000000' AS Time), 1, N'Alta')
INSERT [dbo].[UNIDAD_FUNCIONAL_C] ([IdHistorico], [IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [Fecha], [Hora], [Act], [Operacion]) VALUES (6, 7, 2, N'1B', N'Departamento', 0.20, 1, CAST(N'2026-11-06' AS Date), CAST(N'00:30:29.0000000' AS Time), 1, N'Alta')
INSERT [dbo].[UNIDAD_FUNCIONAL_C] ([IdHistorico], [IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [Fecha], [Hora], [Act], [Operacion]) VALUES (7, 6, 2, N'1A', N'Departamento', 0.30, 1, CAST(N'2026-11-06' AS Date), CAST(N'00:30:29.0000000' AS Time), 1, N'Alta')
INSERT [dbo].[UNIDAD_FUNCIONAL_C] ([IdHistorico], [IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [Fecha], [Hora], [Act], [Operacion]) VALUES (8, 5, 2, N'PB', N'Local', 0.50, 1, CAST(N'2026-11-06' AS Date), CAST(N'00:30:29.0000000' AS Time), 1, N'Alta')
INSERT [dbo].[UNIDAD_FUNCIONAL_C] ([IdHistorico], [IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [Fecha], [Hora], [Act], [Operacion]) VALUES (9, 4, 1, N'2B', N'Cochera', 0.15, 1, CAST(N'2026-11-06' AS Date), CAST(N'00:30:29.0000000' AS Time), 1, N'Alta')
INSERT [dbo].[UNIDAD_FUNCIONAL_C] ([IdHistorico], [IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [Fecha], [Hora], [Act], [Operacion]) VALUES (10, 3, 1, N'2A', N'Departamento', 0.25, 1, CAST(N'2026-11-06' AS Date), CAST(N'00:30:29.0000000' AS Time), 1, N'Alta')
INSERT [dbo].[UNIDAD_FUNCIONAL_C] ([IdHistorico], [IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [Fecha], [Hora], [Act], [Operacion]) VALUES (11, 2, 1, N'1B', N'Departamento', 0.30, 1, CAST(N'2026-11-06' AS Date), CAST(N'00:30:29.0000000' AS Time), 0, N'Alta')
INSERT [dbo].[UNIDAD_FUNCIONAL_C] ([IdHistorico], [IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [Fecha], [Hora], [Act], [Operacion]) VALUES (12, 1, 1, N'1A', N'Departamento', 0.30, 1, CAST(N'2026-11-06' AS Date), CAST(N'00:30:29.0000000' AS Time), 1, N'Alta')
INSERT [dbo].[UNIDAD_FUNCIONAL_C] ([IdHistorico], [IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [Fecha], [Hora], [Act], [Operacion]) VALUES (13, 2, 1, N'1B', N'Departamento', 0.35, 1, CAST(N'2026-11-06' AS Date), CAST(N'00:38:59.0000000' AS Time), 0, N'Modificacion')
INSERT [dbo].[UNIDAD_FUNCIONAL_C] ([IdHistorico], [IdUnidadFuncional], [IdConsorcio], [Numero], [Tipo], [Coeficiente], [Activa], [Fecha], [Hora], [Act], [Operacion]) VALUES (14, 2, 1, N'1B', N'Departamento', 0.30, 1, CAST(N'2026-11-06' AS Date), CAST(N'18:30:49.0000000' AS Time), 1, N'Restauracion')
GO
SET IDENTITY_INSERT [dbo].[UNIDAD_FUNCIONAL_C] OFF
GO
INSERT [dbo].[Usuario_Permiso] ([Permiso_ID], [Usuario_ID], [DVH]) VALUES (N'28a2317f-4de7-4976-8810-bf9fc517c6ea', N'ce8ba34d-afa4-4c84-8738-96ceb2e87c00', 48)
INSERT [dbo].[Usuario_Permiso] ([Permiso_ID], [Usuario_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'0e4f5d83-b886-45a9-8429-74b0654cd493', 53)
INSERT [dbo].[Usuario_Permiso] ([Permiso_ID], [Usuario_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'42d88568-a6ab-4d41-a377-a242d7b3fef7', 31)
INSERT [dbo].[Usuario_Permiso] ([Permiso_ID], [Usuario_ID], [DVH]) VALUES (N'ed371317-81c3-456c-8c1a-0a535360e254', N'b9c09721-83e1-4874-9bb2-58d8f4520248', 60)
INSERT [dbo].[Usuario_Permiso] ([Permiso_ID], [Usuario_ID], [DVH]) VALUES (N'28a2317f-4de7-4976-8810-bf9fc517c6ea', N'42d88568-a6ab-4d41-a377-a242d7b3fef7', 96)
GO
ALTER TABLE [dbo].[UNIDAD_FUNCIONAL] ENABLE TRIGGER ALL
GO
