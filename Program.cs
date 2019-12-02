using System;
using System.Collections.Generic;
using System.IO;
using MetaTiger.Service;

namespace MetaTiger
{
    class Program
    {

        static void Main(string[] args)
        {
           if(args == null || args.Length == 0){
             ApresentationService.run();
           }else{
             ApresentationService.run(args);
           }
        }     
    }
    
}
