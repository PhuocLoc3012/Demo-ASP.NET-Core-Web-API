﻿namespace DemoASP.NET_CORE1.Helpers
{
    public class QueryObject
    {

        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public string? SortBy { get; set; }
        public bool IsDecsending { get; set; } = false;

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;

    }
}