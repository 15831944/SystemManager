﻿
using System;
using System.Collections.Generic;
using System.Text;


namespace SystemManager
{


	public class LinuxManagement : SystemManagement
	{

		private const string LibcIsAFreakingTextFile = @"/lib/x86_64-linux-gnu/libc.so.6";

		[System.Runtime.InteropServices.DllImport(LibcIsAFreakingTextFile)]
		private static extern int reboot(RebootFlags cmd);


		public enum RebootFlags : uint
		{
			// This means that the
			// CAD keystroke will cause a SIGINT signal to be sent to init
			// (process 1), whereupon this process may decide upon a proper
			// action (maybe: kill all processes, sync, reboot).
			LINUX_REBOOT_CMD_CAD_OFF = 0 // RB_DISABLE_CAD


				,
			// This means that
			// the CAD keystroke will immediately cause the action associated
			// with LINUX_REBOOT_CMD_RESTART.
			LINUX_REBOOT_CMD_CAD_ON = 0x89abcdef // RB_ENABLE_CAD


				,
			//The message "System halted." is printed, and the system is halted.
			// Control is given to the ROM monitor, if there is one.  If not
			// preceded by a sync(2), data will be lost.
			LINUX_REBOOT_CMD_HALT = 0xcdef0123 // RB_HALT_SYSTEM; since Linux 1.1.76


				,
			// Execute a kernel that has been loaded earlier with kexec_load(2).  
			// This option is available only if the kernel was configured with
			// CONFIG_KEXEC.
			LINUX_REBOOT_CMD_KEXEC = 0x45584543 // RB_KEXEC; since Linux 2.6.13


				, 
			// The message "Power down." is printed, the system is stopped, and all power
			// is removed from the system, if possible.  If not preceded by a
			// sync(2), data will be lost.
			LINUX_REBOOT_CMD_POWER_OFF = 0x4321fedc // RB_POWER_OFF; since Linux 2.1.30


				,
			// The message "Restarting system." is
			// printed, and a default restart is performed immediately.  If
			// not preceded by a sync(2), data will be lost.
			LINUX_REBOOT_CMD_RESTART = 0x1234567 // RB_AUTOBOOT


				,
			// The message "Restarting system with command '%s'" is printed, 
			// and a restart (using the command string given in arg) 
			// is performed immediately.  If not preceded by a sync(2), data will be lost.
			LINUX_REBOOT_CMD_RESTART2 = 0xa1b2c3d4 // since Linux 2.1.30


				,
			// The system is suspended (hibernated) to disk.  
			// This option is available only if the kernel 
			// was configured with CONFIG_HIBERNATION.
			LINUX_REBOOT_CMD_SW_SUSPEND = 0xd000fce1 // RB_SW_SUSPEND; since Linux 2.5.18

		} // End Enum RebootFlags



		public override void Restart()
		{
			// http://stackoverflow.com/questions/2678766/how-to-restart-linux-from-inside-a-c-program
			//sync();
			//setuid (0);
			reboot(RebootFlags.LINUX_REBOOT_CMD_RESTART);

			//reboot(RB_POWER_OFF);
		}

		public override string HostName
		{
			get{ 
				return Environment.MachineName;
			}
			set{ 
				//#include <unistd.h>
				//http://stackoverflow.com/questions/12490622/where-is-c-size-t-defined-in-linux
				// http://stackoverflow.com/questions/504810/how-do-i-find-the-current-machines-full-hostname-in-c-hostname-and-domain-info
				// http://stackoverflow.com/questions/7646669/rename-computer-programmaticaly-c-sharp-net
				// int gethostname(char* name, size_t len);
				// int sethostname(const char* name, size_t len);
				// int gethostname(string name, System.IntPtr len);
				// int sethostname(string name, System.IntPtr len);
				throw new NotImplementedException ();
			}
		}


	}


	public class WindowsManagement : SystemManagement
	{


		public override void Standby()
		{
			throw new NotImplementedException ();
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

	}

    public abstract class SystemManagement
    {


        public virtual string HostName
        {
			get
			{ 
				return System.Environment.MachineName;
			}
            
			set
			{ 
				throw new NotImplementedException ();
			}

        }


        public virtual void pkill(string name)
        { 
			throw new NotImplementedException ();
		}


        public virtual void Standby()
        {
			throw new NotImplementedException ();
        }


        public virtual void Hibernate()
        { 
			throw new NotImplementedException ();
		}


        public virtual void Shutdown()
        {
			throw new NotImplementedException ();
        }


        public virtual void Restart()
        {
			throw new NotImplementedException ();
        }


    } // End abstract class SystemManagement


} // End Namespace SystemManager
