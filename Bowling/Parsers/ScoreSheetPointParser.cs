using System;
using System.Collections.Generic;
using System.Text;
using Bowling.GameTypes;

namespace Bowling.Parsers
{
    public class ScoreSheetPointParser
    {
        public static bool TryParse<T>(char character, out int points, int spareFirstThrow = 0) where T : IBowlingGameType, new()
        {
            bool success = true;
            T gameData = new T();

            switch (character)
            {
                case '/':
                    points = gameData.NumberOfPins - spareFirstThrow;
                    break;
                case '-':
                    points = 0;
                    break;
                case 'x':
                    points = gameData.NumberOfPins;
                    break;
                default:
                    success = int.TryParse(character.ToString(), out points);
                    break;
            }

            return success;
        }
    }
}
