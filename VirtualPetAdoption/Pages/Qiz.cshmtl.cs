using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Models;

namespace VirtualPetAdoption.Pages
{
    public class QuizModel : PageModel
    {
        // add the database context
        private readonly PetAdoptionContext _context;

        //Add the pasge model witht he database context - so the html page is updated w/data
        public QuizModel(PetAdoptionContext context)
        {
            _context = context;
        }

        //Bind persists the form data after the user add their name and energy preference
        //need 2 of these NAME and ENERGYPREF
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public int EnergyPreference { get; set; }

        //Nothing we need to do, 
        public void OnGet()
        {
        }

        //onPost method is called when form submit button is clicked
        public async Task<IActionResult> OnPostAsync()
        {
            // get a list of pets from database
            var pets = await _context.Pets.ToListAsync();
            
            //Declare a variable to store the pet that is best match and variable
            //help calculate the best pet
            //Closes to the energy number to preference
            Pet bestMatch = null;
            int smallestDifference = int.MaxValue;

            //Find the best pet by looping through the pets from the db and compare energy
            foreach (var pet in pets)
            {
                //Calculate the difference between user level to pet energy level
                int difference = Math.Abs(pet.EnergyLevel - EnergyPreference);
                
                //test is difference is the smallest one so far
                if (difference < smallestDifference)
                {
                    smallestDifference = difference;
                    bestMatch = pet;
                } //end if
            } //end method

            // returns the redirect to the results page *This can have many different matching, but not in this lab
            return RedirectToPage("./Results", new { petId = bestMatch.Id, userName = Name });
        } //end onPost
    } //end class
} //end namespace