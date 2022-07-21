using RoomBooking.Core.Interface;
using RoomBooking.Core.RoomStatuses;

namespace RoomBooking.Core.Logic
{
    public class Room
    {
        private string _name;
        private IStatus _status;
        private int _roomPriority;

        public Room (string name, int roomPriority)
        {
            _name = name;
            _status = new AvailableStatus(this);
            _roomPriority = roomPriority;   
        }

        public bool CheckinRoom()
        {
            if (_status.CheckinRoom())
            {
                return true;
            }
            return false;
        }

        public bool CheckoutRoom()
        {
            if (_status.CheckoutRoom())
            {
                return true;
            }
            return false;
        }

        public bool CleanRoom()
        {
            if (_status.CleanRoom())
            {
                return true;
            }
            return false;
        }

        public bool RepairRoom()
        {
            if (_status.RepairRoom())
            {
                return true;
            }
            return false;
        }

        internal void ChangeRoomStatus(IStatus status)
        {
            this._status = status;
        }

        public int Priority()
        {
            return _roomPriority;
        }
    }
}
