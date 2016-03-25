using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;

namespace Trippindicular.Classes.Network
{
    class ServerNetworkManager : INetworkManager
    {
        NetServer netServer;
        public void Connect()
        {
            var config = new NetPeerConfiguration("Asteroid")
            {
                Port = Convert.ToInt32("14242"),
                //SimulatedMinimumLatency = 0.2f, 
                //SimulatedLoss = 0.1f 
            };
            config.EnableMessageType(NetIncomingMessageType.WarningMessage);
            config.EnableMessageType(NetIncomingMessageType.VerboseDebugMessage);
            config.EnableMessageType(NetIncomingMessageType.ErrorMessage);
            config.EnableMessageType(NetIncomingMessageType.Error);
            config.EnableMessageType(NetIncomingMessageType.DebugMessage);
            config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
            netServer = new NetServer(config);
            netServer.Start();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public Lidgren.Network.NetIncomingMessage ReadMessage()
        {
            throw new NotImplementedException();
        }

        public void Recycle(Lidgren.Network.NetIncomingMessage im)
        {
            throw new NotImplementedException();
        }

        public Lidgren.Network.NetOutgoingMessage CreateMessage()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
