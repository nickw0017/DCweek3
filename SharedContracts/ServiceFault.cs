using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SharedContracts
{
    [DataContract]
    public class ServiceFault
    {
        [DataMember] public string Code { get; set; }
        [DataMember] public string Message { get; set; }

    }
}
