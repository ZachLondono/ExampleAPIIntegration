using FluentValidation;
using TVMazeIntegration.Models.Requests;

namespace TVMazeIntegration.Validation;

internal class ListEpisodesByShowIdRequestValidator : AbstractValidator<ListEpisodesByShowIdRequest> {

    public ListEpisodesByShowIdRequestValidator() {

        RuleFor(r => r.ShowId)
            .GreaterThan(0);

    }

}