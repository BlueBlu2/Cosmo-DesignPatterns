using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmoStatePattern.GoodEx.UI;

namespace CosmoStatePattern.GoodEx.Logic
{

    public class NewState : BookingState
    {
        public override void Cancle(BookingContext booking)
        {
            booking.TransitionToState(new ClosedState("Booking Cancled"));
        }

        public override void DatePassed(BookingContext booking)
        {
            booking.TransitionToState(new ClosedState("Booking Expired"));
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            booking.Attendee = attendee;
            booking.TicketCount = ticketCount;
            booking.TransitionToState(new PendingState());
        }

        public override void EnterState(BookingContext booking)
        {
            booking.BookingID = new Random().Next();
            booking.ShowState("New");
            booking.View.ShowEntryPage();
        }
    }    
}
