using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.Metadata;
using Salesforce_Package.Manage;
using Salesforce_Package.ManageXML;
using Salesforce_Package.Xml.Config;
using Salesforce_Package.MetadataApi;

namespace Salesforce_Package.Metadata{
    class MetadataService {
        public static void validate(Dictionary<string, List<string>> mapPackage, List<IMetadata> MetaDatas)
        {
           ConsoleHelper.WriteDoneLine(">> Validating Metadata...");

            foreach (var type in mapPackage)
            {
                foreach (var member in type.Value)
                {
                    foreach (IMetadata m_Metadata in MetaDatas)
                    {
                        m_Metadata.isValidThenAdd(type.Key, member);
                    }
                }
            }
        }
        
        public static void merge(string pathSource,string pathDir, List<IMetadata> MetaDatas)
        {
            ConsoleHelper.WriteDoneLine(">> Merging Metadata...");
            foreach (IMetadata m_Metadata in MetaDatas)
            {
                m_Metadata.doMerge();
            }
            ManageXMLCustomObjectMerge merge = ManageXMLCustomObjectMerge.getInstance();
            merge.defaultParameters(pathSource);
            merge.writeAllInstances(pathDir);
        }

        public static void copyPackage(string path, string pathDir)
        {
            ConsoleHelper.WriteDoneLine(">> Copying package...");   
            ManageCopy.doCopy(path.Replace("package.xml", ""), pathDir, "package.xml");            
        }

        public static void copy(string pathFiles, string pathDir, List<IMetadata> MetaDatas)
        {
            ConsoleHelper.WriteDoneLine(">> Copying Metadata...");
            foreach (IMetadata m_Metadata in MetaDatas)
            {
                m_Metadata.doCopy(pathFiles, pathDir);
            }
        }

        public static List<IMetadata> createDirectory(Dictionary<string, List<string>> mapPackage, string pathDir)
        {
            ConsoleHelper.WriteDoneLine(">> Creating directories...");
            List<IMetadata> MetaDatas = ManageDirectory.buildDirectorys(mapPackage, pathDir);
            return MetaDatas;
        }

    }

}