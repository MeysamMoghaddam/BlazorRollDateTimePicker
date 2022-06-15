using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollDateTimePicker
{
    public class DateTimePickerOption
    {
        /// <summary>
        /// MM-YYYY
        /// YYYY-MM-DD hh
        /// YYYY-MM-DD hh:mm:ss
        /// hh:mm:ss
        /// MM
        /// hh
        /// ss
        /// DD
        /// mm
        /// YYYY
        /// YYYY/DD
        /// hh:mm
        /// YYYY-MM-DD hh:mm
        /// YYYY-MM-DD
        /// </summary>
        public string DateFormat { get; set; } = "YYYY-MM-DD";

        public int BeginYear { get; set; } = 2000;
        public int EndYear { get; set; } = 2100;
        public Language Language { get; set; }
    }
    public class Language
    {
        public string Title { get; set; } = "Select Date";
        public string Cancel { get; set; } = "Cancel";
        public string Confirm { get; set; } = "Confirm";
        public string Year { get; set; } = "Year";
        public string Month { get; set; } = "Month";
        public string Day { get; set; } = "Day";
        public string Hour { get; set; } = "Hour";
        public string Min { get; set; } = "Min";
        public string Sec { get; set; } = "Sec";
    }
}
