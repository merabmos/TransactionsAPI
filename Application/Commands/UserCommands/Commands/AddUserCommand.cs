﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands.Commands;

public record AddUserCommand(string FirstName, string LastName, string Email, string Password) : IRequest;

