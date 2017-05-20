using System;
using System.Collections.Generic;

namespace Soul.Models
{
    public class WorkingHours
    {
        //-----------------------------------------------------------------------------------------------
        public List<string> Hours { get; } = null;
        //-----------------------------------------------------------------------------------------------
        public WorkingHours()
        {
            Hours = new List<string>();
            FillHours(Hours);
        }
        //-----------------------------------------------------------------------------------------------
        private void FillHours(List<string> hours)
        {
            for (int i = 9; i < 18; i++)
            {
                hours.Add(String.Format("{0,2:d2}:{1,2:d2}", i, 0));
                hours.Add(String.Format("{0,2:d2}:{1,2:d2}", i, 30));
            }
        }
    }
}
