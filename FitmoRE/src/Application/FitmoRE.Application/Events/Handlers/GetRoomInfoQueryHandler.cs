using FitmoRE.Application.DTO;
using FitmoRE.Application.Events.Queries;
using FitmoRE.Application.Models.Models;
using FitmoRE.Application.Repositories;
using MediatR;

namespace FitmoRE.Application.Events.Handlers;

public class GetRoomInfoQueryHandler : IRequestHandler<GetRoomInfoQuery, RoomInfoResponseDto>
{
    private readonly IRoomRepository _roomRepository;

    public GetRoomInfoQueryHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public Task<RoomInfoResponseDto> Handle(GetRoomInfoQuery request, CancellationToken cancellationToken)
    {
        GymRoomModel roomModel = _roomRepository.GetById(request.RoomId);
        if (string.IsNullOrEmpty(roomModel.RoomId))
        {
            return Task.FromResult(new RoomInfoResponseDto
            {
                BranchId = string.Empty,
            });
        }

        return Task.FromResult(new RoomInfoResponseDto
        {
            RoomNum = roomModel.RoomNumber,
            Space = roomModel.Space,
            Temperature = roomModel.Temperature,
            Capacity = roomModel.Capacity,
            BranchId = roomModel.BranchId,
        });
    }
}