# 🏢 ConsorAdmin

> Sistema de administración de consorcios de propiedad.  
> Liquidación y cobro de expensas, gestión de servicios con proveedores y reportes, todo en un solo lugar.

**UAI** · Trabajo de Diploma 2026  
**Alumno:** Martin Nahuel Esquivel Barker  
**Legajo:** B00103913-T1

---

## 🏗️ Arquitectura

El sistema está armado en **capas** sobre una única base de datos SQL Server (`ConsorAdminDB`):

```
                         ┌──────────────────────┐
                         │         App          │  WinForms MDI (.NET 8)
                         └──────────┬───────────┘
                                    │
                         ┌──────────┴───────────┐
                         │         BLL          │  Reglas de negocio
                         └──────────┬───────────┘
                                    │
                         ┌──────────┴───────────┐
                         │         DAL          │  ADO.NET (SqlClient)
                         └──────────┬───────────┘
                                    │
                         ┌──────────┴───────────┐
                         │   📦 ConsorAdminDB   │  SQL Server / LocalDB
                         └──────────────────────┘

     Transversales a todas las capas:
     ┌────────────┐   ┌────────────┐   ┌──────────────────────────────┐
     │    INT     │   │     BE     │   │             SER              │
     │(interfaces)│   │(entidades) │   │ sesión, permisos, servicios  │
     └────────────┘   └────────────┘   └──────────────────────────────┘
```

| Capa | Proyecto | Responsabilidad | Referencia a |
|------|----------|-----------------|--------------|
| Presentación | `App` (AppBase) | Formularios WinForms MDI y ayuda en línea | BE, BLL, SER |
| Lógica de negocio | `BLL` | Validaciones, reglas y orquestación de cada caso de uso | BE, DAL, INT, SER |
| Acceso a datos | `DAL` | Consultas SQL con ADO.NET | BE, INT, SER |
| Servicios | `SER` | Sesión, permisos (Composite), encriptación, PDF, XML, ayuda | INT, BE |
| Entidades | `BE` | Clases que representan las tablas | INT |
| Interfaces | `INT` | Contratos y enumerados compartidos | Ninguna |

Cada BLL trabaja solamente con su propio DAL; cuando necesita datos de otra entidad se los pide a la BLL dueña.

---

## 📁 Estructura del proyecto

Las clases propias del negocio llevan el sufijo **`_755ME`** y se agrupan por proceso: **PN01** (liquidación de expensas) y **PN02** (gestión de servicios).

### 🔒 SER/ · Servicios transversales

```
SER/
├── 📂 Composite/                🎯 Patrón Composite
│   ├── PermisoCompuesto.cs      Clase base abstracta
│   ├── Familia.cs               Nodo: agrupa patentes y otras familias
│   └── Patente.cs               Hoja: habilita una opción del menú
├── SessionManager.cs            🔁 Singleton: usuario logueado e idioma
├── Encriptador.cs               🔐 Hash SHA-256 de contraseñas
├── ExportadorPdfService.cs      📄 Reportes en PDF (PDFsharp)
├── SerializacionService_755ME.cs  Serialización XML de expensas
├── AyudaService_755ME.cs        Ruta de los temas de la ayuda en línea
└── Excepciones*.cs              Excepciones propias (login, base de datos, unidad no encontrada)
```

### 📦 BE/ · Entidades

```
BE/
├── Usuario.cs · Bitacora.cs · Idioma.cs · Etiqueta.cs · Traduccion.cs · DigitoVerificadorVertical.cs
├── 📂 PN01/                     Consorcio, UnidadFuncional, Consorcista, Gasto, Expensa, Pago,
│                                OrdenDePago, Egreso, Servicio, historial de unidades y BE de reportes
└── 📂 PN02/                     Proveedor
```

### 🗄️ DAL/ · Acceso a datos

```
DAL/
├── Conexion.cs                  Lee el servidor de Configuracion_755ME.txt
├── AbstractDAL.cs · DAO.cs      Base genérica de CRUD y ejecución de SQL
├── UsuarioDAL.cs · PermisoDAL.cs · BitacoraDAL.cs · TraductorDAL.cs
├── BackupDAL.cs                 BACKUP / RESTORE de SQL Server
├── DigitoVerificadorVerticalDAL.cs
├── 📂 PN01/                     Un DAL por entidad de expensas + ReporteGlobalDAL
└── 📂 PN02/                     ProveedorDAL
```

### ⚙️ BLL/ · Lógica de negocio

```
BLL/
├── UsuarioBLL.cs                Login, bloqueo por intentos fallidos, alta y permisos
├── PermisoBLL.cs                Familias y patentes
├── VerificadorBLL.cs            Cálculo y control de DVH / DVV
├── ResolucionIntegridadBLL.cs   Restaurar backup o recalcular dígitos ante una falla
├── BitacoraBLL.cs · BackupBLL.cs · TraductorBLL.cs
├── 📂 PN01/                     Consorcios, unidades, gastos, liquidación, pagos, órdenes,
│                                egresos, fondo, estado de cuenta y reporte global
└── 📂 PN02/                     Proveedores y servicios
```

### 🖥️ App/ · Interfaz

```
App/
├── Program.cs                   Punto de entrada, cultura es-AR y control de conexión
├── frmMdiPrincipal.cs           MDI padre, menú armado según las patentes del usuario
├── frmLogin.cs · frmUsuarios.cs · frmFamilias.cs · frmEditarIdiomas.cs
├── frmBackup.cs · frmBitacora.cs · frmIntegridad.cs
├── Form*_755ME.cs               Pantallas de negocio (PN01 y PN02), reportes y serialización
├── FormAyuda_755ME.cs           ❓ Ventana de ayuda en línea (F1)
└── 📂 Ayuda/                    🌐 Temas de ayuda en HTML (es / en)
```

---

## 🎨 Patrones de diseño

| Patrón | Implementación | Propósito |
|--------|----------------|-----------|
| 🔁 **Singleton** | `SessionManager` | Una sola sesión activa en toda la aplicación |
| 🌳 **Composite** | `PermisoCompuesto` → `Familia` + `Patente` | Árbol de permisos asignable a usuarios |
| 👁️ **Observer** | `IIdiomaObserver` + `SessionManager` | Las pantallas abiertas se traducen al cambiar de idioma |
| 🧱 **Clase base genérica** | `AbstractDAL<T>` / `AbstractBLL<T>` sobre `ICrud<T>` | CRUD común para las entidades de seguridad |

---

## 🗄️ Base de datos

### ConsorAdminDB

> Seguridad y arquitectura base

`Usuario` · `Permiso` · `Familia_Patente` · `Usuario_Permiso` · `Bitacora` · `Idioma` · `Etiqueta` · `Traduccion` · `DigitoVerificadorVertical`

> Negocio

`CONSORCIO` · `UNIDAD_FUNCIONAL` · `UNIDAD_FUNCIONAL_C` · `CONSORCISTA` · `UNIDAD_CONSORCISTA` · `GASTO` · `EXPENSA` · `PAGO` · `ORDEN_PAGO` · `EGRESO` · `SERVICIO` · `PROVEEDOR`

`UNIDAD_FUNCIONAL_C` guarda el historial de cambios de las unidades funcionales y la completan los triggers `TR_UNIDAD_FUNCIONAL_Insert` y `TR_UNIDAD_FUNCIONAL_Update`.

---

## 🛠️ Tecnologías

- .NET 8.0
- Windows Forms (WinForms MDI)
- ADO.NET (`System.Data.SqlClient`)
- SQL Server / SQL Server LocalDB
- PDFsharp (reportes PDF)
- Inno Setup (instalador)

---

<p align="center">
  <sub>ConsorAdmin · UAI 2026</sub>
</p>
