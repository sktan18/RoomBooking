using RoomBooking.Core.Interface;
using RoomBooking.Core.Logic;

namespace RoomBooking.Core.RoomStatuses
{
    public class OccupiedStatus : BaseStatus, IStatus
    {
        public OccupiedStatus(Room room) : base(room)
        {
        }

        public bool CheckinRoom()
        {
            return false;
        }

        public bool CheckoutRoom()
        {
            this._room.ChangeRoomStatus(new VacantStatus(this._room));
            return true;
        }

        public bool CleanRoom()
        {
            return false;
        }

        public bool RepairRoom()
        {
            return false;
        }

        public bool RoomRepaired()
        {
            return false;
        }
    }
}
