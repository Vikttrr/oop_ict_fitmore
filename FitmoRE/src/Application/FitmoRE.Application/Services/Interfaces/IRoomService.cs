using FitmoRE.Application.DTO;

namespace FitmoRE.Application.Services.Interfaces;
public interface IRoomService
{
    RoomInfoResponseDto GetRoomInfo(RoomInfoDto roomId);
}