using FitmoRE.Application.DTO;

namespace FitmoRE.Application.Models.Entities.Repositories
{
    public interface ITrainingRepository
    {
        AddTrainingResponseDto Add(TrainingSession addTrainingDto);

        TrainingInfoResponseDto GetById(string trainingId);

        TrainingInfoResponseDto Update(AddTrainingDto addTrainingDto);

        AddTrainingDto Delete(string trainingId);

        IEnumerable<TrainingInfoResponseDto> GetAll();
    }
}