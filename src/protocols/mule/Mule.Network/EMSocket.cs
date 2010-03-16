#region File Header

//
//  Copyright (C) 2008 Jingnan Si
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
//
//
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Mule.Network
{
    //public class StandardPacketQueueEntry
    //{
    //    public StandardPacketQueueEntry(Packet packet,uint size)
    //    {
    //        Packet = packet;
    //        ActualPayloadSize = size;
    //    }

    //    public uint ActualPayloadSize
    //    {
    //        get;
    //        set;
    //    }

    //    public Packet Packet
    //    {
    //        get;
    //        set;
    //    }
    //};
    public struct StandardPacketQueueEntry
    {
        public StandardPacketQueueEntry(Packet packet, uint size)
        {
            Packet = packet;
            ActualPayloadSize = size;
        }

        public uint ActualPayloadSize;

        public Packet Packet;
    };

    public interface EMSocket : EncryptedStreamSocket, ThrottledFileSocket
    {
        void SendPacket(Packet packet, bool delpacket, bool controlpacket, uint actualPayloadSize, bool bForceImmediateSend);
        bool IsConnected { get; }
        byte ConnectionState { get; }
        bool IsRawDataMode { get; }
        uint DownloadLimit { get; set; }
        bool EnableDownloadLimit { get; set; }

        uint TimeOut { get; set;}

        bool Connect(string lpszHostAddress, uint nHostPort);

        void InitProxySupport();
        void RemoveAllLayers();
        string LastProxyError { get; }
        bool ProxyConnectFailed { get; }

        string GetFullErrorMessage(uint dwError);

        ulong GetSentBytesCompleteFileSinceLastCallAndReset();
        ulong GetSentBytesPartFileSinceLastCallAndReset();
        ulong GetSentBytesControlPacketSinceLastCallAndReset();
        ulong GetSentPayloadSinceLastCallAndReset();
        void TruncateQueues();

        void CleanUp();

    }
}
