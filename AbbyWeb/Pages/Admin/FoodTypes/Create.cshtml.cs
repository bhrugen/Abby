using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes;

[BindProperties]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;
    
    public FoodType FoodType { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
      
        if (ModelState.IsValid)
        {
            await _db.FoodType.AddAsync(FoodType);
            await _db.SaveChangesAsync();
            TempData["success"] = "FoodType created successfully";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
