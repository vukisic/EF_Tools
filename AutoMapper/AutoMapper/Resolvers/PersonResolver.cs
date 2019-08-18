using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Resolvers
{
    public class PersonResolver : IValueResolver<PersonRequest, PersonResponse, string>
    {
        public string Resolve(PersonRequest source, PersonResponse destination, string destMember, ResolutionContext context)
        {
            return $"{source.FirstName} {source.LastName}";
        }
    }
}
