using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Dail.Domain.Entities;
public class ApplicationUser : IdentityUser
{
    [MaxLength(256)]
    public string FirstName { get; set; }
    [MaxLength(256)]
    public string LastName { get; set; }
}