using Dail.Application.Common.Constants;
using Dail.Application.Common.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Text;

namespace Dail.Application.Features.TimeSchedules.Commands.ModifyTimeSchedule;
public class ModifyTimeScheduleValidator : AbstractValidator<ModifyTimeScheduleCommand>
{
    public ModifyTimeScheduleValidator(IStringLocalizer<MessagesLocalizer> localizer)
    {
        RuleFor(p => p.Id)
               .NotNull()
               .NotEmpty()
               .GreaterThan(0)
               .WithMessage(localizer.GetString(MessageCodes.IsRequired)?.Value);

        RuleFor(p => p.Title)
               .NotNull()
               .NotEmpty()
               .WithMessage(localizer.GetString(MessageCodes.IsRequired)?.Value);

        RuleFor(p => p.Description)
               .MaximumLength(1024)
               .WithMessage(string.Format(localizer.GetString(MessageCodes.IsRequired).Value, 1024));
    }
}