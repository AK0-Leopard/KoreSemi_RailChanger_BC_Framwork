using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.bc.winform
{
    public sealed class ConfigSystem : IInternalConfigSystem
    {
        private static IInternalConfigSystem clientConfigSystem;
        private object appsettings;
        public static void Install()
        {
            FieldInfo[] fiStateValues = null;
            Type tInitState = typeof(System.Configuration.ConfigurationManager).GetNestedType("InitState", BindingFlags.NonPublic);
            if (null != tInitState)
            {
                fiStateValues = tInitState.GetFields();
            }
            FieldInfo fiInit = typeof(System.Configuration.ConfigurationManager).GetField("s_initState", BindingFlags.NonPublic | BindingFlags.Static);
            FieldInfo fiSystem = typeof(System.Configuration.ConfigurationManager).GetField("s_configSystem", BindingFlags.NonPublic | BindingFlags.Static);
            if (fiInit != null && fiSystem != null && null != fiStateValues)
            {
                fiInit.SetValue(null, fiStateValues[1].GetValue(null));
                fiSystem.SetValue(null, null);
            }
            ConfigSystem confSys = new ConfigSystem();
      //      Type configFactoryType = Type.GetType
      //          ("System.Configuration.Internal.InternalConfigSettingsFactory, System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
      //          true);
            
            Type configFactoryType = Type.GetType
                ("System.Configuration.Internal.InternalConfigSettingsFactory, System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                true);
            IInternalConfigSettingsFactory configSettingsFactory =
                (IInternalConfigSettingsFactory)Activator.CreateInstance(configFactoryType, true);
            configSettingsFactory.SetConfigurationSystem(confSys, false);
       //     Type clientConfigSystemType = Type.GetType
       //         ("System.Configuration.ClientConfigurationSystem, System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", true);
       //     clientConfigSystem = (IInternalConfigSystem)Activator.CreateInstance(clientConfigSystemType, true);
            Type clientConfigSystemType = Type.GetType
                ("System.Configuration.ClientConfigurationSystem, System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", true);
            clientConfigSystem = (IInternalConfigSystem)Activator.CreateInstance(clientConfigSystemType, true);

        }

        public object GetSection(string configKey)
        {
            // get the section from the default location (web.config or app.config)
            object section = clientConfigSystem.GetSection(configKey);
            return section;
        }

        public void RefreshConfig(string sectionName)
        {
            clientConfigSystem.RefreshConfig(sectionName);
        }

        public bool SupportsUserConfig
        {
            get { return clientConfigSystem.SupportsUserConfig; }
        }
    }
}
