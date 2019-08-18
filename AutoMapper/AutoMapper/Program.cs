using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.ArraysAndLists;
using AutoMapper.BeforeAndAfter;
using AutoMapper.Converters;
using AutoMapper.Generics;
using AutoMapper.Intro;
using AutoMapper.NullSubstitute;
using AutoMapper.Resolvers;
using AutoMapper.ValueConverters;

namespace AutoMapper
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            //Obsolute way - Static Api
            /*
            Mapper.Initialize(cfg => cfg.CreateMap<Source, Destination>());

            var source = new Source()
            {
                Value = "Alabama"
            };


            var destination = Mapper.Map<Destination>(source);

            Console.WriteLine($"Source : {source.Value}");
            Console.WriteLine($"Destination : {destination.Value}");
            */


            //Instance Api - DIP
            /*
            var cfg = new MapperConfiguration(x => x.CreateMap<Source, Destination>());
            var mapper = cfg.CreateMapper();

            var source = new Source()
            {
                Value = "Alabama"
            };


            var destination = mapper.Map<Destination>(source);

            Console.WriteLine($"Source : {source.Value}");
            Console.WriteLine($"Destination : {destination.Value}");
            */

            var source = new Source() { Date = DateTime.Now };
            var cfg = new MapperConfiguration(x => x.AddProfile<IntroProfile>());
            var mapper = cfg.CreateMapper();

            var destination = mapper.Map<Destination>(source);

            Console.WriteLine($"Source:{source.Date.Day}.{source.Date.Month}.{source.Date.Year}");
            Console.WriteLine($"Destination:{destination.Day}.{destination.Month}.{destination.Year}");

            Mapper.Initialize(x =>
            {
                x.CreateMap<CSource, CDest>();
                x.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
                x.CreateMap<string, DateTime>().ConvertUsing<StringDateTimeConverter>();
            });

            var csrc = new CSource()
            {
                Number = "5",
                Date="01/01/2018"
            };

            var cdest = Mapper.Map<CSource, CDest>(csrc);

            Console.WriteLine(csrc.Number);
            Console.WriteLine(cdest.Number);

            Console.WriteLine($"Source:{csrc.Date}");
            Console.WriteLine($"Destination:{cdest.Date.Day}/{cdest.Date.Month}/{cdest.Date.Year}");

            var acfg = new MapperConfiguration(x => {
                x.CreateMap<ASource, ADest>();
                x.CreateMap<ASourceParent, ADestParent>().Include<ASource, ADest>();
            });
            var aMapper = acfg.CreateMapper();
            var srcArr = new[]
            {
                new ASource(){Value=1,Value1=1},
                new ASource(){Value=2,Value1=2}
            };

            var destArr = aMapper.Map<ASource[], ADest[]>(srcArr);
            var destList=aMapper.Map<ASource[],List<ADest>>(srcArr);


            var personcfg = new MapperConfiguration(x =>
            {
                x.CreateMap<PersonRequest, PersonResponse>()
                 .ForMember(dest => dest.FullName, opt => opt.MapFrom<PersonResolver>());
                x.ValueTransformers.Add<string>(val => val + "!!!");
            });

            var personMapper = personcfg.CreateMapper();

            var request = new PersonRequest()
            {
                FirstName = "Vuk",
                LastName = "Isic"
            };

            var response = personMapper.Map<PersonResponse>(request);

            var pricecfg = new MapperConfiguration(
                x => x.CreateMap<DecimalPrice, StringPrice>()
                .ForMember(dest => dest.Price, opt => opt.ConvertUsing(new PriceConverter())));

            var priceMapper = pricecfg.CreateMapper();

            var price1 = new DecimalPrice()
            {
                Price = new decimal(234.44)
            };

            var price2 = priceMapper.Map<StringPrice>(price1);


            var pConfig=new MapperConfiguration(
                x=>x.CreateMap<Person,PersonDTO>()
                .BeforeMap((src,des)=>src.Age += 10)
                .AfterMap((src,dest)=>dest.Name += "Mr."));

            var pMapper = pConfig.CreateMapper();

            var per = new Person
            {
                Name = "Vuk",
                Age = 11
            };

            var per2 = pMapper.Map<PersonDTO>(per);


            var eventcfg = new MapperConfiguration(x => x.CreateMap<SrcEvent, DestEvent>()
              .ForMember(dest => dest.EventName, opt => opt.NullSubstitute("NullEvent")));

            var eventMapper = eventcfg.CreateMapper();

            var eventsrc = new SrcEvent() { EventName = null };
            var eventdes = eventMapper.Map<DestEvent>(eventsrc);


            var gencfg = new MapperConfiguration(x => x.CreateMap(typeof(GenSource<>), typeof(GenDest<>)));
            var genMapper = gencfg.CreateMapper();

            var gs = new GenSource<int> { Value = 10 };
            var ds = genMapper.Map<GenSource<int>, GenDest<int>>(gs);

            Console.ReadLine();
        }


    }
}
