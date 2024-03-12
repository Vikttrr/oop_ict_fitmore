namespace FitmoRE.Infrastructure.Persistence.Entities;

public partial class TrainingRegistration
{
    public int Registrationid { get; set; }

    public int? Trainingid { get; set; }

    public int? Clientid { get; set; }

    public DateOnly? Registrationdate { get; set; }

    public bool? Isconfirmed { get; set; }
}
