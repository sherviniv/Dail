﻿using Dail.Application.Common.Constants;
using Dail.Application.Common.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Text;

namespace Dail.Application.Features.Activities.Commands.AddActivity;

public class AddActivityValidator : AbstractValidator<AddActivityCommand>
{
    public AddActivityValidator(IStringLocalizer<MessagesLocalizer> localizer)
    {
        RuleFor(p => p.Title)
               .NotNull()
               .NotEmpty()
               .WithMessage(localizer.GetString(MessageCodes.IsRequired)?.Value);

        RuleFor(p => p.Description)
               .MaximumLength(1024)
               .WithMessage(string.Format(localizer.GetString(MessageCodes.IsRequired).Value, 1024));
    }
}