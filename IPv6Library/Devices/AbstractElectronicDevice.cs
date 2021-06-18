using System.Collections.Generic;

namespace IPv6Library.Devices
{
    public abstract class AbstractElectronicDevice
    {
        private int _id;
        public int Id { get=>_id; set=>_id=value; }
        
        private AbstractCable[] _cables;
        public AbstractCable[] Cables { get => _cables;set => _cables = value;}

        protected AbstractElectronicDevice(AbstractCable[] cables, int id)
        {
           _cables = cables;
        }
        
    }
}