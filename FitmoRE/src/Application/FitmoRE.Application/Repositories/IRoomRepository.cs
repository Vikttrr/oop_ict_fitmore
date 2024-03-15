using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

namespace FitmoRE.Application.Repositories;
public interface IRoomRepository
{
    GymRoom GetById(string roomId);

    IEnumerable<RoomInfoResponseDto?> GetAll();

    string Add(GymRoom room);

    RoomInfoResponseDto? Update(GymRoom room);

    RoomInfoDto? Delete(string roomId);
}