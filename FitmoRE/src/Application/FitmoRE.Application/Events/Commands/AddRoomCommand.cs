using FitmoRE.Application.DTO;
using MediatR;

namespace FitmoRE.Application.Events.Commands;

public class AddRoomCommand : IRequest<AddRoomResponseDto>
{
    public AddRoomDto AddRoomDto { get; }

    public AddRoomCommand(AddRoomDto addRoomDto)
    {
        AddRoomDto = addRoomDto;
    }
}