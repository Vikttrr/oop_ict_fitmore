namespace FitmoRE.Application.Models.Entities;

public class TrainingRegistration
{
    public string RegistrationId { get; set; }

    public string TrainingId { get; set; }

    public string? ClientId { get; set; }

    public string? RegistrationDate { get; set; }

    public bool IsConfirmed { get; set; }

    public TrainingRegistration(string registrationId, string trainingId, string? clientId, bool isConfirmed)
    {
        RegistrationId = registrationId;
        TrainingId = trainingId;
        ClientId = clientId;

        // RegistrationDate = registrationDate;
        IsConfirmed = isConfirmed;
    }
}
