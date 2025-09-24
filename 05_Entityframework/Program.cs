using System;
using _05_Entityframework.Entities;

namespace _05_Entityframework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicAppDbContext context = new MusicAppDbContext();

            context.Artists.Add(new Artist()
            {
                Name = "FamousYou",
                Surname = "The",
                CountryId = 1
            });
            context.SaveChanges();

            foreach (var client in context.Artists)
            {
                Console.WriteLine(client.Name + " " + client.Surname);
            }

            Artist ar = context.Artists.Find(1);

            Console.WriteLine($"{ar.Name}  {ar.Surname}");

            if (ar != null)
            {
                context.Artists.Remove(ar);
                context.SaveChanges();
            }
        }
    }
}