using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Model
{
    public class CustomerNotFoundException: Exception
    {
        public CustomerNotFoundException(string message): base(message)
        {
            
        }
    }
}
