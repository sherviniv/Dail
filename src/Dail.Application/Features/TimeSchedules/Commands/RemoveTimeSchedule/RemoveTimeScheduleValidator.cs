using Dail.Application.Common.Constants;
using Dail.Application.Common.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Text;

namespace Dail.Application.Features.Activities.Commands.RemoveActivity;
public class RemoveTimeScheduleValidator : AbstractValidator<RemoveTimeScheduleCommand>
{
    public RemoveTimeScheduleValidator(IStringLocalizer<MessagesLocalizer> localizer)
    {
        RuleFor(p => p.Id)
               .NotNull()
               .NotEmpty()
               .GreaterThan(0)
               .WithMessage(localizer.GetString(MessageCodes.IsRequired)?.Value);
    }
}