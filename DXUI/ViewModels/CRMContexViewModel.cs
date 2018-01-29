using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using DXUI.Localization;using DXUI.CRMContexDataModel;

namespace DXUI.ViewModels {
    /// <summary>
    /// Represents the root POCO view model for the CRMContex data model.
    /// </summary>
    public partial class CRMContexViewModel : DocumentsViewModel<CRMContexModuleDescription, ICRMContexUnitOfWork> {

		const string TablesGroup = "Tables";

		const string ViewsGroup = "Views";
		INavigationService NavigationService { get { return this.GetService<INavigationService>(); } }
	
        /// <summary>
        /// Creates a new instance of CRMContexViewModel as a POCO view model.
        /// </summary>
        public static CRMContexViewModel Create() {
            return ViewModelSource.Create(() => new CRMContexViewModel());
        }

		        static CRMContexViewModel() {
            MetadataLocator.Default = MetadataLocator.Create().AddMetadata<CRMContexMetadataProvider>();
        }
        /// <summary>
        /// Initializes a new instance of the CRMContexViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the CRMContexViewModel type without the POCO proxy factory.
        /// </summary>
        protected CRMContexViewModel()
		    : base(UnitOfWorkSource.GetUnitOfWorkFactory()) {
        }

        protected override CRMContexModuleDescription[] CreateModules() {
			return new CRMContexModuleDescription[] {
                new CRMContexModuleDescription(CRMContexResources.CiudadPlural, "CiudadCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.CiudadDbSet)),
                new CRMContexModuleDescription(CRMContexResources.ProvinciaPlural, "ProvinciaCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.ProviciaDbSet)),
                new CRMContexModuleDescription(CRMContexResources.ClaimPlural, "ClaimCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.ClaimDbSet)),
                new CRMContexModuleDescription(CRMContexResources.UserPlural, "UserCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.UserDbSet)),
                new CRMContexModuleDescription(CRMContexResources.ExternalLoginPlural, "ExternalLoginCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.ExternalLoginDbSet)),
                new CRMContexModuleDescription(CRMContexResources.PerfilPlural, "PerfilCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.PefilDbset)),
                new CRMContexModuleDescription(CRMContexResources.GerenciaPlural, "GerenciaCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Gerencia)),
                new CRMContexModuleDescription(CRMContexResources.VendedorPlural, "VendedorCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Vendedor)),
                new CRMContexModuleDescription(CRMContexResources.ClientePlural, "ClienteCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Clientes)),
                new CRMContexModuleDescription(CRMContexResources.ContactoPlural, "ContactoCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.ContactoDbSet)),
                new CRMContexModuleDescription(CRMContexResources.OportunidadPlural, "OportunidadCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.OportunidadDsDbSet)),
                new CRMContexModuleDescription(CRMContexResources.EtapaPlural, "EtapaCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Etapas)),
                new CRMContexModuleDescription(CRMContexResources.LineaNegocioPlural, "LineaNegocioCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.LineaNegocios)),
                new CRMContexModuleDescription(CRMContexResources.ProductoPlural, "ProductoCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Productoes)),
                new CRMContexModuleDescription(CRMContexResources.TipoGestionPlural, "TipoGestionCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.TipoGestions)),
                new CRMContexModuleDescription(CRMContexResources.RolePlural, "RoleCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.RoleDbSet)),
                new CRMContexModuleDescription(CRMContexResources.TareaPlural, "TareaCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.TareaDbSet)),
                new CRMContexModuleDescription(CRMContexResources.TareaHistorialPlural, "TareaHistorialCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.TareaHistorials)),
			};
        }
                		protected override void OnActiveModuleChanged(CRMContexModuleDescription oldModule) {
            if(ActiveModule != null && NavigationService != null) {
                NavigationService.ClearNavigationHistory();
            }
            base.OnActiveModuleChanged(oldModule);
        }
	}

    public partial class CRMContexModuleDescription : ModuleDescription<CRMContexModuleDescription> {
        public CRMContexModuleDescription(string title, string documentType, string group, Func<CRMContexModuleDescription, object> peekCollectionViewModelFactory = null)
            : base(title, documentType, group, peekCollectionViewModelFactory) {
        }
    }
}