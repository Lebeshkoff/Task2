using CargoTransportLib.Cargos;

namespace CargoTransportLib.Trailers
{
    /// <summary>
    /// USe for create regrigerator types of trailer
    /// </summary>
    interface IChilled
    {
        /// <summary>
        /// Temperature in trailer
        /// </summary>
        public int Temperature { get; set; }
        /// <summary>
        /// Type of solid goods
        /// </summary>
        public GoodsType Type { get; set; }
    }
}
