﻿using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.TransactionQueries;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<Transaction>>
{
    private readonly IRepository<Transaction> _transactionRepository;
    private readonly IMediator _mediator;
    public GetAllUsersQueryHandler(IRepository<Transaction> transactionRepository, IMediator mediator)
    {
        _transactionRepository = transactionRepository;
        _mediator = mediator;
    }

    public Task<IEnumerable<Transaction>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        return _transactionRepository.GetAllAsync(request.filter);
    }
}
