using System;
using System.Collections.Generic;
using System.Text;
using Bowling.Calculators;
using Bowling.Parsers;
using Bowling.GameTypes;

namespace Bowling.Game
{
    public class TenPinBowling : IBowling
    {
        public int CalculateScore(string game)
        {
            bool scoreCardParseSuccess = ScoreCardParser.TryParse<TenPinBowlingType>(game, out var scoreCard);
            return BowlingScoreCalculator<TenPinBowlingType>.CalculateScore(scoreCard);
            
        }
    }
}
