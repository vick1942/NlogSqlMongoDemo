using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLogDemo
{
    public class Program
    {
        //Steps to install NLOG.MONGO 
        //Step 1 : Install Install-Package NLog.Mongo in the Package Manager console
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Logger loggerMongo = LogManager.GetLogger("databaseLoggerMongo");
        private static Logger loggersql = LogManager.GetLogger("databaseLoggerSQL");
        //Go through this website for mongo
        //Install Install-Package NLog.Mongo this
        //https://github.com/loresoft/NLog.Mongo
        static void Main(string[] args)
        {
            try
            {
                logger.Trace("Sample trace message in the NLOG File");
                logger.Debug("Sample debug message in FIle");
                int zero = 0;
                loggersql.Debug("Sample debug message in SQL");
                loggersql.Warn("Sample warning message in SQL ");
                loggersql.Fatal("Sample fatal message in SQL");
                int result = 5 / zero;
            }
            catch (DivideByZeroException ex)
            {

                // add custom message and pass in the exception
                loggerMongo.Error(ex, "Mongo Error !! Whoops!");
                loggersql.Error(ex, "Error message in the SQL ");
                loggersql.Info("Sample info message in the SQL");
            }
            //FILE AND SQL
            logger.Debug("Log debug in file");
        }
    }
}


//Table log and Sp
//create table[dbo].[Logs]
//(

//[LogId][int] IDENTITY(1,1) not null,
//	[Level] [varchar] (max) not null,
//	[CallSite] [varchar] (max) not null,
//	[Type] [varchar] (max) not null,
//	[Message] [varchar] (max) not null,
//	[StackTrace] [varchar] (max) not null,
//	[InnerException] [varchar] (max) not null,
//	[AdditionalInfo] [varchar] (max) not null,
//	[LoggedOnDate] [datetime] not null constraint[df_logs_loggedondate]  default (getutcdate()),

//	constraint[pk_logs] primary key clustered
//   (
//       [LogId]

//   )
//)

//GO

//select* from Logs

//Create procedure[dbo].[InsertLog]
//(
//  @level varchar(max),
//	@callSite varchar(max),
//	@type varchar(max),
//	@message varchar(max),
//	@stackTrace varchar(max),
//	@innerException varchar(max),
//	@additionalInfo varchar(max)
//)
//as

//insert into dbo.Logs
//(

//    [Level],
//    CallSite,

//    [Type],

//    [Message],
//    StackTrace,
//    InnerException,
//    AdditionalInfo
//)
//values
//(
//    @level,
//    @callSite,
//    @type,
//    @message,
//    @stackTrace,
//    @innerException,
//    @additionalInfo
//)

//go