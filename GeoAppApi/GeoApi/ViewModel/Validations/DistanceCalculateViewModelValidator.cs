using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoApi.ViewModel.Validations
{
    public class DistanceCalculateViewModelValidator:AbstractValidator<DistanceCalculateViewModel>
    {
        public DistanceCalculateViewModelValidator()
        {
            RuleFor(vm => vm.FirstLat).NotEmpty().WithMessage("FirstLat cannot be empty");
            RuleFor(vm => vm.FirstLong).NotEmpty().WithMessage("FirstLong cannot be empty");
            RuleFor(vm => vm.SecLat).NotEmpty().WithMessage("SecLat cannot be empty");
            RuleFor(vm => vm.SecLong).NotEmpty().WithMessage("SecLong cannot be empty");
        }
    }
}
