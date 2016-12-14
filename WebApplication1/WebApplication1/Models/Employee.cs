using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string JobTitle { get; set; }

        public Employee(string name, int age, string jobTitle)
        {
            Name = name;
            Age = age;
            JobTitle = jobTitle;
        }

        public string WhatISay()
        {
            return "Doing my job as best as I can!";
        }

        public List<Employee> ShowAllEmployees()
        {
            var theList = new List<Employee> {new Employee("Millie", 34, "Engineer"), new Employee("Mike", 45, "Relations Manager"), new Employee("Lou", 19, "Customer Service")};
            return theList;
        } 
    }
}