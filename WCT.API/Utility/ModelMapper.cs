using AutoMapper.Attributes;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCT.API.Utility
{
    public static class ModelMapper
    {
        public static void Init()
        {
            typeof(ModelMapper).Assembly.MapTypes();
        }
    }
}