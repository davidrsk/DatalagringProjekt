using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{
    class Seeding
    {
        static void Main() 
        {
            using (var ctx = new Context())
            {
                ctx.RemoveRange(ctx.Sales);
                ctx.RemoveRange(ctx.Movies);
                ctx.RemoveRange(ctx.Customers);

                ctx.AddRange(new List<Customer> {
                    new Customer {
                        FirstName = "Björn",
                        LastName = "Andersson",
                        EmailAdress = "björn.com"
                    },
                    new Customer { 
                        FirstName = "Robin",
                        LastName = "Karlsson",
                        EmailAdress = "robinson@.com"
                    },
                    new Customer { 
                        FirstName = "Kalle",
                        LastName = "Nilsson",
                        EmailAdress = "kalle@com"
                    },
                });

                // Här laddas data in från SeedData foldern för att fylla ut Movies tabellen
                var movies = new List<Movie>();
                var lines = File.ReadAllLines(@"..\..\..\SeedData\MovieGenre.csv");
                for (int i = 1; i < 200; i++)
                {
                    // imdbId,Imdb Link,Title,IMDB Score,Genre,Poster
                    var cells = lines[i].Split(',');

                    var url = cells[5].Trim('"');
                    var title = cells[2];
                    var releaseYears = "";

                    if (title.Contains("(")){
                        var array = cells[2].Split(" (");
                        title = array[0];
                        releaseYears = array[1].Trim(')');
                    };

                    


                    // Hoppa över alla icke-fungerande url:er
                    try { var test = new Uri(url); }
                    catch (Exception) { continue; }

                    movies.Add(new Movie {
                        Title = title, // ta bort år
                        ImageURL = url,
                        Score = cells[3],
                        Genre = cells[4],
                        ReleaseYear = releaseYears,
                    }); ;
                }
                ctx.AddRange(movies);

                ctx.SaveChanges();
            }
        }
    }
}
