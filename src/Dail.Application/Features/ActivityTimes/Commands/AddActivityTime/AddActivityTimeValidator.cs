using Dail.Application.Common.Constants;
using Dail.Application.Common.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Text;

namespace Dail.Application.Features.ActivityTimes.Commands.AddActivityTime;

public class AddActivityTimeValidator : AbstractValidator<AddActivityTimeCommand>
{
    public AddActivityTimeValidator(IStringLocalizer<MessagesLocalizer> localizer)
    {
        RuleFor(p => p.Title)
               .MaximumLength(256)
               .WithMessage(string.Format(localizer.GetString(MessageCodes.IsRequired).Value, 1024));

        RuleFor(p => p.EndTime)
               .NotNull()
               .NotEmpty()
               .WithMessage(localizer.GetString(MessageCodes.IsRequired)?.Value)
               .MaximumLength(11)
               .WithMessage(string.Format(localizer.GetString(MessageCodes.IsRequired).Value, 11));

        RuleFor(p => p.StartTime)
               .NotNull()
               .NotEmpty()
               .WithMessage(localizer.GetString(MessageCodes.IsRequired)?.Value)
               .MaximumLength(11)
               .WithMessage(string.Format(localizer.GetString(MessageCodes.IsRequired).Value, 11));
    }
}