using FluentValidation.Attributes;
using GeoApi.ViewModel.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoApi.ViewModel
{
    [Validator(typeof(LoginViewModel))]
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
