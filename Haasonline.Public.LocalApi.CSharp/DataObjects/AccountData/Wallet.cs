using System.Collections.Generic;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.AccountData
{
    public class Wallet
    {
        public Dictionary<string, decimal> Coins { get; set; }
        public Dictionary<string, Position> Positions { get; set; }
    }
}