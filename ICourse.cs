using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction_Exception_handling
{
    internal interface ICourse
    {
        public void AddGroup(Group groups);
        public Group GetGroupByNo(string no);
        public Group[] GetGroupsByPointRange(byte minPoint, byte maxPoint);
        public Group[] Search(string str);
    }
}
