using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.models.order;

public enum OrderedStatus
{
    [EnumMember(Value ="Pending")]
    pending,

    [EnumMember(Value = "Payment Received")]
    paymentReceived,

    [EnumMember(Value = "Payment Failed")]
    paymentFailed
}
