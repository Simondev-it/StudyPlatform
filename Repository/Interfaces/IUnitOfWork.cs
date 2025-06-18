﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IChapterRepository ChapterRepository { get; }
        Task<int> SaveChangeAsync();


    }
}
