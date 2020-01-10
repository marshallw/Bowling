using Bowling.GameTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Models
{
    public class ScoreCard<T> where T: IBowlingGameType, new()
    {
        private List<IFrame<T>> _frames;

        public List<IFrame<T>> Frames => _frames;

        public ScoreCard(List<IFrame<T>> playerFrames)
        {
            _frames = playerFrames;
        }
    }
}
