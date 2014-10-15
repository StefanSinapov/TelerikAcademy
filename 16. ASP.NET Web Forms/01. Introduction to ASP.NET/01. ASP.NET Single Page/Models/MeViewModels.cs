using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _01.ASP.NET_Single_Page.Models
{
    // Models returned by MeController actions.
    public class GetViewModel
    {
        public string Hometown { get; set; }
    }
}