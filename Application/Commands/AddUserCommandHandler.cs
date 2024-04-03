﻿using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHashService _passwordHashService;
        public AddUserCommandHandler(IRepository<User> userRepository, 
                                     IUnitOfWork unitOfWork,
                                     IPasswordHashService passwordHashService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _passwordHashService = passwordHashService;
        }
        public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            user.HashedPassword = _passwordHashService.HashPassword(request.Password);

            await _userRepository.AddAsync(user);

            await _unitOfWork.CommitAsync();
        }
    }
}