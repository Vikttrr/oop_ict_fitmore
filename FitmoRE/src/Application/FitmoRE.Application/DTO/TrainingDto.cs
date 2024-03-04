namespace FitmoRE.Application.DTO
{
    public class TrainingDto
    {
        public int RoomId { get; set; }

        public int TrainerId { get; set; }

        public int EmployeeId { get; set; }

        public int NumberOfParticipants { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}