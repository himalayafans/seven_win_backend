﻿using SevenWinBackend.Application.Base;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Repositories
{
    /// <summary>
    /// 出7制胜游戏记录表
    /// </summary>
    public interface ISevenWinRecordRepository : IRepository<SevenWinRecord>
    {
    }
}
