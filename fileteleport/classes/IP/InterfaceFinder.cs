
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace fileteleport
{
    public static class InterfaceFinder
    {

        /// <summary>
        /// Find connected interface and their ip and mask
        /// </summary>
        /// <returns>A list of list which the first row is the ip and the second is the mask</returns>
        public static List<List<IPAddress>> Find()
        {
            List<List<IPAddress>> ipsAndMasks = new List<List<IPAddress>>();
            //Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if(item.Speed > 0)
                {
                    //Console.WriteLine("Found : " + item.Id);
                    if (item.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || item.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    {
                        //Console.WriteLine(ni.Name);
                        foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {                                                                
                                    ipsAndMasks.Add(new List<IPAddress>());
                                    ipsAndMasks[ipsAndMasks.Count - 1].Add(ip.Address);
                                    ipsAndMasks[ipsAndMasks.Count - 1].Add(ip.IPv4Mask);
                                    Console.WriteLine(ip.Address + " / " + ip.IPv4Mask);                                
                            }
                        }
                    }
                }
            }
            //Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            return ipsAndMasks;
        }

        /// <summary>
        /// Find connected interface and their ip and mask
        /// </summary>
        /// <returns>A list of ip address</returns>
        public static List<IPAddress> FindIPAddress()
        {
            List<IPAddress> ips = new List<IPAddress>();
            //Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.Speed > 0)
                {
                    //Console.WriteLine("Found : " + item.Id);
                    if (item.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || item.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    {
                        //Console.WriteLine(ni.Name);
                        foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                ips.Add(ip.Address);
                                //Console.WriteLine(ip.Address);
                            }
                        }
                    }
                }
            }
            //Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            return ips;
        }
        //private static List<string> FindConnectedAdapt()
        //{
        //    //Console.WriteLine("--------------------------------------------------------------------------------------------");
        //    var networks = NetworkListManager.GetNetworks(NetworkConnectivityLevels.Connected);
        //    List<string> netConAdaptId = new List<string>();

        //    foreach (Network network in networks)
        //    {
        //        //Name property corresponds to the name I originally asked about
        //        //Console.WriteLine("[" + network.Name + "]");

        //        //Console.WriteLine("\t[NetworkConnections]");
        //        foreach (NetworkConnection conn in network.Connections)
        //        {
        //            //Print network interface's GUID
        //            //Console.WriteLine("\t\t" + conn.AdapterId.ToString());
        //            netConAdaptId.Add(("{" + conn.AdapterId.ToString() + "}").ToUpper());
        //        }
        //    }
        //    return netConAdaptId;
        //}
    }
}
