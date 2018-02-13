using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ChartModels
{
    public class DiasSinGestionarSerie
    {
        public string DisplayName { get; set; }

        public List<DiasSingestionarSerieValue> Values { get; set; }

    }

    public class DiasSingestionarSerieValue
    {
        public string Argument { get; set; }

        public double Valor { get; set; }
    }
}
