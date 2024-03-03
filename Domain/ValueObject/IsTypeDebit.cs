using debit;

public class TransactionType
{
    public string Type { get; }
   

    public TransactionType(string type)
    {
        if (type != "Entrada" && type != "Saida")
        {
            throw new Exception("Tipo inválido");
        }

        Type = type;
    }

    public decimal ProcessTransaction(decimal value)
    {
        if (Type == "Entrada")
        {
            if (value < 0)
            {
                throw new Exception("O valor de entrada deve ser positivo.");
            }
            Console.WriteLine($"Tipo: {Type}, Valor: {value}");
            return value;
        }
        if (Type == "Saida")
        {
            decimal valorNegativo = value * -1;
            Console.WriteLine($"Tipo: {Type}, Valor: {valorNegativo}");
            return valorNegativo;
        }
        throw new NotSupportedException("Tipo de transação não suportado");
    }
}
