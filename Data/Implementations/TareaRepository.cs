using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using Domain.ChartModels;
using Domain.Entities;

namespace Data.Implementations
{
    internal class TareaRepository: Repository<Tarea>, ITareaRepository
    {
        internal TareaRepository(CRMContex context) : base(context)
        {
        }

        public List<DiasSinGestionarSerie> SeriesDiasSinGestionar(int clienteId)
        {
            var value = new List<DiasSinGestionarSerie>()
            {
                new DiasSinGestionarSerie()
                {
                    DisplayName = "Llamada",
                    Values =  SeriesDiasSinGestionar(clienteId,TareaTipo.LLamada)
                },

                new DiasSinGestionarSerie()
                {
                    DisplayName = "Visita",
                    Values =  SeriesDiasSinGestionar(clienteId,TareaTipo.Visita)
                }
            };

            return value;

        }


        private List<DiasSingestionarSerieValue> SeriesDiasSinGestionar(int clienteId, TareaTipo tareaTipo)
        {

            var serie = new List<DiasSingestionarSerieValue>();

            for (int i = 1; i < DateTime.Now.Month + 1; i++)
            {

                DateTime firstDay = new DateTime(DateTime.Now.Year, i, 1);
                DateTime lastDay = new DateTime(DateTime.Now.Year, firstDay.Month, DateTime.DaysInMonth(firstDay.Year, firstDay.Month));

                var value = Set.Count(c=> c.TareaTipo == tareaTipo && c.ClienteId == clienteId && c.Fecha <= lastDay.Date && c.Fecha >= firstDay.Date);

                DateTimeFormatInfo mfi = new DateTimeFormatInfo();
                
                serie.Add(new DiasSingestionarSerieValue()
                {
                    Argument =  mfi.GetMonthName(firstDay.Month),
                    Valor = value,
                });
                
            }


            return serie;
        }

       
    }
}
