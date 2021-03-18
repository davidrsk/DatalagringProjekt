﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConnection
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public virtual List<Rental> Rentals { get; set; }
    }
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string Score { get; set; }
        public string ImageURL { get; set; }
        public virtual List<Rental> Rentals { get; set; }
    }
    public class Rental
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateExpires { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
