namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class Client
{
    public string Clientid { get; set; } = null!;

    public string? Fullname { get; set; }

    public DateOnly? Dateofbirth { get; set; }

    public string? Phonenumber { get; set; }

    public string? Email { get; set; }

    public bool? Isactive { get; set; }

#pragma warning disable CA2227
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
#pragma warning restore CA2227

#pragma warning disable CA2227
    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
#pragma warning restore CA2227

#pragma warning disable CA2227
    public virtual ICollection<TrainingRegistration> TrainingRegistrations { get; set; } = new List<TrainingRegistration>();
#pragma warning restore CA2227
}
