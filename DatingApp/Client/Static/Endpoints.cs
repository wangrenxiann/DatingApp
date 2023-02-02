using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string PlayersEndpoint = $"{Prefix}/players";
        public static readonly string MessagesEndpoint = $"{Prefix}/messages";

    }
}
