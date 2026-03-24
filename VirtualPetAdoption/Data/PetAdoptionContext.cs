using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Models;

namespace VirtualPetAdoption.Models
{
    //Database context class
    public class PetAdoptionContext : DbContext
    {
        //Constructor for database context
        //Constructor is same name as class file * This is create a new object {which is why it is empty}
        public PetAdoptionContext(DbContextOptions<PetAdoptionContext> options) : base(options)
        {
        }
        
        //Attributes for the class - set of pet objects to populate
        public DbSet<Pet> Pets { get; set; }

        //Method for the class - OnModel creating -- override: give it new behavoir in the pet adoption class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //Create data model with a group of pets
            //how is an image create? > no image yet, but add later
            modelBuilder.Entity<Pet>().HasData(
                new Pet
                {
                    Id = 1,
                    Name = "Fluffy",
                    Species = "Cat",
                    Description = "A calm and relaxed cat who enjoys naps.",
                    ImageUrl = "/images/cat.png",
                    EnergyLevel = 2
                },
                new Pet
                {
                    Id = 2,
                    Name = "Rex",
                    Species = "Dog",
                    Description = "A high-energy dog who loves to play fetch.",
                    ImageUrl = "/images/dog.png",
                    EnergyLevel = 5
                },
                new Pet
                {
                    Id = 3,
                    Name = "Nibbles",
                    Species = "Rabbit",
                    Description = "A friendly rabbit with moderate energy.",
                    ImageUrl = "/images/rabbit.png",
                    EnergyLevel = 3
                } // end pet
            );
        }
    }
}