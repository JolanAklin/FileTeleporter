﻿
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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace fileteleport
{
    public static class MachineDiscoverer
    {
        private static Form1 mainForm;
        public static List<string> allPcName = new List<string>();
        public static List<IPAddress> allIPOfTransfer = new List<IPAddress>();
        private static UdpClient udpClient;
        private static int PORT;
        private static IPEndPoint from;
        private static int TCPResponse = 8765;

        /// <summary>
        /// Generate a CSV style string with an argument like connected,...
        /// 1st row : argument / 2nd : machine name and the rest : ip and mask
        /// </summary>
        /// <param name="argument">first row of the CSV file, can be connected, disconnected</param>
        /// <returns></returns>
        private static byte[] GetMachineAndIp(string argument)
        {
            IPAddress[] myIps = InterfaceFinder.FindIPAddress().ToArray();
            string strMessageToSend = argument + ";" + System.Environment.MachineName + ";";
            List<List<IPAddress>> ipsAndMasks = InterfaceFinder.Find();
            for (var i = 0; i < myIps.Length; i++)
            {
                strMessageToSend += ipsAndMasks[i][0].ToString() + ";" + ipsAndMasks[i][1].ToString();
                if (i != myIps.Length - 1)
                {
                    strMessageToSend += ";";
                }
            }
            return Encoding.UTF8.GetBytes(strMessageToSend);
        }

        public static void send(UdpClient udpClientLocal, int PORTLocal, IPEndPoint fromLocal, Form1 mainFormRef)
        {
            udpClient = udpClientLocal;
            PORT = PORTLocal;
            from = fromLocal;
            mainForm = mainFormRef;
            
            string pcName = System.Environment.MachineName;
            

            byte[] toSend = GetMachineAndIp("connected");

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
            Thread threadGetOtherPcIp = new Thread(() => ReceiveIpFromOtherMachine());
            threadGetOtherPcIp.IsBackground = true;
            threadGetOtherPcIp.Start();
            foreach (var ipAndMask in InterfaceFinder.Find())
            {
                try
                {
                    udpClient.Send(toSend, toSend.Length, IPCalculator.CalculateBCAddress(ipAndMask[0], ipAndMask[1]).ToString(), PORT);
                    Console.WriteLine("[send] => " + Encoding.UTF8.GetString(toSend) + " [throught] => broadcast (" + IPCalculator.CalculateBCAddress(ipAndMask[0], ipAndMask[1]).ToString() + ")");
                }
                catch(SocketException s)
                {

                }
            }                        
            while (true)
            {
                var recvBuffer = udpClient.Receive(ref from);
                string recvMessage = Encoding.UTF8.GetString(recvBuffer);
                //if the programm receive info about antoher pc

                string strStatus = recvMessage.Split(';')[0];
                string strPc = recvMessage.Split(';')[1];
                
                if (strPc != pcName)
                {
                    Console.WriteLine("[receive] => " + recvMessage + " [throught] => broadcast");
                    if (strStatus == "connected")
                    {
                        Thread.Sleep(100);
                        string broadcastersIP = FindMatchingNetwork(recvMessage);
                        Console.WriteLine("[send] => " + Encoding.UTF8.GetString(toSend) + " [to] => " + broadcastersIP.ToString());
                        IPSender(broadcastersIP.ToString());
                    }
                    else if (strStatus == "disconnected")
                    {
                        try
                        {
                            allIPOfTransfer.RemoveAt(allPcName.IndexOf(strPc));
                            allPcName.Remove(strPc);
                            mainForm.invokeDeleteMachine(strPc);
                        }catch
                        {

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
                try
                {
                    udpClient.Send(data, data.Length, IPCalculator.CalculateBCAddress(ipAndMask[0], ipAndMask[1]).ToString(), PORT);
                }
                catch (SocketException e)
                {                    
                }
            }
        }

        #region TCP sender and receiver for ips of the other computer
        private static void IPSender(string ipBroadcaster)
        {
            string ipOfBroadcaster = ipBroadcaster;
            IPAddress ipAddrBroadcaster = IPAddress.Parse(ipOfBroadcaster);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddrBroadcaster, TCPResponse);
            // Creation TCP/IP Socket using  
            // Socket Class Costructor 
            Socket sendSocket = new Socket(ipAddrBroadcaster.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Connect Socket to the remote  
            // endpoint using method Connect()
            sendSocket.Connect(localEndPoint);

            // We print EndPoint information  
            // that we are connected 
            Console.WriteLine("Socket connected to -> {0} ", sendSocket.RemoteEndPoint.ToString());
            //send some info in csv format (length of the file, file name with it's extension and the name of the pc)
            byte[] byteStringCSV = GetMachineAndIp("connected");
            List<byte> byteToSend = new List<byte>();
            byteToSend.AddRange(byteStringCSV);
            byteToSend.AddRange(Encoding.UTF8.GetBytes("<EOF>"));
            sendSocket.Send(byteToSend.ToArray());
            // Close Socket using  
            // the method Close()
            sendSocket.Shutdown(SocketShutdown.Both);
            sendSocket.Close();
        }
        private static void ReceiveIpFromOtherMachine()
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, TCPResponse);

            Socket listener = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Using Bind() method we associate a 
            // network address to the Server Socket 
            // All client that will connect to this  
            // Server Socket must know this network 
            // Address 
            listener.Bind(localEndPoint);

            // Using Listen() method we create  
            // the Client list that will want 
            // to connect to Server 
            listener.Listen(10);
            while (true)
            {
                //if (threadStop)
                //{
                //    Console.WriteLine("thread closed");
                //    break;
                //}
                // Suspend while waiting for 
                // incoming connection Using  
                // Accept() method the server  
                // will accept connection of client 
                Socket clientSocket = listener.Accept();

                //file info receiver
                byte[] bytes = new Byte[1024];
                string data;
                while (true)
                {
                    int numByte = clientSocket.Receive(bytes);
                    data = Encoding.UTF8.GetString(bytes, 0, numByte);
                    if (data.IndexOf("<EOF>") > -1)
                        break;
                }
                data = data.Split('<')[0];
                Console.WriteLine("[receive] => " + data + " [throught] => TCP socket");
                FindMatchingNetwork(data);
                // Close client Socket using the 
                // Close() method. After closing, 
                // we can use the closed Socket  
                // for a new Client Connection
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
        #endregion


        /// <summary>
        /// Find the ip which let the 2 pcs communicate to each other
        /// </summary>
        /// <param name="ipCsv">A CSV file that contain the state of the machine, his name and his ips and masks</param>
        /// <returns></returns>
        private static string FindMatchingNetwork(string ipCsv)
        {
            List<List<IPAddress>> ipsAndMasks = InterfaceFinder.Find();
            List<IPAddress> NetAddresses = new List<IPAddress>();
            List<IPAddress> otherMachineNetAddresses = new List<IPAddress>();
            for (int i = 0; i < ipsAndMasks.Count; i++)
            {
                NetAddresses.Add(IPCalculator.NetworkCalculator(ipsAndMasks[i][0], ipsAndMasks[i][1]));
            }
            string[] data = ipCsv.Split(';');
            string otherPcName = data[1];
            bool findNetIp = false;
            IPAddress foundedNetIp = IPAddress.Any;
            for (int i = 2; i < data.Length; i+=2)
            {
                IPAddress NetIp = IPCalculator.NetworkCalculator(IPAddress.Parse(data[i]), IPAddress.Parse(data[i + 1]));
                for (int j = 0; j < NetAddresses.Count; j++)
                {
                    if (NetIp.Equals(NetAddresses[j]))
                    {
                        findNetIp = true;
                        foundedNetIp = IPAddress.Parse(data[i]);
                        break;
                    }
                    if (findNetIp)
                        break;
                }
            }
            
            bool write = true;
            for (int j = 0; j < allPcName.Count; j++)
            {
                if (allPcName[j] == otherPcName)
                {
                    //Console.WriteLine(allPcName[j] + " == " + otherPcName + " | " + allIPOfTransfer[j] + " == " + foundedNetIp);
                    write = false;
                    break;
                }
            }
            if (write)
            {
                Console.WriteLine("pc name: " + otherPcName);
                allPcName.Add(otherPcName);
                Console.WriteLine("ip: " + foundedNetIp);
                allIPOfTransfer.Add(foundedNetIp);
                mainForm.ShowPcInvoke(new Machine(otherPcName, foundedNetIp, mainForm));
            }
            return foundedNetIp.ToString();
        }
    }
}
