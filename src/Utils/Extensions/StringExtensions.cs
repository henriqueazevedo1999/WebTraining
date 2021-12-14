using System.Globalization;
using System.Text.RegularExpressions;

namespace Utils.Extensions;

public static class StringExtensions
{
	public static bool IsValidCPF(this string cpf)
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
		tempCpf += digito;
		soma = 0;
		for (int i = 0; i < 10; i++)
			soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
		resto = soma % 11;
		if (resto < 2)
			resto = 0;
		else
			resto = 11 - resto;
		digito += resto.ToString();
		return cpf.EndsWith(digito);
	}

	public static string Normatize(this string name)
    {
		name.Trim();
		name = Regex.Replace(name, @"\s+", " ");
		TextInfo textInfo = new CultureInfo("pt-br", false).TextInfo;
		return textInfo.ToTitleCase(name);
    }

	public static string RemoveMask(this string field)
    {
		return field.Replace(".", "")
					.Replace(",", "")
					.Replace(",", "")
					.Replace("-", "")
					.Replace("(", "")
					.Replace(")", "")
					.Replace("_", "");
	}

	public static string FormatAsCPF(this string cpf)
    {
		return cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
	}
}
