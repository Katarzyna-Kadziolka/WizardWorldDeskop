using System.Text.RegularExpressions;

namespace WizardWorldDesktop.Extensions; 

public static class StringExtensions {
    public static string ToSentence(this string s) {
        return Regex.Replace(s, "(\\B[A-Z])", " $1");
    }

    public static string RemoveSpaces(this string s) {
        return s.Replace(" ", "");
    }
}