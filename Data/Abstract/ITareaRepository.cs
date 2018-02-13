using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ChartModels;
using Domain.Entities;

namespace Data.Abstract
{
    public interface ITareaRepository: IRepository<Tarea>
    {
        List<DiasSinGestionarSerie> SeriesDiasSinGestionar(int clientId);
    }
}
