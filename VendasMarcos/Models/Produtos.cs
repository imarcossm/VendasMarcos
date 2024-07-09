using System;
using System.Collections.Generic;

namespace VendasMarcos.TempModel;

/// <summary>
/// PRODUTOS
/// </summary>
public partial class Produtos
{
    public int Codigo { get; set; }

    public int Codfornecedor { get; set; }

    public int Codgrupo { get; set; }

    public string? Codfisiografico { get; set; }

    public string Unidade { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public decimal Qtdefiscal { get; set; }

    public decimal? Qtdemin { get; set; }

    public decimal? Comissao { get; set; }

    public decimal? Margemlucro { get; set; }

    public decimal Precovenda { get; set; }

    public decimal? Descontomaximo { get; set; }

    public decimal Custonota { get; set; }

    public bool Desativado { get; set; }

    public int CodTabela { get; set; }

    public int? Qtdegarantia { get; set; }

    public int? Medidagarantia { get; set; }

    public bool? Possuiserial { get; set; }

    public string? Codean { get; set; }

    public string? Referencia { get; set; }

    public decimal? Ipi { get; set; }

    public decimal? Icmscredito { get; set; }

    public decimal? Icmsdebito { get; set; }

    public decimal? Impostofederal { get; set; }

    public int? Validade { get; set; }

    public string? Medidavalidade { get; set; }

    public decimal Custopauta { get; set; }

    public decimal? Peso { get; set; }

    public decimal? Descontocompra { get; set; }

    /// <summary>
    /// Percentual a ser descontado automaticamente do preço de venda do produto em Orçamentos, Pré-Vendas e Notas Fiscais de Saída
    /// </summary>
    public decimal? Descontovenda { get; set; }

    public decimal? Frete { get; set; }

    public int? Codecfaliquota { get; set; }

    public decimal? Icmsreducaoentrada { get; set; }

    public decimal? Icmsreducaosaida { get; set; }

    public decimal? Despesaadministrativa { get; set; }

    public decimal? Outrasdespesas { get; set; }

    public decimal? Precorecomendado { get; set; }

    public decimal? Precoaposdesconto { get; set; }

    public int? Codmarca { get; set; }

    public bool Naoinventariar { get; set; }

    public int Tipoitem { get; set; }

    public string? Codfabricante { get; set; }

    public string? Codanterior { get; set; }

    public decimal Refq { get; set; }

    public bool Askdescadicional { get; set; }

    public decimal? Pis { get; set; }

    public decimal? Cofins { get; set; }

    public string? Codncm { get; set; }

    public decimal? Icmssubstituto { get; set; }

    public decimal? Diferencaicms { get; set; }

    public bool Precoautomatico { get; set; }

    public decimal Precominimo { get; set; }

    public decimal Fatorprecovenda { get; set; }

    public decimal Comissaovenda { get; set; }

    public string? Observacao { get; set; }

    /// <summary>
    /// Lista de Serviços, obrigar o preenchimento caso tipoitem seja 3 (Serviços).
    /// </summary>
    public int? Clistserv { get; set; }

    public int Codtributoestrutura { get; set; }

    public decimal? Seguro { get; set; }

    public string? Infcomplementar { get; set; }

    /// <summary>
    /// Natureza da receita, conforme registro M410 do EFD PIS/COFINS Versão 1.03
    /// </summary>
    public int? Natreceita { get; set; }

    public int? Cprodanp { get; set; }

    public string? DescadicionalDefault { get; set; }

    public DateTime Lastupdatepdvinfo { get; set; }

    public bool? Synctomobile { get; set; }

    public int? Codformula { get; set; }

    /// <summary>
    /// Campo que pode ser utilizado na confecção de fórmula para cálculo do preço de venda
    /// </summary>
    public decimal? Descontocalc { get; set; }

    public int? Codbalanca { get; set; }

    /// <summary>
    /// 0 - Definição de quantidade na balança por peso, 1 - Definição de quantidade na balança por unidade;
    /// </summary>
    public int? Tipocodbalanca { get; set; }

    public DateTime? Lastupdatemobileinfo { get; set; }

    /// <summary>
    /// Define se a quantidade do produto pode ser fracionada nas operações de movimentação do produto
    /// </summary>
    public bool Fracionaqtde { get; set; }

    public string? Cestcodigo { get; set; }

    public bool ExigeSerie { get; set; }

    /// <summary>
    /// 0 = Veículo Novo, 1 = Medicamentos, 2 = Armas, 3 = Combustível; Por enquanto somente o tipo Veículo Novo
    /// </summary>
    public int? Tipodetalhamento { get; set; }

    /// <summary>
    /// Especifica se o produto é fiscalmente rastreável
    /// </summary>
    public bool Rastreiofiscal { get; set; }
}
