﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace Meeting_Room_Booking_Add_In
{
    public partial class ThisAddIn
    {
        //Inspector represents the window in which an Outlook Item is displayed
        //This ispector field maintains a reference to the collection of Inspector windows in the current Outlook instance
        //This reference prevents the garbage collector from freeing the memory that contains the event handler for the
        //E:Microsoft.Office.Interop.Outlook.InspectorsEvents_Event.NewInspector event.
        Outlook.Inspectors inspectors;

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
            Outlook.AppointmentItem appointmentItem = Inspector.CurrentItem;
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
