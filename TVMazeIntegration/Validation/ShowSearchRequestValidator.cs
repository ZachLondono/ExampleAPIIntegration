using FluentValidation;
using TVMazeIntegration.Models;

namespace TVMazeIntegration.Validation;

internal class ShowSearchRequestValidator : AbstractValidator<ShowSearchRequest> {

    public ShowSearchRequestValidator() {

        RuleFor(r => r.Query)
            .NotEmpty()
            .NotNull();
    
    }

}
