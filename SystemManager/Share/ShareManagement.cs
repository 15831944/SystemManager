
using Trinet.Networking;


namespace SimpleTests
{


    class ShareManagement
    {

        /*
        [System.Runtime.InteropServices.DllImport("Netapi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        private static extern int NetShareEnum(
             System.Text.StringBuilder ServerName,
             int level,
             ref System.IntPtr bufPtr,
             uint prefmaxlen,
             ref int entriesread,
             ref int totalentries,
             ref int resume_handle
             );
        */



        public static System.Collections.Generic.List<Share> ListShares()
        {
            System.Collections.Generic.List<Share> ls = new System.Collections.Generic.List<Share>();

            try
            {
                ShareCollection shi = ShareCollection.LocalShares;
                if (shi == null)
                    return ls;

                foreach (Share si in shi)
                    ls.Add(si);
            }
            catch (System.Exception ex)
            {
                // Silently ignore errors. Just don't crash.
                System.Diagnostics.Debug.WriteLine(System.Environment.NewLine);
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }

            return ls;
        } // End Function ListShares 


        public static void ListShareInfo()
        {
            System.Console.WriteLine(System.Environment.NewLine + "Shares on local computer:");
            ShareCollection shi = ShareCollection.LocalShares;
            if (shi != null)
            {
                foreach (Share si in shi)
                {
                    System.Console.WriteLine("{0}: {1} [{2}]", si.ShareType, si, si.Path);

                    // If this is a file-system share, try to
                    // list the first five subfolders.
                    // NB: If the share is on a removable device,
                    // you could get "Not ready" or "Access denied"
                    // exceptions.

                    if (si.IsFileSystem)
                    {
                        try
                        {
                            System.IO.DirectoryInfo d = si.Root;
                            System.IO.DirectoryInfo[] Flds = d.GetDirectories();
                            for (int i = 0; i < Flds.Length && i < 5; i++)
                                System.Console.WriteLine("\t{0} - {1}", i, Flds[i].FullName);

                            System.Console.WriteLine();
                        }
                        catch (System.Exception ex)
                        {
                            System.Console.WriteLine("\tError listing {0}:\n\t{1}\n", si, ex.Message);
                        }
                    }
                }
            }
            else
                System.Console.WriteLine("Unable to enumerate the local shares.");
        }
    }


}
