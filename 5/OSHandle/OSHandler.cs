using System;

namespace OSHandle
{
    class OSHandler: IDisposable
    {
        public int Handle { get; set; }

        ~OSHandler()
        {
            //Finalize ...
            Handle = 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            //Dispose ...
            Handle = 0;
        }
    }
}
