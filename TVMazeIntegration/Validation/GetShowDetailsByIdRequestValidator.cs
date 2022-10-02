using FluentValidation;
using TVMazeIntegration.Models.Requests;

namespace TVMazeIntegration.Validation;

internal class GetShowDetailsByIdRequestValidator : AbstractValidator<GetShowDetailsByIdRequest> {

    public GetShowDetailsByIdRequestValidator() {

        RuleFor(r => r.ShowId)
            .GreaterThan(0);

    }

}