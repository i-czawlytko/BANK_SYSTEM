using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using BankWebApi.ContextFolder;

namespace BankWebApi.Entitys
{
    public static class DBInit
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.PhysClients.Any() || context.CompanyClients.Any() || context.Giros.Any() || context.Deposits.Any() || context.Credits.Any()) return;

            var sections_phys = new List<PhysClients>()
            {
                new PhysClients(){id=1,client_name="Иванов Иван", birth_date = new DateTime(1995,5,20) },
                new PhysClients(){id=2,client_name="Петров Петр", birth_date = new DateTime(1999,9,1) },
                new PhysClients(){id=3,client_name="Алексей Алексеев", birth_date = new DateTime(1992,4,25) }
            };

            var sections_comp = new List<CompanyClients>()
            {
                new CompanyClients(){id=1,company_name="ООО ВЕКТОР", create_date = new DateTime(2005,5,20), parent_id=0 },
                new CompanyClients(){id=2,company_name="ООО СПЕКТР", create_date = new DateTime(2013,4,2), parent_id=0 },
                new CompanyClients(){id=3,company_name="ООО ШАНС", create_date = new DateTime(2012,1,11), parent_id=1 }
            };

            var sections_giro = new List<Giros>()
            {
                new Giros(){id=1,amount=5550,create_date = new DateTime(2019,4,2),owner_id=1,owner_type = "PHYS" },
                new Giros(){id=2,amount=16050,create_date = new DateTime(2020,4,2),owner_id=1,owner_type = "COMPANY" },
                new Giros(){id=3,amount=77400,create_date = new DateTime(2013,4,2),owner_id=2,owner_type = "PHYS" }
            };

            var sections_depos = new List<Deposit>()
            {
                new Deposit(){id=1,amount=60050,create_date = new DateTime(2018,4,2),cap = true,percent = 9,owner_id=1,owner_type = "PHYS" },
                new Deposit(){id=2,amount=53050,create_date = new DateTime(2017,2,2),cap = false,percent = 8,owner_id=2,owner_type = "PHYS" },
                new Deposit(){id=3,amount=44000,create_date = new DateTime(2016,5,12),cap = true,percent = 11,owner_id=3,owner_type = "COMPANY" }
            };

            var sections_credit = new List<Credits>()
            {
                new Credits(){id=1,amount=360050,create_date = new DateTime(2015,4,2),percent = 15,owner_id=1,owner_type = "PHYS" },
                new Credits(){id=2,amount=500050,create_date = new DateTime(2013,2,2),percent = 13,owner_id=2,owner_type = "COMPANY" },
                new Credits(){id=3,amount=600050,create_date = new DateTime(2016,9,2),percent = 12,owner_id=2,owner_type = "COMPANY" }
            };

            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var section in sections_phys)
                {
                    context.PhysClients.Add(section);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[PhysClients] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[PhysClients] OFF");
                trans.Commit();
            }

            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var section in sections_comp)
                {
                    context.CompanyClients.Add(section);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[CompanyClients] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[CompanyClients] OFF");
                trans.Commit();
            }

            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var section in sections_giro)
                {
                    context.Giros.Add(section);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Giros] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Giros] OFF");
                trans.Commit();
            }

            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var section in sections_depos)
                {
                    context.Deposits.Add(section);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Deposits] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Deposits] OFF");
                trans.Commit();
            }

            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var section in sections_credit)
                {
                    context.Credits.Add(section);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Credits] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Credits] OFF");
                trans.Commit();
            }
        }
    }
}
