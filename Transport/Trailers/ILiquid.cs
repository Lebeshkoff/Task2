using CargoTransportLib.Cargos;

namespace CargoTransportLib.Trailers
{
    /// <summary>
    /// Use for create tank types of trailer
    /// </summary>
    interface ILiquid
    {
        /// <summary>
        /// Liquid type
        /// </summary>
        public LiquidType Type { get; set; }
    }
}
