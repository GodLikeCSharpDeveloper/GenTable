﻿using System.ComponentModel.DataAnnotations.Schema;
using BlazorStoreServAppV5.Models.AuthModel;

namespace GenericTableBlazorAppV4.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string CreateOrderDate { get; set; }
        public string CloseOrderDate { get; set;}
        public int FullPrice { get; set; }
        public bool IsCanceled { get; set; } = false;
        public Users User { get; set; }
        public int UserId { get; set; }
        public List<ProductModel> Products { get; set; }

    }
}
