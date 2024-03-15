namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class TrainingRegistration
{
    public string Registrationid { get; set; } = null!;

    public string? Trainingid { get; set; }

    public string? Clientid { get; set; }

    public string? Registrationdate { get; set; }

    public bool Isconfirmed { get; set; }

    public virtual Client? Client { get; set; }

    public virtual TrainingSession? Training { get; set; }
}
