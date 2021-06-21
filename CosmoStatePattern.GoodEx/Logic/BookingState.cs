using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmoStatePattern.GoodEx.UI;

namespace CosmoStatePattern.GoodEx.Logic
{
    public abstract class BookingState
    {
        public abstract void EnterState(BookingContext booking);
        public abstract void Cancle(BookingContext booking);
        public abstract void DatePassed(BookingContext booking);
        public abstract void EnterDetails(BookingContext booking, string attendee, int ticketCount);
    }
}
