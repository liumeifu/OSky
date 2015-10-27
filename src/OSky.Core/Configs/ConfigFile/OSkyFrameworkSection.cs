// -----------------------------------------------------------------------
//  <copyright file="OSkyFrameworkSection.cs" company="">
//      Copyright (c) 2014-2015 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2015-06-30 13:44</last-date>
// -----------------------------------------------------------------------

using System.Configuration;


namespace OSky.Core.Configs.ConfigFile
{
    internal class OSkyFrameworkSection : ConfigurationSection
    {
        private const string XmlnsKey = "xmlns";
        private const string DataKey = "data";
        private const string LoggingKey = "logging";

        [ConfigurationProperty(XmlnsKey, IsRequired = false)]
        private string Xmlns
        {
            get { return (string)this[XmlnsKey]; }
            set { this[XmlnsKey] = value; }
        }

        [ConfigurationProperty(DataKey)]
        public virtual DataElement Data
        {
            get { return (DataElement)this[DataKey]; }
            set { this[DataKey] = value; }
        }

        [ConfigurationProperty(LoggingKey)]
        public virtual LoggingElement Logging
        {
            get { return (LoggingElement)this[LoggingKey]; }
            set { this[LoggingKey] = value; }
        }
    }
}