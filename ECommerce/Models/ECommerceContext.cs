﻿using System.Data.Entity;


namespace ECommerce.Models
{
    public class ECommerceContext : DbContext
    {
        // auto constructor ctor and tab 2 times
        public ECommerceContext() : base("DefaultConnection") //base DB connection
        {

        }
    }
}