using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Models
{
    public class ThrowResult
    {
        private int _pinsKnockedOver;

        public int PinsKnockedOver => _pinsKnockedOver;
        public ThrowResult(int pinsKnockedOver)
        {
            _pinsKnockedOver = pinsKnockedOver;
        }
    }
}
