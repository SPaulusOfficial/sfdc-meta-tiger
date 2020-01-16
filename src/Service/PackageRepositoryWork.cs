using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MetaTiger.Metadata;
using MetaTiger.ManageFile;
using MetaTiger.ManageFileXML;
using MetaTiger.Xml.Config;
using MetaTiger.Api.Metadata;
using MetaTiger.Helper;

namespace MetaTiger.Service{
    class PackageRepositoryWork {
        
        PackageManifest packageManifest;
        Dictionary<string, List<string>> mapPackage;

        public PackageRepositoryWork(PackageManifest pm,Dictionary<string, List<string>> mp){
            packageManifest = pm;
            mapPackage = mp;
        }

        public void run()
        {
            List<IMetadata> MetaDatas = this.createDirectory(mapPackage, packageManifest.DirectoryTarget);
            this.validate(mapPackage, MetaDatas);
            this.copy(packageManifest.RepositorySource, packageManifest.DirectoryTarget, MetaDatas);
            this.merge(packageManifest.RepositorySource, packageManifest.DirectoryTarget, MetaDatas);
            this.copyPackage(packageManifest.PackageFile, packageManifest.DirectoryTarget);
        }

        private void validate(Dictionary<string, List<string>> mapPackage, List<IMetadata> MetaDatas)
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
        
        private void merge(string pathSource,string pathDir, List<IMetadata> MetaDatas)
        {
            ConsoleHelper.WriteDoneLine(">> Merging Metadata...");
            foreach (IMetadata m_Metadata in MetaDatas)
            {
                m_Metadata.doMerge();
            }
            //ManageXMLCustomObjectMerge mergeobject = ManageXMLCustomObjectMerge.getInstance();
            //mergeobject.defaultParameters(pathSource);
            //mergeobject.writeAllInstances(pathDir);

            //ManageXMLWorkflowMerge mergeworkflow = ManageXMLWorkflowMerge.getInstance();
            //mergeworkflow.defaultParameters(pathSource);
            //mergeworkflow.writeAllInstances(pathDir);
        }

        private void copyPackage(string path, string pathDir)
        {
            ConsoleHelper.WriteDoneLine(">> Copying package...");   
            ManageFileCopy.doCopy(path.Replace("package.xml", ""), pathDir, "package.xml");            
        }

        private void copy(string pathFiles, string pathDir, List<IMetadata> MetaDatas)
        {
            ConsoleHelper.WriteDoneLine(">> Copying Metadata...");
            foreach (IMetadata m_Metadata in MetaDatas)
            {
                m_Metadata.doCopy(pathFiles, pathDir);
            }
        }

        private List<IMetadata> createDirectory(Dictionary<string, List<string>> mapPackage, string pathDir)
        {
            ConsoleHelper.WriteDoneLine(">> Creating directories...");
            List<IMetadata> MetaDatas = ManageFileDirectory.buildDirectorys(mapPackage, pathDir);
            return MetaDatas;
        }

    }

}