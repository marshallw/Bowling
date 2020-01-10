using System;
using System.Collections.Generic;
using System.Text;
using Bowling.Models;
using System.Linq;
using Bowling.GameTypes;
using Bowling.Enums;

namespace Bowling.Parsers
{
    public static class ScoreCardParser
    {
        public static bool TryParse<T>(string gameString, out ScoreCard<T> scoreCard) where T : IBowlingGameType, new()
        {
            scoreCard = null;
            Queue<char> gameQueue = new Queue<char>(gameString.ToLower().ToCharArray());
            List<ThrowResult> bowlResults = new List<ThrowResult>();
            List<IFrame<T>> frames = new List<IFrame<T>>();
            bool success = true;

            foreach (char character in gameQueue)
            {
                var characterTypeParserResults = ScoreSheetCharacterTypeParser.TryParse(character, out ScoreSheetCharacterTypeEnum characterType);
                if (!characterTypeParserResults) success = false;
                switch (characterType)
                {
                    case ScoreSheetCharacterTypeEnum.Frame:
                    if (bowlResults.Count > 0)
                    {
                        frames.Add(new Frame<T>(bowlResults));
                        bowlResults = new List<ThrowResult>();
                    }
                        break;
                    case ScoreSheetCharacterTypeEnum.Points:
                        var pointParsingResults = ScoreSheetPointParser.TryParse<T>(character, out int points, bowlResults.Any() ? bowlResults.First().PinsKnockedOver : 0);
                        if (pointParsingResults)
                        {
                            bowlResults.Add(new ThrowResult(points));
                        }
                        else
                        {
                            success = false;
                        }
                        break;
                }
            }
            
            if (bowlResults.Count > 0)
            {
                frames.Add(new EndGameFrame<T>(bowlResults));
            }

            if (success) scoreCard = new ScoreCard<T>(frames);
            
            return success;
        }
    }
}
