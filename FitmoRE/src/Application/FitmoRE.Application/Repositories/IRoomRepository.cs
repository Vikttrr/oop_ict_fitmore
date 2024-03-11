namespace FitmoRE.Application.Repositories;

using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

public interface IRoomRepository
{
    GymRoom GetById(string roomId);

    IEnumerable<RoomInfoResponseDto> GetAll();

    RoomInfoResponseDto Add(RoomInfoDto gymRoomDto);

    RoomInfoResponseDto Update(RoomInfoDto gymRoomDto);

    RoomInfoDto Delete(string roomId);
}