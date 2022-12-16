namespace OTPServices.ServiceHelper
{
    public class TOTPLog
    {
        private readonly long _timeStamp;
        public TOTPLog(long timeStamp)
        {
            _timeStamp = timeStamp;
        }
        #region WriteLogMessage
        public void WriteLogMessage(string logMessage)
        {
            StreamWriter log;
            FileStream? fileStream = null;
            DirectoryInfo? logDirInfo = null;
            FileInfo logFileInfo;
            string logFilePath = Environment.CurrentDirectory+"\\Logs\\";
            logFilePath = logFilePath + DateTime.Today.ToString("MM-dd-yyyy") + "-" + _timeStamp.ToString() + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.Write("\r\n--------------------------------------------------------------------------------------------");
            log.Write("\r\nLog Details : {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            log.Write("\r\nLog Message : {0}", logMessage);
            log.Write("\r\n--------------------------------------------------------------------------------------------");
            log.Close();
        }
        #endregion End WriteLogMessage
    }
}
