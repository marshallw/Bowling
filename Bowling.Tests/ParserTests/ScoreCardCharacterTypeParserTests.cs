using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Bowling.Parsers;
using Bowling.Enums;
namespace Bowling.Tests.ParserTests
{
    class ScoreCardCharacterTypeParserTests
    {
        [TestCase('1')]
        [TestCase('5')]
        [TestCase('8')]
        [TestCase('x')]
        [TestCase('/')]
        [TestCase('-')]
        [TestCase('|')]
        public void ScoreCardCharacterTypeParser_CanParse(char character)
        {
            Assert.IsTrue(ScoreSheetCharacterTypeParser.TryParse(character, out ScoreSheetCharacterTypeEnum _));
        }

        [TestCase('\\')]
        [TestCase('~')]
        [TestCase('t')]
        [TestCase('X')]
        [TestCase('_')]
        [TestCase('?')]
        [TestCase('[')]
        public void ScoreCardCharacterTypeParser_CantParse(char character)
        {
            Assert.IsFalse(ScoreSheetCharacterTypeParser.TryParse(character, out ScoreSheetCharacterTypeEnum _));
        }

        [TestCase('1', ScoreSheetCharacterTypeEnum.Points)]
        [TestCase('5', ScoreSheetCharacterTypeEnum.Points)]
        [TestCase('8', ScoreSheetCharacterTypeEnum.Points)]
        [TestCase('x', ScoreSheetCharacterTypeEnum.Points)]
        [TestCase('/', ScoreSheetCharacterTypeEnum.Points)]
        [TestCase('-', ScoreSheetCharacterTypeEnum.Points)]
        [TestCase('|', ScoreSheetCharacterTypeEnum.Frame)]
        public void ScoreCardCharacterTypeParser_ReturnsProperEnum(char character, ScoreSheetCharacterTypeEnum expected)
        {
            ScoreSheetCharacterTypeParser.TryParse(character, out ScoreSheetCharacterTypeEnum result);

            Assert.AreEqual(result, expected);
        }
    }
}
