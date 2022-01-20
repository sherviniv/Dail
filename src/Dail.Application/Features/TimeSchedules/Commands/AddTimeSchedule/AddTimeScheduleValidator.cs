using Dail.Application.Common.Constants;
using Dail.Application.Common.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Text;

namespace Dail.Application.Features.TimeSchedules.Commands.AddTimeSchedule;

public class AddTimeScheduleValidator : AbstractValidator<AddTimeScheduleCommand>
{
    public AddTimeScheduleValidator(IStringLocalizer<MessagesLocalizer> localizer)
    {
        RuleFor(p => p.Title)
               .NotNull()
               .NotEmpty()
               .WithMessage(localizer.GetString(MessageCodes.IsRequired)?.Value);

        RuleFor(p => p.Description)
               .MaximumLength(1024)
               .WithMessage(string.Format(localizer.GetString(MessageCodes.IsRequired).Value, 128));
    }
}