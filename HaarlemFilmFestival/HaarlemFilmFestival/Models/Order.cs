﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaarlemFilmFestival.Models
{
    [Table("Orders")]
    public class Order
    {
        public Order()
        {
            OrderRecords = new List<OrderRecord>();
        }

        public Order(Customer customer)
        {
            this.Customer = customer;
            this.Customer_Id = customer.Id;
        }
        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime OrderTime { get; set; }
        public bool Paid { get; set; }
        public int Code { get; set; }

        // Koppeling naar Klant
        public virtual Customer Customer { get; set; }
        public int Customer_Id { get; set; }

        // Koppeling naar Orderregels
        public ICollection<OrderRecord> OrderRecords { get; set; }
    }
}