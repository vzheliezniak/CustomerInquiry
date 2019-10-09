using Business.Model;

namespace Business.Abstract
{
    public interface ICustomerInquiryManager
    {
        CustomerProfile GetCustomerProfile(int customerId = 0, string email = null);
    }
}
