﻿using AutoMapper;
using System.Linq;
using System.Reflection;

namespace EntityFrameworkCoreApp.BusinessLogic.Services
{
    public partial class BusinessLogicMappingProfile : Profile
    {
        public BusinessLogicMappingProfile()
        {
            this.GetType()
                .GetTypeInfo()
                .DeclaredMethods
                .Where(t => t.Name.Contains("Initialize"))
                .Where(t => t.IsPrivate)
                .Where(t => !t.IsStatic)
                .ToList()
                .ForEach(t => t.Invoke(this, null));
        }
    }
}
