using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting_Room_Booking_Add_In
{
    class jsonPlanDataClass
    {
        public static string jsonPlanData = "" +
            "{" +
                "'floors':" +
                "[" +
                    "{'Name':' '," +
                        "'rooms':[{}]" +
                    "}," +
                    "{'Name':'9th Floor'," +
                       "'rooms':[" +
                                "{'Id':'cr-NBLR-1.9.3000@netapp.com', 'Name':'Blackbird', 'locationX':'0', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3001@netapp.com', 'Name':'Dove', 'locationX':'10', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3002@netapp.com', 'Name':'Eagle', 'locationX':'20', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3003@netapp.com', 'Name':'Hawk', 'locationX':'30', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3004@netapp.com', 'Name':'Hummingbird', 'locationX':'40', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3005@netapp.com', 'Name':'Ibis', 'locationX':'50', 'locationY':'5', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3006@netapp.com', 'Name':'Falcon', 'locationX':'50', 'locationY':'0', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3007@netapp.com', 'Name':'Kite', 'locationX':'65', 'locationY':'0', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3008@netapp.com', 'Name':'Magpie', 'locationX':'65', 'locationY':'5', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3009@netapp.com', 'Name':'Meadowlard', 'locationX':'70', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3010@netapp.com', 'Name':'Peacock', 'locationX':'80', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3011@netapp.com', 'Name':'Quail', 'locationX':'90', 'locationY':'5', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3012@netapp.com', 'Name':'Pigeon', 'locationX':'90', 'locationY':'0', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3014@netapp.com', 'Name':'Crane', 'locationX':'105', 'locationY':'0', 'sizeX':'20', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3016@netapp.com', 'Name':'Swallow', 'locationX':'135', 'locationY':'5', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3017@netapp.com', 'Name':'Crossbil', 'locationX':'135', 'locationY':'0', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3018@netapp.com', 'Name':'Teal', 'locationX':'140', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3019@netapp.com', 'Name':'Bulbul', 'locationX':'150', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3020@netapp.com', 'Name':'Wagtail', 'locationX':'160', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3021@netapp.com', 'Name':'Lark', 'locationX':'170', 'locationY':'0', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3022@netapp.com', 'Name':'Siskin', 'locationX':'140', 'locationY':'40', 'sizeX':'25', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3023@netapp.com', 'Name':'Wren', 'locationX':'135', 'locationY':'45', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3024@netapp.com', 'Name':'Swan', 'locationX':'135', 'locationY':'40', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3026@netapp.com', 'Name':'Turnstone', 'locationX':'115', 'locationY':'40', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3027@netapp.com', 'Name':'Tern', 'locationX':'105', 'locationY':'40', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3029@netapp.com', 'Name':'Redstart', 'locationX':'90', 'locationY':'40', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3030@netapp.com', 'Name':'Sandpiper', 'locationX':'90', 'locationY':'45', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3031@netapp.com', 'Name':'Raven', 'locationX':'70', 'locationY':'40', 'sizeX':'20', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3032@netapp.com', 'Name':'Pelican', 'locationX':'65', 'locationY':'40', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3033@netapp.com', 'Name':'Pewee', 'locationX':'65', 'locationY':'45', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3034@netapp.com', 'Name':'Petrel', 'locationX':'50', 'locationY':'45', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3035@netapp.com', 'Name':'Owl', 'locationX':'50', 'locationY':'40', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3036@netapp.com', 'Name':'Kingbird', 'locationX':'40', 'locationY':'40', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3037@netapp.com', 'Name':'Jay', 'locationX':'30', 'locationY':'40', 'sizeX':'10', 'sizeY':'10'}," +
                                "{'Id':'cr-NBLR-1.9.3038@netapp.com', 'Name':'Kingfisher', 'locationX':'25', 'locationY':'40', 'sizeX':'5', 'sizeY':'5'}," +
                                "{'Id':'cr-NBLR-1.9.3039@netapp.com', 'Name':'Sparrow', 'locationX':'25', 'locationY':'45', 'sizeX':'5', 'sizeY':'5'}" +
                                "]" +
                    "}" +
               "]" +
           "}";
    }
}
