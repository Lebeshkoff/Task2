﻿using CargoTransportLib.Cargos;

namespace CargoTransportLib.Trailers
{
    interface IChilled
    {
        public int Temperature { get; set; }

        public GoodsType Type { get; set; }
    }
}
