using FitmoRE.Application.DTO;
using FitmoRE.Application.Events.Queries;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using MediatR;

namespace FitmoRE.Application.Events.Handlers;

public class GetTrainingInfoQueryHandler : IRequestHandler<GetTrainingInfoQuery, TrainingInfoResponseDto>
{
    private readonly ITrainingRepository _trainingRepository;

    public GetTrainingInfoQueryHandler(ITrainingRepository trainingRepository)
    {
        _trainingRepository = trainingRepository;
    }

    public Task<TrainingInfoResponseDto> Handle(GetTrainingInfoQuery request, CancellationToken cancellationToken)
    {
        TrainingSessionModel? training = _trainingRepository.GetById(request.TrainingId);
        if (training == null)
        {
            return Task.FromResult(new TrainingInfoResponseDto()
            {
                EmployeeId = string.Empty,
            });
        }

        var responseDto = new TrainingInfoResponseDto
        {
            RoomId = training.RoomId,
            EmployeeId = training.EmployeeId,
            ParticipantsNumber = training.NumberOfParticipants,
            StartTime = training.StartTime,
            EndTime = training.EndTime,
            Description = training.Description,
        };

        return Task.FromResult(responseDto);
    }
}