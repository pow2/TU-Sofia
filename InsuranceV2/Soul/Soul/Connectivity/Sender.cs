using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soul.Connectivity
{
    public interface ISender
    {
        void RenderResponseAsync(string msg);
    }
}
