using CountriesApp.Application.Contracts;
using FluentValidation;

namespace CountriesApp.Application.Services;

public class IntegersService : IIntegersService
{
    private readonly IValidator<RequestObj> _validator;

    public IntegersService(IValidator<RequestObj> validator)
    {
        _validator = validator;
    }

    public async Task<int> GetSecondLargest(RequestObj request)
    {
        await _validator.ValidateAndThrowAsync(request);

        int secondLargest = CalculateSecondLargest(request.RequestArrayObj);

        return secondLargest;
    }

    private static int CalculateSecondLargest(IEnumerable<int> array)
    {
        var distinctOrderedArray = array.Distinct().OrderByDescending(num => num).ToList();

        if (distinctOrderedArray.Count < 2)
            return distinctOrderedArray.FirstOrDefault();

        return distinctOrderedArray[1];
    }
}
