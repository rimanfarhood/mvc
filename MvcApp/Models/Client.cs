using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<ItemClient>? ItemClients { get; set; }


    }
}