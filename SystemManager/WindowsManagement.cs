
using System;
using System.Collections.Generic;
using System.Text;


using System.Runtime.InteropServices;


namespace SystemManager
{

	public class OsXManagement : SystemManagement
	{
		// Black box
		// http://stackoverflow.com/questions/12523704/mac-os-x-equivalent-header-file-for-sysinfo-h-in-linux
	}


    public class WindowsManagement : SystemManagement
    {


		[DllImport("kernel32.dll")]
		private static extern bool SetComputerName(string lpComputerName);



		[DllImport("kernel32.dll")]
		private static extern int SetSuspendState(bool b1, bool b2, bool b3);


		public override string HostName
		{
			get
			{
				return Environment.MachineName;
			}
			set
			{
				// http://stackoverflow.com/questions/7646669/rename-computer-programmaticaly-c-sharp-net
				SetComputerName(value);
			}
		}


        public override void Standby()
        {
            // http://msdn.microsoft.com/en-us/library/aa373201(VS.85).aspx
			SetSuspendState(true,false,false); //SetSuspendState(TRUE, FALSE, FALSE);
		} // End Sub Standby


        public override void Shutdown()
        {
			throw new NotImplementedException();
            // http://www.daniweb.com/software-development/cpp/threads/182433/how-to-shutdown-your-computer-using-c
            //ExitWindowsEx(EWX_POWEROFF, SHTDN_REASON_MAJOR_OTHER);
            //system("shutdown /s /t 0");
            /*
            if( ! ExitWindowsEx(...))
            {
                // maybe lastError will tell something useful ...
                DWORD lastError = GetLastError();
            }
            */
		} // End Sub Shutdown


    } // End Class WindowsManagement


} // End Namespace SystemManager
