using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG2BIceTask2
{

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ApprovalLimitAttribute : Attribute
    {
        public double Limit { get; }

        public ApprovalLimitAttribute(double limit)
        {
            Limit = limit;
        }
    }

    [ApprovalLimit(1000)]
    public class TeamLead
    {
        public bool ApprovePayment(Payment payment)
        {
            if (payment.Price <= 1000)
            {
                payment.Status = Status.Approved;
                Console.WriteLine($"Team Lead approved payment {payment.RequestId} for price {payment.Price}");
                return true;
            }
            else
            {
                payment.Status = Status.Rejected;
                Console.WriteLine($"Team Lead cannot approve payment {payment.RequestId} for price {payment.Price}");
                return false;
            }
        }
    }


    [ApprovalLimit(10000)]
    public class Manager
    {
        public bool ApprovePayment(Payment payment)
        {
            if (payment.Price > 1000 && payment.Price <= 10000)
            {
                payment.Status = Status.Approved;
                Console.WriteLine($"Manager approved payment {payment.RequestId} for price {payment.Price}");
                return true;
            }
            else
            {
                payment.Status = Status.Rejected;
                Console.WriteLine($"Manager cannot approve payment {payment.RequestId} for price {payment.Price}");
                return false;
            }
        }
    }
    [ApprovalLimit(double.MaxValue)]
    public class Director
    {
        public bool ApprovePayment(Payment payment)
        {
            if (payment.Price > 10000)
            {
                payment.Status = Status.Approved;
                Console.WriteLine($"Director approved payment {payment.RequestId} for price {payment.Price}");
                return true;
            }
            else
            {
                payment.Status = Status.Rejected;
                Console.WriteLine($"Director cannot approve payment {payment.RequestId} for price {payment.Price}");
                return false;
            }
        }
    }

}
