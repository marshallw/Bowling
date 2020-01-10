using Bowling.GameTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Models
{
    public class EndGameFrame<T> : IFrame<T> where T: IBowlingGameType, new()
    {
        private List<ThrowResult> _throwResults;

        public EndGameFrame(List<ThrowResult> throwResults)
        {
            _throwResults = throwResults;
        }
        public bool IsStrike => false;

        public bool IsSpare => false;

        public int Score => 0;

        public int NumThrows => _throwResults.Count;

        public List<ThrowResult> ThrowResults => _throwResults;
    }
}
