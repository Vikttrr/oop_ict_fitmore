// using FitmoRE.Application.DTO;
// using FitmoRE.Application.Models.Entities;
// using FitmoRE.Application.Repositories;
// using Microsoft.EntityFrameworkCore;
//
// namespace FitmoRE.Infrastructure.Persistence.Repositories;
//
// public class UserRepository : RepositoryBase<Client>, IUserRepository
//     {
//         private readonly DbContext _context;
//
//         public UserRepository(DbContext dbContext) : base(dbContext)
//         {
//             _context = dbContext;
//         }
//
//         protected override DbSet<TrainingRegistration> DbSet => _context.Set<TrainingRegistration>();
//
//         protected override DbSet<Client> DbSet => _context.Set<Client>();
//
//         protected override bool Equal(Client entity1, Client entity2)
//         {
//             return entity1.ClientId == entity2.ClientId;
//         }
//
//         public string Add(Client userRegistrationDto)
//         {
//             Add(userRegistrationDto);
//             _context.SaveChanges();
//
//             return new UserRegistrationResponseDto { Message = "User added successfully", ClientId = userRegistrationDto.ClientId.ToString() };
//         }
//
//         public UserInfoResponseDto GetById(int clientId)
//         {
//             var result = GetById(clientId);
//
//             return result != null
//                 ? new UserInfoResponseDto
//                 {
//                     FullName = result.FullName,
//                     BirthDate = result.DateOfBirth.ToString("yyyy-MM-dd"),
//                     Phone = result.PhoneNumber,
//                     Email = result.Email,
//                     Address = result.Address,
//                     IsActive = result.IsActive
//                 }
//                 : null;
//         }
//
//         public UserAuthResponseDto FindByPhoneAndClientId(UserAuthDto userAuthDto)
//         {
//             var result = DbSet<>.FirstOrDefault(user => user.PhoneNumber == userAuthDto.Phone && user.ClientId.ToString() == userAuthDto.ClientId);
//
//             return result != null
//                 ? new UserAuthResponseDto { Message = "User found" }
//                 : new UserAuthResponseDto { Message = "User not found" };
//         }
//
//         public UserInfoResponseDto Update(UserInfoDto userInfoDto)
//         {
//             if (int.TryParse(userInfoDto.ClientId, out int clientId))
//             {
//                 var entity = GetById(clientId);
//
//                 if (entity != null)
//                 {
//                     entity.FullName = userInfoDto.FullName;
//                     entity.DateOfBirth = DateTime.Parse(userInfoDto.BirthDate);
//                     entity.PhoneNumber = userInfoDto.Phone;
//                     entity.Email = userInfoDto.Email;
//                     entity.Address = userInfoDto.Address;
//
//                     Update(entity);
//                     _context.SaveChanges();
//
//                     return new UserInfoResponseDto
//                     {
//                         FullName = entity.FullName,
//                         BirthDate = entity.DateOfBirth.ToString("yyyy-MM-dd"),
//                         Phone = entity.PhoneNumber,
//                         Email = entity.Email,
//                         Address = entity.Address,
//                         IsActive = entity.IsActive
//                     };
//                 }
//             }
//
//             return null;
//         }
//
//         public UserInfoDto Delete(int clientId)
//         {
//             var entity = GetById(clientId);
//
//             if (entity != null)
//             {
//                 Remove(entity);
//                 _context.SaveChanges();
//
//                 return new UserInfoDto { ClientId = entity.ClientId.ToString() };
//             }
//
//             return null;
//         }
//
//         public IEnumerable<UserInfoResponseDto> GetAll()
//         {
//             var results = DbSet<>.ToList();
//
//             return results.Select(result => new UserInfoResponseDto
//             {
//                 FullName = result.FullName,
//                 BirthDate = result.DateOfBirth.ToString("yyyy-MM-dd"),
//                 Phone = result.PhoneNumber,
//                 Email = result.Email,
//                 Address = result.Address,
//                 IsActive = result.IsActive
//             });
//         }
//     }