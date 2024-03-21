using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Models;

namespace FitmoRE.Application.Repositories;
public interface IRoomRepository
{
    GymRoomModel GetById(string roomId);

    IEnumerable<RoomInfoResponseDto?> GetAll();

    string Add(GymRoomModel roomModel);

    RoomInfoResponseDto? Update(GymRoomModel roomModel);

    RoomInfoDto? Delete(string roomId);
}