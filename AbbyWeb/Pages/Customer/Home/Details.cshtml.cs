using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace AbbyWeb.Pages.Customer.Home
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
		public ShoppingCart ShoppingCart { get; set; }

        public void OnGet(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            

            ShoppingCart = new()
            { 
                ApplicationUserId = claim.Value,
                MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,FoodType"),
                MenuItemId=id
            };
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ShoppingCart shoppingCartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
                   filter: u => u.ApplicationUserId == ShoppingCart.ApplicationUserId &&
                    u.MenuItemId == ShoppingCart.MenuItemId);

                if (shoppingCartFromDb == null)
                {

                    _unitOfWork.ShoppingCart.Add(ShoppingCart);
                    _unitOfWork.Save();
                }
                else
				{
                    _unitOfWork.ShoppingCart.IncrementCount(shoppingCartFromDb, ShoppingCart.Count);
				}
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
