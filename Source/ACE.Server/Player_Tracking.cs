using System;
using System.Linq;
using ACE.Server.Network;

namespace ACE.Server.WorldObjects
{
    partial class Player
    {
        //TODO: Implement HWID
        /// <summary>
        /// Unique identifier for the connected player.
        /// </summary>
        public string ClientID => (Session?.EndPoint?.Address?.ToString()) ?? "UNKNOWN";
    }
}
