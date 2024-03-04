namespace FitmoRE.Application.DTO
{
    public class SubscriptionDto
    {
        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan Duration { get; set; }

        public bool IsActive { get; set; }
    }
}