using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Fomantic.Blazor.Docs.Helpers
{

    
    /// <summary>
    /// Utility class to provide documentation for various types where available with the assembly
    /// </summary>
    public static class DocumenationExtensions
    {
        public static bool IsDelegate(this Type sourceType)
        {
            if (sourceType.IsSubclassOf(typeof(MulticastDelegate)))
                return true;
            return false;
        }

        static bool IsParams(this ParameterInfo param)
        {
            return param.IsDefined(typeof(ParamArrayAttribute), false);
        }
        static public HttpClient Client { get; set; }
        public static string GetMethodFullname(this MethodInfo methodInfo)
        {
            var parametersString = "";
            foreach (var parameterInfo in methodInfo.GetParameters())
            {
                if (parametersString.Length > 0)
                {
                    parametersString += ",";
                }
                if (parameterInfo.IsParams())
                {
                    var fullname = parameterInfo.ParameterType?.GetElementType()?.FullName;
                    //   Console.WriteLine(methodInfo.Name + $" has Params named {parameterInfo.Name} , {fullname}");
                    if (fullname != null)
                    {
                        fullname = Regex.Replace(fullname, @"\[\[.*\]\]", "");

                        parametersString += fullname;
                    }
                    else
                    {
                        //  Console.WriteLine(methodInfo.Name + $" has Params named {parameterInfo.Name} , fullname is null");
                    }


                }
                else
                {
                    parametersString += Regex.Replace(parameterInfo.ParameterType.FullName, @"\[\[.*\]\]", "");
                }
            }

            if (parametersString.Length > 0)
                return methodInfo.Name + "(" + parametersString + ")";
            else
                return methodInfo.Name;
        }
        /// <summary>
        /// Provides the documentation comments for a specific method
        /// </summary>
        /// <param name="methodInfo">The MethodInfo (reflection data ) of the member to find documentation for</param>
        /// <returns>The XML fragment describing the method</returns>
        public static async Task<XmlElement> GetMethodDocumentation(this MethodInfo methodInfo)
        {
            return await XmlFromName(methodInfo.DeclaringType, 'M', methodInfo.GetMethodFullname());
        }

        /// <summary>
        /// Provides the documentation comments for a specific member
        /// </summary>
        /// <param name="memberInfo">The MemberInfo (reflection data) or the member to find documentation for</param>
        /// <returns>The XML fragment describing the member</returns>
        public static async Task<XmlElement> GetDocumentation(this MemberInfo memberInfo)
        {

            // First character [0] of member type is prefix character in the name in the XML
            return await XmlFromName(memberInfo.DeclaringType, memberInfo.MemberType.ToString()[0], memberInfo.Name);
        }

        /// <summary>
        /// Provides the documentation comments for a specific member
        /// </summary>
        /// <param name="memberInfo">The MemberInfo (reflection data) or the member to find documentation for</param>
        /// <returns>The XML fragment describing the member</returns>
        public static async Task<XmlElement> GetDocumentation(this EventInfo eventInfo)
        {

            // First character [0] of member type is prefix character in the name in the XML
            return await XmlFromName(eventInfo.DeclaringType, 'E', eventInfo.Name);
        }
        /// <summary>
        /// Returns the Xml documenation summary comment for this member
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public async static Task<string> GetSummary(this MemberInfo memberInfo)
        {
            try
            {

                var element = await memberInfo.GetDocumentation();
                var summaryElm = element?.SelectSingleNode("summary");
                if (summaryElm == null) return "";
                return summaryElm.InnerText.Trim();
            }
            catch (Exception)
            {

                return "";
            }

        }
        /// <summary>
        /// Returns the Xml documenation summary comment for this member
        /// </summary>
        /// <param name="eventInfo"></param>
        /// <returns></returns>
        public async static Task<string> GetSummary(this EventInfo eventInfo)
        {
            try
            {

                var element = await eventInfo.GetDocumentation();
                var summaryElm = element?.SelectSingleNode("summary");
                if (summaryElm == null) return "";
                return summaryElm.InnerText.Trim();
            }
            catch (Exception)
            {

                return "";
            }

        }
        public async static Task<string> GetParamSummary(this MethodInfo memberInfo, string paramName)
        {
            try
            {
                var element = await memberInfo.GetMethodDocumentation();
                var text = element.InnerXml.Split(@"/param>").FirstOrDefault(d => d.Contains(paramName));
                if (text != null)
                {
                    Console.WriteLine($"param splits {paramName} is {text}");
                    var x = Regex.Match(text, $"<param name=\"{paramName}\">.*<");
                    if (x.Success)
                    {
                        var value = x.Value.Replace($"<param name=\"{paramName}\">", "").Replace(@"<", "");
                        Console.WriteLine($"param {paramName} is {value}");
                        return value;
                    }

                }
                Console.WriteLine($"param {paramName} is null");
                return "";


            }
            catch (Exception)
            {

                return "";
            }

        }
        /// <summary>
        /// Provides the documentation comments for a specific type
        /// </summary>
        /// <param name="type">Type to find the documentation for</param>
        /// <returns>The XML fragment that describes the type</returns>
        public async static Task<XmlElement> GetDocumentation(this Type type)
        { // Prefix in type names is T
            var doc = await XmlFromName(type, 'T', "");

            return doc;
        }
        /// <summary>
        /// Provides the documentation comments for a specific type
        /// </summary>
        /// <param name="type">Type to find the documentation for</param>
        /// <returns>The XML fragment that describes the type</returns>
        public async static Task<XmlElement> GetDocumentationOfEnum(this Type type, string enumName)
        { // Prefix in type names is T
            var doc = await XmlFromName(type, 'F', enumName);

            return doc;
        }
        /// <summary>
        /// Gets the summary portion of a type's documenation or returns an empty string if not available
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async static Task<string> GetSummary(this Type type)
        {
            var element = await type.GetDocumentation();

            var summaryElm = element?.SelectSingleNode("summary");

            if (summaryElm == null) return "";

            return summaryElm.InnerText.Trim();
        }

        public async static Task<string> GetSummary(this MethodInfo methodInfo)
        {
            var element = await methodInfo.GetMethodDocumentation();

            var summaryElm = element?.SelectSingleNode("summary");

            if (summaryElm == null) return "";

            return summaryElm.InnerText.Trim();
        }
        /// <summary>
        /// Gets the summary portion of a type's documenation or returns an empty string if not available
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async static Task<string> GetSummaryOfEnum(this Type type, string enumname)
        {
            var element = await type.GetDocumentationOfEnum(enumname);

            var summaryElm = element?.SelectSingleNode("summary");

            if (summaryElm == null) return "";

            return summaryElm.InnerText.Trim();
        }
        public static IEnumerable<Type> GetParentTypes(this Type type)
        {
            // is there any base type?
            if (type == null)
            {
                yield break;
            }

            // return all implemented or inherited interfaces
            foreach (var i in type.GetInterfaces())
            {
                yield return i;
            }

            // return all inherited types
            var currentBaseType = type.BaseType;
            while (currentBaseType != null)
            {
                yield return currentBaseType;
                currentBaseType = currentBaseType.BaseType;
            }
        }
        /// <summary>
        /// Obtains the XML Element that describes a reflection element by searching the 
        /// members for a member that has a name that describes the element.
        /// </summary>
        /// <param name="type">The type or parent type, used to fetch the assembly</param>
        /// <param name="prefix">The prefix as seen in the name attribute in the documentation XML</param>
        /// <param name="name">Where relevant, the full name qualifier for the element</param>
        /// <returns>The member that has a name that describes the specified reflection element</returns>
        private async static Task<XmlElement> XmlFromName(this Type type, char prefix, string name)
        {
            string fullName;

            if (string.IsNullOrEmpty(name))
                fullName = prefix + ":" + Regex.Replace(type.FullName, @"\[\[.*\]\]", "");
            else
                fullName = prefix + ":" + Regex.Replace(type.FullName, @"\[\[.*\]\]", "") + "." + name;

            var xmlDocument = await XmlFromAssembly(type.Assembly);
            //Console.WriteLine(fullName);
            var matchedElement = xmlDocument["doc"]["members"].SelectSingleNode("member[@name='" + fullName + "']");
            // Console.WriteLine(fullName);
            if (matchedElement != null && matchedElement.InnerXml.Contains("<inheritdoc />"))
            {

                if (string.IsNullOrEmpty(name))
                    matchedElement = await XmlFromName(type.BaseType, prefix, "");
                else
                {
                    Type typec = null;
                    if (prefix == 'M')
                    {
                        typec = type.GetParentTypes().FirstOrDefault(d => d.GetMethods().Any(d =>
                        {
                            return d.GetMethodFullname() == name;
                        }));
                        //  Console.WriteLine($"method {fullName} in {typec?.Name}");
                    }
                    else if (prefix == 'E')

                    {
                        typec = type.GetParentTypes().FirstOrDefault(d => d.GetEvents().Any(d => d.Name == name));
                    }
                    else
                    {
                        typec = type.GetParentTypes().FirstOrDefault(d => d.GetProperties().Any(d => d.Name == name));
                    }

                    if (typec == null)
                    {
                        return null;
                    }
                    matchedElement = await XmlFromName(typec, prefix, name);
                    // Console.WriteLine(matchedElement.InnerXml); 
                }

            }
            if (matchedElement is XmlElement)
            {
                return (XmlElement)matchedElement;
            }

            return null;

        }

        /// <summary>
        /// A cache used to remember Xml documentation for assemblies
        /// </summary>
        private static readonly Dictionary<Assembly, XmlDocument> Cache = new Dictionary<Assembly, XmlDocument>();

        /// <summary>
        /// A cache used to store failure exceptions for assembly lookups
        /// </summary>
        private static readonly Dictionary<Assembly, Exception> FailCache = new Dictionary<Assembly, Exception>();

        /// <summary>
        /// Obtains the documentation file for the specified assembly
        /// </summary>
        /// <param name="assembly">The assembly to find the XML document for</param>
        /// <returns>The XML document</returns>
        /// <remarks>This version uses a cache to preserve the assemblies, so that 
        /// the XML file is not loaded and parsed on every single lookup</remarks>
        public async static Task<XmlDocument> XmlFromAssembly(this Assembly assembly)
        {
            if (FailCache.ContainsKey(assembly))
            {
                throw FailCache[assembly];
            }

            try
            {

                if (!Cache.ContainsKey(assembly))
                {
                    // load the docuemnt into the cache
                    Cache[assembly] = await XmlFromAssemblyNonCached(assembly);
                }

                return Cache[assembly];
            }
            catch (Exception exception)
            {
                FailCache[assembly] = exception;
                throw exception;
            }
        }

        /// <summary>
        /// Loads and parses the documentation file for the specified assembly
        /// </summary>
        /// <param name="assembly">The assembly to find the XML document for</param>
        /// <returns>The XML document</returns>
        private async static Task<XmlDocument> XmlFromAssemblyNonCached(Assembly assembly)
        {

            var assemblyFilename = assembly.GetName().Name;

            string url = $"docs/{assemblyFilename}.xml";

            var streamReader = await Client.GetStreamAsync(url);

            var xmlDocument = new XmlDocument();
            xmlDocument.Load(streamReader);

            return xmlDocument;

        }
    }
}
