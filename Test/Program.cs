using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Implementations;
using Domain.Entities;
using Faker;
using Faker.Generator;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var clienteFactory = new Faker<Cliente>();
            var clientes = clienteFactory.CreateMany(1);

            using (var uw = new UnitOfWork())
            {
                uw.ClienteRepository.AddAll(clientes);
                uw.SaveChanges();
            }
        }
    }
}
