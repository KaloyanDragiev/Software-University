﻿namespace CarDealerApp.Models.BindingModels
{
    public class NewPartBindingModel
    {
        public string Name { get; set; }

        public double? Price { get; set; }

        public int SupplierId { get; set; }

        public int Quantity { get; set; }
    }
}