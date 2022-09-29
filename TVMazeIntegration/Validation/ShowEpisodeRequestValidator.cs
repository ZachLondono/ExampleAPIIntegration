using FluentValidation;
using TVMazeIntegration.Models;

namespace TVMazeIntegration.Validation;

internal class ShowEpisodeRequestValidator : AbstractValidator<ShowEpisodeRequest> {

    public ShowEpisodeRequestValidator() {

        RuleFor(r => r.ShowId)
            .GreaterThan(0);

    }

}