using SevenWinBackend.Application.Interfaces;
using SevenWinBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Common
{
    public class QueryOptions : IQueryOptions
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchType { get; set; } = string.Empty;
        public string? SearchValue { get; set; } = string.Empty;

        public SortDescriptor? Sort { get; set; } = null;
    }
}
