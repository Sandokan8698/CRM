using Data;
using DevExpress.Mvvm.DataAnnotations;
using Domain.Entities;
using DXUI.Localization;

namespace DXUI.CRMContexDataModel {

    public class CRMContexMetadataProvider {
		        public static void BuildMetadata(MetadataBuilder<Ciudad> builder) {
			builder.DisplayName(CRMContexResources.Ciudad);
						builder.Property(x => x.CiudadId).DisplayName(CRMContexResources.Ciudad_CiudadId);
						builder.Property(x => x.Nombre).DisplayName(CRMContexResources.Ciudad_Nombre);
						builder.Property(x => x.Provincia).DisplayName(CRMContexResources.Ciudad_Provincia);
			        }
		        public static void BuildMetadata(MetadataBuilder<Provincia> builder) {
			builder.DisplayName(CRMContexResources.Provincia);
						builder.Property(x => x.ProvinciaId).DisplayName(CRMContexResources.Provincia_ProvinciaId);
						builder.Property(x => x.Nombre).DisplayName(CRMContexResources.Provincia_Nombre);
			        }
		        public static void BuildMetadata(MetadataBuilder<Claim> builder) {
			builder.DisplayName(CRMContexResources.Claim);
						builder.Property(x => x.ClaimId).DisplayName(CRMContexResources.Claim_ClaimId);
						builder.Property(x => x.ClaimType).DisplayName(CRMContexResources.Claim_ClaimType);
						builder.Property(x => x.ClaimValue).DisplayName(CRMContexResources.Claim_ClaimValue);
						builder.Property(x => x.User).DisplayName(CRMContexResources.Claim_User);
			        }
		        public static void BuildMetadata(MetadataBuilder<User> builder) {
			builder.DisplayName(CRMContexResources.User);
						builder.Property(x => x.UserId).DisplayName(CRMContexResources.User_UserId);
						builder.Property(x => x.UserName).DisplayName(CRMContexResources.User_UserName);
						builder.Property(x => x.PasswordHash).DisplayName(CRMContexResources.User_PasswordHash);
						builder.Property(x => x.SecurityStamp).DisplayName(CRMContexResources.User_SecurityStamp);
						builder.Property(x => x.Perfil).DisplayName(CRMContexResources.User_Perfil);
			        }
		        public static void BuildMetadata(MetadataBuilder<ExternalLogin> builder) {
			builder.DisplayName(CRMContexResources.ExternalLogin);
						builder.Property(x => x.ExternalLoginId).DisplayName(CRMContexResources.ExternalLogin_ExternalLoginId);
						builder.Property(x => x.LoginProvider).DisplayName(CRMContexResources.ExternalLogin_LoginProvider);
						builder.Property(x => x.ProviderKey).DisplayName(CRMContexResources.ExternalLogin_ProviderKey);
						builder.Property(x => x.User).DisplayName(CRMContexResources.ExternalLogin_User);
			        }
		        public static void BuildMetadata(MetadataBuilder<Perfil> builder) {
			builder.DisplayName(CRMContexResources.Perfil);
						builder.Property(x => x.PerfilId).DisplayName(CRMContexResources.Perfil_PerfilId);
						builder.Property(x => x.ImagenUrl).DisplayName(CRMContexResources.Perfil_ImagenUrl);
						builder.Property(x => x.Ocupacion).DisplayName(CRMContexResources.Perfil_Ocupacion);
						builder.Property(x => x.Nombre).DisplayName(CRMContexResources.Perfil_Nombre);
						builder.Property(x => x.Apellidos).DisplayName(CRMContexResources.Perfil_Apellidos);
			        }
		        public static void BuildMetadata(MetadataBuilder<Gerencia> builder) {
			builder.DisplayName(CRMContexResources.Gerencia);
						builder.Property(x => x.PerfilId).DisplayName(CRMContexResources.Gerencia_PerfilId);
						builder.Property(x => x.ImagenUrl).DisplayName(CRMContexResources.Gerencia_ImagenUrl);
						builder.Property(x => x.Ocupacion).DisplayName(CRMContexResources.Gerencia_Ocupacion);
						builder.Property(x => x.Nombre).DisplayName(CRMContexResources.Gerencia_Nombre);
						builder.Property(x => x.Apellidos).DisplayName(CRMContexResources.Gerencia_Apellidos);
						builder.Property(x => x.Nuevo).DisplayName(CRMContexResources.Gerencia_Nuevo);
			        }
		        public static void BuildMetadata(MetadataBuilder<Vendedor> builder) {
			builder.DisplayName(CRMContexResources.Vendedor);
						builder.Property(x => x.PerfilId).DisplayName(CRMContexResources.Vendedor_PerfilId);
						builder.Property(x => x.ImagenUrl).DisplayName(CRMContexResources.Vendedor_ImagenUrl);
						builder.Property(x => x.Ocupacion).DisplayName(CRMContexResources.Vendedor_Ocupacion);
						builder.Property(x => x.Nombre).DisplayName(CRMContexResources.Vendedor_Nombre);
						builder.Property(x => x.Apellidos).DisplayName(CRMContexResources.Vendedor_Apellidos);
						builder.Property(x => x.PresuspuestoAsignado).DisplayName(CRMContexResources.Vendedor_PresuspuestoAsignado);
			        }
		        public static void BuildMetadata(MetadataBuilder<Cliente> builder) {
			builder.DisplayName(CRMContexResources.Cliente);
						builder.Property(x => x.ClienteId).DisplayName(CRMContexResources.Cliente_ClienteId);
						builder.Property(x => x.Ruc).DisplayName(CRMContexResources.Cliente_Ruc);
						builder.Property(x => x.Telefono).DisplayName(CRMContexResources.Cliente_Telefono);
						builder.Property(x => x.TelefonoConvencional).DisplayName(CRMContexResources.Cliente_TelefonoConvencional);
						builder.Property(x => x.Direccion).DisplayName(CRMContexResources.Cliente_Direccion);
						builder.Property(x => x.Email).DisplayName(CRMContexResources.Cliente_Email);
						builder.Property(x => x.FechaNacimiento).DisplayName(CRMContexResources.Cliente_FechaNacimiento);
						builder.Property(x => x.Nombre).DisplayName(CRMContexResources.Cliente_Nombre);
						builder.Property(x => x.Sector).DisplayName(CRMContexResources.Cliente_Sector);
						builder.Property(x => x.DescripcionSector).DisplayName(CRMContexResources.Cliente_DescripcionSector);
						builder.Property(x => x.Division).DisplayName(CRMContexResources.Cliente_Division);
						builder.Property(x => x.VendedorId).DisplayName(CRMContexResources.Cliente_VendedorId);
						builder.Property(x => x.Ciudad).DisplayName(CRMContexResources.Cliente_Ciudad);
						builder.Property(x => x.Provincia).DisplayName(CRMContexResources.Cliente_Provincia);
						builder.Property(x => x.Vendedor).DisplayName(CRMContexResources.Cliente_Vendedor);
			        }
		        public static void BuildMetadata(MetadataBuilder<Contacto> builder) {
			builder.DisplayName(CRMContexResources.Contacto);
						builder.Property(x => x.ContactoId).DisplayName(CRMContexResources.Contacto_ContactoId);
						builder.Property(x => x.Nombre).DisplayName(CRMContexResources.Contacto_Nombre);
						builder.Property(x => x.Cargo).DisplayName(CRMContexResources.Contacto_Cargo);
						builder.Property(x => x.Celular).DisplayName(CRMContexResources.Contacto_Celular);
						builder.Property(x => x.FechaNacimiento).DisplayName(CRMContexResources.Contacto_FechaNacimiento);
						builder.Property(x => x.Email).DisplayName(CRMContexResources.Contacto_Email);
						builder.Property(x => x.TomaDecision).DisplayName(CRMContexResources.Contacto_TomaDecision);
						builder.Property(x => x.Cliente).DisplayName(CRMContexResources.Contacto_Cliente);
			        }
		        public static void BuildMetadata(MetadataBuilder<Oportunidad> builder) {
			builder.DisplayName(CRMContexResources.Oportunidad);
						builder.Property(x => x.OportunidadId).DisplayName(CRMContexResources.Oportunidad_OportunidadId);
						builder.Property(x => x.Nombre).DisplayName(CRMContexResources.Oportunidad_Nombre);
						builder.Property(x => x.FechaInicio).DisplayName(CRMContexResources.Oportunidad_FechaInicio);
						builder.Property(x => x.TipoCartera).DisplayName(CRMContexResources.Oportunidad_TipoCartera);
						builder.Property(x => x.Cantidad).DisplayName(CRMContexResources.Oportunidad_Cantidad);
						builder.Property(x => x.PVU).DisplayName(CRMContexResources.Oportunidad_PVU);
						builder.Property(x => x.Potencial).DisplayName(CRMContexResources.Oportunidad_Potencial);
						builder.Property(x => x.ExpectativaVenta).DisplayName(CRMContexResources.Oportunidad_ExpectativaVenta);
						builder.Property(x => x.ExpectativaAsesor).DisplayName(CRMContexResources.Oportunidad_ExpectativaAsesor);
						builder.Property(x => x.FechaPrevistaCierre).DisplayName(CRMContexResources.Oportunidad_FechaPrevistaCierre);
						builder.Property(x => x.Asesor).DisplayName(CRMContexResources.Oportunidad_Asesor);
						builder.Property(x => x.Cliente).DisplayName(CRMContexResources.Oportunidad_Cliente);
						builder.Property(x => x.ContactoVenta).DisplayName(CRMContexResources.Oportunidad_ContactoVenta);
						builder.Property(x => x.Etapa).DisplayName(CRMContexResources.Oportunidad_Etapa);
						builder.Property(x => x.LineaNegocio).DisplayName(CRMContexResources.Oportunidad_LineaNegocio);
						builder.Property(x => x.Producto).DisplayName(CRMContexResources.Oportunidad_Producto);
						builder.Property(x => x.TipoGestion).DisplayName(CRMContexResources.Oportunidad_TipoGestion);
						builder.Property(x => x.TomadorDesicion).DisplayName(CRMContexResources.Oportunidad_TomadorDesicion);
			        }
		        public static void BuildMetadata(MetadataBuilder<Etapa> builder) {
			builder.DisplayName(CRMContexResources.Etapa);
						builder.Property(x => x.EtapaId).DisplayName(CRMContexResources.Etapa_EtapaId);
						builder.Property(x => x.Porciento).DisplayName(CRMContexResources.Etapa_Porciento);
						builder.Property(x => x.Descripcion).DisplayName(CRMContexResources.Etapa_Descripcion);
			        }
		        public static void BuildMetadata(MetadataBuilder<LineaNegocio> builder) {
			builder.DisplayName(CRMContexResources.LineaNegocio);
						builder.Property(x => x.LineaNegocioId).DisplayName(CRMContexResources.LineaNegocio_LineaNegocioId);
						builder.Property(x => x.Descripcion).DisplayName(CRMContexResources.LineaNegocio_Descripcion);
			        }
		        public static void BuildMetadata(MetadataBuilder<Producto> builder) {
			builder.DisplayName(CRMContexResources.Producto);
						builder.Property(x => x.ProductoId).DisplayName(CRMContexResources.Producto_ProductoId);
						builder.Property(x => x.Nombre).DisplayName(CRMContexResources.Producto_Nombre);
			        }
		        public static void BuildMetadata(MetadataBuilder<TipoGestion> builder) {
			builder.DisplayName(CRMContexResources.TipoGestion);
						builder.Property(x => x.TipoGestionId).DisplayName(CRMContexResources.TipoGestion_TipoGestionId);
						builder.Property(x => x.Descripcion).DisplayName(CRMContexResources.TipoGestion_Descripcion);
			        }
		        public static void BuildMetadata(MetadataBuilder<Role> builder) {
			builder.DisplayName(CRMContexResources.Role);
						builder.Property(x => x.RoleId).DisplayName(CRMContexResources.Role_RoleId);
						builder.Property(x => x.Name).DisplayName(CRMContexResources.Role_Name);
			        }
		        public static void BuildMetadata(MetadataBuilder<Tarea> builder) {
			builder.DisplayName(CRMContexResources.Tarea);
						builder.Property(x => x.TareaId).DisplayName(CRMContexResources.Tarea_TareaId);
						builder.Property(x => x.Fecha).DisplayName(CRMContexResources.Tarea_Fecha);
						builder.Property(x => x.Descripcion).DisplayName(CRMContexResources.Tarea_Descripcion);
						builder.Property(x => x.TareaEstado).DisplayName(CRMContexResources.Tarea_TareaEstado);
						builder.Property(x => x.FechaCumplimiento).DisplayName(CRMContexResources.Tarea_FechaCumplimiento);
						builder.Property(x => x.Identificador).DisplayName(CRMContexResources.Tarea_Identificador);
						builder.Property(x => x.AsignadoA).DisplayName(CRMContexResources.Tarea_AsignadoA);
						builder.Property(x => x.CreadoPor).DisplayName(CRMContexResources.Tarea_CreadoPor);
			        }
		        public static void BuildMetadata(MetadataBuilder<TareaHistorial> builder) {
			builder.DisplayName(CRMContexResources.TareaHistorial);
						builder.Property(x => x.TareaHistorialId).DisplayName(CRMContexResources.TareaHistorial_TareaHistorialId);
						builder.Property(x => x.Descripcion).DisplayName(CRMContexResources.TareaHistorial_Descripcion);
						builder.Property(x => x.Fecha).DisplayName(CRMContexResources.TareaHistorial_Fecha);
						builder.Property(x => x.TareaEstado).DisplayName(CRMContexResources.TareaHistorial_TareaEstado);
						builder.Property(x => x.Tarea).DisplayName(CRMContexResources.TareaHistorial_Tarea);
			        }
		    }
}