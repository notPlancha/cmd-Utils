using System;
using System.Linq;

namespace Utils {
    public static class Utils {
        public static int InputToInt(string str) {
            string input;
            int ret;
            do {
                Console.WriteLine(str);
                input = Console.ReadLine();
            } while (int.TryParse(input, out ret) == false);
            return ret;
        }
        public static bool DoubleIs0(double a, string str = null) {
            if (a == 0) {
                Console.Write(str);
                return true;
            } else return false;
        }
        public static double InputToDouble(string str) {
            string input;
            double ret;
            do {
                Console.WriteLine(str);
                input = Console.ReadLine();
            } while (double.TryParse(input, out ret) == false);
            return ret;
        }
        public static void InputToArray(string str, ref double[] arra, bool formatedString = false) {
            for (int i = 0; i < arra.Length; i++) {
                arra[i] = formatedString ? InputToDouble(String.Format(str, i + 1)) : InputToDouble(str);
            }
            foreach (int i in arra) {
                if (i != 0) return;
            }
            throw new AllInputsAre0();
        }
        public static string InputsToKey(string question, string[] options, bool cycleUntilValidNUmber = true, bool clear = true) {
            string ret; int number;
            do {
                if (clear) Console.Clear();
                Console.WriteLine(question);
                if (options.Length > 0) {
                    for (int i = 1; i <= options.Length; i++) {
                        if (options[i - 1] != null)
                            Console.WriteLine(String.Format("{0} - {1}", i, options[i - 1]));
                    }
                    ret = Console.ReadKey(intercept: true).KeyChar.ToString();
                } else { return "1"; }
            } while (cycleUntilValidNUmber ? int.TryParse(ret, out number) && number <= options.Length : false);
            return ret;
        }
        public static ConsoleKey InputsToKey(string question, string[] keysToCheck, string[] options, bool cycleUntilValidNUmber = true, bool clear = true) {
            ConsoleKey ret; int number;
            do {
                if (clear) Console.Clear();
                Console.WriteLine(question);
                if (options.Length > 0) {
                    for (int i = 0; i < keysToCheck.Length; i++) {
                        if (keysToCheck[i] != null)
                            Console.WriteLine(String.Format("{0} - {1}", keysToCheck[i].ToString(), options[i]));
                    }
                    ret = Console.ReadKey(intercept: true).Key;
                } else { return new ConsoleKey(); }
            } while (cycleUntilValidNUmber ? keysToCheck.Contains(ret.ToString()) : false);
            return ret;
        }
        public static ConsoleKey InputsToKey(string question, ConsoleKey[] keysToCheck, string[] options, bool cycleUntilValidNUmber = true, bool clear = true) {
            ConsoleKey ret;
            if (clear) Console.Clear();
            Console.WriteLine(question);
            if (options.Length > 0) {
                for (int i = 0; i < keysToCheck.Length; i++) {
                    if (keysToCheck[i] == default) continue;
                    Console.WriteLine(String.Format("{0} - {1}", keysToCheck[i].ToString(), options[i]));
                }
            } else { return new ConsoleKey(); }
            do {
                ret = Console.ReadKey(intercept: true).Key;
            } while (cycleUntilValidNUmber ? !keysToCheck.Contains(ret) : false);
            return ret;
        }
        public static bool ValidKey(ConsoleKey key, string[] options) {
            foreach (string option in options) {
                if (key.ToString() == option) return true;
            }
            return false;
        }
        public static bool ValidKey(ConsoleKey key, ConsoleKey[] options) {
            foreach (ConsoleKey option in options) {
                if (key.Equals(option)) return true; //maybe doesnt work
            }
            return false;
        }
        public static bool ValidKey(string key, string[] options) {
            if (options.All(key.Contains)) {
                return true;
            } else return false;
        }
        public static ConsoleKey InputToKey(string message, bool inter = true) {
            Console.WriteLine(message);
            return Console.ReadKey(intercept: inter).Key;
        }

    }

    public class AllInputsAre0 : Exception {
        public AllInputsAre0(string message = "All inputs are 0") : base(message) {

        }

    }
}
