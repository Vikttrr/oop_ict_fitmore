// using FitmoRE.Application.DTO;
// using FitmoRE.Application.Models.Entities;
// using FitmoRE.Application.Repositories;
// using Microsoft.EntityFrameworkCore;
//
// namespace FitmoRE.Infrastructure.Persistence.Repositories;
//
// public class TrainingRegistrationRepository : RepositoryBase<TrainingRegistration>, ITrainingRegistrationRepository
//     {
//         private readonly DbContext _context;
//
//         public TrainingRegistrationRepository(DbContext dbContext) : base(dbContext)
//         {
//             _context = dbContext;
//         }
//
//         protected override DbSet<TrainingRegistration> DbSet => _context.Set<TrainingRegistration>();
//
//         protected override bool Equal(TrainingRegistration entity1, TrainingRegistration entity2)
//         {
//             return entity1.RegistrationId == entity2.RegistrationId;
//         }
//
//         public TrainingSignupResponseDto AddNew(TrainingRegistration trainingSignupDto)
//         {
//             Add(trainingSignupDto);
//             _context.SaveChanges();
//
//             return new TrainingSignupResponseDto
//             {
//                 RegistrationId = trainingSignupDto.RegistrationId
//             };
//         }
//
//         public TrainingSignupDto GetById(string registrationId)
//         {
//             if (!string.IsNullOrEmpty(registrationId))
//             {
//                 var result = GetById(registrationId);
//
//                 if (result != null)
//                 {
//                     return new TrainingSignupDto
//                     {
//                         TrainingId = result.TrainingId,
//                         ClientId = result.ClientId,
//                         DateTime = result.RegistrationDate.ToString("yyyy-MM-dd HH:mm:ss")
//                     };
//                 }
//             }
//
//             return null;
//         }
//
//         public TrainingSignupResponseDto Update(TrainingSignupDto trainingSignupDto)
//         {
//             if (!string.IsNullOrEmpty(trainingSignupDto.RegistrationId))
//             {
//                 var entity = GetById(trainingSignupDto.RegistrationId);
//
//                 if (entity != null)
//                 {
//                     entity.TrainingId = trainingSignupDto.TrainingId;
//                     entity.ClientId = trainingSignupDto.ClientId;
//                     entity.RegistrationDate = DateTime.Parse(trainingSignupDto.DateTime);
//
//                     Update(entity);
//                     _context.SaveChanges();
//
//                     return new TrainingSignupResponseDto { Message = "Training registration updated successfully", RegistrationId = entity.RegistrationId };
//                 }
//             }
//
//             return null;
//         }
//
//         public TrainingSignupDto Delete(string registrationId)
//         {
//             if (!string.IsNullOrEmpty(registrationId))
//             {
//                 var entity = GetById(registrationId);
//
//                 if (entity != null)
//                 {
//                     Remove(entity);
//                     _context.SaveChanges();
//
//                     return new TrainingSignupDto
//                     {
//                         TrainingId = entity.TrainingId,
//                         ClientId = entity.ClientId,
//                         DateTime = entity.RegistrationDate.ToString("yyyy-MM-dd HH:mm:ss")
//                     };
//                 }
//             }
//
//             return null;
//         }
//
//         public IEnumerable<TrainingSignupDto> GetAllByTrainingId(string trainingId)
//         {
//             if (!string.IsNullOrEmpty(trainingId))
//             {
//                 var results = DbSet.Where(tr => tr.TrainingId == trainingId).ToList();
//
//                 return results.Select(result => new TrainingSignupDto
//                 {
//                     TrainingId = result.TrainingId,
//                     ClientId = result.ClientId,
//                     DateTime = result.RegistrationDate.ToString("yyyy-MM-dd HH:mm:ss")
//                 });
//             }
//
//             return Enumerable.Empty<TrainingSignupDto>();
//         }
//
//         public IEnumerable<TrainingSignupDto> GetAllByClientId(string clientId)
//         {
//             if (!string.IsNullOrEmpty(clientId))
//             {
//                 var results = DbSet.Where(tr => tr.ClientId == clientId).ToList();
//
//                 return results.Select(result => new TrainingSignupDto
//                 {
//                     TrainingId = result.TrainingId.ToString(),
//                     ClientId = result.ClientId.ToString(),
//                     DateTime = result.RegistrationDate.ToString("yyyy-MM-dd HH:mm:ss")
//                 }).ToList();
//             }
//             return Enumerable.Empty<TrainingSignupDto>();
//         }
//     }