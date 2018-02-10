using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Exchange.WebServices.Data;

namespace Meeting_Room_Booking_Add_In
{

    //Defining the data model
    public class Model
    {
        public List<Floor> floors { get; set; }
    }

    public class Floor
    {
        public string Name { get; set; }
        public List<Room> rooms { get; set; }
    }

    public class Room
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int locationX { get; set; }
        public int locationY { get; set; }
        public int sizeX { get; set; }
        public int sizeY { get; set; }
    }


    public partial class ThisAddIn
    {
        //Inspector represents the window in which an Outlook Item is displayed
        //This ispector field maintains a reference to the collection of Inspector windows in the current Outlook instance
        //This reference prevents the garbage collector from freeing the memory that contains the event handler for the
        //E:Microsoft.Office.Interop.Outlook.InspectorsEvents_Event.NewInspector event.
        Outlook.Inspectors inspectors;
        static Outlook.AppointmentItem appointmentItem;

        //Event Handler ThisAddIn_Startup runs as soon as the add-in is clicked
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //Attach an event handler to the new inspector event
            inspectors = this.Application.Inspectors;
            inspectors.NewInspector += Inspectors_NewInspector;
        }

        //Deprecated. ThisAddIn_Shutdown runs as soon as the add-in is closed
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }


        //Method gets executed at the New Inspector event
        private void Inspectors_NewInspector(Outlook.Inspector Inspector)
        {
            //add a sample body text onto meeting item
            appointmentItem = Inspector.CurrentItem;
            if(appointmentItem != null)
            {
                //the EntryID property is not set for an Outlook item until it is saved or sent
                if (appointmentItem.EntryID==null)
                {
                    //append the body of the meeting item
                    appointmentItem.Body = "Meeting Room Booking Addin";
                }
            }
        }

        //Event handler for button click
        public static void buttonClick(object sender,EventArgs e)
        {
            //find the sender button
            var button = (System.Windows.Forms.Button)sender;
            //change button backcolor
            button.BackColor = System.Drawing.Color.Blue;

            //add the button to appointment attendees list
            appointmentItem.Recipients.Add(button.Name);
        }

        //Event handler for load free busy button click
        public static void loadFreeBusy(object sender, EventArgs e)
        {
            List<AttendeeInfo> attendees = new List<AttendeeInfo>();
            for (int i = 0; i < RoomSelectionGui.buttons.Count; i++)
            {
                RoomSelectionGui.buttons[i].BackColor = System.Drawing.Color.LightGoldenrodYellow;
                attendees.Add(RoomSelectionGui.buttons[i].Name);
            }

            ExchangeService exchangeService = new ExchangeService();
            exchangeService.UseDefaultCredentials = true;
            exchangeService.Url = new Uri("https://email.netapp.com/EWS/Exchange.asmx");
            AvailabilityOptions myOptions = new AvailabilityOptions();
            myOptions.MeetingDuration = appointmentItem.Duration;
            myOptions.RequestedFreeBusyView = FreeBusyViewType.Detailed;
            GetUserAvailabilityResults freeBusyResults = exchangeService.GetUserAvailability(attendees, new TimeWindow(appointmentItem.Start.Date, appointmentItem.Start.Date.AddDays(1)), AvailabilityData.FreeBusy, myOptions);


            //Check for each of the attendees availability
            for (int attendeeIndex = 0; attendeeIndex < freeBusyResults.AttendeesAvailability.Count; attendeeIndex++)
            {
                //Calendar events contains the count and the information for each attendee meetings
                foreach (CalendarEvent calenderItem in freeBusyResults.AttendeesAvailability[attendeeIndex].CalendarEvents)
                {
                    //if the attendee has a 'Busy' status at that time slot, mark red
                    //appointmentItem.Body += "Debug:\n"+"appointmentItem.Start:=" + appointmentItem.Start + "\n" + "calenderItem.StartTime:=" + calenderItem.StartTime + "\n" + "appointmentItem.End:=" + appointmentItem.End + "\n" + "calenderItem.EndTime:=" + calenderItem.EndTime + "\n" + "DateTime.Compare(appointmentItem.Start, calenderItem.StartTime) should be <=0:="+ DateTime.Compare(appointmentItem.Start, calenderItem.StartTime) + "\n" + "DateTime.Compare(appointmentItem.End, calenderItem.EndTime) should be <=0:=" + DateTime.Compare(appointmentItem.End, calenderItem.EndTime)+"\n";
                    if ((DateTime.Compare(appointmentItem.Start, calenderItem.StartTime) <= 0 && DateTime.Compare(appointmentItem.End, calenderItem.EndTime) >= 0)||(DateTime.Compare(appointmentItem.Start, calenderItem.StartTime) >= 0 && DateTime.Compare(appointmentItem.End, calenderItem.EndTime) <= 0))
                    {
                        //appointmentItem.Body += "Match!";
                        RoomSelectionGui.buttons[attendeeIndex].BackColor = System.Drawing.Color.OrangeRed;
                    }
                }
            }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
