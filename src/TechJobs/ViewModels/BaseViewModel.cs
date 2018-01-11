using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class BaseViewModel : Controller
    {
        public BaseViewModel() { }

        public JobFieldType Column { get; set; }

        public List<JobFieldType> Columns { get; set; }

        public string Title { get; set; } = "";
    }
}