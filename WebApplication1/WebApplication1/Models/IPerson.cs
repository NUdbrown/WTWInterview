using System.Collections.Generic;

namespace WebApplication1.Models
{
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
        string WhatISay();
        List<IPerson> ShowAll();
    }

}