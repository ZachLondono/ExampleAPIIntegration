using FluentValidation;
using TVMazeIntegration.Models.Requests;

namespace TVMazeIntegration.Validation;

internal class SearchByNameRequestValidator : AbstractValidator<SearchByNameRequest> {

    public SearchByNameRequestValidator() {

        RuleFor(r => r.Query)
            .NotEmpty()
            .NotNull();
    
    }

}
