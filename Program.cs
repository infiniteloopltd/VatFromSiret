using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace VatFromSiret
{
    class Program
    {
        static void Main(string[] args)
        {
            var vat = VatFromSiret("34877056100077");
            Debug.Assert(vat == "XFR49348770561");
        }

        public static string VatFromSiret(string siret)
        {
            // const validation = (12 + 3 * (parseInt(number, 10) % 97)) % 97
            if (siret.Length > 9) siret = siret.Substring(0, 9); // siren
            var numSiret = Convert.ToInt32(siret);
            var validation = (12 + 3 * (numSiret % 97)) % 97;
            return "FR" + validation + siret;
        }
    }
}
