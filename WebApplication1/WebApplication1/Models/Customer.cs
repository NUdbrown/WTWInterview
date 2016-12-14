using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace WebApplication1.Models
{
    public class Customer : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Customer(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string WhatISay()
        {
            return "I am a customer! Need good service!";
        }

        public List<IPerson> ShowAll()
        {
            var theList = new List<Customer> {new Customer("Jim", 35), new Customer("Sally", 18), new Customer("Jesse", 20)};
            return new List<IPerson>(theList);
        }
    }
}