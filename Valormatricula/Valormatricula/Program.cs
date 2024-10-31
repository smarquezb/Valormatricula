
    class Program
{
           static void Main(string[] args)
    {
        bool repetir = true;
        while (repetir)
        {
            Estudiante estudiante = new Estudiante();
            estudiante.Creditos = LeerEntero("Ingrese el número de créditos del estudiante:");
            estudiante.ValorCredito = LeerDecimal("Ingrese el valor por crédito:");
            estudiante.Estrato = LeerEntero("Ingrese el estrato del estudiante (1, 2 o 3):");
            decimal costoMatricula = estudiante.CalcularMatricula();
            decimal subsidio = estudiante.ObtenerSubsidio();
            Console.WriteLine($"\nCosto de matrícula: {costoMatricula:C}");
            Console.WriteLine($"Subsidio: {subsidio:C}\n");
            Console.WriteLine("¿Desea calcular otra matrícula? (s/n)");
            repetir = Console.ReadLine().ToLower() == "s";
        }
        Console.WriteLine("Programa finalizado.");
    }
    static int LeerEntero(string mensaje)
    {
        int resultado;
        while (true)
        {
            Console.WriteLine(mensaje);
            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out resultado))
                return resultado;
            else
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero.");
        }
    }
    static decimal LeerDecimal(string mensaje)
    {
        decimal resultado;
        while (true)
        {
            Console.WriteLine(mensaje);
            string entrada = Console.ReadLine();
            if (decimal.TryParse(entrada, out resultado))
                return resultado;
            else
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número decimal.");
        }
    }
}
class Estudiante
{
    public int Creditos { get; set; }
    public decimal ValorCredito { get; set; }
    public int Estrato { get; set; }
    public decimal CalcularMatricula()
    {
        decimal costoNormal = Creditos * ValorCredito;
        decimal costoExtra = (Creditos > 20) ? (Creditos - 20) * ValorCredito * 2 : 0;
        decimal total = costoNormal + costoExtra;
        decimal descuento = Estrato switch
        {
            1 => 0.80m,
            2 => 0.50m,
            3 => 0.30m,
            _ => 0.0m
        };
        return total * (1 - descuento);
    }
    public decimal ObtenerSubsidio()
    {
        return Estrato switch
        {
            1 => 200000,
            2 => 100000,
            _ => 0
        };
    }
}
