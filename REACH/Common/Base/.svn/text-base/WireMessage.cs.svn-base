using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace REACH.Common.Base
{
    public class WireMessage
    {
        private const int UInt32SerializedSize = 55;

        public static void SendMessage(TcpClient connection, RMessage message)
        {
            NetworkStream writer = connection.GetStream();
            byte[] buffer = Serial.ObjectToByteArray(message);
            UInt32 length = (UInt32)(buffer.Length);
            writer.Write(Serial.ObjectToByteArray(length), 0, Serial.ObjectToByteArray(length).Length);
            writer.Flush();
            writer.Write(buffer,0,buffer.Length);
            writer.Flush();
        }

        public static RMessage ReceiveMessage(TcpClient connection)
        {
            byte[] messageChars;
            NetworkStream reader;
            try
            {
                reader = connection.GetStream();
            }
            catch (ObjectDisposedException)
            {
                return null;
            }
            try
            {
                byte[] messageLengthChars = new byte[UInt32SerializedSize];
                ReadNCaracters(reader, UInt32SerializedSize, messageLengthChars);
                UInt32 messageLength = (UInt32)(Serial.ByteArrayToObject(messageLengthChars));
                messageChars = new byte[messageLength];
                ReadNCaracters(reader, messageLength, messageChars);
            }
            catch (IOException)
            {
                return null;
            }
            return (RMessage)(Serial.ByteArrayToObject(messageChars));
        }

        private static void ReadNCaracters(NetworkStream reader, UInt32 numberOfChars, byte[] buffer)
        {
            int counter = 0;
            while (counter < numberOfChars)
            {
                try
                {
                    counter += reader.Read(buffer, counter, (int)(numberOfChars - counter));
                }
                catch (IOException ex)
                {
                    throw ex;
                }
            }
        }
    }
}
