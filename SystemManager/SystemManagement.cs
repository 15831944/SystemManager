
using System;
using System.Collections.Generic;
using System.Text;


namespace SystemManager
{


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
