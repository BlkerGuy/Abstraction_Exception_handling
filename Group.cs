using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstraction_Exception_handling
{
    class Group
    {
        string _no;
        byte _avgPoint;

        public byte AvgPoint
        {
            get => _avgPoint;
            set
            {
                if (value >= 0 || value <= 100)
                {
                    _avgPoint = value;
                }
            }
        }

        public string No
        {
            get => _no;
            set
            {
                if (CheckGroupNo(value))
                {
                    _no = value;
                }
            }
        }
        public bool CheckGroupNo(string groupNo)
        {
            if (char.IsLetter(groupNo[0]) && char.IsUpper(groupNo[0]) && groupNo.Substring(1, 3).All(char.IsDigit) && groupNo.Length == 4)
            {
                return true;
            }
            return false;
        }
    }
}
