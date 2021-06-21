using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CosmoStatePattern.GoodEx.UI;

namespace CosmoStatePattern.GoodEx.Logic
{
    public class PendingState : BookingState
    {
        private CancellationTokenSource cancellationToken;
        public override void Cancle(BookingContext booking)
        {
            cancellationToken.Cancel();
        }

        public override void DatePassed(BookingContext booking)
        {
            
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            
        }

        public override void EnterState(BookingContext booking)
        {
            cancellationToken = new CancellationTokenSource();

            booking.ShowState("Pending");
            booking.View.ShowStatusPage("Processing Booking");

            StaticFunctions.ProcessBooking(booking, ProcessingComplete, cancellationToken);
        }

        public void ProcessingComplete(BookingContext booking, ProcessingResult result)
        {
            switch (result)
            {
                case ProcessingResult.Sucess:
                    booking.TransitionToState(new BookedState());
                    break;
                case ProcessingResult.Fail:
                    booking.View.ShowProcessingError();
                    booking.TransitionToState(new NewState());
                    break;
                case ProcessingResult.Cancel:
                    booking.TransitionToState(new ClosedState("Processing Cancled"));
                    break;
            }
        }
    }    
}
