using System.Dynamic;

namespace EspacioEmpleados;

public class Empleado {

    private string nombre;
    private string apellido;
    private DateTime fechaNacimiento;
    private char estadoCivil;
    private DateTime fechaIngreso;
    private double sueldoBasico;
    private Cargos cargo;

    /* Constructor */
    /*
    public Empleado(string nombre, string apellido, DateTime fechaNacimiento, char estadoCivil, DateTime fechaIngreso, double sueldoBasico, Cargos cargo) {
        this.nombre = nombre;
        this.apellido = apellido;
        this.fechaNacimiento = fechaNacimiento;
        this.estadoCivil = estadoCivil;
        this.fechaIngreso = fechaIngreso;
        this.sueldoBasico = sueldoBasico;
        this.cargo = cargo;
    }
    */

    /* Getters and setters */
    public string Nombre {
        get => nombre;
        set => nombre = value;
    }
    public string Apellido {
        get => apellido;
        set => apellido = value;
    }
    public DateTime FechaNacimiento {
        get => fechaNacimiento;
        set => fechaNacimiento = value;
    }
    public char EstadoCivil {
        get => estadoCivil;
        set => estadoCivil = value;
    }
    public DateTime FechaIngreso {
        get => fechaIngreso;
        set => fechaIngreso = value;
    }
    public double SueldoBasico {
        get => sueldoBasico;
        set => sueldoBasico = value;
    }
    public Cargos Cargo {
        get => cargo;
        set => cargo = value;
    }

    /* Métodos */
    public double aniosAntiguedad() {
        TimeSpan diferencia = DateTime.Now - fechaIngreso;
        return diferencia.TotalDays / 360;
    }

    public int calcularEdad() {
        int edad = DateTime.Now.Year - fechaNacimiento.Year;
        
        if (fechaNacimiento.Month > DateTime.Now.Month)
        {
            edad++;
        }
        else if (fechaNacimiento.Month == DateTime.Now.Month)
        {
            if (fechaNacimiento.Day >= DateTime.Now.Day)
                edad++;
        }

        return edad;
    }

    public int aniosParaJubilarse() {
        return 65 - calcularEdad();
    }

    public double calcularSalario() {
        double salario = this.sueldoBasico + calcularSalarioAdicional();
        return salario;
    }

    public double calcularSalarioAdicional() {
        double adicional = 0;

        // i) 1 % del sueldo básico por cada año de antigüedad hasta los 20 años, a partir de este, el porcentaje se fija en 25%.
        int porcentaje = 0;
        int aniosCompletosAntiguedad = Convert.ToInt32(aniosAntiguedad());

        if (aniosCompletosAntiguedad >= 20) porcentaje = 25;
        else porcentaje = aniosCompletosAntiguedad;

        adicional += sueldoBasico - sueldoBasico * (porcentaje/100);

        //  ii) Si el cargo es Ingeniero o Especialista, el Adicional se incrementa en un 50%.
        if (this.cargo == Cargos.Ingeniero || this.cargo == Cargos.Especialista) 
            adicional += adicional * 1.50;

        // iii) Si es casado al Adicional se le aumenta $150.000.
        if (this.estadoCivil.ToString().ToLower().Equals("c")) 
            adicional += 150000;

        return adicional;
    }

    public override string ToString() {
        return $"Empleado {nombre} {apellido} - Edad {calcularEdad()} - Fecha de nacimiento {fechaNacimiento} - Estado civil {estadoCivil.ToString().ToUpper()} - Fecha de ingreso {fechaIngreso} - Sueldo basico ${sueldoBasico} - Cargo {cargo}";
    }

}