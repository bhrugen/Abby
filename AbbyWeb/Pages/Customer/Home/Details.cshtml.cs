using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Pages.Customer.Home
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public MenuItem MenuItem { get; set; }
        [Range(1, 100, ErrorMessage = "Please select a count between 1 and 100")]
        public int Count { get; set; }

        public void OnGet(int id)
        {
            MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id,includeProperties:"Category,FoodType");
        }
    }
}
