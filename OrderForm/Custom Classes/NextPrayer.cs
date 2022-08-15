using PrayerTimes;
using System;
namespace OrderForm
{
    internal static class NextPrayer
    {
        public enum state
        {
            DhuhrPeriod = 0, DhuhrSalahPeriod = 1,
            AsrPeriod = 2, AsrSalahPeriod = 3,
            MagribPeriod = 4, MagribSalahPeriod = 5,
            IshaPeriod = 6, IshaSalahPeriod = 7,
            AfterIsha = 8, After12am = 9, stateless = 10
        }
        public static string UpdateCounter()
        {
            PrayerTimesCalculator calc = new PrayerTimesCalculator(24.715468, 46.696223);
            calc.CalculationMethod = CalculationMethods.Makkah;
            calc.AsrJurusticMethod = AsrJuristicMethods.Shafii;
            Times times = calc.GetPrayerTimes(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 4);
            return GetCountdown(times, GetCurrentPeriod(times));
        }
        public static state UpdateCounter(bool sss)
        {
            PrayerTimesCalculator calc = new PrayerTimesCalculator(24.715468, 46.696223);
            calc.CalculationMethod = CalculationMethods.Makkah;
            calc.AsrJurusticMethod = AsrJuristicMethods.Shafii;
            Times times = calc.GetPrayerTimes(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 4);
            return GetCurrentPeriod(times);
        }
        public static state GetCurrentPeriod(Times ts)
        {
            TimeSpan now = DateTime.Now.TimeOfDay;

            ////////////
            TimeSpan TillDhuhrPeriodStart = new TimeSpan(6, 0, 0);
            TimeSpan TillDhuhrPeriodEnd = ts.Dhuhr;
            if (NextSalah(now, TillDhuhrPeriodStart, TillDhuhrPeriodEnd) == true) return state.DhuhrPeriod;
            else
            {
                TimeSpan DhurSalahStart = ts.Dhuhr;
                TimeSpan DhurSalahEnd = ts.Dhuhr + TimeSpan.FromMinutes(30);
                if (NextSalah(now, DhurSalahStart, DhurSalahEnd) == true) return state.DhuhrSalahPeriod;
                else
                {
                    TimeSpan TillAsrPeriodStart = DhurSalahEnd;
                    TimeSpan TillAsrPeriodEnd = ts.Asr;
                    if (NextSalah(now, TillAsrPeriodStart, TillAsrPeriodEnd) == true) return state.AsrPeriod;
                    else
                    {
                        TimeSpan AsrSalahStart = ts.Asr;
                        TimeSpan AsrSalahEnd = ts.Asr + TimeSpan.FromMinutes(30);
                        if (NextSalah(now, AsrSalahStart, AsrSalahEnd) == true) return state.AsrSalahPeriod;
                        else
                        {
                            TimeSpan TillMagribPeriodStart = AsrSalahEnd;
                            TimeSpan TillMagribPeriodEnd = ts.Maghrib;
                            if (NextSalah(now, TillMagribPeriodStart, TillMagribPeriodEnd) == true) return state.MagribPeriod;
                            else
                            {
                                TimeSpan MagribSalahStart = ts.Maghrib;
                                TimeSpan MagribSalahEnd = ts.Maghrib + TimeSpan.FromMinutes(20);
                                if (NextSalah(now, MagribSalahStart, MagribSalahEnd) == true) return state.MagribSalahPeriod;
                                else
                                {
                                    TimeSpan TillIshaPeriodStart = MagribSalahEnd;
                                    TimeSpan TillIshaPeriodEnd = ts.Isha;
                                    if (NextSalah(now, TillIshaPeriodStart, TillIshaPeriodEnd) == true) return state.IshaPeriod;
                                    else
                                    {
                                        TimeSpan IshaSalahStart = ts.Isha;
                                        TimeSpan IshaSalahEnd = ts.Isha + TimeSpan.FromMinutes(20);
                                        if (NextSalah(now, IshaSalahStart, IshaSalahEnd) == true) return state.IshaSalahPeriod;
                                        else
                                        {
                                            TimeSpan EndOfWorkPeriodStart = ts.Isha;
                                            TimeSpan EndOfWork = new TimeSpan(23, 59, 59);
                                            if (NextSalah(now, EndOfWorkPeriodStart, EndOfWork) == true) return state.AfterIsha;

                                        }
                                    }

                                }

                            }


                        }
                    }

                }
            }
            return state.After12am;

        }
        public static string GetCountdown(Times ts, state cp)
        {
            TimeSpan now = DateTime.Now.TimeOfDay;

            switch (cp)
            {
                case state.DhuhrPeriod:
                    TimeSpan DhuhrCountDown = ts.Dhuhr - now;
                    return DhuhrCountDown.ToString(@"hh\:mm\:ss");

                case state.DhuhrSalahPeriod:
                    TimeSpan DhurSalahEnd = ts.Dhuhr + TimeSpan.FromMinutes(30);
                    TimeSpan TillDhuhrSalahEnds = DhurSalahEnd - now;
                    return TillDhuhrSalahEnds.ToString(@"hh\:mm\:ss");

                case state.AsrPeriod:
                    TimeSpan AsrCountDown = ts.Asr - now;
                    return AsrCountDown.ToString(@"hh\:mm\:ss");

                case state.AsrSalahPeriod:
                    TimeSpan AsrSalahEnds = ts.Asr + TimeSpan.FromMinutes(30);
                    TimeSpan TillAsrEnds = AsrSalahEnds - now;
                    return TillAsrEnds.ToString(@"hh\:mm\:ss");

                case state.MagribPeriod:
                    TimeSpan MagribCountDown = ts.Maghrib - now;
                    return MagribCountDown.ToString(@"hh\:mm\:ss");

                case state.MagribSalahPeriod:
                    TimeSpan MagribSalahEnds = ts.Maghrib + TimeSpan.FromMinutes(20);
                    TimeSpan TillMagribEnds = MagribSalahEnds - now;
                    return TillMagribEnds.ToString(@"hh\:mm\:ss");

                case state.IshaPeriod:
                    TimeSpan IshaCountDown = ts.Isha - now;
                    return IshaCountDown.ToString(@"hh\:mm\:ss");

                case state.IshaSalahPeriod:
                    TimeSpan IshaSalahEnd = ts.Isha + TimeSpan.FromMinutes(30);
                    TimeSpan tillSalahEnds = IshaSalahEnd - now;
                    return tillSalahEnds.ToString(@"hh\:mm\:ss");

                case state.AfterIsha:
                    return "00:00:00";

                case state.After12am:
                    return "00:00:00";

                default: return "00:00:00";

            }

        }
        private static bool NextSalah(TimeSpan now, TimeSpan start, TimeSpan end)
        {
            if (start < end)
                return start <= now && now <= end;
            // start is after end, so do the inverse comparison
            return !(end < now && now < start);
        }
    }
}
