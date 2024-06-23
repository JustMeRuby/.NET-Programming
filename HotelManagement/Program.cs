using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainData;

namespace HotelManagement
{
    class Program
    {
        static void UpdateNumberOfRooms(Hotel hotel)
        {
            hotel.ValNumberOfRooms = hotel.Rooms.Count;
        }
        static void Main(string[] args)
        {
            Hotel hotel = new Hotel("Sneaky Hotel");

            hotel.HotelAddOrRemoveEvent += new Hotel.HotelHandler(UpdateNumberOfRooms);

            //hotel.Rooms.Add(new Room("R001", 1, ConditionType.Standard, BedType.SingleBedRoom));
            //hotel.Rooms.Add(new Room("R002", 2, ConditionType.Superior, BedType.DoubleBedRoom));
            //hotel.Rooms.Add(new Room("R004", 4, ConditionType.Suite, BedType.ExtraBedRoom));
            //hotel.HotelInfo();

            //Console.WriteLine("Room Searching ..................\n");
            //hotel.SearchRoom("R001").RoomInfo();
            //hotel.SearchRoom("R003").RoomInfo();
            //hotel.SearchRoom(0).RoomInfo();
            //hotel.SearchRoom(10).RoomInfo();

            //Console.WriteLine("Room Searching ..................\n");
            //Console.WriteLine(hotel.SearchRoom("R001").ConvertToString());
            //Console.WriteLine(hotel.SearchRoom("R003").ConvertToString());
            //Console.WriteLine(hotel.SearchRoom(0).ConvertToString());
            //Console.WriteLine(hotel.SearchRoom(10).ConvertToString());

            hotel.AddRoom(new Room("R001", 1, ConditionType.Standard, BedType.SingleBedRoom));
            hotel.AddRoom(new Room("R002", 2, ConditionType.Superior, BedType.DoubleBedRoom));
            hotel.AddRoom(new Room("R004", 4, ConditionType.Suite, BedType.ExtraBedRoom));
            hotel.HotelInfo();
            Room room = hotel.SearchRoom("R001");
            hotel.RemoveRoom(room);
            hotel.HotelInfo();

            Console.ReadKey();
        }
    }
}

namespace MainData
{
    public enum ConditionType { Standard, Superior, Deluxe, Suite}
    public enum BedType { ConnectingRoom, SingleBedRoom, TwinBedRoom, DoubleBedRoom, TripleBedRoom, ExtraBedRoom}
    public class Room
    {
        private string RoomID;
        private int Capacity;
        ConditionType condition;
        BedType bedtype;

        public Room(string RoomID = "Not assigned", int Capacity = 0,
                    ConditionType condition = ConditionType.Standard, BedType bedtype = BedType.SingleBedRoom)
        {
            this.RoomID = RoomID;
            this.Capacity = Capacity;
            this.condition = condition;
            this.bedtype = bedtype;
        }

        public string ValRoomID
        {
            get { return RoomID; }
            set { RoomID = value; }
        }
        public int ValCapacity
        {
            get { return Capacity; }
            set { Capacity = value; }
        }
        public ConditionType Valcondition
        {
            get { return condition; }
            set { condition = value; }
        }
        public BedType Valbedtype
        {
            get { return bedtype; }
            set { bedtype = value; }
        }

        public void RoomInfo()
        {
            string conditionName = Enum.GetName(typeof(ConditionType), condition);
            string bedtypeName = Enum.GetName(typeof(BedType), bedtype);

            Console.WriteLine("Displaying Room Info ..................\n------------");
            Console.WriteLine("Room ID: {0}", RoomID);
            Console.WriteLine("Condition: {0}", conditionName);
            Console.WriteLine("Bed Type: {0}", bedtypeName);
        }
    }
    public class Hotel
    {
        public List<Room> Rooms { get; set; }
        string Name;
        Dictionary<ConditionType, string> conditioninfo = new Dictionary<ConditionType, string>();
        public delegate void HotelHandler(Hotel hotel);
        public event HotelHandler HotelAddOrRemoveEvent;
        int NumberOfRooms = 0;

        public Hotel(string Name = "Not assigned")
        {
            Rooms = new List<Room>();
            this.Name = Name;
            conditioninfo.Add(ConditionType.Standard, "Stardard Rooms have the lowest quality and price");
            conditioninfo.Add(ConditionType.Superior, "Superior Rooms are bigger or have good view");
            conditioninfo.Add(ConditionType.Deluxe, "Deluxe Rooms have high quality, are usually placed on higher floors");
            conditioninfo.Add(ConditionType.Suite, "Suite Rooms offer special services, are placed on the highest floor");
        }

        public string ValName
        {
            get { return Name; }
            set { Name = value; }
        }
        public int ValNumberOfRooms
        {
            get { return NumberOfRooms; }
            set { NumberOfRooms = value; }
        }

        public void OnHotelChanger(Hotel hotel)
        {
            if (HotelAddOrRemoveEvent != null)
            {
                HotelAddOrRemoveEvent(this);
            }
        }
        public void AddRoom(Room room)
        {
            Rooms.Add(room);
            OnHotelChanger(this);
        }
        public void RemoveRoom(Room room)
        {
            Rooms.Remove(room);
            OnHotelChanger(this);
        }

        public void HotelInfo()
        {
            Console.WriteLine("Displaying Hotel Info ..................\n------------");
            Console.WriteLine("Hotel Name: {0}", Name);
            Console.WriteLine("Number of Rooms: {0}, icluding:\n", NumberOfRooms);
            foreach(Room room in Rooms)
            {
                KeyValuePair<ConditionType, string> info = conditioninfo.FirstOrDefault(o => o.Key == room.Valcondition);
                room.RoomInfo();
                Console.WriteLine("---{0}---", info.Value);
                Console.WriteLine("------------------------------");
            }
            Console.WriteLine();
        }

        public Room SearchRoom<T>(T search)
        {
            Room r = new Room();
            if (typeof(T) == typeof(string))
            {
                r = Rooms.FirstOrDefault(o => o.ValRoomID == search.ToString());
                if (r != null) { return r; }
            }
            else if (typeof(T) == typeof(int))
            {
                if(Convert.ToInt32(search) < Rooms.Count)
                {
                    return Rooms[Convert.ToInt32(search)];
                }
            }
            Console.WriteLine("404 Not Found");
            return new Room();
        }
    }
    public static class MyExtensions
    {
        public static string ConvertToString(this Room room)
        {
            string conditionName = Enum.GetName(typeof(ConditionType), room.Valcondition);
            string bedtypeName = Enum.GetName(typeof(BedType), room.Valbedtype);

            if (room.ValRoomID != "Not assigned")
            {
                return String.Format("Room ID: {0} - {1} - {2} for {3} people",
                                    room.ValRoomID, room.Valcondition, room.Valbedtype, room.ValCapacity);
            }
            else return "";
        }
    }

}