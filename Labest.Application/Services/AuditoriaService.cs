public class AuditoriaService : IAuditoriaService
{
    private static readonly List<LogAuditoria> _logs = new();

    public void Registrar(string usuario, string acao, string entidade)
    {
        _logs.Add(new LogAuditoria
        {
            Usuario = usuario,
            Acao = acao,
            Entidade = entidade,
            Data = DateTime.Now
        });
    }

    public List<LogAuditoria> Listar()
    {
        return _logs;
    }
}