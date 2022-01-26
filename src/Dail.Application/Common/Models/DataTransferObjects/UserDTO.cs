namespace Dail.Application.Common.Models.DataTransferObjects;

public class UserDTO
{
    public string Id { get; set; } = String.Empty;
    public string Email { get; set; } 
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
}