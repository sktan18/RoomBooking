﻿using RoomBooking.Core.Logic;

namespace RoomBooking.Core.RoomStatuses
{
    public class BaseStatus
    {
        private Room _room;

        public BaseStatus(Room room)
        {
            _room = room;
        }
    }
}
