using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models.ViewModels
{
    public class MovieCollectionViewModel
    {
        public IEnumerable<ApplicationResponse> ApplicationResponses { get; set; }
    }
    

}
