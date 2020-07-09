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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Security.Permissions;
using System.ComponentModel;

namespace fileteleport
{
    public class sendFile
    {
        private Form1 mainForm;
        Thread threadConnect;
        Thread threadBind;
        public void Initialize(Form1 mainForm)
        {
            this.mainForm = mainForm;
            var context = SynchronizationContext.Current;
            threadBind = new Thread(() =>  Bind());
            threadBind.IsBackground = true;
            threadBind.Start();
        }
        public void Send(string destIP, string fileToSend)
        {
            threadConnect = new Thread(() => Connect(destIP, fileToSend));
            threadConnect.IsBackground = true;
            threadConnect.Start();
        }
        private void sendThroughSocket(Socket s, string filePath)
        {
            using (var file = File.OpenRead(filePath))
            {
                byte[] sendBuffer = new byte[5000000];                
                long bytesLeftToTransmit = file.Length;
                while (bytesLeftToTransmit > 0)
                {
                    int dataToSend = file.Read(sendBuffer, 0, sendBuffer.Length);
                    bytesLeftToTransmit -= dataToSend;
                    s.Send(sendBuffer);                      
                }
                sendBuffer = null;
            }
        }
        public List<byte> receivedMsg = new List<byte>();

        public byte[] StreamtoByteArray(Stream stream)
        {
            int offset = 0;
            int remaining = (int)stream.Length;
            byte[] data = new byte[remaining];
            while (remaining > 0)
            {
                int read = stream.Read(data, offset, remaining);
                if (read <= 0)
                    throw new EndOfStreamException();
                remaining -= read;
                offset += read;
            }
            return data;
        }

        public byte[] FileToByteArray(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            byte[] binary = StreamtoByteArray(fs);
            fs.Close();
            return binary;
        }

        public void Connect(string ip, string filepath)
        {
            string filename = "";
            FileInfo fileinfo = new FileInfo(filepath);
            bool exception = false;
            try
            {
                filename = filepath;
                //file = FileToByteArray(filename);

            }
            catch
            {
                mainForm.ShowError("The file cannot be opened");
                exception = true;
            }
            if(!exception)
            {
                IPAddress ipAddr = IPAddress.Parse(ip);
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 53457);
                // Creation TCP/IP Socket using  
                // Socket Class Costructor 
                Socket sendSocket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);


                // Connect Socket to the remote  
                // endpoint using method Connect()
                sendSocket.Connect(localEndPoint);

                // We print EndPoint information  
                // that we are connected 
                Console.WriteLine("Socket connected to -> {0} ", sendSocket.RemoteEndPoint.ToString());
                //send some info in csv format (length of the file, file name with it's extension and the name of the pc)
                string sendInfo = (fileinfo.Length).ToString() + ";" + fileinfo.Name + ";" + mainForm.pcName + "<EOF>";
                sendSocket.Send(Encoding.UTF8.GetBytes(sendInfo));

                Thread.Sleep(100);
                try
                {
                    sendThroughSocket(sendSocket,filename);
                }catch(Exception e)
                {
                    mainForm.ShowError("an error as occured when sending the file: " + e.Message);
                }
                //sendSocket.Send(file);
                // Close Socket using  
                // the method Close()
                sendSocket.Shutdown(SocketShutdown.Both);
                sendSocket.Close();
            }

        }

        public void Bind()
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 53457);

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
                string[] splitedData = data.Split(';');
                string strLenght = splitedData[0];
                string filename = splitedData[1];
                string pcName = splitedData[2].Split('<')[0];
                string[] fileNameExtension = new string[2];
                string[] fileName = filename.Split('\\');
                fileNameExtension = fileName[fileName.Length - 1].Split('.');
                long nbKo = Convert.ToInt64(strLenght);
                bool isConvertible = false;
                int length = 0;
                int operation = 1;
                while(!isConvertible)
                {
                    try
                    {
                        length = Convert.ToInt32(nbKo / operation);
                        isConvertible = true;
                    }
                    catch(OverflowException e)
                    {
                        isConvertible = false;
                        if (operation == 1)
                            operation = 1024;
                        else
                            operation = Convert.ToInt32(Math.Pow(operation, 2));
                    }
                }
                bytes = new Byte[1];
                mainForm.ShowSaveDialogue(fileNameExtension, strLenght, pcName);
                FileStream Stream = new FileStream(fileName[fileName.Length -1],FileMode.Create);                
                int bytesLeftToReceive = length;
                byte[] receiveBuffer = new byte[5000000];
                int offset = 0;
                //receive the file content
                while(bytesLeftToReceive> 0)
                {
                    int bytesRead = clientSocket.Receive(receiveBuffer);
                    if (bytesRead > bytesLeftToReceive )
                    {
                        //if we don't do that the file will have a lot of zeroes at the end
                        Stream.Write(receiveBuffer, 0, bytesLeftToReceive * operation);
                    }
                    else
                    {
                        Stream.Write(receiveBuffer, 0, bytesRead);                        
                    }
                        bytesLeftToReceive -= bytesRead / operation;
                    //receivedMsg.AddRange(bytes);
                }
                receiveBuffer = null;
                Stream.Close();
                //dialogue box for saving the file

                // Close client Socket using the 
                // Close() method. After closing, 
                // we can use the closed Socket  
                // for a new Client Connection
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }

        //write the received file
        public void WriteFile(bool writeFile, string path)
        {
            //if (writeFile)
            //{
            //    File.WriteAllBytes(path, receivedMsg.ToArray());
            //}
        }
    }
}
