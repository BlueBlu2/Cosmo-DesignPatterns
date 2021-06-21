using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmoStatePattern.GoodEx.UI;

namespace CosmoStatePattern.GoodEx.Logic
{
    public class ClosedState : BookingState
    {
        private string reasonClosed;
        public ClosedState(string reason)
        {
            reasonClosed = reason;
        }
        public override void Cancle(BookingContext booking)
        {
            booking.View.ShowError("Invalid Action for this state", "Closed Booking Error");
        }

        public override void DatePassed(BookingContext booking)
        {
            booking.View.ShowError("Invalid Action for this state", "Closed Booking Error");
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            booking.View.ShowError("Invalid Action for this state", "Closed Booking Error");
        }

        public override void EnterState(BookingContext booking)
        {
            booking.ShowState("Closed");
            booking.View.ShowStatusPage(reasonClosed);
        }
    } 
}
