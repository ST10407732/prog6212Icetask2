using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG2BIceTask2
{
    public class ApprovalService
    {

        public void ProcessPayment(Payment payment, object approver)
        {
            var approveMethod = approver.GetType().GetMethod("ApprovePayment");
            var result = (bool)approveMethod.Invoke(approver, new object[] { payment });

            payment.Status = result ? Status.Approved : Status.Rejected;
        }
    }
}
