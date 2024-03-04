namespace FitmoRE.Application.DTO
{
    public class SignupForTrainingDto
    {
        public int ClientId { get; set; }

        public int TrainingSessionId { get; set; }

        public DateTime PreferredDateTime { get; set; }

        public string SpecialRequests { get; set; } = string.Empty;
    }
}