using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventBus
{
    public class AssemblyLoader
    {
        private static IEnumerable<Type> types = null;

        public static void ResolveAssembly(string path)
        {
            //run once
            if (types == null)
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                //if (!dir.Exists) dir = new DirectoryInfo(HostingEnvronment.GetMapPath("/"));
                var searchFiles = dir.GetFiles("*.dll", SearchOption.AllDirectories);
                var TypeList = searchFiles.SelectMany(f => AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(f.FullName)).GetTypes());
                types = TypeList;
            }
        }

        public static IEnumerable<Type> TypesOf(Type type)
        {

            var queryTypes = from t in types
                             where (type.IsAssignableFrom(t) && !t.IsInterface) || t.GetInterfaces().Any(i => i.Name == type.Name)
                             select t;

            return queryTypes;

        }


      

    }
}
