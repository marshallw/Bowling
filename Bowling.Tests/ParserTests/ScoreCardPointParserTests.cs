using Bowling.GameTypes;
using Bowling.Parsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Tests.ParserTests
{
    class ScoreCardPointParserTests
    {
        [TestCase('1')]
        [TestCase('5')]
        [TestCase('8')]
        [TestCase('x')]
        [TestCase('/')]
        [TestCase('-')]
        public void ScoreCardPointParser_CanParse(char character)
        {
            Assert.IsTrue(ScoreSheetPointParser.TryParse<TenPinBowlingType>(character, out int _));
        }

        [TestCase('\\')]
        [TestCase('~')]
        [TestCase('t')]
        [TestCase('X')]
        [TestCase('_')]
        [TestCase('?')]
        [TestCase('[')]
        public void ScoreCardPointParser_CantParse(char character)
        {
            Assert.IsFalse(ScoreSheetPointParser.TryParse<TenPinBowlingType>(character, out int _));
        }

        [TestCase('1', 0, 1)]
        [TestCase('5', 0, 5)]
        [TestCase('8', 0, 8)]
        [TestCase('x', 0, 10)]
        [TestCase('/', 0, 10)]
        [TestCase('/', 4, 6)]
        [TestCase('-', 0, 0)]
        public void ScoreCardPointParser_ReturnsProperEnum(char character, int  firstThrow, int expected)
        {
            ScoreSheetPointParser.TryParse<TenPinBowlingType>(character, out int result, firstThrow);

            Assert.AreEqual(expected, result);
        }
    }
}
