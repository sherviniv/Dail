using Dail.Application.Common.Constants;
using Dail.Application.Common.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Text;

namespace Dail.Application.Features.Activities.Commands.AssignActivity;

public class AssignActivityValidator : AbstractValidator<AssignActivityCommand>
{
    public AssignActivityValidator(IStringLocalizer<MessagesLocalizer> localizer)
    {
 
    }
}