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
            throw new NotImplementedException();
        }

        public bool CheckoutRoom()
        {
            throw new NotImplementedException();
        }

        public bool CleanRoom()
        {
            throw new NotImplementedException();
        }

        public bool RepairRoom()
        {
            throw new NotImplementedException();
        }
    }
}
