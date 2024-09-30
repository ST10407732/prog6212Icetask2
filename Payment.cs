using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG2BIceTask2
{
    public enum Status
    {
        Pending,
        Approved,
        Rejected
    }

    public class Payment
    {
        public int RequestId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
    }
}
