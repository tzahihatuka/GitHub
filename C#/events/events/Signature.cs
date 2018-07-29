
namespace events
{
    internal class Signature
    {
        public string FullName { get; set; }
        public string FullSignature { get; set; }

        public Signature(string fullName, string fullSignature)
        {
            this.FullSignature = fullSignature;
            this.FullName = fullName;
        }
    }
}