namespace EspacioCalculadora;

public class Calculadora {
    private double resultado;

    public Calculadora() {
        resultado = 0;
    }

    public double Resultado {
        get {
            return resultado;
        }
    }

    public void sumar(double termino) {
        resultado += termino;
    }

    public void restar(double termino) {
        resultado -= termino;
    }

    public void multiplicar(double termino) {
        resultado *= termino;
    }

    public void dividir(double termino) {
        resultado /= termino;
    }

    public void limpiar() {
        resultado = 0;
    }

}