using FitmoRE.Application.DTO;
using FitmoRE.Application.Models.Entities;

namespace FitmoRE.Application.Models.Entities.Repositories
{
    public interface ITrainingRepository
    {
        AddTrainingResponseDto Add(TrainingSession trainingSession);

        TrainingInfoResponseDto GetById(string trainingId);

        TrainingInfoResponseDto Update(TrainingSession trainingSession);

        AddTrainingDto Delete(string trainingId);

        IEnumerable<TrainingInfoResponseDto> GetAll();
    }
}