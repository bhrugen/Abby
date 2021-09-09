using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories;

[BindProperties]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;
    
    public Category Category { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        await _db.Category.AddAsync(Category);
        await _db.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
