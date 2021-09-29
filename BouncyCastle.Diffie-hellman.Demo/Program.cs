﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyCastle.Diffie_hellman.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Public Key Alice
            var pubAlice = @"-----BEGIN PUBLIC KEY-----
MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEOkLo3q6MN3XS5xlY3OowqMkvPrYz
j4hLVJ2Wkuob3KQb1QidaAQsJ6Azy0yTuBanL4iy+dewA3YjejBMZEoh6w==
-----END PUBLIC KEY-----
";
            // EC-Private Key Alice
            var priAlice = @"-----BEGIN EC PRIVATE KEY-----
MHcCAQEEIC9LMxwIwKThjtaUAJbJBCU0vFa+H8G98p/Z9JLYmEehoAoGCCqGSM49
AwEHoUQDQgAEOkLo3q6MN3XS5xlY3OowqMkvPrYzj4hLVJ2Wkuob3KQb1QidaAQs
J6Azy0yTuBanL4iy+dewA3YjejBMZEoh6w==
-----END EC PRIVATE KEY-----
";

            // Public Key Bob
            var pubBob = @"-----BEGIN PUBLIC KEY-----
MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEnDMGlBFH7jbHHAYgdPR7247xqzRF
Y1HFy4HfejSgUKBxgj6biZUwSbNKuino7ObZnqrnJayWJZ7f4Eb6XuT6yQ==
-----END PUBLIC KEY-----
";

            // EC-Private Key Bob
            var priBob = @"-----BEGIN EC PRIVATE KEY-----
MHcCAQEEIGqA4f7o5oBF5FgEQtNmz6fWKg/OcPPUORMX3uRc7sduoAoGCCqGSM49
AwEHoUQDQgAEnDMGlBFH7jbHHAYgdPR7247xqzRFY1HFy4HfejSgUKBxgj6biZUw
SbNKuino7ObZnqrnJayWJZ7f4Eb6XuT6yQ==
-----END EC PRIVATE KEY-----
";

            var secretAlice = DiffieHellmanKeyAgreementUtil.GetPairKey(priAlice, pubBob);
            var secretBob = DiffieHellmanKeyAgreementUtil.GetPairKey(priBob, pubAlice);


            Console.WriteLine($"secretAlice: {secretAlice}");
            Console.WriteLine($"secretBob: {secretBob}");
            Console.ReadKey();
        }
    }
}
