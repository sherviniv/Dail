using Dail.Application.Features.Activities.Models;
using Dail.Application.Features.Reports.Models;
using MediatR;

namespace Dail.Application.Features.Reports.Queries.GetUserDashboard;
public class GetUserDashboardQuery : IRequest<UserDashboardViewModel>
{
}