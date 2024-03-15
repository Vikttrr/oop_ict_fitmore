namespace FitmoRE.Application.DTO;

public class UserInfoResponseDto
{
    public string? FullName { get; set; } = string.Empty;

    public string? BirthDate { get; set; } = string.Empty;

    public string? Phone { get; set; } = string.Empty;

    public string? Email { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    // public string SubscriptionType { get; set; } = string.Empty;
    public bool? IsActive { get; set; }

    public string? ClientId { get; set; }
}