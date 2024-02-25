using CountriesApp.Application.Models;
using FluentValidation;

namespace CountriesAPI.Validators;

public class RequestObjValidator : AbstractValidator<RequestObj>
{
    public RequestObjValidator()
    {
        RuleFor(it => it.RequestArrayObj)
            .NotNull().WithMessage("RequestArray must not be null.")
            .NotEmpty().WithMessage("RequestArray must not be empty.")
            .Must(it => it.Count() > 1).WithMessage("RequestArray must contain more than 1 elements.");
    }
}
