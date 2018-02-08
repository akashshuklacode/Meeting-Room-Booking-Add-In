using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Meeting_Room_Booking_Add_In
{
    [System.ComponentModel.ToolboxItemAttribute(false)]
    partial class RoomSelectionGui : Microsoft.Office.Tools.Outlook.FormRegionBase
    {

//Custom Behaviour
//---------------------------------------------------------------------------------------------------------------------

        //Declaration of static properties
        public static Model planData;
        public static List<Floor> floors;
        public static List<string> floorNames;
        public static List<Room> rooms;
        public static List<Button> buttons;

        //Entry Point for Execution
        public RoomSelectionGui(Microsoft.Office.Interop.Outlook.FormRegion formRegion)
            : base(Globals.Factory, formRegion)
        {
            //Load all graphic components
            this.InitializeComponent();

            //Deserialize the json file to fill up entries
            this.PopulateData();
        }

        private void PopulateData()
        {
            //Deserialize Plan Json data to populate planData
            planData = Newtonsoft.Json.JsonConvert.DeserializeObject<Model>("{'floors':[{'Name':'Ground Floor','rooms':[{'Id':'1', 'Name':'1st Room', 'locationX':'0', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'},{'Id':'1', 'Name':'2nd Room', 'locationX':'10', 'locationY':'10', 'sizeX':'10', 'sizeY':'10'}]},{'Name':'1st Floor','rooms':[{'Id':'1', 'Name':'1st Room', 'locationX':'0', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'},{'Id':'2', 'Name':'2nd Room', 'locationX':'10', 'locationY':'10', 'sizeX':'10', 'sizeY':'10'},{'Id':'3', 'Name':'3rd Room', 'locationX':'20', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}]}]}");

            //populate floors' list
            floors = new List<Floor>();
            for(int index=0;index<planData.floors.Count;index++)
            {
                floors.Add(planData.floors[index]);
            }

            //populate floors name's list
            floorNames = new List<string>();
            for(int index=0;index<planData.floors.Count;index++)
            {
                floorNames.Add(planData.floors[index].Name);
            }

            
            //assign data source of floor combobox with floor name's list
            this.FloorListComboBox.DataSource = floorNames;
            //assign event handler for floor list combobox selected index change
            this.FloorListComboBox.SelectedIndexChanged += new System.EventHandler(FloorListComboBoxSelectionChanged);

            //populate panel with selected floor
            //default floor is Ground Floor (0)
            populateRoomPanel(0);
        }

        private void populateRoomPanel(int floorIndex)
        {
            //clear the room's panel
            this.panelRooms.Controls.Clear();

            //get the lis of rooms for the selected floor
            rooms = new List<Room>();
            for(int index=0;index<planData.floors[floorIndex].rooms.Count;index++)
            {
                rooms.Add(planData.floors[floorIndex].rooms[index]);
            }

            //create the button list
            buttons = new List<Button>();

            //add new button object to the buttons list
            for(int i=0;i<planData.floors[floorIndex].rooms.Count;i++)
            {
                buttons.Add(new Button());
            }

            //for each room's button resize and reposition the button
            for (int i = 0; i < buttons.Count; i++)
            {
                //add the button to the panel
                panelRooms.Controls.Add(buttons[i]);
                //populate each button
                int scale = 10;
                buttons[i].Location = new System.Drawing.Point(rooms[i].locationX*scale,rooms[i].locationY*scale);
                buttons[i].Size = new System.Drawing.Size(rooms[i].sizeX * scale, rooms[i].sizeY * scale);
                buttons[i].Name = rooms[i].Name;
                buttons[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                buttons[i].BackColor = System.Drawing.Color.DarkGray;
                //assing an action for button click
                //generic for all buttons
                buttons[i].Click += new System.EventHandler(ThisAddIn.buttonClick);
            }
        }

        //Event handler for floor selection changed from dropdown
        private void FloorListComboBoxSelectionChanged(object sender, EventArgs e)
        {
            //populate the panel with the information of selected floor respectively
            populateRoomPanel(this.FloorListComboBox.SelectedIndex);
        }
//-------------------------------------------------------------------------------------------------------------------


        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FloorListComboBox = new System.Windows.Forms.ComboBox();
            this.panelRooms = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // FloorListComboBox
            // 
            this.FloorListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FloorListComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FloorListComboBox.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FloorListComboBox.FormattingEnabled = true;
            this.FloorListComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FloorListComboBox.Location = new System.Drawing.Point(20, 20);
            this.FloorListComboBox.Name = "FloorListComboBox";
            this.FloorListComboBox.Size = new System.Drawing.Size(220, 26);
            this.FloorListComboBox.TabIndex = 0;
            // 
            // panelRooms
            // 
            this.panelRooms.Location = new System.Drawing.Point(20, 70);
            this.panelRooms.Name = "panelRooms";
            this.panelRooms.Size = new System.Drawing.Size(1064, 628);
            this.panelRooms.TabIndex = 1;
            // 
            // RoomSelectionGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRooms);
            this.Controls.Add(this.FloorListComboBox);
            this.Name = "RoomSelectionGui";
            this.Size = new System.Drawing.Size(1460, 753);
            this.FormRegionShowing += new System.EventHandler(this.RoomSelectionGui_FormRegionShowing);
            this.FormRegionClosed += new System.EventHandler(this.RoomSelectionGui_FormRegionClosed);
            this.ResumeLayout(false);

        }

        #endregion

        #region Form Region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private static void InitializeManifest(Microsoft.Office.Tools.Outlook.FormRegionManifest manifest, Microsoft.Office.Tools.Outlook.Factory factory)
        {
            manifest.FormRegionName = "Select Room";
            manifest.ShowReadingPane = false;

        }

        #endregion

        private System.Windows.Forms.ComboBox FloorListComboBox;
        private System.Windows.Forms.Panel panelRooms;

        public partial class RoomSelectionGuiFactory : Microsoft.Office.Tools.Outlook.IFormRegionFactory
        {
            public event Microsoft.Office.Tools.Outlook.FormRegionInitializingEventHandler FormRegionInitializing;

            private Microsoft.Office.Tools.Outlook.FormRegionManifest _Manifest;

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public RoomSelectionGuiFactory()
            {
                this._Manifest = Globals.Factory.CreateFormRegionManifest();
                RoomSelectionGui.InitializeManifest(this._Manifest, Globals.Factory);
                this.FormRegionInitializing += new Microsoft.Office.Tools.Outlook.FormRegionInitializingEventHandler(this.RoomSelectionGuiFactory_FormRegionInitializing);
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public Microsoft.Office.Tools.Outlook.FormRegionManifest Manifest
            {
                get
                {
                    return this._Manifest;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            Microsoft.Office.Tools.Outlook.IFormRegion Microsoft.Office.Tools.Outlook.IFormRegionFactory.CreateFormRegion(Microsoft.Office.Interop.Outlook.FormRegion formRegion)
            {
                RoomSelectionGui form = new RoomSelectionGui(formRegion);
                form.Factory = this;
                return form;
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            byte[] Microsoft.Office.Tools.Outlook.IFormRegionFactory.GetFormRegionStorage(object outlookItem, Microsoft.Office.Interop.Outlook.OlFormRegionMode formRegionMode, Microsoft.Office.Interop.Outlook.OlFormRegionSize formRegionSize)
            {
                throw new System.NotSupportedException();
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            bool Microsoft.Office.Tools.Outlook.IFormRegionFactory.IsDisplayedForItem(object outlookItem, Microsoft.Office.Interop.Outlook.OlFormRegionMode formRegionMode, Microsoft.Office.Interop.Outlook.OlFormRegionSize formRegionSize)
            {
                if (this.FormRegionInitializing != null)
                {
                    Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs cancelArgs = Globals.Factory.CreateFormRegionInitializingEventArgs(outlookItem, formRegionMode, formRegionSize, false);
                    this.FormRegionInitializing(this, cancelArgs);
                    return !cancelArgs.Cancel;
                }
                else
                {
                    return true;
                }
            }

            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            Microsoft.Office.Tools.Outlook.FormRegionKindConstants Microsoft.Office.Tools.Outlook.IFormRegionFactory.Kind
            {
                get
                {
                    return Microsoft.Office.Tools.Outlook.FormRegionKindConstants.WindowsForms;
                }
            }
        }
    }

    partial class WindowFormRegionCollection
    {
        internal RoomSelectionGui RoomSelectionGui
        {
            get
            {
                foreach (var item in this)
                {
                    if (item.GetType() == typeof(RoomSelectionGui))
                        return (RoomSelectionGui)item;
                }
                return null;
            }
        }
    }
}
