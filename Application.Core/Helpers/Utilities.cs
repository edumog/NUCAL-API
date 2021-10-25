using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Helpers
{
    public static class Utilities
    {
        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
