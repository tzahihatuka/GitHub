using System;

namespace events
{
    class Program
    {
        static void Main(string[] args)
        {

            Parson[] peopleArray = new Parson[7];
            Signature[] signatureArray= new Signature[7];






            for (int i = 0; i < peopleArray.Length; i++)
            {
                peopleArray[i]=new Parson();
            }
            peopleArray[0].FullName = "Bob Arnold";
            peopleArray[0].WantToSign = true;
            peopleArray[1].FullName = "Alice Avery";
            peopleArray[1].WantToSign = true;
            peopleArray[2].FullName = "Albert Bailey";
            peopleArray[2].WantToSign = true;
            peopleArray[3].FullName = "Matt Baker";
            peopleArray[3].WantToSign = false;
            peopleArray[4].FullName = "Carol Campbell";
            peopleArray[4].WantToSign = true;
            peopleArray[5].FullName = "Kevin Brown";
            peopleArray[5].WantToSign = false;
            peopleArray[6].FullName = "Lisa Bower";
            peopleArray[6].WantToSign = true;


            peopleArray[0].SignatureActions += (string s) => {
                return peopleArray[0].FullName.ToLower();
           
            };
            peopleArray[1].SignatureActions += (string s) => {
                return peopleArray[1].FullName.Replace(" ", string.Empty); ;

            };
            peopleArray[2].SignatureActions += (string s) => {
                string[] words;
                words = peopleArray[2].FullName.Split();
                string a = words[0];
                string b = words[1]; 
                return a[0].ToString() + b[0].ToString();

            };
            peopleArray[3].SignatureActions += (string s) => {
                string[] words;
                words = peopleArray[3].FullName.Split();
                string a = words[0];
                string b = words[1];
                return a[0].ToString() + " " + b;

            };
            peopleArray[4].SignatureActions += (string s) => {
                return peopleArray[4].FullName.ToUpper();

            };
            peopleArray[5].SignatureActions += (string s) => {
                return peopleArray[5].FullName.Replace(" ", "."); ;

            };
            peopleArray[6].SignatureActions += (string s) => {
                string[] words;
                words = peopleArray[6].FullName.Split();
                string a = words[0];
                return a.ToLower();
            };

            for (int i = 0; i < peopleArray.Length; i++)
            {
               signatureArray[i] =   new Signature(peopleArray[i].FullName, peopleArray[i].SignActions());
            }

            foreach (Signature item in signatureArray)
            {
                Console.WriteLine($"Full Name: {item.FullName}\nSignature: {item.FullSignature}\n\n");
            }
            
        }
       

    }
}
