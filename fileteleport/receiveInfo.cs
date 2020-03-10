
//Copyright 2019 Jolan Aklin and Yohan Zbinden


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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace fileteleport
{
    public static class receiveInfo
    {
        private static Form1 mainForm;
        public static List<string> allPcName = new List<string>();
        public static List<IPAddress> allIPOfTransfer = new List<IPAddress>();
        private static UdpClient udpClient;
        private static int PORT;
        private static IPEndPoint from;
        public static void send(UdpClient udpClientLocal, int PORTLocal, IPEndPoint fromLocal, Form1 mainFormRef)
        {
            udpClient = udpClientLocal;
            PORT = PORTLocal;
            from = fromLocal;
            mainForm = mainFormRef;
            IPAddress[] allNetworkIp = GetAllNetworkIPOfPc();
            string pcName = System.Environment.MachineName;
            IPAddress[] myIps = InterfaceFinder.FindIPAddress().ToArray();
            IPAddress[] subnetMasks = GetAllSubnetMask();
            string strMessageToSend = "";
            strMessageToSend += pcName + ";";
            List<List<IPAddress>> ipsAndMasks = InterfaceFinder.Find();
            for (var i = 0; i < myIps.Length; i++)
            {
                strMessageToSend += ipsAndMasks[i][0].ToString() + ";" + ipsAndMasks[i][1].ToString();
                if (i != myIps.Length - 1)
                {
                    strMessageToSend += ";";
                }
            }
            var toSend = Encoding.UTF8.GetBytes(strMessageToSend);

            bool meAsSend = false;
            /*string pcName = Environment.MachineName;
            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            string strMessageToSend = "";
            strMessageToSend += pcName + ";";
            for (var i = 0; i < allLocalIp.Length; i++)
            {
                strMessageToSend += allLocalIp[i].ToString() + ";" + allLocalSubnet[i];
                if (i != myIps.Length - 1)
                {
                    strMessageToSend += ";";
                }

            }
            byte[] toSend = Encoding.UTF8.GetBytes(strMessageToSend);*/
            var data = Encoding.UTF8.GetBytes("connected" + ";" + Environment.MachineName);
            foreach (var ipAndMask in InterfaceFinder.Find())
            {
                udpClient.Send(data, data.Length, IPCalculator.CalculateBCAddress(ipAndMask[0],ipAndMask[1]).ToString(), PORT);
                Thread.Sleep(100);
                udpClient.Send(toSend, toSend.Length, IPCalculator.CalculateBCAddress(ipAndMask[0], ipAndMask[1]).ToString(), PORT);
            }
            Console.WriteLine("[send] => " + Encoding.UTF8.GetString(data));
            while (true)
            {
                var recvBuffer = udpClient.Receive(ref from);
                string recvMessage = Encoding.UTF8.GetString(recvBuffer);
                //if the programm receive info about antoher pc
                if (recvMessage.Split(';')[0] != Environment.MachineName && !(recvMessage.Split(';')[0] == "connected" || recvMessage.Split(';')[0] == "disconnected"))
                {
                    Console.WriteLine("[receive] => " + Encoding.UTF8.GetString(recvBuffer));
                    string strResult = Encoding.UTF8.GetString(recvBuffer);
                    string[] eachIp = strResult.Split(';');
                    if (eachIp.Length != 0)
                    {
                        IPAddress[] reiceivedNetworks = new IPAddress[(eachIp.Length - 1) / 2];
                        IPAddress[] ipAddreses = new IPAddress[(eachIp.Length - 1) / 2];
                        string otherPcName = eachIp[0];
                        for (int r = 1; r < eachIp.Length; r += 2)
                        {
                            IPAddress IP = IPAddress.Parse(eachIp[r]);
                            IPAddress subnetMask = IPAddress.Parse(eachIp[r + 1]);
                            ipAddreses[(r - 1) / 2] = IP;
                            Console.WriteLine(GetNetworkIP(IP, subnetMask));
                            reiceivedNetworks[(r - 1) / 2] = GetNetworkIP(IP, subnetMask);
                        }
                        List<int> whichIp = new List<int>();
                        int i = 0;
                        while (i < reiceivedNetworks.Length)
                        {
                            for (var g = 0; g < allNetworkIp.Length; g++)
                            {
                                if (reiceivedNetworks[i].Equals(allNetworkIp[g]))
                                {
                                    whichIp.Add(i);
                                    break;
                                }
                            }
                            i++;
                        }
                        Console.WriteLine(whichIp);
                        if (whichIp.Count > 0)
                        {
                            int g = 0;
                            while (g < whichIp.Count)
                            {
                                if (PingHost(ipAddreses[g].ToString()))
                                {
                                    bool write = true;
                                    for (int j = 0; j < allPcName.Count; j++)
                                    {
                                        if (allPcName[j] == otherPcName)
                                        {
                                            //Console.WriteLine(allPcName[j] + " == " + otherPcName + " | " + allIPOfTransfer[j] + " == " + ipAddreses[g]);
                                            write = false;
                                            break;
                                        }
                                    }
                                    if (write)
                                    {
                                        Console.WriteLine("pc name: " + otherPcName);
                                        allPcName.Add(otherPcName);
                                        Console.WriteLine("ip: " + ipAddreses[g]);
                                        allIPOfTransfer.Add(ipAddreses[g]);
                                        mainForm.ShowPcInvoke(new Machine(otherPcName, ipAddreses[g], mainForm));
                                    }
                                    break;
                                }
                                g++;
                            }
                        }
                    }
                }
                else
                {
                    string strPc = recvMessage.Split(';')[1];
                    string strStatus = recvMessage.Split(';')[0];
                    if (strPc != pcName)
                    {
                        if (strStatus == "connected")
                        {                            
                            Console.WriteLine("[receive] => " + recvMessage);
                            Thread.Sleep(100);
                            Console.WriteLine("[send] => " + Encoding.UTF8.GetString(toSend));
                            foreach (var ipAndMask in InterfaceFinder.Find())
                            {
                                udpClient.Send(toSend, toSend.Length, IPCalculator.CalculateBCAddress(ipAndMask[0], ipAndMask[1]).ToString(), PORT);
                            }
                        }
                        else if (strStatus == "disconnected")
                        {
                            allIPOfTransfer.RemoveAt(allPcName.IndexOf(strPc));
                            allPcName.Remove(strPc);
                            mainForm.invokeDeleteMachine(strPc);
                        }
                    }
                }
            }
        }
        public static void disconnect()
        {
            var data = Encoding.UTF8.GetBytes("disconnected" + ";" + Environment.MachineName);
            Console.WriteLine("[send] => " + "disconnected" + ";" + Environment.MachineName);
            foreach (var ipAndMask in InterfaceFinder.Find())
            {
                udpClient.Send(data, data.Length, IPCalculator.CalculateBCAddress(ipAndMask[0], ipAndMask[1]).ToString(), PORT);

            }
        }
        /// <summary>
        /// get the network ip of an IP and a subnet mask
        /// </summary>
        /// <param name="IP">IP in the network</param>
        /// <param name="SubnetMask">subnet mask of the network</param>
        /// <returns>network IP address</returns>
        public static IPAddress GetNetworkIP(IPAddress IP, IPAddress SubnetMask)
        {
            byte[] byteOfIP = IP.GetAddressBytes();
            byte[] byteOfSubnet = SubnetMask.GetAddressBytes();
            if (byteOfIP.Length != byteOfSubnet.Length)
            {
                throw new Exception("Error: ip and subnet mask are not of the same length");
            }
            byte[] networkAddress = new byte[byteOfIP.Length];
            for (int i = 0; i < byteOfIP.Length; i++)
            {
                networkAddress[i] = (byte)(byteOfIP[i] & (byteOfSubnet[i]));
            }
            return new IPAddress(networkAddress);
        }
        /// <summary>
        /// get all network ip of all interfaces of the local pc
        /// </summary>
        /// <returns>all netowrk ip</returns>
        public static IPAddress[] GetAllNetworkIPOfPc()
        {
            IPAddress[] myIps = InterfaceFinder.FindIPAddress().ToArray();
            IPAddress[] subnetMasks = GetAllSubnetMask();
            List<IPAddress> networkAddress = new List<IPAddress>();
            for (int i = 0; i < myIps.Length; i++)
            {
                networkAddress.Add(GetNetworkIP(myIps[i], subnetMasks[i]));
            }
            return networkAddress.ToArray();
        }
        public static IPAddress[] GetAllIps()
        {
            //based from https://stackoverflow.com/questions/9855230/how-do-i-get-the-network-interface-and-its-right-ipv4-address
            List<IPAddress> allIps = new List<IPAddress>();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    //Console.WriteLine(ni.Name);
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            allIps.Add(ip.Address);
                        }
                    }
                }
            }
            return allIps.ToArray();
        }
        public static IPAddress[] GetAllSubnetMask()
        {
            //based from https://stackoverflow.com/questions/9855230/how-do-i-get-the-network-interface-and-its-right-ipv4-address
            List<IPAddress> allSubnetMasks = new List<IPAddress>();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    //Console.WriteLine(ni.Name);
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            allSubnetMasks.Add(ip.IPv4Mask);
                        }
                    }
                }
            }
            return allSubnetMasks.ToArray();
        }
        public static bool IsInSameNetwork(IPAddress ip1, IPAddress subnet1, IPAddress ip2, IPAddress subnet2)
        {
            IPAddress network1 = GetNetworkIP(ip1, subnet1);
            IPAddress network2 = GetNetworkIP(ip2, subnet2);
            return network1.Equals(network2);
        }
        public static int WhereIsTrue(bool[] array)
        {
            int iWhereFirst = -1;
            int i = 0;
            while (iWhereFirst == -1 && i < array.Length - 1)
            {
                if (array[i])
                {
                    iWhereFirst = i;
                }
                i++;
            }
            return iWhereFirst;
        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }
    }
}
