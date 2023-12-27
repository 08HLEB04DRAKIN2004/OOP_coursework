using System;
using System.ComponentModel.DataAnnotations;
using OOP.Domain.Entity;

namespace OOP.Domain.ViewModel.Orders
{
    public class OrdersViewModel
    {
        public int Order_id { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public DateTime? Date { get; set; }

        public decimal? Amount { get; set; }
        public int Client_id { get; set; }
        // If you need to display client information in the view
        public Client Client { get; set; }

       
    }
}
