using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using testeSoftware.Controllers;
using testeSoftware.Model;

namespace TrbTesteUnitTestes {
    class CalcIRPFTest {

        [SetUp]
        public void Setup() {

        }

        [Test]
        public void Calc_irpf_contribuinte_null() {

            var contribuinteMock = Calculo.CalcIRPF(new Contribuinte());

            Assert.IsNull(contribuinteMock, "Objeto nulo");
        }

        [Test]
        public void Calc_irpf_dependentes_menor_zero() {
            var contribuinteSalario = new Contribuinte() { Salario = 2000, Dependentes = -1 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.IsNotNull(contribuinteMock, "Dependente menor que zero");
        }

        [Test]
        public void Calc_irpf_salario_menor_zero() {

            var contribuinteSalario = new Contribuinte() { Salario = -5 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.IsNull(contribuinteMock, "Salario maior que zero");

            contribuinteSalario.Salario = 0;
            contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.IsNull(contribuinteMock, "Salario maior que zero");

            contribuinteSalario.Salario = 1500;
            contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.IsNotNull(contribuinteMock, "Salario maior que zero");
        }

        [Test]
        public void Calc_irpf_isento() {
            var contribuinteSalario = new Contribuinte() { Salario = 1800, Dependentes = 1 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.AreEqual(contribuinteMock.ValorIR, 0, "Salário não isento");

            contribuinteSalario.Salario = 3000;
            contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.AreEqual(contribuinteMock.ValorIR, 0, "Salário não isento");
        }

        [Test]
        public void Calc_irpf_1_salario_ok() {
            var contribuinteSalario = new Contribuinte() { Salario = 2900, Dependentes = 1 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.AreEqual(contribuinteMock.ValorIR, Math.Round(40.91,2), "Salário fora da faixa");

        }

        [Test]
        public void Calc_irpf_1_salario_acima() {
            var contribuinteSalario = new Contribuinte() { Salario = 3500, Dependentes = 1 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.AreEqual(contribuinteMock.ValorIR, Math.Round(40.91, 2), "Salário acima da faixa");

        }

        [Test]
        public void Calc_irpf_1_salario_abaixo() {
            var contribuinteSalario = new Contribuinte() { Salario = 1500, Dependentes = 1 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.AreEqual(contribuinteMock.ValorIR, Math.Round(40.91, 2), "Salário abaixo da faixa");

        }

        [Test]
        public void Calc_irpf_2_salario_ok() {
            var contribuinteSalario = new Contribuinte() { Salario = 3500, Dependentes = 1 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.AreEqual(contribuinteMock.ValorIR, Math.Round(84.01, 2), "Salário fora da faixa");

        }

        [Test]
        public void Calc_irpf_2_salario_acima() {
            var contribuinteSalario = new Contribuinte() { Salario = 4500, Dependentes = 1 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.AreEqual(contribuinteMock.ValorIR, Math.Round(84.01, 2), "Salário acima da faixa");

        }

        [Test]
        public void Calc_irpf_2_salario_abaixo() {
            var contribuinteSalario = new Contribuinte() { Salario = 1500, Dependentes = 1 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.AreEqual(contribuinteMock.ValorIR, Math.Round(84.01, 2), "Salário abaixo da faixa");

        }

        [Test]
        public void Calc_irpf_3_salario_ok() {
            var contribuinteSalario = new Contribuinte() { Salario = 4500, Dependentes = 1 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.AreEqual(contribuinteMock.ValorIR, Math.Round(222.34, 2), "Salário fora da faixa");

        }

        [Test]
        public void Calc_irpf_3_salario_acima() {
            var contribuinteSalario = new Contribuinte() { Salario = 5500, Dependentes = 1 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.AreEqual(contribuinteMock.ValorIR, Math.Round(222.34, 2), "Salário acima da faixa");

        }

        [Test]
        public void Calc_irpf_3_salario_abaixo() {
            var contribuinteSalario = new Contribuinte() { Salario = 1500, Dependentes = 1 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.AreEqual(contribuinteMock.ValorIR, Math.Round(222.34, 2), "Salário abaixo da faixa");

        }

        [Test]
        public void Calc_irpf_4_salario_ok() {
            var contribuinteSalario = new Contribuinte() { Salario = 10000, Dependentes = 1 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.AreEqual(contribuinteMock.ValorIR, Math.Round(1651.86, 2), "Salário fora da faixa");

        }

        [Test]
        public void Calc_irpf_4_salario_acima() {
            var contribuinteSalario = new Contribuinte() { Salario = 15000, Dependentes = 1 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.AreEqual(contribuinteMock.ValorIR, Math.Round(1651.86, 2), "Salário acima da faixa");

        }

        [Test]
        public void Calc_irpf_4_salario_abaixo() {
            var contribuinteSalario = new Contribuinte() { Salario = 1500, Dependentes = 1 };
            var contribuinteMock = Calculo.CalcIRPF(contribuinteSalario);
            Assert.AreEqual(contribuinteMock.ValorIR, Math.Round(1651.86, 2), "Salário abaixo da faixa");

        }

    }
}
