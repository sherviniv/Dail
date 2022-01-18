using Dail.Application.Common.Constants;
using Dail.Application.Common.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Text;

namespace Dail.Application.Features.Activities.Commands.AddActivity;

public class AddActivityValidator : AbstractValidator<AddActivityCommand>
{
    public AddActivityValidator(IStringLocalizer<MessagesLocalizer> localizer)
    {
        RuleFor(p => p.)
               .NotNull()
               .NotEmpty()
               .WithMessage(localizer.GetString(MessageCodes.req)?.Value);
    }
}