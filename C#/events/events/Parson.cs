using System;

namespace events
{
    delegate string SignatureHandler(string subject);
    class Parson
    {
        public event SignatureHandler SignatureActions;

        public string FullName { get; set; }
        public Boolean WantToSign { get; set; }

        public string SignActions()

        {
            if (WantToSign)
            {
                if (SignatureActions != null)
                {
                    
                   return SignatureActions(FullName);

                }

            }


            return null;
        }
    }
}
