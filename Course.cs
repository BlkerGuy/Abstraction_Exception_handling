using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Abstraction_Exception_handling
{
    class Course : ICourse
    {
        public Group[] Grups = new Group[0];
        public void AddGroup(Group groups)
        {
            Array.Resize(ref Grups, Grups.Length + 1);
            Grups[Grups.Length - 1] = groups;

            Console.WriteLine("Congratulation! group created.\n");
        }

        public Group GetGroupByNo(string no)
        {
            if (no != null)
            {
                for (int i = 0; i < Grups.Length; i++)
                {
                    if (Grups[i].No.Contains(no))
                    {
                        return Grups[i];
                    }
                }
            }
            return null;
        }

       public  Group[] GetGroupsByPointRange(byte minPoint, byte maxPoint)
        {
            Group[] groups = new Group[0];
            if (Grups.Length != 0)
            {
                for (int i = 0; i < Grups.Length; i++)
                {
                    if (Grups[i].AvgPoint >= minPoint && Grups[i].AvgPoint <= maxPoint)
                    {
                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = Grups[i];
                    }
                }
                return groups;
            }
            return null;
        }

        public Group[] Search(string str)
        {
            Group[] groups = new Group[0];
            if (str != null || str != " ")
            {
                for (int i = 0; i < Grups.Length; i++)
                {
                    if (Grups[i].No.Contains(str))
                    {
                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = Grups[i];
                    }
                }
            }
            return groups;
        }
    }
}
