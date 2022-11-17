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
        public string? SearchType { get; set; } = null;
        public string? SearchValue { get; set; } = null;
        public bool? IsSortAscending { get; set; } = null;
        public string? SortBy { get; set; } = null;
        long? IQueryOptions.StartTime { get; set; } = null;
        long? IQueryOptions.EndTime { get; set; } = null;
    }
}
