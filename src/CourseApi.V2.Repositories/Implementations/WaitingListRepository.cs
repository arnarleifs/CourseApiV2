﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApi.V2.Models.Entities;
using CourseApi.V2.Repositories.Base;
using CourseApi.V2.Repositories.Interfaces;

namespace CourseApi.V2.Repositories.Implementations
{
    public class WaitingListRepository : RepositoryBase<WaitingList>, IWaitingListRepository
    {
        public WaitingListRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
