namespace CP2
{
    class Medico
    {
        private Guid id;
        private string nome;
        private string crm;
        private string especialidade;
        private List<Consulta> consultas;

        public Guid Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Crm { get => crm; set => crm = value; }
        public string Especialidade { get => especialidade; set => especialidade = value; }
        public List<Consulta> Consultas { get => consultas; set => consultas = value; }

        public Medico(string nome, string crm, string especialidade)
        {
            this.id = Guid.NewGuid();
            this.nome = nome;
            this.crm = crm;
            this.especialidade = especialidade;
            this.consultas = new List<Consulta>();
        }

        public void AdicionarConsulta(Consulta consulta)
        {
            consultas.Add(consulta);
        }
    }
}
