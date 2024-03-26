using FitmoRE.Application.DTO;
using MediatR;

namespace FitmoRE.Application.Events.Queries;

public class GetRoomInfoQuery : IRequest<RoomInfoResponseDto>
{
    public string RoomId { get; }

    public GetRoomInfoQuery(string roomId)
    {
        RoomId = roomId;
    }
}