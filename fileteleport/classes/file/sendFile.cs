
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
        private bool sendThroughSocket(Socket s, string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open);
            int chunkSize = 500000000;
            long remaining = file.Length;
            int offset = 0;
            while (true)
            {
                int sizeToRead = chunkSize;
                if (remaining < chunkSize)
                {

                }
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
            byte[] file = new byte[0];
            bool exception = false;
            try
            {
                filename = filepath;
                file = FileToByteArray(filename);

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
                string sendInfo = file.Length.ToString() + ";" + filename.Split('/')[filename.Split('/').Length - 1] + ";" + mainForm.pcName + "<EOF>";
                sendSocket.Send(Encoding.UTF8.GetBytes(sendInfo));

                Thread.Sleep(100);
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


                int nbKo = Convert.ToInt32(Convert.ToDouble(strLenght)/* / 1024*/);
                bytes = new Byte[1];
                //receive the file content
                for (int i = 0; i < nbKo; i++)
                {
                    int numByte = clientSocket.Receive(bytes);
                    receivedMsg.AddRange(bytes);
                }
                //dialogue box for saving the file
                mainForm.ShowSaveDialogue(fileNameExtension, strLenght, pcName);

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
            if (writeFile)
            {
                File.WriteAllBytes(path, receivedMsg.ToArray());
            }
        }
    }
}
