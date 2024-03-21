namespace FitmoRE.Application.Models.Models;

public class TrainingRegistrationModel
{
    public string RegistrationId { get; set; }

    public string TrainingId { get; set; }

    public string? ClientId { get; set; }

    public string? RegistrationDate { get; set; }

    public bool IsConfirmed { get; set; }

    public TrainingRegistrationModel(string registrationId, string trainingId, string? clientId, bool isConfirmed)
    {
        RegistrationId = registrationId;
        TrainingId = trainingId;
        ClientId = clientId;

        // RegistrationDate = registrationDate;
        IsConfirmed = isConfirmed;
    }
}
