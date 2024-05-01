using MinaSignerNet;
using System.Numerics;

namespace CryptomonServer.Dtos
{

    public class DepositEvents
    {
        public List<DepositEvent> Events { get; set; }
    }

    public class DepositEvent
    {
        public List<DepositEventData> EventData { get; set; }
    }

    public class DepositEventData
    {
        public List<string> Data { get; set; }


        public bool IsDeposit
        {
            get { return Data[0] == "0"; }
        }

        public int Index
        {
            get { return int.Parse(Data[1]); }
        }

        public string Account
        {
            get
            {
                return new PublicKey(BigInteger.Parse(Data[2]), Data[3] == "1").ToString();
            }
        }


        public UInt64 Amount
        {
            get { return UInt64.Parse(Data[4]); }
        }
    }
}
