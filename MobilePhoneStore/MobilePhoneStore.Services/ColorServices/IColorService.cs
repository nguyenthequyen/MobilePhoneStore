using MobilePhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Services
{
    public interface IColorService : IBaseService<Color>
    {
        public IEnumerable<Color> GetColorsByColorId(string id);
    }
}
