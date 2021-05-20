using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public sealed class ApiResponse<T>
    {
        public ResponseInfo Info { get; set; }
        public List<T> Results { get; set; }
    }
}
