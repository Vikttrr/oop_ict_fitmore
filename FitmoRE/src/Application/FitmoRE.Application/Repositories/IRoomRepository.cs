using FitmoRE.Application.DTO;

namespace FitmoRE.Application.Repositories
{
    public interface IRoomRepository
    {
        RoomInfoResponseDto GetById(string roomId);

        IEnumerable<RoomInfoResponseDto> GetAll();

        RoomInfoResponseDto Add(RoomInfoDto gymRoomDto);

        RoomInfoResponseDto Update(RoomInfoDto gymRoomDto);

        RoomInfoDto Delete(string roomId);
    }
}