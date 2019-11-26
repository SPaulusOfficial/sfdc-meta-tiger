using System;
using System.Collections.Generic;
using System.IO;
using MetaTiger.MetaTigerInterface;

namespace MetaTiger
{
    class Program
    {

        static void Main(string[] args)
        {
           if(args == null || args.Length == 0){
             MetaTigerProgramInterface.run();
           }else{
             MetaTigerProgramInterface.run(args);
           }
        }     
    }
    
}
