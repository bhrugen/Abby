using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories;

public class IndexModel : PageModel
{
    private readonly ICategoryRepository _dbCategory;

    public IEnumerable<Category> Categories{ get; set; }

    public IndexModel(ICategoryRepository dbCategory)
    {
        _dbCategory = dbCategory;
    }

    public void OnGet()
    {
        Categories = _dbCategory.GetAll();
    }
}
