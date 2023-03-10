using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Finbuckle.SharedDatabase.TestApplication.Application.Interfaces;
using Finbuckle.SharedDatabase.TestApplication.Application.Users;
using Finbuckle.SharedDatabase.TestApplication.Domain.Common;
using Finbuckle.SharedDatabase.TestApplication.Domain.Entities;
using Finbuckle.SharedDatabase.TestApplication.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.ServiceImplementations.ServiceImplementation", Version = "1.0")]

namespace Finbuckle.SharedDatabase.TestApplication.Application.Implementation
{
    [IntentManaged(Mode.Merge)]
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public UsersService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<Guid> Create(UserCreateDto dto)
        {
            var newUser = new User
            {
                Email = dto.Email,
                Username = dto.Username,
                Roles = dto.Roles.Select(CreateRole).ToList(),
            };
            _userRepository.Add(newUser);
            await _userRepository.UnitOfWork.SaveChangesAsync();
            return newUser.Id;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<UserDto> FindById(Guid id)
        {
            var element = await _userRepository.FindByIdAsync(id);
            return element.MapToUserDto(_mapper);
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<UserDto>> FindAll()
        {
            var elements = await _userRepository.FindAllAsync();
            return elements.MapToUserDtoList(_mapper);
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task Put(Guid id, UserUpdateDto dto)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);
            existingUser.Email = dto.Email;
            existingUser.Username = dto.Username;
            existingUser.Roles.UpdateCollection(dto.Roles, (e, d) => e.Id == d.Id, UpdateRole);
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<UserDto> Delete(Guid id)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);
            _userRepository.Remove(existingUser);
            return existingUser.MapToUserDto(_mapper);
        }

        public void Dispose()
        {
        }

        [IntentManaged(Mode.Fully)]
        private Role CreateRole(CreateUserRoleDto dto)
        {
            return new Role
            {
                Name = dto.Name,
            };
        }

        [IntentManaged(Mode.Fully)]
        private static void UpdateRole(Role entity, UpdateUserRoleDto dto)
        {
            entity.Name = dto.Name;
            entity.UserId = dto.UserId;
        }
    }
}