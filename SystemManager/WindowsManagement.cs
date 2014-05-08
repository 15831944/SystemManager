
using System;
using System.Collections.Generic;
using System.Text;


namespace SystemManager
{


    public class WindowsManagement : SystemManagement
    {


        public override void Standby()
        {
            throw new NotImplementedException();
            // http://msdn.microsoft.com/en-us/library/aa373201(VS.85).aspx
            //SetSuspendState(TRUE, FALSE, FALSE);
        }


        public override void Shutdown()
        {
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
        }


    } // End Class WindowsManagement


} // End Namespace SystemManager
