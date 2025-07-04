﻿using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITopicRepository : IGenericRepository<Topic, int>
    {
        public Task<Topic> GetTopicById(int id);
    }
}
