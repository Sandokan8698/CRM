using DUI.DataModel.DesignTime;
using DUI.DataModel.Model;
using DUI.DataModel.Runtime;

namespace DUI.DataModel {
    public static class UnitOfWorkSource {
        class DbUnitOfWorkFactory : IUnitOfWorkFactory {
            public static readonly IUnitOfWorkFactory Instance = new DbUnitOfWorkFactory();
            DbUnitOfWorkFactory() { }
            IRealtorWorldUnitOfWork IUnitOfWorkFactory.CreateUnitOfWork() {
                return new RealtorWorldUnitOfWork();
            }
        }
        class DesignUnitOfWorkFactory : IUnitOfWorkFactory {
            public static readonly IUnitOfWorkFactory Instance = new DesignUnitOfWorkFactory();
            DesignUnitOfWorkFactory() { }
            IRealtorWorldUnitOfWork IUnitOfWorkFactory.CreateUnitOfWork() {
                return new DesignTimeRealtorWorldUnitOfWork();
            }
        }
        public static IUnitOfWorkFactory GetUnitOfWorkFactory(bool isInDesignTime = false) {
            return isInDesignTime ? DesignUnitOfWorkFactory.Instance : DbUnitOfWorkFactory.Instance;
        }
        public static IRealtorWorldUnitOfWork CreateUnitOfWork(bool isInDesignTime = false) {
            return GetUnitOfWorkFactory(isInDesignTime).CreateUnitOfWork();
        }
    }
}
