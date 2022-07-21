using RoomBooking.Core.Logic;

namespace RoomBooking.Core.Interface
{
    public interface IStatus
    {
        public bool CheckinRoom();

        public bool CheckoutRoom();

        public bool CleanRoom();

        public bool RepairRoom();

    } 
}
