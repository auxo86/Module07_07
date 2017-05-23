using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod02_01.Models;
using System.Data.Entity;

namespace Mod02_01.DAL
{
    //public class OperaInitializer:DropCreateDatabaseAlways<OperaContext>
    public class OperaInitializer: DropCreateDatabaseIfModelChanges<OperaContext>
    {  
        protected override void Seed(OperaContext context)
        {
            base.Seed(context);
            context.Operas.Add(new Opera()
            {
                Title = "Cosi Fan Tutte",
                Year = 1791,
                Composer = "Mozart"
            });
            context.Operas.Add(new Opera
            {
                Title = "Rigoletto",
                Year = 1851,
                Composer = "Giuseppe Verdi",
            });
            context.Operas.Add(new Opera
            {
                Title = "Nixon in China",
                Year = 1987,
                Composer = "John Adams"
            });
            context.Operas.Add(new Opera
            {
                Title = "Wozzeck",
                Year = 1922,
                Composer = "Alban Berg"
            });
            context.SaveChanges();
        }
    }
}
