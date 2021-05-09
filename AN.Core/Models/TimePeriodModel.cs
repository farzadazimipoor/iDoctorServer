using AN.Core.Enums;
using System;

namespace AN.Core.Models
{
    /// <summary>
    /// مدل بازه زمانی برای نوبت دهی
    /// </summary>
    public class TimePeriodModel
    {
        /// <summary>
        /// ساعت شروع بازه زمانی
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// ساعت پایان بازه زمانی
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// نوع بازه زمانی (خالی - نویت - زمان استراحت و یا ناشناخته
        /// </summary>
        public TimePeriodType Type { get; set; }

        /// <summary>
        /// مدت زمان بازه زمانی
        /// </summary>
        public int Duration { get; set; }



    }
}
