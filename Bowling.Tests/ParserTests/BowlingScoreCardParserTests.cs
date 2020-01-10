using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Bowling.Models;
using Bowling.Parsers;
using Bowling.GameTypes;

namespace Bowling.Tests.ParserTests
{
    class BowlingScoreCardParserTests
    {
        [TestCase("X|X|X|X|X|X|X|X|X|X||XX", 11)]
        [TestCase("X|X|X|X|X|X|X|2/|54||", 9)]
        [TestCase("26|25|--|2/|5/|X|81|-2|6/|22||", 10)]
        public void BowlingScoreCardGenerator_CreatesProperNumberOfFrames(string scoreCardString, int numFrames)
        {
            var success = ScoreCardParser.TryParse<TenPinBowlingType>(scoreCardString, out ScoreCard<TenPinBowlingType> scoreCard);

            Assert.AreEqual(scoreCard.Frames.Count, numFrames);
        }

        [TestCase("X|X|X|X|X~X|!|X|X|T||XX")]
        [TestCase("X|^|X|X|X~X|!|X|X|T||")]
        [TestCase("X|X|X|X|X|X|X|2/|5@||")]
        public void BowlingScoreCardParser_CreationFails(string scoreCardString)
        {
            Assert.IsFalse(ScoreCardParser.TryParse<TenPinBowlingType>(scoreCardString, out var scoreCard));
        }

        [TestCase("X|X|X|X|X|X|X|X|X|X||XX")]
        [TestCase("9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||")]
        [TestCase("5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5")]
        [TestCase("X|7/|9-|X|-8|8/|-6|X|X|X||81")]
        public void BowlingScoreCardParser_CreationSucceeds(string scoreCardString)
        {
            Assert.IsTrue(ScoreCardParser.TryParse<TenPinBowlingType>(scoreCardString, out var scoreCard));
        }
    }
}
