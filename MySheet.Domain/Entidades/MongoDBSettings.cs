using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySheet.Domain.Entidades
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}
