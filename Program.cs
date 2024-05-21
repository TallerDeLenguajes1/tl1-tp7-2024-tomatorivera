using EspacioEmpleados;

/*
Empleado empleadoA = new Empleado("Tomas", 
                                  "Rivera", 
                                  new DateTime(2003, 09, 19),
                                  's',
                                  new DateTime(2019,07,27),
                                  875000,
                                  Cargos.Ingeniero);
Empleado empleadoB = new Empleado("Guillermo",
                                  "Diaz",
                                  new DateTime(2002, 09, 21),
                                  'c',
                                  new DateTime(2009, 05, 21),
                                  650000,
                                  Cargos.Especialista);
Empleado empleadoC = new Empleado("Jonas",
                                  "Cruz",
                                  new DateTime(2003, 07, 19),
                                  's',
                                  new DateTime(2021, 08, 16),
                                  693000,
                                  Cargos.Administrativo);
*/

static Empleado solicitarDatos() {
    Empleado nuevoEmpleado = new Empleado();

    Console.Write("\tIngrese el nombre: ");
    nuevoEmpleado.Nombre = Console.ReadLine();

    Console.Write("\tIngrese el apellido: ");
    nuevoEmpleado.Apellido = Console.ReadLine();
    
    // Sin validacion de numeros pero con mucha fe en el usuario <3
    Console.WriteLine("\tIngrese la fecha de nacimiento");
    Console.Write("\t\tAnio: ");
    int anio = Convert.ToInt32(Console.ReadLine());
    Console.Write("\t\tMes: ");
    int mes = Convert.ToInt32(Console.ReadLine());
    Console.Write("\t\tDia: ");
    int dia = Convert.ToInt32(Console.ReadLine());
    nuevoEmpleado.FechaNacimiento = new DateTime(anio, mes, dia);

    Console.Write("\tEstado civil: ");
    char estadoCivil = Console.ReadLine()[0];
    nuevoEmpleado.EstadoCivil = estadoCivil;

    Console.WriteLine("\tIngrese la fecha de ingreso");
    Console.Write("\t\tAnio: ");
    anio = Convert.ToInt32(Console.ReadLine());
    Console.Write("\t\tMes: ");
    mes = Convert.ToInt32(Console.ReadLine());
    Console.Write("\t\tDia: ");
    dia = Convert.ToInt32(Console.ReadLine());
    nuevoEmpleado.FechaIngreso = new DateTime(anio, mes, dia);

    Console.Write("\tIngrese el sueldo basico: ");
    nuevoEmpleado.SueldoBasico = Convert.ToDouble(Console.ReadLine());

    int opcion = 0;
    do {
        Console.WriteLine("\tIngrese el cargo");
        Console.WriteLine("\t\t1. Auxiliar");
        Console.WriteLine("\t\t2. Administrativo");
        Console.WriteLine("\t\t3. Ingeniero");
        Console.WriteLine("\t\t4. Especialista");
        Console.WriteLine("\t\t5. Investigador");
        Console.Write("\t> Digite su opcion: ");
        opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion) {
            case 1:
                nuevoEmpleado.Cargo = Cargos.Auxiliar;
                break;
            case 2:
                nuevoEmpleado.Cargo = Cargos.Administrativo;
                break;
            case 3:
                nuevoEmpleado.Cargo = Cargos.Ingeniero;
                break;
            case 4:
                nuevoEmpleado.Cargo = Cargos.Especialista;
                break;
            case 5:
                nuevoEmpleado.Cargo = Cargos.Investigador;
                break;
            default:
                Console.WriteLine("\t\a[!] Opcion invalida");
                break;
        }
    } while (opcion < 1 || opcion > 5);

    return nuevoEmpleado;
}

int nEmpleados = 1;
Empleado[] empleados = new Empleado[nEmpleados];

double totalSalarios = 0;
Empleado proximoJubilarse = null;

for (int i=0 ; i<nEmpleados ; i++)
{
    Console.WriteLine($"===== Ingresando datos del empleado {(i+1)} =====");
    Empleado nuevoEmpleado = solicitarDatos();
    empleados[i] = nuevoEmpleado;

    totalSalarios += nuevoEmpleado.calcularSalario();

    if (proximoJubilarse == null || nuevoEmpleado.aniosParaJubilarse() < proximoJubilarse.aniosParaJubilarse()) {
        proximoJubilarse = nuevoEmpleado;
    }
}

Console.Write("\nEMPLEADO PROXIMO A JUBILARSE: ");
Console.Write($"\t{proximoJubilarse}");

Console.WriteLine($"\nSuma de salarios: ${totalSalarios}");

// Pruebo las funciones
Empleado pruebas = empleados[0];
Console.WriteLine($"Datos del empleado {pruebas.Nombre} {pruebas.Apellido}");
Console.WriteLine($"\tEdad: {pruebas.calcularEdad()}");
Console.WriteLine($"\tSalario basico {pruebas.SueldoBasico}");
Console.WriteLine($"\tSalario adicional {pruebas.calcularSalarioAdicional()}");
Console.WriteLine($"\tSalario total {pruebas.calcularSalario()}");
Console.WriteLine($"\tAnios de antiguedad {pruebas.aniosAntiguedad()}");
Console.WriteLine($"\tAnios para jubilarse {pruebas.aniosParaJubilarse()}");