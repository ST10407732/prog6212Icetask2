using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG2BIceTask2
{
    public partial class MainWindow : Window
    {
        private ApprovalService approvalService = new ApprovalService();
        private static List<Payment> payments = new List<Payment>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Payment payment = new Payment
            {
                RequestId = int.Parse(RequestIdInput.Text),
                Price = double.Parse(PriceInput.Text),
                Description = DescriptionInput.Text,
                Date = RequestDateInput.SelectedDate.Value,
                Status = Status.Pending
            };

            payments.Add(payment);
            MessageBox.Show($"Payment {payment.RequestId} submitted and is pending approval.");
        }

        private void OpenApprovalWindowButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Approval Window and pass the list of pending payments
            ApprovalWindow approvalWindow = new ApprovalWindow(payments);
            approvalWindow.Show();
        }
    }


}