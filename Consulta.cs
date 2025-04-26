namespace CP2
{
    class Consulta
    {
        private Guid id;
        private DateOnly data;
        private TimeOnly hora;
        private DateTime criadoUTC;
        private Paciente paciente;

        public Guid Id { get => id; set => id = value; }
        public DateOnly Data { get => data; set => data = value; }
        public TimeOnly Hora { get => hora; set => hora = value; }
        public DateTime CriadoUTC { get => criadoUTC; set => criadoUTC = value; }
        public Paciente Paciente { get => paciente; set => paciente = value; }

        public Consulta(DateOnly data, TimeOnly hora, DateTime criadoUTC, Paciente paciente)
        {
            this.id = Guid.NewGuid();
            this.data = data;
            this.hora = hora;
            this.criadoUTC = criadoUTC;
            this.paciente = paciente;
        }
    }
}
