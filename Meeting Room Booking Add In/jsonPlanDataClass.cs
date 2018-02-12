using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting_Room_Booking_Add_In
{
    class jsonPlanDataClass
    {
        public static string jsonPlanData = "{" +
            "'floors':[" +
            "{'Name':'Ground Floor'," +
            "'rooms':[" +
            "{'Id':'cr-NBLR-1.9.3018@netapp.com', 'Name':'1st Room', 'locationX':'0', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}," +
            "{'Id':'cr-NBLR-1.9.3019@netapp.com', 'Name':'2nd Room', 'locationX':'10', 'locationY':'10', 'sizeX':'10', 'sizeY':'10'}" +
            "]" +
            "}," +
            "{'Name':'1st Floor'," +
            "'rooms':[" +
            "{'Id':'1', 'Name':'1st Room', 'locationX':'0', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}," +
            "{'Id':'2', 'Name':'2nd Room', 'locationX':'10', 'locationY':'10', 'sizeX':'10', 'sizeY':'10'}," +
            "{'Id':'3', 'Name':'3rd Room', 'locationX':'20', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}" +
            "]" +
            "}" +
            "]" +
            "}";
    }
}
