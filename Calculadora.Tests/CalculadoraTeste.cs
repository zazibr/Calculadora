namespace CalculadoraTest;
using Calculadora;

public class CalculadoraTest
{
    public Calculadora construirClasse()
    {
        string data = "23/05/2024";
        Calculadora calc = new Calculadora(data);
        return calc;
    }

    
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-1, 1, 0)]
    [InlineData(-1, -1, -2)]
    public void TesteSomar(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();
        int resultadoCalculadora = calc.Somar(val1, val2);
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(1, 2, -1)]
    [InlineData(-1, 1, -2)]
    [InlineData(-1, -1, 0)]
    public void TesteSubtrair(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();
        int resultadoCalculadora = calc.Subtrair(val1, val2);
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(-1, 1, -1)]
    [InlineData(-1, -1, 1)]
    public void TesteMultiplicar(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();
        int resultadoCalculadora = calc.Multiplicar(val1, val2);
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(6, 2, 3)]
    [InlineData(5, 5, 1)]
    [InlineData(-1, -1, 1)]
    public void TesteDividir(int val1, int val2, int resultado)
    {
        Calculadora calc = construirClasse();
        int resultadoCalculadora = calc.Dividir(val1, val2);
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {

        Calculadora calc = construirClasse();
        Assert.Throws<DivideByZeroException>(() => calc.Dividir(3, 0));
    }

    [Fact]
    public void TestarHistorico()
    {

        Calculadora calc = construirClasse();

        calc.Somar(1, 2);
        calc.Somar(3, 4);
        calc.Somar(4, 5);
        calc.Somar(5, 6);

        var lista = calc.Historico();

        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
    }
}