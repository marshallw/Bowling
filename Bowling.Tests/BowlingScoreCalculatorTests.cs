using Bowling.Calculators;
using Bowling.GameTypes;
using Bowling.Models;
using Bowling.Parsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Bowling.GameTypes;

namespace Bowling.Tests
{
    class BowlingScoreCalculatorTests
    {
        [TestCase("X|X|X|X|X|X|X|X|X|X||XX", 300)]
        [TestCase("9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||", 90)]
        [TestCase("5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5", 150)]
        [TestCase("X|7/|9-|X|-8|8/|-6|X|X|X||81", 167)]
        public void BowlingScoreCalculator_CalculatesProperly(string scoreCardString, int actualScore)
        {
            bool success = ScoreCardParser.TryParse<TenPinBowlingType>(scoreCardString, out ScoreCard<TenPinBowlingType> scoreCard);
            
            int calculatedScore = BowlingScoreCalculator<TenPinBowlingType>.CalculateScore(scoreCard);
            
            Assert.AreEqual(actualScore, calculatedScore);
        }
    }
}
