using Business.Model;

namespace Business.Abstract
{
    public interface ICustomerInquiryManager
    {
        CustomerProfile GetCustomerProfile(decimal customerId = 0, string email = null);
    }
}
