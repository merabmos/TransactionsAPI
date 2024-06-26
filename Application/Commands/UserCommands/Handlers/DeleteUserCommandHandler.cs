﻿using Application.Commands.UserCommands.Commands;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands.Handlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    public readonly IUserRepository _repository;
    public readonly IUnitOfWork _unitOfWork;
    public DeleteUserCommandHandler(
        IUserRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);
        _repository.Delete(user);
        await _unitOfWork.CommitAsync();
    }
}
