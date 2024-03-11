namespace FitmoRE.Application.Models.Entities;

public class TrainingRegistration
{
    public string RegistrationId { get; set; }

    public string TrainingId { get; set; }

    public string ClientId { get; set; }

    public DateTime RegistrationDate { get; set; }

    public bool IsConfirmed { get; set; }

    public TrainingRegistration(string registrationId, string trainingId, string clientId, DateTime registrationDate, bool isConfirmed)
    {
        RegistrationId = registrationId;
        TrainingId = trainingId;
        ClientId = clientId;
        RegistrationDate = registrationDate;
        IsConfirmed = isConfirmed;
    }
}
