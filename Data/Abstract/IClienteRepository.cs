using System;
using System.Collections.Generic;
using Data.Abstract;
using Domain.Entities;
using Domain.Views;

namespace Data.Abstract
{
    public interface IClienteRepository: IRepository<Cliente>
    {
        List<ViewDiasSinGestionar> DiasSinGestionar(int userId);
    }
}