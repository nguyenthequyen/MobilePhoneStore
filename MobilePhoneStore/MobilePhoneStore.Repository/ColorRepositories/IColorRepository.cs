using MobilePhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Repository
{
    public interface IColorRepository : IBaseRepository<Color>
    {
        IEnumerable<Color> GetColorsByColorId(string id);
    }
}
