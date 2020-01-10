using Bowling.GameTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Models
{
    public interface IFrame<T> where T: IBowlingGameType, new()
    {
        public bool IsStrike { get; }
        public bool IsSpare { get; }
        public int Score { get; }
        public int NumThrows { get; }
        public List<ThrowResult> ThrowResults { get; }
    }
}
