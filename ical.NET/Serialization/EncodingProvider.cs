using System;
using System.Text;
using Ical.Net.Interfaces.Serialization;

namespace Ical.Net.Serialization
{
    public class EncodingProvider : IEncodingProvider
    {
        public delegate string EncoderDelegate(byte[] data);

        public delegate byte[] DecoderDelegate(string value);

        private readonly ISerializationContext _mSerializationContext;

        public EncodingProvider(ISerializationContext ctx)
        {
            _mSerializationContext = ctx;
        }

        public byte[] Decode8Bit(string value)
        {
            try
            {
                var utf8 = new UTF8Encoding();
                return utf8.GetBytes(value);
            }
            catch
            {
                return null;
            }
        }

        public byte[] DecodeBase64(string value)
        {
            try
            {
                return Convert.FromBase64String(value);
            }
            catch
            {
                return null;
            }
        }

        public virtual DecoderDelegate GetDecoderFor(string encoding)
        {
            if (encoding == null)
            {
                return null;
            }

            switch (encoding.ToUpper())
            {
                case "8BIT":
                    return Decode8Bit;
                case "BASE64":
                    return DecodeBase64;
                default:
                    return null;
            }
        }

        public string Encode8Bit(byte[] data)
        {
            try
            {
                var utf8 = new UTF8Encoding();
                return utf8.GetString(data, 0, data.Length);
            }
            catch
            {
                return null;
            }
        }

        public string EncodeBase64(byte[] data)
        {
            try
            {
                return Convert.ToBase64String(data);
            }
            catch
            {
                return null;
            }
        }

        public virtual EncoderDelegate GetEncoderFor(string encoding)
        {
            if (encoding == null)
            {
                return null;
            }

            switch (encoding.ToUpper())
            {
                case "8BIT":
                    return Encode8Bit;
                case "BASE64":
                    return EncodeBase64;
                default:
                    return null;
            }
        }

        public string Encode(string encoding, byte[] data)
        {
            if (encoding == null || data == null)
            {
                return null;
            }

            var encoder = GetEncoderFor(encoding);
            return encoder?.Invoke(data);
        }

        public string DecodeString(string encoding, string value)
        {
            if (encoding == null || value == null)
            {
                return null;
            }

            var data = DecodeData(encoding, value);
            if (data == null)
            {
                return null;
            }

            // Decode the string into the current encoding
            var encodingStack = _mSerializationContext.GetService(typeof (IEncodingStack)) as IEncodingStack;
            return encodingStack.Current.GetString(data, 0, data.Length);
        }

        public byte[] DecodeData(string encoding, string value)
        {
            if (encoding == null || value == null)
            {
                return null;
            }

            var decoder = GetDecoderFor(encoding);
            return decoder?.Invoke(value);
        }
    }
}