using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Abby.Models.ViewModel;
using Abby.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe;
using System.Collections.Generic;
using System.Linq;

namespace AbbyWeb.Pages.Admin.Order
{
    public class OrderDetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public OrderDetailVM OrderDetailVM { get; set; }
        public OrderDetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            OrderDetailVM = new()
            {
                OrderHeader = _unitOfWork.OrderHeader.GetFirstOrDefault(u => u.Id == id, includeProperties: "ApplicationUser"),
                OrderDetails = _unitOfWork.OrderDetail.GetAll(u => u.OrderId == id).ToList()
            };
        }

        public IActionResult OnPostOrderCompleted(int orderId)
        {
            _unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusCompleted);
            _unitOfWork.Save();
            return RedirectToPage("OrderList");
        }
        public IActionResult OnPostOrderRefund(int orderId)
        {
            OrderHeader orderHeader = _unitOfWork.OrderHeader.GetFirstOrDefault(o => o.Id == orderId);

            var options = new RefundCreateOptions
            {
                Reason = RefundReasons.RequestedByCustomer,
                PaymentIntent = orderHeader.PaymentIntentId
            };

            var service = new RefundService();
            Refund refund = service.Create(options);

            _unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusRefunded);
            _unitOfWork.Save();
            return RedirectToPage("OrderList");
        }

        public IActionResult OnPostOrderCancel(int orderId)
        {
            _unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusCancelled);
            _unitOfWork.Save();
            return RedirectToPage("OrderList");
        }
    }
}
