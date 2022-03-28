using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Demo.Shared.Extensions
{
    public static class Extension
    {
        public static bool IsValidGuid(string guidString)
        {
            // Length of a proper GUID, without any surrounding braces.
            const int len_without_braces = 36;

            // Delimiter for GUID data parts.
            const char delim = '-';

            // Delimiter positions.
            const int d_0 = 8;
            const int d_1 = 13;
            const int d_2 = 18;
            const int d_3 = 23;

            // Before Delimiter positions.
            const int bd_0 = 7;
            const int bd_1 = 12;
            const int bd_2 = 17;
            const int bd_3 = 22;

            if (guidString == null)
                return false;

            if (guidString.Length != len_without_braces)
                return false;

            if (guidString[d_0] != delim ||
                guidString[d_1] != delim ||
                guidString[d_2] != delim ||
                guidString[d_3] != delim)
                return false;

            for (int i = 0;
                i < guidString.Length;
                i = i + (i == bd_0 ||
                        i == bd_1 ||
                        i == bd_2 ||
                        i == bd_3
                        ? 2 : 1))
            {
                if (!IsHex(guidString[i])) return false;
            }

            return true;
        }

        private static bool IsHex(char c)
        {
            return ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'));
        }
        public static bool IsSocialSecurityNumber(this string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
