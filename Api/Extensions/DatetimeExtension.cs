using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Extensions
{
    public static class DatetimeExtension
    {
        public static int CalculateAge(this DateTime dob)
        {
            var today = DateTime.Now;
            var age = today.Year - dob.Year;
            if(dob >today.AddYears(-age)) age--;
            return age;


        }
    }
}