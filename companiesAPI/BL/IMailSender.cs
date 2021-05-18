using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace BL
{
    public interface IMailSender
    {
        bool SendEmail();

    }
}