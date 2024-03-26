using FitmoRE.Application.DTO;
using MediatR;

namespace FitmoRE.Application.Events.Queries;

public class GetTrainingInfoQuery : IRequest<TrainingInfoResponseDto>
{
    public string TrainingId { get; }

    public GetTrainingInfoQuery(string trainingId)
    {
        TrainingId = trainingId;
    }
}