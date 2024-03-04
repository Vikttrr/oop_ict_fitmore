namespace FitmoRE.Application.Models.Entities.Repositories;

public interface IGymRoomRepository
{
    GymRoom GetById(int roomId);

    IEnumerable<GymRoom> GetAll();

    void Add(GymRoom gymRoom);

    void Update(GymRoom gymRoom);

    void Delete(int roomId);

    void SaveChanges();
}