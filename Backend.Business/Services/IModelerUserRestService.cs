﻿using System.Linq;
using Shared.Business.DTOs;
using Backend.Core.Service;

namespace Backend.Business.Services
{
    public interface IModelerUserRestService : IReadonlyRestService<UserDTO>, IAuthorizationService
    {
        IQueryable<UserDTO> GetActive();

    }
}