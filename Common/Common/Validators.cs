using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Zch.Common
{
    public class Validators
    {
        private readonly int[] _ValidNums = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
        private int _Sum;

        public bool ValidateNip(string Nip)
        {
            if (!Regex.IsMatch(Nip, @"^[\d]{10}$"))
                return false;
            _Sum = 0;
            for (int t = 8; t >= 0; t--)
                _Sum += (_ValidNums[t]) * Convert.ToInt32(Nip.Substring(t, 1));
            return ((_Sum % 11) == 10 ? false : ((_Sum % 11) == Convert.ToInt32(Nip.Substring(9, 1))));
        }
        public bool ValidateRegon(ref string szRegon)
        {
            byte[] tab8 = new byte[8] { 8, 9, 2, 3, 4, 5, 6, 7 };
            byte[] tab13 = new byte[13] { 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 };
            byte[] tablicz = new byte[] { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57 };
            bool bResult = false;
            int suma = 0;
            int sumcontrol = 0;

            szRegon = szRegon.Trim();

            if ((szRegon.Length == 9) || (szRegon.Length == 14))
            {
                foreach (char l in szRegon)
                {
                    byte b = Convert.ToByte(l);
                    if (Array.IndexOf(tablicz, Convert.ToByte(l)) == -1) return false;
                }

                sumcontrol = Convert.ToInt32(szRegon[(szRegon.Length == 9) ? 8 : 13].ToString());

                for (int i = 0; i < ((szRegon.Length == 9) ? 8 : 13); i++)
                {
                    suma += ((szRegon.Length == 9) ? tab8[i] : tab13[i]) * Convert.ToInt32(szRegon[i].ToString());
                }

                bResult = ((((suma % 11) != 10) ? (suma % 11) : 0) == sumcontrol);
            }
            else return false;

            return bResult;
        }
        public bool ValidatePesel(ref string szPesel)
        {
            byte[] tab = new byte[10] { 9, 7, 3, 1, 9, 7, 3, 1, 9, 7 };
            byte[] tablicz = new byte[] { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57 };
            bool bResult = false;
            int suma = 0;
            int sumcontrol = 0;

            szPesel = szPesel.Trim();

            if (szPesel.Length == 11)
            {
                foreach (char l in szPesel)
                {
                    byte b = Convert.ToByte(l);
                    if (Array.IndexOf(tablicz, Convert.ToByte(l)) == -1) return false;
                }

                sumcontrol = Convert.ToInt32(szPesel[10].ToString());

                for (int i = 0; i < 10; i++)
                {
                    suma += tab[i] * Convert.ToInt32(szPesel[i].ToString());
                }

                bResult = ((suma % 10) == sumcontrol);

                if (bResult)
                {
                    int rok = 0;
                    int mies = 0;
                    int dzien = Convert.ToInt32(szPesel[4].ToString()) * 10 + Convert.ToInt32(szPesel[5].ToString());

                    if (szPesel[2] == '0' || szPesel[2] == '1')
                    {
                        rok = 1900;
                        mies = Convert.ToInt32(szPesel[2].ToString()) * 10 + Convert.ToInt32(szPesel[3].ToString());
                    }
                    else if (szPesel[2] == '2' || szPesel[2] == '3')
                    {
                        rok = 2000;
                        mies = (Convert.ToInt32(szPesel[2].ToString()) * 10 + Convert.ToInt32(szPesel[3].ToString()) - 20);
                    }
                    else if (szPesel[2] == '4' || szPesel[2] == '5')
                    {
                        rok = 2100;
                        mies = (Convert.ToInt32(szPesel[2].ToString()) * 10 + Convert.ToInt32(szPesel[3].ToString()) - 40);
                    }
                    else if (szPesel[2] == '6' || szPesel[2] == '7')
                    {
                        rok = 2200;
                        mies = (Convert.ToInt32(szPesel[2].ToString()) * 10 + Convert.ToInt32(szPesel[3].ToString()) - 60);
                    }
                    else if (szPesel[2] == '8' || szPesel[2] == '9')
                    {
                        rok = 1800;
                        mies = (Convert.ToInt32(szPesel[2].ToString()) * 10 + Convert.ToInt32(szPesel[3].ToString()) - 80);
                    }
                    rok += Convert.ToInt32(szPesel[0].ToString()) * 10 + Convert.ToInt32(szPesel[1].ToString());
                    String szDate = rok.ToString() + "-" + (mies < 10 ? "0" + mies.ToString() : mies.ToString()) + "-" + (dzien < 10 ? "0" + dzien.ToString() : dzien.ToString());
                    DateTime dt;
                    bResult = DateTime.TryParse(szDate, out dt);
                }
            }
            else return false;

            return bResult;
        }
        public bool ValidateDO(ref string szNR, bool retFormated = true)
        {
            byte[] tab = new byte[9] { 7, 3, 1, 9, 7, 3, 1, 7, 3 };
            byte[] tablicz = new byte[] { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57 };

            bool bResult = false;
            int sumcontrol = 0;
            int sum = 0;

            szNR = szNR.Trim().Replace(" ", "");

            if (szNR.Length == 9)
            {
                byte b;

                for (int i = 0; i < 3; i++)
                {
                    b = Convert.ToByte(szNR[i]);
                    if (b < 65 || b > 90) return false;
                }
                for (int i = 3; i < 9; i++)
                {
                    b = Convert.ToByte(szNR[i]);
                    if (b < 48 || b > 57) return false;
                }

                sumcontrol = Convert.ToInt32(szNR[3].ToString());

                for (int i = 0; i < 9; i++)
                {
                    if (i < 3)
                    {
                        sum += (Convert.ToByte(szNR[i]) - 55) * tab[i];
                    }
                    else
                    {
                        sum += Convert.ToInt32(szNR[i].ToString()) * tab[i];
                    }
                }

                bResult = ((sum % 10) == 0);

            }
            else return false;

            if (bResult && retFormated)
            {
                szNR = szNR.Insert(3, " ");
            }

            return bResult;
        }
        [Obsolete]
        private bool ValidateIBAN_NRB(ref string szNR, bool retFormated = true)
        {
            bool bResult = false;

            szNR = szNR.Trim()
                        .Replace(" ", "")
                        .Replace("-", "");

            if (szNR.Length == 26 || szNR.Length == 28)
            {
                string nr = szNR;
                if (nr.Length == 26)
                {
                    nr = (nr + "PL" + nr.Substring(0, 2)).Remove(0, 2);
                }
                else
                {
                    nr = (nr + nr.Substring(0, 4)).Remove(0, 4);
                }

                nr = nr.Replace("P", "25").Replace("L", "21");

                String nr6 = nr.Substring(0, 6);
                String nr12 = nr.Substring(6, 6);
                String nr18 = nr.Substring(12, 6);
                String nr24 = nr.Substring(18, 6);
                String nr30 = nr.Substring(24);

                int r = Convert.ToInt32(nr6) % 97;
                nr12 = (r > 0 ? r.ToString() : "") + nr12;
                r = Convert.ToInt32(nr12) % 97;
                nr18 = (r > 0 ? r.ToString() : "") + nr18;
                r = Convert.ToInt32(nr18) % 97;
                nr24 = (r > 0 ? r.ToString() : "") + nr24;
                r = Convert.ToInt32(nr24) % 97;
                nr30 = (r > 0 ? r.ToString() : "") + nr30;

                bResult = (Convert.ToInt32(nr30) % 97 == 1);
            }
            else return false;

            if (bResult && retFormated)
            {
                if (szNR.Length == 26)
                {
                    szNR = szNR.Insert(22, " ").Insert(18, " ").Insert(14, " ").Insert(10, " ").Insert(6, " ").Insert(2, " ");
                }
                else
                {
                    szNR = szNR.Insert(24, " ").Insert(20, " ").Insert(16, " ").Insert(12, " ").Insert(8, " ").Insert(4, " ");
                }
            }

            return bResult;
        }
        public bool IsIbanChecksumValid(string iban)
        {
            if (string.IsNullOrEmpty(iban))
                return false;

            if (iban.Length < 4 || iban[0] == ' ' || iban[1] == ' ' || iban[2] == ' ' || iban[3] == ' ') throw new InvalidOperationException();

            var checksum = 0;
            var ibanLength = iban.Length;
            for (int charIndex = 0; charIndex < ibanLength; charIndex++)
            {
                if (iban[charIndex] == ' ') continue;

                int value;
                var c = iban[(charIndex + 4) % ibanLength];
                if ((c >= '0') && (c <= '9'))
                {
                    value = c - '0';
                }
                else if ((c >= 'A') && (c <= 'Z'))
                {
                    value = c - 'A';
                    checksum = (checksum * 10 + (value / 10 + 1)) % 97;
                    value %= 10;
                }
                else if ((c >= 'a') && (c <= 'z'))
                {
                    value = c - 'a';
                    checksum = (checksum * 10 + (value / 10 + 1)) % 97;
                    value %= 10;
                }
                else throw new InvalidOperationException();

                checksum = (checksum * 10 + value) % 97;
            }
            return checksum == 1;
        }
    }
}