using Data;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.DesignTime;
using DevExpress.Mvvm.DataModel.EF6;
using System;
using System.Collections;
using System.Linq;

namespace DXUI.CRMContexDataModel {

    /// <summary>
    /// Provides methods to obtain the relevant IUnitOfWorkFactory.
    /// </summary>
    public static class UnitOfWorkSource {

        /// <summary>
        /// Returns the IUnitOfWorkFactory implementation based on the current mode (run-time or design-time).
        /// </summary>
        public static IUnitOfWorkFactory<ICRMContexUnitOfWork> GetUnitOfWorkFactory() {
            return GetUnitOfWorkFactory(ViewModelBase.IsInDesignMode);
        }

		/// <summary>
        /// Returns the IUnitOfWorkFactory implementation based on the given mode (run-time or design-time).
        /// </summary>
        /// <param name="isInDesignTime">Used to determine which implementation of IUnitOfWorkFactory should be returned.</param>
        public static IUnitOfWorkFactory<ICRMContexUnitOfWork> GetUnitOfWorkFactory(bool isInDesignTime) {
			if(isInDesignTime)
                return new DesignTimeUnitOfWorkFactory<ICRMContexUnitOfWork>(() => new CRMContexDesignTimeUnitOfWork());
            return new DbUnitOfWorkFactory<ICRMContexUnitOfWork>(() => new CRMContexUnitOfWork(() => new CRMContex()));
        }
    }
}