﻿using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITopicService
    {
        Task<List<Topic>> GetAllTopicsAsync();

        Task<Topic> GetTopicsByIdAsync(int id);
    }
}
