using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<FoodType> FoodTypes { get; set; }
    public IndexModel(ApplicationDbContext db)
    {
        _db=db;
    }

    public void OnGet()
    {
        FoodTypes = _db.FoodType;
    }
}
