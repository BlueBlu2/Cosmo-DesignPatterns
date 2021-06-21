using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CosmoStatePattern.BadEx.UI;

namespace CosmoStatePattern.BadEx.Logic
{
    public class Booking
    {
        private MainWindow View { get;  set; }
        public string Attendee { get; set; }
        public int TicketCount { get; set; }
        public int BookingID { get; set; }
        private bool IsNew;
        private bool IsPending;
        private bool IsBooked;

        private CancellationTokenSource cancelToken;
       
        public Booking(MainWindow view)
        {
            IsNew = true;
            View = view;
            BookingID = new Random().Next();
            ShowState("New");
            View.ShowEntryPage();
        }

        public void SubmitDetails(string attendee, int ticketCount)
        {
            if (IsNew)
            {
                IsPending = true;
                IsNew = false;
                Attendee = attendee;
                TicketCount = ticketCount;
                cancelToken = new CancellationTokenSource();
                StaticFunctions.ProcessBooking(this, ProcessingComplete, cancelToken);

                ShowState("Pending");
                View.ShowStatusPage("Processing Booking");
            }
        }

        public void Cancel()
        {
            if (IsNew == true)
            {
                ShowState("Closed");
                View.ShowStatusPage("Canceled By user");
                IsNew = false;
            }
            else if (IsPending)
            {
                cancelToken.Cancel();
            }
            else if (IsBooked)
            {
                ShowState("Closed");
                View.ShowStatusPage("Booking canceled: Expect a refund");
                IsBooked = false; 
            }
            else
            {
                View.ShowError("Closed Bookings Cannot Be Canceled");
            }
        }

        public void DatePassed()
        {
            if (IsNew == true)
            {
                ShowState("Closed");
                View.ShowStatusPage("Booking Expired");
                IsNew = false;
            }
            else if (IsBooked)
            {
                ShowState("Closed");
                View.ShowStatusPage("Wh hope you enjoyed the event");
                IsBooked = false;
            }
        }

        public void ProcessingComplete(Booking booking, ProcessingResult result)
        {
            IsPending = false;
            switch (result)
            {
                case ProcessingResult.Sucess:
                    IsBooked = true;
                    ShowState("Booked");
                    View.ShowStatusPage("Enjoy the Event");
                    break;
                case ProcessingResult.Fail:
                    View.ShowProcessingError();
                    Attendee = string.Empty;
                    BookingID = new Random().Next();
                    IsNew = true;
                    ShowState("New");
                    View.ShowEntryPage();
                    break;
                case ProcessingResult.Cancel:
                    ShowState("Closed");
                    View.ShowStatusPage("Processing Canceled");
                    break;
            }
        }

        public void ShowState(string stateName)
        {
            View.grdDetails.Visibility = System.Windows.Visibility.Visible;
            View.lblCurrentState.Content = stateName;
            View.lblTicketCount.Content = TicketCount;
            View.lblAttendee.Content = Attendee;
            View.lblBookingID.Content = BookingID;
        }

      

    }
}


