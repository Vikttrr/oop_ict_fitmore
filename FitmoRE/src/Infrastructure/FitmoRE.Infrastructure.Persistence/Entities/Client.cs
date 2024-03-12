namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class Client
{
    public int Clientid { get; set; }

    public string? Fullname { get; set; }

    public DateOnly? Dateofbirth { get; set; }

    public string? Phonenumber { get; set; }

    public string? Email { get; set; }

    public bool? Isactive { get; set; }
}
