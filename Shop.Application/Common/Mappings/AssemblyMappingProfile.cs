using AutoMapper;
using Shop.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) => 
            ApplyMappingsFromAssembly(assembly);

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {   
           // змінна приймає всі каласи які реалізують інтерфейс
           var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && 
                i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();
            foreach (var type in types)
            {
                
                var instance = Activator.CreateInstance(type);
                // вікриває метод який реалізовано
                var methodInfo = type.GetMethod("Mapping");
                // відкриває метод в якому немає реалізації
                methodInfo?.Invoke(instance,new object[] { this });
            }
        }
    }
}
