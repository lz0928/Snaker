/**
*
*	Title:  Snaker
*			主题： xxx
*	Description:
*			功能： yyy
*
*	Data:	2017
*	Version：0.1版本
*	MOdify Recoder
*
*/

using System;
using System.Diagnostics;
using System.IO;


namespace OT.Foundation{

	public class Debuger {
        public static bool EnableLog;
        public static bool EnableLogLoop;
        public static bool EnableTime = true;
        public static bool EnableSave = false;
        public static bool EnableStack = false;
        public static string LogFileDir = "";
        public static string LogFileName = "";
        public static string Prefix = "> ";
        public static StreamWriter LogFileWriter = null;
        public static bool UseUnityEngine = true;

        public static void Init()
        {
            if (UseUnityEngine)
            {
                LogFileDir = UnityEngine.Application.persistentDataPath + "/DebugerLog/";
            }
            else
            {
                string path = System.AppDomain.CurrentDomain.BaseDirectory;
                LogFileDir = path + "/DebugerLog/";
            }
        }

        private static void Internal_Log(string msg, object context = null)
        {
            if (UseUnityEngine)
            {
                UnityEngine.Debug.Log(msg, (UnityEngine.Object)context);
            }
            else
            {
                Console.WriteLine(msg);
            }
        }

        private static void Internal_LogWarning(string msg, object context = null)
        {
            if (UseUnityEngine)
            {
                UnityEngine.Debug.LogWarning(msg, (UnityEngine.Object)context);
            }
            else
            {
                Console.WriteLine(msg);
            }
        }

        private static void Internal_LogError(string msg, object context = null)
        {
            if (UseUnityEngine)
            {
                UnityEngine.Debug.LogError(msg, (UnityEngine.Object)context);
            }
            else
            {
                Console.WriteLine(msg);
            }
        }

        //----------------------------------------------------------------------
        public static void LogLoop(string tag, string methodName, string message = "")
        {
            if (!Debuger.EnableLogLoop)
            {
                return;
            }

            message = GetLogText(tag, methodName, message);
            Internal_Log(Prefix + message);
            
        }



        //----------------------------------------------------------------------
        private static string GetLogText(string tag, string methodName, string message)
        {
            string str = "";
            if (Debuger.EnableTime)
            {
                DateTime now = DateTime.Now;
                str = now.ToString("HH:mm:ss.fff") + " ";//添加log时间
            }

            str = str + tag + "::" + methodName + "() " + message;
            return str;
        }

        //----------------------------------------------------------------------
    }
}
