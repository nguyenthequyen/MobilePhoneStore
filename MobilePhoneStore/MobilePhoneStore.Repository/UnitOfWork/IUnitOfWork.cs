using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
