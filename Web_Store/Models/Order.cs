﻿using System.ComponentModel.DataAnnotations;
using Web_Store.Models.Enums;

namespace Web_Store.Models
{
	public class Order
	{
		[Display(Name = "Numer zamówienia")]
		public int Id { get; set; }
		public string BuyerId { get; set; }
		public List<OrderEntry> OrderEntries { get; set; }
		[Display(Name = "Adres")]
		public string Address { get; set; }
		public OrderStatus Status { get; set; }
	}
}
