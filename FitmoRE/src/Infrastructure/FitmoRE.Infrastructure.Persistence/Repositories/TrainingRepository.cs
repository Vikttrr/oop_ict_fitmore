// using FitmoRE.Application.DTO;
// using FitmoRE.Application.Models.Entities;
// using FitmoRE.Application.Repositories;
// using Microsoft.EntityFrameworkCore;
//
// namespace FitmoRE.Infrastructure.Persistence.Repositories;
//
//
// public class TrainingRepository : RepositoryBase<TrainingSession>, ITrainingRepository
// {
//     private readonly DbContext _context;
//
//     public TrainingRepository(DbContext dbContext) : base(dbContext)
//     {
//         _context = dbContext;
//     }
//
//     protected override DbSet<TrainingSession> DbSet => _context.Set<TrainingSession>();
//
//         protected override bool Equal(TrainingSession entity1, TrainingSession entity2)
//         {
//             return entity1.TrainingId == entity2.TrainingId;
//         }
//
//         public string AddNew(TrainingSession trainingSession)
//         {
//             Add(trainingSession);
//             _context.SaveChanges();
//
//             return trainingSession.TrainingId;
//         }
//
//
//         public TrainingInfoResponseDto GetById(string trainingId)
//         {
//             if (!string.IsNullOrEmpty(trainingId))
//             {
//                 var result = GetById(trainingId);
//
//                 if (result != null)
//                 {
//                     return new TrainingInfoResponseDto
//                     {
//                         RoomId = result.RoomId,
//                         EmployeeId = result.EmployeeId,
//                         ParticipantsNumber = result.NumberOfParticipants,
//                         StartTime = result.StartTime,
//                         EndTime = result.EndTime,
//                         Description = result.Description
//                     };
//                 }
//             }
//
//             return null;
//         }
//
//
//         public TrainingInfoResponseDto Update(AddTrainingDto addTrainingDto)
//         {
//             if (!string.IsNullOrEmpty(addTrainingDto.TrainingId))
//             {
//                 var entity = GetById(addTrainingDto.TrainingId);
//
//                 if (entity != null)
//                 {
//                     entity.RoomId = addTrainingDto.RoomId;
//                     entity.EmployeeId = addTrainingDto.EmployeeId;
//                     entity.NumberOfParticipants = addTrainingDto.ParticipantsNumber;
//                     entity.StartTime = addTrainingDto.StartTime;
//                     entity.EndTime = addTrainingDto.EndTime;
//                     entity.Description = addTrainingDto.Description;
//
//                     Update(entity);
//                     _context.SaveChanges();
//
//                     return new TrainingInfoResponseDto
//                     {
//                         RoomId = entity.RoomId,
//                         EmployeeId = entity.EmployeeId,
//                         ParticipantsNumber = entity.NumberOfParticipants,
//                         StartTime = entity.StartTime,
//                         EndTime = entity.EndTime,
//                         Description = entity.Description
//                     };
//                 }
//             }
//
//             return null;
//         }
//
//
//         public AddTrainingDto Delete(string trainingId)
//         {
//             if (!string.IsNullOrEmpty(trainingId))
//             {
//                 var entity = GetById(trainingId);
//
//                 if (entity != null)
//                 {
//                     Remove(entity);
//                     _context.SaveChanges();
//
//                     return new AddTrainingDto
//                     {
//                         TrainingId = entity.TrainingId,
//                         RoomId = entity.RoomId,
//                         EmployeeId = entity.EmployeeId,
//                         NumberOfParticipants = entity.NumberOfParticipants,
//                         StartTime = entity.StartTime,
//                         EndTime = entity.EndTime,
//                         Description = entity.Description
//                     };
//                 }
//             }
//
//             return null;
//         }
//
//
//         public IEnumerable<TrainingInfoResponseDto> GetAllTraining()
//         {
//             var results = DbSet.ToList();
//
//             return results.Select<TrainingSession, TrainingInfoResponseDto>(result => new TrainingInfoResponseDto
//             {
//                 RoomId = result.RoomId,
//                 EmployeeId = result.EmployeeId,
//                 NumberOfParticipants = result.NumberOfParticipants,
//                 StartTime = result.StartTime,
//                 EndTime = result.EndTime,
//                 Description = result.Description
//             });
//         }
//
//     }