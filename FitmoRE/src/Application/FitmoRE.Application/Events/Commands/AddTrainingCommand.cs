using FitmoRE.Application.DTO;
using MediatR;

namespace FitmoRE.Application.Events.Commands;

public class AddTrainingCommand : IRequest<AddTrainingResponseDto>
{
    public AddTrainingDto TrainingDto { get; }

    public AddTrainingCommand(AddTrainingDto trainingDto)
    {
        TrainingDto = trainingDto;
    }
}