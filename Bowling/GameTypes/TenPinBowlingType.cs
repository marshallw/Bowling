using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.GameTypes
{
    public struct TenPinBowlingType : IBowlingGameType
    {
        public int NumberOfPins => 10;
    }
}
