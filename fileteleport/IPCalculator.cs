
//Copyright 2019,2020 Jolan Aklin and Yohan Zbinden


//This file is part of FileTeleporter.

//FileTeleporter is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, version 3 of the License.

//FileTeleporter is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with FileTeleporter.  If not, see<https://www.gnu.org/licenses/>.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;

namespace fileteleport
{
    public static class IPCalculator
    {
        public static IPAddress CalculateBCAddress(IPAddress ip, IPAddress mask)
        {
            string[] ipPart = ip.ToString().Split('.');
            byte[] bIp = new byte[4];
            for (int i = 0; i < bIp.Length; i++)
            {
                bIp[i] = Convert.ToByte(Convert.ToInt32(ipPart[i]));
            }

            string[] maskPart = mask.ToString().Split('.');
            byte[] bMask = new byte[4];
            for (int i = 0; i < bMask.Length; i++)
            {
                bMask[i] = Convert.ToByte(Convert.ToInt32(maskPart[i]));
            }

            byte[] BCAddress = new byte[4];
            for (int i = 0; i < bMask.Length; i++)
            {
                BCAddress[i] = (byte)(bIp[i] | (bMask[i] ^ 255));
                //Console.WriteLine(BCAddress[i].ToString());
            }
            return new IPAddress(BCAddress);
        }


        /// <summary>
        /// Calculate the network ip
        /// </summary>
        /// <param name="ip">the machine ip</param>
        /// <param name="mask">his mask</param>
        /// <returns>the network ip in IPAddress</returns>
        public static IPAddress NetworkCalculator(IPAddress ip, IPAddress mask)
        {
            string[] ipPart = ip.ToString().Split('.');
            byte[] bIp = new byte[4];
            for (int i = 0; i < bIp.Length; i++)
            {
                bIp[i] = Convert.ToByte(Convert.ToInt32(ipPart[i]));
            }

            string[] maskPart = mask.ToString().Split('.');
            byte[] bMask = new byte[4];
            for (int i = 0; i < bMask.Length; i++)
            {
                bMask[i] = Convert.ToByte(Convert.ToInt32(maskPart[i]));
            }

            byte[] NetAddress = new byte[4];
            for (int i = 0; i < bMask.Length; i++)
            {
                NetAddress[i] = (byte)(bIp[i] & bMask[i]);
            }
            return new IPAddress(NetAddress);
        }
    }
}
