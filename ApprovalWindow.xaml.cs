using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROG2BIceTask2
{
    public partial class ApprovalWindow : Window
    {
        private List<Payment> payments;
        private ApprovalService approvalService = new ApprovalService();
        private Payment selectedPayment;

        public ApprovalWindow(List<Payment> paymentList)
        {
            InitializeComponent();
            payments = paymentList.Where(p => p.Status == Status.Pending).ToList();
            LoadPayments();
        }

        private void LoadPayments()
        {
            RequestList.Items.Clear();
            foreach (var payment in payments)
            {
                RequestList.Items.Add($"Request ID: {payment.RequestId}, Price: {payment.Price}");
            }
        }

        private void RequestList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RequestList.SelectedIndex >= 0)
            {
                selectedPayment = payments[RequestList.SelectedIndex];
                SelectedRequestDetails.Text = $"Request ID: {selectedPayment.RequestId}\n" +
                                              $"Price: {selectedPayment.Price}\n" +
                                              $"Description: {selectedPayment.Description}\n" +
                                              $"Date: {selectedPayment.Date.ToShortDateString()}\n" +
                                              $"Status: {selectedPayment.Status}";
            }
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPayment != null)
            {
                string approverRole = (ApproverRole.SelectedItem as ComboBoxItem).Content.ToString();
                switch (approverRole)
                {
                    case "Team Lead":
                        approvalService.ProcessPayment(selectedPayment, new TeamLead());
                        break;
                    case "Manager":
                        approvalService.ProcessPayment(selectedPayment, new Manager());
                        break;
                    case "Director":
                        approvalService.ProcessPayment(selectedPayment, new Director());
                        break;
                }
                LoadPayments();
                SelectedRequestDetails.Text = $"Payment {selectedPayment.RequestId} has been {selectedPayment.Status}.";
            }
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPayment != null)
            {
                selectedPayment.Status = Status.Rejected;
                LoadPayments();
                SelectedRequestDetails.Text = $"Payment {selectedPayment.RequestId} has been rejected.";
            }
        }
    }

}
