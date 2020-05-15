using System;
using System.Diagnostics;
    public static class StringHelper
    {
        public static string inverseBarLeft(this string str)
        {
            return str.Replace(@"\","/");
        }

        public static string inverseBarRight(this string str)
        {
            return str.Replace("/","\\");
        }

        public static string escapeForEmpty(this string str){
            return str.Replace("\\","");
        }

        public static Boolean isNullOrEmpty(this string str){
            return (str!="" && str!=null);
        }

    }