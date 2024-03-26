using FitmoRE.Application.DTO;
using FitmoRE.Application.Events.Commands;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using MediatR;

namespace FitmoRE.Application.Events.Handlers;

public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand, AddRoomResponseDto>
{
    private readonly IRoomRepository _roomRepository;

    public AddRoomCommandHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public Task<AddRoomResponseDto> Handle(AddRoomCommand request, CancellationToken cancellationToken)
    {
        string id = new Random().Next().ToString();
        var gymRoom = new GymRoomModel(
            id,
            request.AddRoomDto.RoomNumber,
            request.AddRoomDto.Space,
            request.AddRoomDto.Temperature,
            request.AddRoomDto.Capacity,
            request.AddRoomDto.BranchId);

        string newId = _roomRepository.Add(gymRoom);

        return Task.FromResult(new AddRoomResponseDto
        {
            RoomId = newId,
        });
    }
}