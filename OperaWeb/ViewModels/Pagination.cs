using System;
using System.Collections.Generic;

namespace OperaWeb.ViewModels
{
    public class Pagination<T>
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling(Count / (double)PageSize);
            }
        }

        public bool HasPrevious()
        {
            return PageNumber > 1;
        }

        public bool HasNext()
        {
            return PageNumber < PageCount;
        }
    }
}
