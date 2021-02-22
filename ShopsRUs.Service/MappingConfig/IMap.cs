using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ShopsRUs.Service.MappingConfig
{
    public interface IMap<T>
    {
        void Map(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
