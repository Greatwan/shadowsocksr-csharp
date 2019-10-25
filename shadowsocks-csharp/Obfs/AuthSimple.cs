using System;
using System.IO;
using System.Collections.Generic;
using Shadowsocks.Controller;
using System.Security.Cryptography;

namespace Shadowsocks.Obfs
{
    public class AuthSimple : ObfsBase
    {
        public AuthSimple(string method)
       : base(method)
        {
        }
        public static List<string> SupportedObfs()
        {
            return new List<string>(_obfs.Keys);
        }
        private static Dictionary<string, int[]> _obfs = new Dictionary<string, int[]> {
            {"auth_simple", new int[]{1, 0, 1}},
        };
        public override Dictionary<string, int[]> GetObfs()
        {
            return _obfs;
        }
        public override byte[] ClientPreEncrypt(byte[] plaindata, int datalength, out int outlength)
        {
            if (plaindata == null)
            {
                outlength = 0;
                return plaindata;
            }
            outlength = 1 + Server.param.Length + 2 + datalength;

            byte[] dst = new byte[outlength];
            byte[] tokenLengByte = { (byte)Server.param.Length }; // 1 byte
            byte[] token = System.Text.Encoding.ASCII.GetBytes(Server.param);
            byte[] bufLengByte = BitConverter.GetBytes((ushort)datalength); // 2 byte
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bufLengByte);

            int dstArrBeginIndex = 0;
            Buffer.BlockCopy(tokenLengByte, 0, dst, dstArrBeginIndex, 1);
            dstArrBeginIndex += tokenLengByte.Length;
            Buffer.BlockCopy(token, 0, dst, dstArrBeginIndex, Server.param.Length);
            dstArrBeginIndex += Server.param.Length;
            Buffer.BlockCopy(bufLengByte, 0, dst, dstArrBeginIndex, 2);
            dstArrBeginIndex += bufLengByte.Length;
            Buffer.BlockCopy(plaindata, 0, dst, dstArrBeginIndex, datalength);

            return dst;
        }
        public override byte[] ClientEncode(byte[] encryptdata, int datalength, out int outlength)
        {
            outlength = datalength;
            return encryptdata;
        }

        public override byte[] ClientDecode(byte[] encryptdata, int datalength, out int outlength, out bool needsendback)
        {
            outlength = datalength;
            needsendback = false;
            return encryptdata;
        }
        public override byte[] ClientPostDecrypt(byte[] plaindata, int datalength, out int outlength)
        {
            if (plaindata == null)
            {
                outlength = 0;
                return plaindata;
            }
            //todo 加个解密
            outlength = datalength;
            return plaindata;
        }
        public override byte[] ClientUdpPreEncrypt(byte[] plaindata, int datalength, out int outlength)
        {
            if (plaindata == null)
            {
                outlength = 0;
                return plaindata;
            }
            byte[] tokenLengByte = { (byte)Server.param.Length }; // 1 byte
            byte[] token = System.Text.Encoding.ASCII.GetBytes(Server.param);

            outlength = 1 + Server.param.Length +  datalength;
            byte[] dst = new byte[outlength];

            int dstArrBeginIndex = 0;
            Buffer.BlockCopy(plaindata, 0, dst, dstArrBeginIndex, datalength);
            dstArrBeginIndex += datalength;
            Buffer.BlockCopy(token, 0, dst, dstArrBeginIndex, Server.param.Length);
            dstArrBeginIndex += Server.param.Length;
            Buffer.BlockCopy(tokenLengByte, 0, dst, dstArrBeginIndex, 1);

            return dst;
        }
        public override byte[] ClientUdpPostDecrypt(byte[] plaindata, int datalength, out int outlength)
        {
            if (plaindata == null)
            {
                Console.WriteLine("plaindata == null");
                outlength = 0;
                return plaindata;
            }
            //int token_len = (int)plaindata[datalength-1];
            //byte[] tokenByte = new byte[token_len];
            //Buffer.BlockCopy(plaindata, datalength-token_len-1, tokenByte, 0, token_len);
            //string tokenStr = System.Text.Encoding.UTF8.GetString(tokenByte);
            //if (tokenStr != Server.param)
            //{
            //    Console.WriteLine(tokenStr + " != " + Server.param);
            //    outlength = 0;
            //    return plaindata;
            //}
            //Console.WriteLine(tokenStr);
            //outlength = datalength - token_len - 1;
            //return plaindata;
            outlength = datalength;
            return plaindata;
        }
    }
}
