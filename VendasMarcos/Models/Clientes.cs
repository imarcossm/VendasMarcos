using System;
using System.Collections.Generic;

namespace VendasMarcos.Models;

public partial class Clientes
{
    public int Codigo { get; set; }

    /// <summary>
    /// 1 - Jurídica, 2 - Física, 3 - Órgão Público Federal, 4 - Órgão Público Estadual, 5 - Outros
    /// </summary>
    public string Denominacao { get; set; } = null!;

    public DateOnly Dtcadastro { get; set; }

    public string Nome { get; set; } = null!;

    public string? Sexo { get; set; }

    public DateOnly? Dtnascimento { get; set; }

    public string? Apelido { get; set; }

    public string? Endereco { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public int Codmunicipio { get; set; }

    public string? Cep { get; set; }

    public bool? Restricao { get; set; }

    public string? Cpfcnpj { get; set; }

    public string? Rg { get; set; }

    public string? Orgemissor { get; set; }

    public string? Ufemissor { get; set; }

    public decimal? Limitecredito { get; set; }

    public string? Email { get; set; }

    public string? Obs { get; set; }

    public string? Estcivil { get; set; }

    public char Semdependente { get; set; }

    public int CodTabela { get; set; }

    public string? Contato { get; set; }

    public bool Bloqueado { get; set; }

    public int? Codvendedor { get; set; }

    public int? Codgrupo { get; set; }

    public int? Codant { get; set; }

    public string? Endereconumero { get; set; }

    public decimal Fatorpreco { get; set; }

    /// <summary>
    /// Campo para informação da &quot;Inscrição na SUFRAMA&quot;, conforme especificações do manual 4.01-NT2009.006 da NFE
    /// </summary>
    public string? Isuf { get; set; }

    /// <summary>
    /// Repassar o custo dos produtos em Orçamentos e Pré-Vendas
    /// </summary>
    public bool Repassecusto { get; set; }

    public DateTime? Lastupdatemobileinfo { get; set; }

    public DateTime Lastupdatepdvinfo { get; set; }

    /// <summary>
    /// 1 = Contribuinte ICMS; 2 = Contribuinte isento; 9 = Não Contribuinte
    /// </summary>
    public int Indiedest { get; set; }

    public int Cpais { get; set; }

    /// <summary>
    /// Identificação do destinatário no caso de comprador estrangeiro. Campo para uso na NF-e
    /// </summary>
    public string? Idestrangeiro { get; set; }

    public string? Ie { get; set; }

    public int RegimeTributarioParticipanteCodigo { get; set; }
}
