using Dail.Application.Common.Constants;
using Dail.Application.Common.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Text;

namespace Dail.Application.Features.ActivityTimes.Commands.ModifyActivityTime;
public class ModifyActivityTimeValidator : AbstractValidator<ModifyActivityTimeCommand>
{
    public ModifyActivityTimeValidator(IStringLocalizer<MessagesLocalizer> localizer)
    {
        RuleFor(p => p.Id)
               .NotNull()
               .NotEmpty()
               .GreaterThan(0)
               .WithMessage(localizer.GetString(MessageCodes.IsRequired)?.Value);

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