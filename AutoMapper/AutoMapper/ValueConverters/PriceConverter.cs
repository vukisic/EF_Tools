using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.ValueConverters
{
    public class PriceConverter : IValueConverter<decimal, string>
    {
        public string Convert(decimal sourceMember, ResolutionContext context)
        {
            return sourceMember.ToString("c");
        }
    }
}
