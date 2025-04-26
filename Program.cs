namespace CP2
{
    class Program
    {
        static List<Paciente> pacientes = new List<Paciente>();
        static List<Medico> medicos = new List<Medico>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- MENU CLÍNICA ---");
                Console.WriteLine("1. Cadastrar Paciente");
                Console.WriteLine("2. Cadastrar Médico");
                Console.WriteLine("3. Agendar Consulta");
                Console.WriteLine("4. Listar Consultas");
                Console.WriteLine("5. Alterar Consultas");
                Console.WriteLine("6. Gerar Relatório Diário");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                string op = Console.ReadLine();
                switch (op)
                {
                    case "1": CadastrarPaciente(); break;
                    case "2": CadastrarMedico(); break;
                    case "3": AgendarConsulta(); break;
                    case "4": ListarConsultas(); break;
                    case "5": AlterarConsultas(); break;
                    case "6": GerarRelatorio(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida."); break;
                }

                Console.Write("\nAperte qualquer tecla para continuar...");
                Console.ReadKey(true);
            }
        }

        public static void CadastrarPaciente()
        {
            Console.WriteLine("Digite o nome do paciente:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o CPF do paciente:");
            string cpf = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento do paciente (dd/mm/yyyy):");
            while (true)
            {
                try
                {
                    DateOnly date = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy");
                    pacientes.Add(new Paciente(nome, cpf, date));
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Data inválida, tente novamente.");
                }
            }
            Console.WriteLine("Paciente cadastrado com sucesso!");
        }

        public static void CadastrarMedico()
        {
            Console.WriteLine("Digite o nome do médico:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o CRM do médico:");
            string crm = Console.ReadLine();

            Console.WriteLine("Digite a especialidade do médico:");
            string especialidade = Console.ReadLine();

            medicos.Add(new Medico(nome, crm, especialidade));
            Console.WriteLine("Médico cadastrado com sucesso!");
        }

        private static T SelecionarEmLista<T>(List<T> lista, string prompt1, Func<T, string> cbFormatador, string prompt2)
        {
            Console.WriteLine(prompt1); // "Listando os Médicos cadastrados:"
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"({i}) {cbFormatador(lista[i])}"); // "(1) Dr. Jaiminho"
            }
            while (true)
            {
                try
                {
                    Console.Write(prompt2 + " "); // "Digite o número do médico: "
                    int num = int.Parse(Console.ReadLine());
                    return lista[num];
                }
                catch (ArgumentOutOfRangeException) { Console.WriteLine("Opção inválida; Tente novamente."); }
                catch (FormatException) { Console.WriteLine("Opção inválida; Tente novamente."); }
            }
        }

        public static void AgendarConsulta()
        {
            if (medicos.Count == 0)
            {
                Console.WriteLine("Não há Médicos cadastrados");
                return;
            }
            if (pacientes.Count == 0)
            {
                Console.WriteLine("Não há Pacientes cadastrados");
                return;
            }

            // Selecionando Médico
            Medico med = SelecionarEmLista(
                medicos,
                "Listando os Médicos cadastrados:\n",
                x => x.Nome,
                "Selecione o número do médico:");
            if (med == null) { Console.WriteLine("Médico não encontrado"); return; }

            // Selecionando Paciente
            Paciente pac = SelecionarEmLista(
                pacientes,
                "Listando os Pacientes cadastrados:\n",
                x => x.Nome,
                "Selecione o número do paciente:");
            if (pac == null) { Console.WriteLine("Paciente não encontrado"); return; }


            // Selecionando Data
            DateOnly date;
            while (true)
            {
                try
                {
                    Console.WriteLine("Digite a data da consulta (dd/mm/yyyy):");
                    date = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy");
                    break;
                }
                catch (FormatException) { Console.WriteLine("Data inválida, tente novamente."); }
            }

            // Selecionando Hora
            TimeOnly time;
            while (true)
            {
                try
                {
                    Console.WriteLine("Digite a hora da consulta (hh:mm):");
                    time = TimeOnly.ParseExact(Console.ReadLine(), "HH:mm");
                    break;
                }
                catch (FormatException e) { Console.WriteLine("Hora inválida, tente novamente." + e.Message); }
            }

            med.AdicionarConsulta(new Consulta(date, time, DateTime.Now, pac));
            Console.WriteLine("Consulta agendada com sucesso!");
        }
        private static Dictionary<Consulta, Medico> MedicosPorConsulta()
        {
            // Cada Médico segura uma lista de consultas, queremos listar todas sem perder a relação consulta-médico
            Dictionary<Consulta, Medico> medicosPorConsulta = [];

            foreach (Medico medico in medicos)
            {
                foreach (Consulta consulta in medico.Consultas)
                {
                    medicosPorConsulta[consulta] = medico;
                }
            }
            return medicosPorConsulta;
        }
        public static void ListarConsultas()
        {

            Dictionary<Consulta, Medico> medicosPorConsulta = MedicosPorConsulta();

            // Amassar Dicionário em uma lista de consultas, e ordenar consultas pela Data
            List<Consulta> consultasOrdenadas = medicosPorConsulta.Keys.OrderBy(x => x.Data).ToList();

            if (consultasOrdenadas.Count == 0)
            {
                Console.WriteLine("Nenhuma consulta cadastrada!");
                return;
            }

            foreach (Consulta consulta in consultasOrdenadas)
            {
                Console.WriteLine($"\nConsulta em {consulta.Data} {consulta.Hora}:");
                Console.WriteLine($"  Médico Responsável: {medicosPorConsulta[consulta].Nome}, {medicosPorConsulta[consulta].Especialidade}");
                Console.WriteLine($"  Paciente: {consulta.Paciente.Nome}");
                Console.WriteLine($"  Consulta registrada em: {consulta.CriadoUTC}");
            }
        }

        public static void AlterarConsultas()
        {
            Dictionary<Consulta, Medico> medicosPorConsulta = MedicosPorConsulta();
            List<Consulta> consultas = medicosPorConsulta.Keys.ToList();

            if (consultas.Count == 0)
            {
                Console.WriteLine("Nenhuma consulta cadastrada!");
                return;
            }

            // Selecionando Consulta
            Consulta cons = SelecionarEmLista(
                consultas,
                "Listando as consultas cadastradas:\n",
                x => $"{x.Data} {x.Hora} - {x.Paciente.Nome} com Dr(a). {medicosPorConsulta[x].Nome}",
                "Digite o número da Consulta:");
            if (cons == null) { Console.WriteLine("Consulta inválida"); return; }

            // Alterando consulta
            while (true)
            {
                try
                {
                    Console.WriteLine("\n--- Alteração de consulta ---");
                    Console.WriteLine("1. Alterar Data");
                    Console.WriteLine("2. Alterar Hora");
                    Console.WriteLine("3. Cancelar Consulta");
                    Console.WriteLine("0. Voltar");
                    Console.Write("Escolha uma opção: ");

                    string op = Console.ReadLine();

                    switch (op)
                    {
                        case "1":
                            Console.WriteLine("Digite a nova data da consulta (dd/mm/yyyy):");
                            DateOnly date = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy");
                            cons.Data = date;
                            Console.WriteLine("Data alterada com sucesso!");
                            break;
                        case "2":
                            Console.WriteLine("Digite a nova hora da consulta (hh:mm):");
                            TimeOnly time = TimeOnly.ParseExact(Console.ReadLine(), "HH:mm");
                            cons.Hora = time;
                            Console.WriteLine("Hora alterada com sucesso!");
                            break;
                        case "3":
                            medicosPorConsulta[cons].Consultas.Remove(cons);
                            Console.WriteLine("Consulta removida.");
                            return;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (FormatException) { Console.WriteLine("Formato inválido. Tente novamente."); }
                catch (ArgumentNullException) { continue; } // Silenciosamente repetir o prompt
                catch
                {
                    Console.WriteLine("Houve um erro. Tente novamente.");
                }
            }
        }

        public static void GerarRelatorio()
        {
            Dictionary<Consulta, Medico> medicosPorConsulta = MedicosPorConsulta();

            // Filtrar somente consultas para hoje; ordenar pela hora
            List<Consulta> consultasOrdenadas = medicosPorConsulta.Keys
                .Where(x => x.Data == DateOnly.FromDateTime(DateTime.Now))
                .OrderBy(x => x.Hora)
                .ToList();
            if (consultasOrdenadas.Count == 0)
            {
                Console.WriteLine("Não há consultas cadastradas para hoje!");
            }

            Console.WriteLine("\nListando consultas para hoje:");
            foreach (Consulta x in consultasOrdenadas)
            {
                Console.WriteLine($"{x.Hora} - {x.Paciente.Nome} com Dr(a). {medicosPorConsulta[x].Nome}");
            }

            // Não pode haver um intervalo médio com menos de 2 consultas
            if (consultasOrdenadas.Count < 2) { return; }

            // Sabendo que as consultas estão ordenadas por hora, podemos só medir a diferença
            // entre a primeira e última consultas, e dividir pela quantidade de intervalos
            TimeSpan deltaTotal = consultasOrdenadas[consultasOrdenadas.Count - 1].Hora - consultasOrdenadas[0].Hora;
            TimeSpan diff = deltaTotal / (consultasOrdenadas.Count - 1);
            Console.WriteLine($"O intervalo médio entre as consultas é de {diff.Minutes} minutos.");
        }
    }
}
