using LocaCarro.Domain.Entities;
using LocaCarro.Infraestructure.Data.Context;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LocaCarro.Infraestructure.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<LocaCarroDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LocaCarroDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Lojas
            var cliente1 = new Cliente() { Id = Guid.NewGuid(), Nome = "Warley Ferreira Silva", Fidelidade = true };
            var cliente2 = new Cliente() { Id = Guid.NewGuid(), Nome = "Fellipe Ferreira Silva", Fidelidade = false };
            var cliente3 = new Cliente() { Id = Guid.NewGuid(), Nome = "Cintia Soares de Oliveira Silva", Fidelidade = true };

            context.Cliente.Add(cliente1);
            context.Cliente.Add(cliente2);
            context.Cliente.Add(cliente3);

            //Tipos de Carro
            var tp1 = new TipoCarro() { Id = Guid.NewGuid(), Descricao = "Compacto", Capacidade = 4 };
            var tp2 = new TipoCarro() { Id = Guid.NewGuid(), Descricao = "Esportivo", Capacidade = 2 };
            var tp3 = new TipoCarro() { Id = Guid.NewGuid(), Descricao = "SUV", Capacidade = 7 };

            context.TipoCarro.Add(tp1);
            context.TipoCarro.Add(tp2);
            context.TipoCarro.Add(tp3);

            //Lojas
            var loja1 = new Loja() { Id = Guid.NewGuid(), Nome = "SouthCar", Tipo = tp1 };
            var loja2 = new Loja() { Id = Guid.NewGuid(), Nome = "WestCar", Tipo = tp2 };
            var loja3 = new Loja() { Id = Guid.NewGuid(), Nome = "NorthCar", Tipo = tp3 };

            context.Loja.Add(loja1);
            context.Loja.Add(loja2);
            context.Loja.Add(loja3);

            //Carros
            var carro1 = new Carro() { Id = Guid.NewGuid(), Nome = "Honda Fit", Tipo = tp1 };
            var carro2 = new Carro() { Id = Guid.NewGuid(), Nome = "Chevrolet Agile", Tipo = tp1 };
            var carro3 = new Carro() { Id = Guid.NewGuid(), Nome = "Ferrari F40", Tipo = tp2 };
            var carro4 = new Carro() { Id = Guid.NewGuid(), Nome = "Lamborguini Gallardo", Tipo = tp3 };
            var carro5 = new Carro() { Id = Guid.NewGuid(), Nome = "Hyunday IX-35", Tipo = tp3 };
            var carro6 = new Carro() { Id = Guid.NewGuid(), Nome = "Honda CRV", Tipo = tp3 };

            context.Carro.Add(carro1);
            context.Carro.Add(carro2);
            context.Carro.Add(carro3);
            context.Carro.Add(carro4);
            context.Carro.Add(carro5);
            context.Carro.Add(carro6);

            //Tarifas
            var tarifa1 = new Tarifa() { Id = Guid.NewGuid(), DiaUtil = true, Fidelizacao = true, Valor = 210.0, Loja = loja1 };
            var tarifa2 = new Tarifa() { Id = Guid.NewGuid(), DiaUtil = true, Fidelizacao = false, Valor = 150.0, Loja = loja1 };
            var tarifa3 = new Tarifa() { Id = Guid.NewGuid(), DiaUtil = false, Fidelizacao = true, Valor = 200.0, Loja = loja1 };
            var tarifa4 = new Tarifa() { Id = Guid.NewGuid(), DiaUtil = false, Fidelizacao = false, Valor = 90.0, Loja = loja1 };
            var tarifa5 = new Tarifa() { Id = Guid.NewGuid(), DiaUtil = true, Fidelizacao = true, Valor = 530.0, Loja = loja2 };
            var tarifa6 = new Tarifa() { Id = Guid.NewGuid(), DiaUtil = true, Fidelizacao = false, Valor = 150.0, Loja = loja2 };
            var tarifa7 = new Tarifa() { Id = Guid.NewGuid(), DiaUtil = false, Fidelizacao = true, Valor = 200.0, Loja = loja2 };
            var tarifa8 = new Tarifa() { Id = Guid.NewGuid(), DiaUtil = false, Fidelizacao = false, Valor = 90.0, Loja = loja2 };
            var tarifa9 = new Tarifa() { Id = Guid.NewGuid(), DiaUtil = true, Fidelizacao = true, Valor = 630.0, Loja = loja3 };
            var tarifa10 = new Tarifa() { Id = Guid.NewGuid(), DiaUtil = true, Fidelizacao = false, Valor = 580.0, Loja = loja3 };
            var tarifa11 = new Tarifa() { Id = Guid.NewGuid(), DiaUtil = false, Fidelizacao = true, Valor = 600.0, Loja = loja3 };
            var tarifa12 = new Tarifa() { Id = Guid.NewGuid(), DiaUtil = false, Fidelizacao = false, Valor = 590.0, Loja = loja3 };

            context.Tarifa.Add(tarifa1);
            context.Tarifa.Add(tarifa2);
            context.Tarifa.Add(tarifa3);
            context.Tarifa.Add(tarifa4);
            context.Tarifa.Add(tarifa5);
            context.Tarifa.Add(tarifa6);
            context.Tarifa.Add(tarifa7);
            context.Tarifa.Add(tarifa8);
            context.Tarifa.Add(tarifa9);
            context.Tarifa.Add(tarifa10);
            context.Tarifa.Add(tarifa11);
            context.Tarifa.Add(tarifa12);
        }
    }
}
