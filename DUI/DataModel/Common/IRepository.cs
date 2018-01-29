using System.Collections.ObjectModel;
using System.Linq;

namespace DUI.DataModel.Common {
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class {
        IQueryable<TEntity> Get();
        TEntity Find(TPrimaryKey key);
        IUnitOfWork UnitOfWork { get; }
        ObservableCollection<TEntity> Local { get; }
    }
}
