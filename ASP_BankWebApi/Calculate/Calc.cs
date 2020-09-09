using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public static class Calc
    {
        public static decimal Deposit(bool cap_flag, decimal amount, DateTime open_date, DateTime estimate_date, int percent)
        {
            if (cap_flag)
            {
                int month_left = MonthLeft(open_date,estimate_date);

                double per_month = ((percent / 12.0) / 100.0) + 1.0;

                decimal result = (decimal)((double)amount * Math.Pow(per_month, (double)month_left));

                return decimal.Round(result,2);
            }
            else
            {
                int years_left = YearLeft(open_date, estimate_date);

                decimal result = amount + (decimal)((percent / (double)100) * (double)amount * (double)years_left);

                return decimal.Round(result, 2);
            }
            //if (estimate_date < DateTime.Today) throw new PastException("Указанная дата раньше текущей");
        }

        public static decimal Credit(decimal amount, DateTime open_date, DateTime repayment_date, int percent)
        {
            int month_left = MonthLeft(open_date, repayment_date);
            double result;
            if (percent!=0)
            {
                double perc_per_month = (double)percent / (12.0 * 100.0);
                double power = Math.Pow(1.0 + perc_per_month, (double)month_left);
                result = (double)amount * ((perc_per_month * power) / (power - 1.0));
            }
            else
            {
                result = (double)amount / (double)month_left;
            }


            return decimal.Round((decimal)result,2);
        }

        public static int YearLeft(DateTime left_date, DateTime right_date)
        {
            int years_left;
            years_left = right_date.Year - left_date.Year;
            if (right_date.Month > left_date.Month) { }
            else if (right_date.Month < left_date.Month)
            {
                years_left--;
            }
            else
            {
                if (right_date.Day >= left_date.Day) { }
                else
                {
                    years_left--;
                }
            }
            return years_left;
        }

        public static int MonthLeft(DateTime left_date, DateTime right_date)
        {
            int month_left;
            month_left = (right_date.Year - left_date.Year) * 12;
            month_left += right_date.Month - left_date.Month;

            if (right_date.Day < left_date.Day) month_left--;
            else { };

            return month_left;
        }
    }
}
