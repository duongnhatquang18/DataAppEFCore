using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public class SeedData
    {
        public static void Seed(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context is EFDBContext prodCtx
                        && prodCtx.Products.Count() == 0)
                {
                    prodCtx.Products.AddRange(Products);
                }
                else if (context is CustomerEFDBContext custCtx
                      && custCtx.Customers.Count() == 0)
                {
                    custCtx.Customers.AddRange(Customers);
                }
                context.SaveChanges();
            }
        }
        public static void ClearData(DbContext context)
        {
            if (context is EFDBContext prodCtx
                    && prodCtx.Products.Count() > 0)
            {
                prodCtx.Products.RemoveRange(prodCtx.Products);
            }
            else if (context is CustomerEFDBContext custCtx
                  && custCtx.Customers.Count() > 0)
            {
                custCtx.Customers.RemoveRange(custCtx.Customers);
            }
            context.SaveChanges();
        }

        private static Product[] Products
        {
            get
            {
                Product[] products = new Product[]
                {
                        new Product { Name = "Kayak", Category = "Watersports",
                            Price = 275, Color = Color.Green, InStock = true },
                        new Product { Name = "Lifejacket", Category = "Watersports",
                            Price = 48.95m, Color = Color.Red, InStock = true },
                        new Product { Name = "Soccer Ball", Category = "Soccer",
                            Price = 19.50m, Color = Color.Blue, InStock = true },
                        new Product { Name = "Corner Flags", Category = "Soccer",
                            Price = 34.95m, Color = Color.Green, InStock = true },
                        new Product { Name = "Stadium", Category = "Soccer",
                            Price = 79500, Color = Color.Red, InStock = true },
                        new Product { Name = "Thinking Cap", Category = "Chess",
                            Price = 16, Color = Color.Blue, InStock = true },
                        new Product { Name = "Unsteady Chair", Category = "Chess",
                            Price = 29.95m, Color = Color.Green, InStock = true },
                        new Product { Name = "Human Chess Board", Category = "Chess",
                            Price = 75, Color = Color.Red, InStock = true },
                        new Product { Name = "Bling-Bling King", Category = "Chess",
                            Price = 1200, Color = Color.Blue, InStock = true }
                };

                ContactLocation hq = new ContactLocation
                {
                    LocationName = "Corporate HQ",
                    Address = "200 Acme Way"
                };
                ContactDetails bob = new ContactDetails
                {
                    Name = "Bob Smith",
                    Phone = "555-107-1234",
                    Location = hq
                };
                Supplier acme = new Supplier
                {
                    Name = "Acme Co",
                    City = "New York",
                    State = "NY",
                    ContactDetails = bob
                };

                Supplier s1 = new Supplier
                {
                    Name = "Surf Dudes",
                    City = "San Jose",
                    State = "CA"
                };
                Supplier s2 = new Supplier
                {
                    Name = "Chess Kings",
                    City = "Seattle",
                    State = "WA"
                };
                foreach (Product p in products)
                {
                    if (p == products[0])
                    {
                        p.Supplier = s1;
                    }
                    else if (p.Category == "Chess")
                    {
                        p.Supplier = s2;
                    }
                    else
                    {
                        p.Supplier = acme;
                    }
                }

                return products;
            }
        }

        private static Customer[] Customers = {
            new Customer { Name = "Alice Smith",
                City = "New York", Country = "USA" },
            new Customer { Name = "Bob Jones",
                City = "Paris", Country = "France" },
            new Customer { Name = "Charlie Davies",
                City = "London", Country = "UK" }};

    }
}
