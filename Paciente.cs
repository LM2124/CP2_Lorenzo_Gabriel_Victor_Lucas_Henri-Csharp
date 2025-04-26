namespace CP2
{
    class Paciente
    {
        private Guid id;
        private string nome;
        private string cpf;
        private DateOnly dataNascimento;

        public Guid Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public DateOnly DataNascimento { get => dataNascimento; set => dataNascimento = value; }

        public Paciente(string nome, string cpf, DateOnly dataNascimento)
        {
            this.id = Guid.NewGuid();
            this.nome = nome;
            this.cpf = cpf;
            this.dataNascimento = dataNascimento;
        }
    }
}
