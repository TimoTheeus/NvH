﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;

public interface INetworkManager : IDisposable
    {
        void Connect();
        void Disconnect();

        NetIncomingMessage ReadMessage();

        void Recycle(NetIncomingMessage im);

        NetOutgoingMessage CreateMessage();
    }
