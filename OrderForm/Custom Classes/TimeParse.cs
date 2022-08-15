using System;
using System.Linq;

namespace OrderForm
{
    public static class TimeParse
    {
        //public static string AUTO()
        //{

        //}
        public static DateTime TT(string txt)
        {
            //bool AM;
            if (txt != null)
            {
                if (txt.Contains("مساء") || txt.Contains("ليلا") || txt.Contains("عصرا") || txt.Contains("ظهرا"))
                {
                    txt = txt.Replace("مساء", "").Replace("ليلا", "").Replace("عصرا", "").Replace("ظهرا", "");
                    txt += " PM";
                    var d = DateTime.Today;
                    DateTime.TryParse(txt, out d);

                    return d;
                }
                else if (txt.Contains("صباحا"))
                {
                    txt = txt.Replace("صباحا", "");
                    txt += " AM";

                    var d = DateTime.Today;
                    DateTime.TryParse(txt, out d);
                    return d;
                }
            }

            return DateTime.Now.AddMinutes(15);
        }

        public static string T(string txt)
        {

            string output = new string(txt.Where(c => (Char.IsDigit(c) || c == '.' || c == ',' || c == ':')).ToArray());
            string TimeOfDay = new string(txt.Where(c => (Char.IsLetter(c))).ToArray());
            string TOD = "";
            switch (TimeOfDay)
            {
                case "ص": { TOD = "صباحا"; break; }
                case "ظ": { TOD = "ظهرا"; break; }
                case "ع": { TOD = "عصرا"; break; }
                case "م": { TOD = "مساء"; break; }
                case "ل": { TOD = "ليلا"; break; }
            }
            int MaxHour;
            int MaxMinute;
            string MH;
            if (Int32.TryParse(output, out MaxHour))
            {
                if (MaxHour <= 1259)
                {
                    if (MaxHour <= 959)
                    {
                        if (MaxHour >= 100)
                        {
                            if (Int32.TryParse(MaxHour.ToString().Substring(1, 2), out MaxMinute))
                            {
                                if (MaxMinute <= 59)
                                {
                                    MH = MaxHour.ToString().Insert(1, ":");
                                    return MH + TOD;
                                }
                            }
                        }
                        else if (MaxHour == 10 || MaxHour == 11 || MaxHour == 12)
                        {
                            MH = MaxHour.ToString().Insert(2, ":00");
                            return MH + TOD;
                        }
                        else if (MaxHour > 0 && MaxHour < 10)
                        {
                            MH = MaxHour.ToString().Insert(1, ":00");
                            return MH + TOD;

                        }
                    }
                    else if (MaxHour >= 1000)
                    {
                        if (Int32.TryParse(MaxHour.ToString().Substring(2, 2), out MaxMinute))
                        {
                            if (MaxMinute <= 59)
                            {
                                MH = MaxHour.ToString().Insert(2, ":");
                                return MH + TOD;
                            }
                        }

                    }
                }

                return "خطأ في التنسيق";
            }
            return "خطأ في التنسيق";

        }

    }


}
