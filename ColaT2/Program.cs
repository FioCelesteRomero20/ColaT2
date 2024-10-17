using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaT2
{
	internal class Program
	{
		//Declaramos la cola de reserva
		static ColaReserva Cola = new ColaReserva(50); // Capacidad de la cola
		static void Main(string[] args)
		{
			// Precargar datos de pacientes al iniciar el programa
			CargaPacientes.PrecargarDatos(Cola);

			int opcion; // Opción del menú			
			string nombreReserva, apellidoReserva;
			int dniReserva;
			long numeroTarjeta;

			// Definir el menú para la cola de reservas
			do
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Reserva tu cita");
				Console.WriteLine("*************************");				
				Console.WriteLine("[1] Agregar Reserva");
				Console.WriteLine("[2] Mostrar Reservas");
				Console.WriteLine("[3] Eliminar la primera reserva hecha");
				Console.WriteLine("[4] Vacia Reserva");
				Console.WriteLine("[5] Salir");
				Console.Write("Elige una opción: ");
				opcion = int.Parse(Console.ReadLine());
				Console.Clear();


				switch (opcion)
				{
					case 1: // Agregar una reserva a la cola
						Console.Clear();
						Console.WriteLine("[1] Agregar Reserva");

						// Ingresar los datos de la reserva
						Console.Write("Nombre: ");
						nombreReserva = Console.ReadLine();
						Console.Write("Apellido: ");
						apellidoReserva = Console.ReadLine();
						Console.Write("DNI: ");
						dniReserva = int.Parse(Console.ReadLine());
						Console.Write("Número de Tarjeta: ");
						numeroTarjeta = long.Parse(Console.ReadLine());

						// Crear el nodo de reserva utilizando el constructor con parámetros
						NodoReserva reserva = new NodoReserva(nombreReserva, apellidoReserva, dniReserva, numeroTarjeta);

						// Agregar la reserva a la cola
						if (Cola.encola(reserva))
						{
							Console.WriteLine("Reserva agregada exitosamente.");
						}
						else
						{
							Console.WriteLine("Error: Cola llena. No se puede agregar más reservas.");
						}

						break;

					case 2: // Mostrar todas las reservas en la cola
						Console.Clear(); // Limpiar la pantalla
						Console.WriteLine("[2] Mostrar Reservas");
						Console.WriteLine("-----------------------------------------------------------------------");
						Console.WriteLine("  Nombre        | Apellido        |   DNI        |  Número de Tarjeta");
						Console.WriteLine("-----------------------------------------------------------------------");

						if (!Cola.vaciaCola())
						{
							// Llamar a un método para mostrar las reservas
							Cola.verCola();
						}
						else
						{
							Console.WriteLine("No hay reservas en la cola.");
						}

						Console.WriteLine("-----------------------------------------------------------------------");
						break;


					case 3: // Eliminar una reserva de la cola
						Console.Clear();
						Console.WriteLine("[3] Eliminar Reserva");

						NodoReserva reservaEliminada = Cola.desencola();

						if (reservaEliminada != null)
						{
							Console.WriteLine("Reserva eliminada exitosamente:");
							Console.WriteLine("Nombre: " + reservaEliminada.Nombre);
							Console.WriteLine("Apellido: " + reservaEliminada.Apellido); // Mostrar apellido
							Console.WriteLine("DNI: " + reservaEliminada.Dni);
							Console.WriteLine("Número de Tarjeta: " + reservaEliminada.NumTarjeta);
						}
						else
						{
							Console.WriteLine("Error: No hay reservas para eliminar.");
						}

						break;

					case 4: // Vaciar la cola
						Console.Clear();
						Console.WriteLine("[4] Vaciar Cola");
						Cola = new ColaReserva(50); // Reinicia la cola
						Console.WriteLine("Cola vaciada exitosamente.");
						break;

					case 5: // Salir
						Console.WriteLine("Saliendo del sistema...");
						break;


					default:
						Console.WriteLine("Opción no válida, intenta nuevamente.");
						break;
				}
				Console.ReadKey();
			} while (opcion != 5);
		}
	}
}
