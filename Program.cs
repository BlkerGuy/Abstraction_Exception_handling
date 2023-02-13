using System;

namespace Abstraction_Exception_handling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Course course = new Course();
            Group groups = new Group();
            string optInput;


            try
            {
                do
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1.Qrup elave et.");
                    Console.WriteLine("2.Bütün qruplara bax.");
                    Console.WriteLine("3.Verilmiş point araligindaki qruplara bax.");
                    Console.WriteLine("4.Verilmiş nomresi qrupa bax.");
                    Console.WriteLine("5.Verilmiş qruplar üzre axtariş et.");
                    Console.WriteLine("\n0.Menudan cix!\n");
                    optInput = Console.ReadLine();
                    {
                        switch (optInput)
                        {
                            case "1":
                                string groupNum;
                                byte count = 0;
                                Group newGroup = new Group();
                                do
                                {
                                    Console.WriteLine("Qrup adi daxil et:  misal:P138");
                                    groupNum = Console.ReadLine();


                                    Console.WriteLine("Qrupun averagePoint daxil edin:");
                                    string avgP = Console.ReadLine();
                                    if (checkStr(avgP))
                                    {
                                        byte avgPoint;
                                        if (byte.TryParse(avgP, out avgPoint) || avgPoint > 100)
                                        {
                                            avgPoint = Convert.ToByte(avgP);
                                            if (newGroup.CheckGroupNo(groupNum))
                                            {
                                                if (course.Grups.Length == 0)
                                                {
                                                    course.AddGroup(new Group { No = groupNum, AvgPoint = avgPoint });
                                                }
                                                else
                                                {
                                                    for (int i = 0; i < course.Grups.Length; i++)
                                                    {
                                                        if (groupNum != course.Grups[i].No)
                                                        {
                                                            count++;
                                                        }
                                                    }
                                                    if (count == course.Grups.Length)
                                                    {
                                                        course.AddGroup(new Group { No = groupNum, AvgPoint = avgPoint });
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Group:{groupNum} artiq movcuddur!!");
                                                    }
                                                }
                                            }
                                        }

                                    }

                                } while (!newGroup.CheckGroupNo(groupNum));
                                break;
                            case "2":
                                Console.WriteLine("Butun qruplar:");
                                for (int i = 0; i < course.Grups.Length; i++)
                                {
                                    Console.WriteLine($"Group:{course.Grups[i].No}");
                                }
                                break;
                            case "3":
                                Console.WriteLine("Zehmet olmasa minumPoint daxil edin:");
                                string input = Console.ReadLine();
                                if (checkStr(input))
                                {
                                    byte minumPoint = Convert.ToByte(input);

                                    Console.WriteLine("Zehmet olmasa maxPoint daxil edin:");
                                    string input2 = Console.ReadLine();
                                    if (checkStr(input2))
                                    {
                                        byte maxPoint = Convert.ToByte(input2);
                                        {
                                            if (minumPoint >= 0 && maxPoint <= 100)
                                            {
                                                var grups = course.GetGroupsByPointRange(minumPoint, maxPoint);
                                                if (grups != null)
                                                {
                                                    foreach (var item in grups)
                                                    {
                                                        Console.WriteLine($"Group:{item.No} and AveragePoint:{item.AvgPoint}");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"{minumPoint}-{maxPoint} Bu araliqda Qrup tapilmadi.");
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            case "4":
                                Console.WriteLine("Grup nomresi daxil edin:");
                                string groupNoInput = Console.ReadLine();
                                if (checkStr(groupNoInput) && groupNoInput.Length == 4)
                                {
                                    if (course.Grups.Length == 0)
                                    {
                                        Console.WriteLine("Siyahi bosdur.");
                                        break;
                                    }
                                    var needValue = course.GetGroupByNo(groupNoInput);
                                    Console.WriteLine($"No: {needValue.No} - AvgPoint: {needValue.AvgPoint}");
                                }
                                break;
                            case "5":
                                Console.WriteLine("Zehmet olmasa axtardiginiz qrupu daxil edin:");
                                string groupStringInput = Console.ReadLine();
                                if (checkStr(groupStringInput) && groups.CheckGroupNo(groupStringInput))
                                    if (course.Grups.Length != 0)
                                    {
                                        var firstLetterGroup = course.Search(groupStringInput.ToUpper());

                                        foreach (var qrups in firstLetterGroup)
                                        {
                                            Console.WriteLine($"Group: {qrups.No}");
                                        }
                                    }
                                    else
                                        Console.WriteLine("Grup siyahisi bosdur");
                                break;
                            default:
                                if (optInput != "0")
                                {
                                    Console.WriteLine("Duzgun eded daxil edin!\n");
                                }
                                break;
                        }
                    }
                } while (optInput != "0");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static bool checkStr(string words)
        {
            if (words != " " && words != "")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Zehmet olmasa kecerli deyer daxil edin!!\n");
            }
            return false;
        }
       
    }
}
