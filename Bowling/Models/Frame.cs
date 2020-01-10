using System;
using System.Collections.Generic;
using System.Text;
using Bowling.Enums;
using System.Linq;
using Bowling.GameTypes;

namespace Bowling.Models
{
    public class Frame<T>: IFrame<T> where T: IBowlingGameType, new()
    {
        private List<ThrowResult> _throwResults;
        private T gameData;
        public Frame(List<ThrowResult> throws)
        {
            _throwResults = throws;
            gameData = new T();
        }

        public bool IsStrike => _throwResults.First().PinsKnockedOver == gameData.NumberOfPins;
        public bool IsSpare => _throwResults.First().PinsKnockedOver != gameData.NumberOfPins && _throwResults.Sum(_ => _.PinsKnockedOver) == gameData.NumberOfPins;
        public int Score => _throwResults.Sum(_ => _.PinsKnockedOver);
        public int NumThrows => _throwResults.Count();
        public List<ThrowResult> ThrowResults => _throwResults;
    }
}
