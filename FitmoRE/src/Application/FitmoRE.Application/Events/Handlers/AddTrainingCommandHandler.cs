using FitmoRE.Application.DTO;
using FitmoRE.Application.Events.Commands;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using MediatR;

namespace FitmoRE.Application.Events.Handlers;

public class AddTrainingCommandHandler : IRequestHandler<AddTrainingCommand, AddTrainingResponseDto>
{
    private readonly ITrainingRepository _trainingRepository;

    public AddTrainingCommandHandler(ITrainingRepository trainingRepository)
    {
        _trainingRepository = trainingRepository;
    }

    public Task<AddTrainingResponseDto> Handle(AddTrainingCommand request, CancellationToken cancellationToken)
    {
        string id = new Random().Next().ToString();
        var trainingSession = new TrainingSessionModel(
            id,
            request.TrainingDto.RoomId,
            request.TrainingDto.EmployeeId,
            request.TrainingDto.ParticipantsNumber,
            request.TrainingDto.StartTime,
            request.TrainingDto.EndTime,
            request.TrainingDto.Description);

        string newId = _trainingRepository.Add(trainingSession);

        var responseDto = new AddTrainingResponseDto()
        {
            TrainingId = newId,
        };

        return Task.FromResult(responseDto);
    }
}