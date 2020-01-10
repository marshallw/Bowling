using Bowling.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Bowling.GameTypes;

namespace Bowling.Calculators
{
    public class BowlingScoreCalculator<T> where T: IBowlingGameType, new()
    {
        public static int CalculateScore(ScoreCard<T> scoreCard)
        {
            int result = 0;
            bool addScoreAsSpare = false;
            List<int> strikesToAddToScore = new List<int>();

            foreach (var frame in scoreCard.Frames)
            {
                foreach (var bowlingThrow in frame.ThrowResults)
                {
                    if (typeof(EndGameFrame<T>) != frame.GetType()) result += bowlingThrow.PinsKnockedOver;

                    if (addScoreAsSpare)
                    {
                        addScoreAsSpare = false;
                        result += bowlingThrow.PinsKnockedOver;
                    }

                    foreach (var strike in strikesToAddToScore)
                    {
                        if (strike > 0) result += bowlingThrow.PinsKnockedOver;
                    }

                    strikesToAddToScore = strikesToAddToScore.Select(_ => --_).Where(_ => _ > 0).ToList();
                }

                if (frame.IsSpare) addScoreAsSpare = true;
                if (frame.IsStrike) strikesToAddToScore.Add(2);
            }

            return result;
        }
    }
}
