using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;
using System.Net;

namespace Trippindicular.Classes.Network
{
    class ClientNetworkManager : INetworkManager
    {
        NetClient netClient;
        
        public void Connect()
        {
            var config = new NetPeerConfiguration("Asteroid")
            {
                //SimulatedMinimumLatency = 0.2f, 
                //SimulatedLoss = 0.1f
            };
            config.EnableMessageType(NetIncomingMessageType.WarningMessage);
            config.EnableMessageType(NetIncomingMessageType.VerboseDebugMessage);
            config.EnableMessageType(NetIncomingMessageType.ErrorMessage);
            config.EnableMessageType(NetIncomingMessageType.Error);
            config.EnableMessageType(NetIncomingMessageType.DebugMessage);
            config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);

            this.netClient = new NetClient(config);
            this.netClient.Start();

            this.netClient.Connect(new IPEndPoint(NetUtility.Resolve("127.0.0.1"), Convert.ToInt32("14242")));
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
