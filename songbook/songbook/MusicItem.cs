using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace songbook
{
    public interface MusicItem
    {
      string ScreenName { get; }
      string IconPath { get; }
    }
}
