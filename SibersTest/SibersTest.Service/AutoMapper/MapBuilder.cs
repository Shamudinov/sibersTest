using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.Service.AutoMapper
{
    public class MapBuilder
    {
        static IMapper mapper;

        public static IMapper Build()
        {
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfile());
                });

                mapper = mappingConfig.CreateMapper();
            }
            return mapper;
        }
    }
}
