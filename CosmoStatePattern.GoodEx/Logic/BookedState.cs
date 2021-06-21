using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmoStatePattern.GoodEx.UI;

namespace CosmoStatePattern.GoodEx.Logic
{
    public class BookedState : BookingState
    {
        public override void Cancle(BookingContext booking)
        {
            booking.TransitionToState(new ClosedState("Booking Cancled: expect a refund"));
        }

        public override void DatePassed(BookingContext booking)
        {
            booking.TransitionToState(new ClosedState("we hope you enjoyed the event ^_^"));
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            
        }

        public override void EnterState(BookingContext booking)
        {
            booking.ShowState("Booked");
            booking.View.ShowStatusPage("Enjoy the event");
        }
    }
}
