using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testeSoftware.Model;

namespace testeSoftware.Controllers {
    public class Calculo {

        public static Contribuinte CalcIRPF(Contribuinte contribuinte) {

            if (contribuinte == null) {
                return null;
            }

            if (contribuinte.Salario <= 0 || contribuinte.Dependentes < 0) return null;

            Double baseINSSCalculo = CalcBase(contribuinte);

            if (baseINSSCalculo <= 1903.98)
                contribuinte.ValorIR = 0;

            else if (baseINSSCalculo > 1903.99 && baseINSSCalculo <= 2826.65)
                contribuinte.ValorIR = Math.Round( (baseINSSCalculo * 0.075) - 142.80 ,2);

            else if (baseINSSCalculo > 2826.65 && baseINSSCalculo <= 3751.05)
                contribuinte.ValorIR = Math.Round ( (baseINSSCalculo * 0.15) - 354.8 ,2);

            else if (baseINSSCalculo > 3751.05 && baseINSSCalculo <= 4664.68)
                contribuinte.ValorIR = Math.Round ( (baseINSSCalculo * 0.225) - 636.13 ,2);

            else if (baseINSSCalculo > 4664.68)
                contribuinte.ValorIR = Math.Round ( (baseINSSCalculo * 0.275) - 869.36 ,2);


            return contribuinte;

        }

        public static Double CalcBase(Contribuinte contribuinte) {

            Double baseINSS = 0;
            if (contribuinte.Salario <= 1751.81)
                baseINSS = contribuinte.Salario - (contribuinte.Salario * 0.08);

            else if (contribuinte.Salario >= 1751.82 && contribuinte.Salario <= 2919.72)
                baseINSS = contribuinte.Salario - (contribuinte.Salario * 0.09);

            else if (contribuinte.Salario >= 2919.73 && contribuinte.Salario <= 5839.45)
                baseINSS = contribuinte.Salario - (contribuinte.Salario * 0.11);

            else if (contribuinte.Salario > 5839.45)
                baseINSS = contribuinte.Salario - (5839.45 * 0.11);

            return (baseINSS - (contribuinte.Dependentes * 189.59));
        }

    }
}
