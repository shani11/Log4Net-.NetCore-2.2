using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


public static class LogFourNet
{
    // Define a static logger variable so that it references the
    private static readonly ILog Log = LogManager.GetLogger(typeof(LogFourNet));

    static LogFourNet()
     {
        var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        Log.Info("Log4net is configured.");
    }

    public static void Info(object currentObj, string msg, [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string caller = "", [CallerMemberName] string memberName = "")
    {
        Log.Info("[" + currentObj.GetType().Namespace + "." +
                 Path.GetFileNameWithoutExtension(caller) + "." + memberName + ":" + lineNumber + "] - " + msg);
    }

    public static void Debug(object currentObj, string msg, [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string caller = "", [CallerMemberName] string memberName = "")
    {
        Log.Debug("[" + currentObj.GetType().Namespace + "." +
                  Path.GetFileNameWithoutExtension(caller) + "." + memberName + ":" + lineNumber + "] - " + msg);
    }

    public static void Error(object currentObj, string msg, [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string caller = "", [CallerMemberName] string memberName = "")
    {
        Log.Error("[" + currentObj.GetType().Namespace + "." +
                  Path.GetFileNameWithoutExtension(caller) + "." + memberName + ":" + lineNumber + "] - " + msg);
    }
}