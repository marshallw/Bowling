using System;
using System.Collections.Generic;
using System.Text;
using Bowling.Enums;
using Bowling.GameTypes;

namespace Bowling.Parsers
{
    public class ScoreSheetCharacterTypeParser
    {
        public static bool TryParse(char toParse, out ScoreSheetCharacterTypeEnum characterType)
        {
            bool success = true;
            characterType = ScoreSheetCharacterTypeEnum.Neither;

            switch (toParse)
            {
                case '|':
                    characterType = ScoreSheetCharacterTypeEnum.Frame;
                    break;
                case '/':
                case '-':
                case 'x':
                    characterType = ScoreSheetCharacterTypeEnum.Points;
                    break;
                default:
                    success = int.TryParse(toParse.ToString(), out int _);
                    if (success) characterType = ScoreSheetCharacterTypeEnum.Points;
                    break;
            }

            return success;
        }
    }
}
