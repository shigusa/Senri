using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senri.Database
{
    public abstract class ConnectBase
    {
        public string Server
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public string User
        {
            get;
            private set;
        }

        public string Password
        {
            get;
            private set;
        }

        public void AddTransaction(decimal amaount)
        {
            Server += CalculateRewardPoints(amaount);
            Name += amaount;
        }
        public abstract int CalculateRewardPoints(decimal amount);
    }
}
