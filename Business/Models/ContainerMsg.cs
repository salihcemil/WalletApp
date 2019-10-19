using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    /// <summary>
    /// Container class for messaging between peers
    /// </summary>
    public class ContainerMsg
    {
        public Transaction transaction { get; set; }
        public Block block { get; set; }
    }
}
