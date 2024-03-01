namespace FitmoRE.Application.Models.Entities;

public class TrainingRegistration
{
    public int RegistrationId { get; set; }

    public int TrainingId { get; set; }

    public int ClientId { get; set; }

    public DateTime RegistrationDate { get; set; }

    public bool IsConfirmed { get; set; }

    public TrainingRegistration(int registrationId, int trainingId, int clientId, DateTime registrationDate, bool isConfirmed)
    {
        RegistrationId = registrationId;
        TrainingId = trainingId;
        ClientId = clientId;
        RegistrationDate = registrationDate;
        IsConfirmed = isConfirmed;
    }
}
