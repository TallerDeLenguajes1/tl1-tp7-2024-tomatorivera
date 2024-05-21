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
    
    Console.Write("\tIngrese la edad: ");

    return nuevoEmpleado;
}

int nEmpleados = 3;
for (int i=0 ; i<nEmpleados ; i++)
{
    Console.WriteLine($"===== Ingresando datos del empleado {(i+1)} =====");
    Empleado empleado = solicitarDatos();
}