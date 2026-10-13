using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaLink.Application.Params
{
    public class BaseQueryParam
    {
        public string? Search { get; set; }

        private int pageIndex = 1;
        public int PageIndex
        {
            get { return pageIndex; }
            set
            {
                pageIndex = (value <= 0) ? 1 : value;
            }
        }

        private const int DefultPageSize = 5;
        private const int MaxPageSize = 10;
        private int pageSize = DefultPageSize;

        public int PageSize
        {
            get { return pageSize; }
            set
            {
                if (value > MaxPageSize) pageSize = MaxPageSize;
                else if (value <= 0) pageSize = DefultPageSize;
                else pageSize = value;
            }
        }
    }
}
