using System;
using System.Linq;

namespace Arcade.Scripts.Extensions
{
    public static class Extensions
    {
        public static bool ImplementsInterface(this Type type, Type interfaceType) 
        {
            var interfaces = type.GetInterfaces();
            return interfaces.Any(mInterface => mInterface == interfaceType);
        }
    }
}