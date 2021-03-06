﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
You are given the following information, but you may prefer to do some research for yourself.

    1 Jan 1900 was a Monday.
    Thirty days has September,
    April, June and November.
    All the rest have thirty-one,
    Saving February alone,
    Which has twenty-eight, rain or shine.
    And on leap years, twenty-nine.
    A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
*/

namespace ProjectEuler19
{
    class Program
    {
        static void Main(string[] args)
        {
            int sundaysOnFirstOfMonth = 0;
            for (int year = 1901; year < 2001; year++)
            {
                for (int month = 1; month < 13; month++)
                {
                    DateTime test = new DateTime(year, month, 1);
                    if (DayOfWeek.Sunday == test.DayOfWeek)
                    {
                        sundaysOnFirstOfMonth++;
                    }
                }
            }
            Console.WriteLine(sundaysOnFirstOfMonth);
            
        }
    }
}
